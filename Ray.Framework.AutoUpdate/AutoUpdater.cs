using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Ray.Framework.AutoUpdate
{
    public class AutoUpdater
    {
        const string FILENAME = "SystemUpdate.config";
        private Config config = null;
        private bool bNeedRestart = false;

        public AutoUpdater()
        {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
        }
        /// <summary>
        /// 检查新版本
        /// </summary>
        /// <exception cref="WebException">无法找到指定资源</exception>
        /// <exception cref="System.NotSupportException">升级地址配置错误</exception>
        /// <exception cref="XmlException">下载的升级文件有错误</exception>
        /// <exception cref="ArgumentException">下载的升级文件有错误</exception>
        /// <exception cref="System.Excpetion">未知错误</exception>
        /// <returns></returns>
        public void Update()
        {
            if (!config.Enabled)
            {
                return;
            }
            /*
            * 请求Web服务器，得到当前最新版本的文件列表，格式同本地的FileList.xml。
            * 与本地的FileList.xml比较，找到不同版本的文件
            * 生成一个更新文件列表，开始DownloadProgress
            * <UpdateFile>
            *  <File path="" url="" lastver="" size=""></File>
            * </UpdateFile>
            * path为相对于应用程序根目录的相对目录位置，包括文件名
            */
            WebClient client = new WebClient();
            string strXml = client.DownloadString(config.ServerUrl);

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //某些文件不再需要了，删除
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            foreach (LocalFile file in config.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    if (rf.LastVer != file.LastVer)
                    {
                        downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size));
                        file.LastVer = rf.LastVer;
                        file.Size = rf.Size;

                        if (rf.NeedRestart)
                            bNeedRestart = true;
                    }

                    listRemotFile.Remove(file.Path);
                }
                else
                {
                    preDeleteFile.Add(file);
                }
            }

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size));
                config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));

                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            if (downloadList.Count > 0)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);

                OnShow?.Invoke();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    foreach (LocalFile file in preDeleteFile)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Path);
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        config.UpdateFileList.Remove(file);
                    }

                    StartDownload(downloadList);
                }
            }
            else
            {
                MessageBox.Show("当前已是最新版本。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //更新成功
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));

                if (bNeedRestart)
                {
                    MessageBox.Show("系统应用已更新，请点击确定重新启动程序。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //DOUAC();
                    Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);

                }

            }


        }

        public static void DoWork()
        {

            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        public static void DOUAC()
        {
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                //AddSecurity();
                Thread newThread = new Thread(AutoUpdater.DoWork);
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            else
            {
                //创建启动对象
                ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //退出
                Application.Exit();
            }
        }

        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                list.Add(node.Attributes["path"].Value, new RemoteFile(node));
            }

            return list;
        }
        public event ShowHandler OnShow;
    }

    public class RemoteFile
    {

        public string Path { get; }
        public string Url { get; }
        public string LastVer { get; }
        public int Size { get; }
        public bool NeedRestart { get; }

        public RemoteFile(XmlNode node)
        {
            Path = node.Attributes["path"].Value;
            Url = node.Attributes["url"].Value;
            LastVer = node.Attributes["lastver"].Value;
            Size = Convert.ToInt32(node.Attributes["size"].Value);
            NeedRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
        }
    }

    public class LocalFile
    {
        [XmlAttribute("path")]
        public string Path { get; set; }
        [XmlAttribute("lastver")]
        public string LastVer { get; set; }
        [XmlAttribute("size")]
        public int Size { get; set; }

        public LocalFile(string path, string ver, int size)
        {
            Path = path;
            LastVer = ver;
            Size = size;
        }

        public LocalFile()
        {
        }

    }


    public delegate void ShowHandler();

    public class DownloadFileInfo
    {

        string downloadUrl = "";
        string fileName = "";
        string lastver = "";
        int size = 0;

        /// <summary>
        /// 要从哪里下载文件
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// 下载完成后要放到哪里去
        /// </summary>
        public string FileFullName { get { return fileName; } }
        public string FileName { get { return Path.GetFileName(FileFullName); } }
        public string LastVer { get { return lastver; } set { lastver = value; } }
        public int Size { get { return size; } }

        public DownloadFileInfo(string url, string name, string ver, int size)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
        }
    }
}
