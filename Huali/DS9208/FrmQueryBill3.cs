using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

using Ray.Framework.DBUtility;

namespace Huali
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
                sql = string.Format("SELECT [����],[������λ],[���ݱ��],sum([ʵ������]) as Ӧɨ����, sum([FActQty]) as ʵɨ����  FROM [dbo].[icstock]  where [����] >= '{0} 00:00:00' and [����] <= '{1} 23:59:59' and [ʵ������] > 0 and [��Ʒ���] Like '02%' group by [����],[������λ],[���ݱ��] order by [����],[������λ],[���ݱ��]", startDate, endDate);
                dt = SqlHelper.ExecuteDataTable(sql);
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["������λ"].Width = 300;
                dataGridViewX1.Columns["����"].Width = 200;
                
                foreach (DataGridViewRow datagridviewrow in dataGridViewX1.Rows)
                {
                    datagridviewrow.Selected = false;

                    if (int.Parse(datagridviewrow.Cells["Ӧɨ����"].Value.ToString()) != int.Parse(datagridviewrow.Cells["ʵɨ����"].Value.ToString()))
                    {
                        datagridviewrow.Selected = true;
                    }
                }
            }
            else
            {
                DesktopAlert.Show("<h2>��������Ч�Ŀ�ʼʱ��ͽ���ʱ�䣡</h2>");
            }
        }
    }
}