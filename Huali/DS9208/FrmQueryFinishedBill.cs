using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Ray.Framework.DBUtility;
using System;
using System.Data;

namespace Huali.DS9208
{
    /// <summary>
    /// 显示已经扫过码的单号
    /// </summary>
    public partial class FrmQueryFinishedBill : Office2007Form
    {
        public FrmQueryFinishedBill()
        {
            InitializeComponent();
        }

        string sql = "";
        DataTable dt = new DataTable();
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");


        private void ButtonX1_Click(object sender, EventArgs e)
        {
            sql = string.Format("SELECT  DISTINCT TOP 200 CONVERT(varchar(10), [日期], 120) as 单据日期,[单据编号] FROM [dbo].[icstock] WHERE [FActQty] > 0 ORDER BY CONVERT(varchar(10), [日期], 120) DESC");
            dt = SqlHelper.ExecuteDataTable(conn, sql);
            CustomDesktopAlert.H2(dt.Rows.Count.ToString());
            dataGridViewX1.DataSource = dt;
        }

    }
}