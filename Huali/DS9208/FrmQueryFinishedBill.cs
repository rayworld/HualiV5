using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Ray.Framework.DBUtility;
using DevComponents.DotNetBar.Controls;

namespace Huali
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

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            sql = string.Format("SELECT  DISTINCT TOP 200 CONVERT(varchar(10), [日期], 120) as 单据日期,[单据编号] FROM [dbo].[icstock] WHERE [FActQty] > 0 ORDER BY CONVERT(varchar(10), [日期], 120) DESC");
            dt = SqlHelper.ExecuteDataTable(sql);
            Utils.H2(dt.Rows.Count.ToString());
            dataGridViewX1.DataSource = dt;
        }

    }
}