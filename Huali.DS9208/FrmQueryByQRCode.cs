using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System;
using System.Data;

namespace Huali.DS9208
{
    public partial class FrmQueryByQRCode : Office2007Form
    {
        public FrmQueryByQRCode()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string mingQRCode = "";
        string sql = "";
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            mingQRCode = EncryptHelper.Decrypt(textBoxX2.Text);
            //mingQRCode = textBoxX2.Text;
            //if (!string.IsNullOrEmpty(mingQRCode) && mingQRCode.Length == 9 && mingQRCode.StartsWith(DateTime.Now.Year.ToString().Substring(2)))
            if (!string.IsNullOrEmpty(mingQRCode) && mingQRCode.Length == 9)
            {
                string tableName = "t_QRCode" + mingQRCode.Substring(0, 4);
                ///二维码是否存在
                sql = string.Format("SELECT FEntryID AS interID FROM [dbo].[{0}] WHERE [FQRCode] = '{1}' ", tableName, mingQRCode);
                object obj = SqlHelper.ExecuteScalar(conn, sql);
                if (obj != null)
                {
                    sql = string.Format("SELECT FEntryID as interID FROM [dbo].[{0}] WHERE [FQRCode] = '{1}' ORDER BY FCodeID DESC", tableName, mingQRCode);
                    object obj1 = SqlHelper.ExecuteScalar(conn, sql);
                    string interID = obj1 != null ? obj1.ToString() : "";
                    string billNo = interID.Substring(0, 10);
                    int entryID = int.Parse(interID.Substring(10));
                    sql = string.Format("SELECT * FROM [icstock] WHERE [单据编号] = '{0}' AND [FEntryID] = {1}", billNo, entryID.ToString());
                    dt = SqlHelper.ExecuteDataTable(conn, sql);
                    dataGridViewX1.DataSource = dt;
                }
                else
                {
                    CustomDesktopAlert.H2(string.Format("{0} 二维码不存在！", mingQRCode));                    
                }
            }
            else
            {
                CustomDesktopAlert.H2("无效的二维码！" );
            }
        }

        private void FrmQueryByQRCode_Load(object sender, EventArgs e)
        {

        }
    }
}
