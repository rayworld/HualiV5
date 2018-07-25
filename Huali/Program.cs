using Huali.CheckMailStat;
using Ray.Framework.Config;
using System;
using System.Windows.Forms;
using Ray.Framework.AutoUpdate;
using System.Net;
using System.Xml;

namespace Huali
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                Utils.H2(String.Format("无法找到指定资源\n\n{0}", exp.Message));
            }
            catch (XmlException exp)
            {
                Utils.H2(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (NotSupportedException exp)
            {
                Utils.H2(String.Format("升级地址配置错误\n\n{0}", exp.Message));
            }
            catch (ArgumentException exp)
            {
                Utils.H2(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (Exception exp)
            {
                Utils.H2(String.Format("升级过程中发生错误\n\n{0}", exp.Message));
            }

            string modelName = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "ModelName");

            if (modelName.ToLower() == "checkmailstat")
            {
                Application.Run(new FrmCheckQRCodeState());
            }
            else
            {
                Application.Run(new FrmMain());
            }
            
        }
    }
}
