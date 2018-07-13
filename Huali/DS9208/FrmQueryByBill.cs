using DevComponents.DotNetBar;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmQueryByBill : Office2007Form
    {
        public FrmQueryByBill()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string sql = "";
        private static readonly string conn = SqlHelper.GetConnectionString("ALiCloud");

        #region 事件
        /// <summary>
        /// 用户输入新的出库单并确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridViewX1.Rows.Clear();
                dataGridViewX1.DataSource = null;
                //得到单据编号
                string billType = comboBoxEx2.SelectedIndex == 0 ? "XOUT" : "QOUT";
                string billNo = billType + textBoxX1.Text;
                sql = string.Format("SELECT [产品名称] AS Disp , [FEntryID] AS Val FROM [dbo].[icstock] WHERE [单据编号] = '{0}'", billNo);
                dt = SqlHelper.ExecuteDataTable(conn, sql);
                DataRow dr = dt.NewRow();
                dr[0] = "";
                dr[1] = 0;
                dt.Rows.InsertAt(dr, 0);
                comboBoxEx1.DataSource = dt;
                comboBoxEx1.DisplayMember = "Disp";
                comboBoxEx1.ValueMember = "Val";
            }
        }

        /// <summary>
        /// 用户选择了新的项目准备录入二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex > 0)
            {
                dataGridViewX1.DataSource = null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            string billType = comboBoxEx2.SelectedIndex == 0 ? "XOUT" : "QOUT";
            string billNo = billType + textBoxX1.Text;
            string interID = billNo + comboBoxEx1.SelectedValue.ToString().PadLeft(4, '0');
            SqlParameter[] parms = { new SqlParameter("@interID", interID) };
            dt = SqlHelper.ExecuteDataSet(conn, CommandType.StoredProcedure, "getQRCodeByinterID", parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("QRCode", typeof(System.String));//二维码

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["QRCode"] = EncryptHelper.Encrypt(dt.Rows[i]["FQRCode"].ToString());
                }
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns[0].HeaderText = "编号";
                dataGridViewX1.Columns[1].HeaderText = "二维码";
                dataGridViewX1.Columns[1].Width = 300;
            }
            else
            {
                Utils.H2("无记录！请检查单据设置");
            }


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBoxEx2.SelectedIndex = 0;
        }

        #endregion
    }
}
