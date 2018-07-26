using DevComponents.DotNetBar;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmQueryCheckState : Office2007Form
    {
        public FrmQueryCheckState()
        {
            InitializeComponent();
        }

        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");


        private void TextBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string QRCode = textBoxX2.Text;
                string mingQRCode = EncryptHelper.Decrypt(QRCode);
                if (!string.IsNullOrEmpty(mingQRCode)&&IsNumeric(mingQRCode))
                {
                    string tableName = "t_QRCode" + mingQRCode.Substring(0, 4);
                    string sql = string.Format("SELECT TOP 1 [FSTATE] FROM " + tableName + "  WHERE [FQRCode] = '" + mingQRCode + "' ORDER BY [FCREATEDATE] DESC ");
                    object obj = SqlHelper.ExecuteScalar(conn, sql);
                    if (obj != null && obj.ToString().ToLower() == "c")
                    {
                        Utils.H2("唯一码已核销！");
                    }
                    else
                    {
                        Utils.H2("唯一码未核销或者不存在！");
                    }
                }
                else
                {
                    Utils.H2("不能识别的唯一码！");

                }

                //清空二维码框
                textBoxX2.Text = "";
            }
        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
    }
}
