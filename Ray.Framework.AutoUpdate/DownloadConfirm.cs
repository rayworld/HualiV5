using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Ray.Framework.AutoUpdate
{
    public partial class DownloadConfirm : Office2007Form
    {
        List<DownloadFileInfo> downloadFileList = null;

        public DownloadConfirm(List<DownloadFileInfo> dfl)
        {
            InitializeComponent();

            downloadFileList = dfl;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString() });
                this.listDownloadFile.Items.Add(item);
            }

            this.Activate();
            this.Focus();
        }
    }
}