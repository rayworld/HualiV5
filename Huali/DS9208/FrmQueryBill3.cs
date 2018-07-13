using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ray.Framework.DBUtility;
using System;
using System.Data;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmQueryBill3 : Office2007Form
    {
        public FrmQueryBill3()
        {
            InitializeComponent();
        }
        string sql = "";
        DataTable dt = new DataTable();

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            string startDate = dateTimeInput1.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dateTimeInput2.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            if (startDate != "0001-01-01" && endDate != "0001-01-01")
            {
                sql = string.Format("SELECT [日期],[购货单位],[单据编号],sum([实发数量]) as 应扫数量, sum([FActQty]) as 实扫数量  FROM [dbo].[icstock]  where [日期] >= '{0} 00:00:00' and [日期] <= '{1} 23:59:59' and [实发数量] > 0 and [产品编号] Like '02%' group by [日期],[购货单位],[单据编号] order by [日期],[购货单位],[单据编号]", startDate, endDate);
                dt = SqlHelper.ExecuteDataTable(sql);
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["购货单位"].Width = 300;
                dataGridViewX1.Columns["日期"].Width = 200;
                
                foreach (DataGridViewRow Datagridviewrow in dataGridViewX1.Rows)
                {
                    Datagridviewrow.Selected = false;

                    if (int.Parse(Datagridviewrow.Cells["应扫数量"].Value.ToString()) != int.Parse(Datagridviewrow.Cells["实扫数量"].Value.ToString()))
                    {
                        Datagridviewrow.Selected = true;
                    }
                }
            }
            else
            {
                DesktopAlert.Show("<h2>请输入有效的开始时间和结束时间！</h2>");
            }
        }
    }
}