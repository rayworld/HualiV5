using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ray.Framework.Config;
using Ray.Framework.DBUtility;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmImportBill : Office2007Form
    {
        public FrmImportBill()
        {
            InitializeComponent();
        }

        string fName = "";
        DataTable dt = new DataTable();
        string sql = "";
        string FCustomId = "FCustomId";
        string FStoreId = "FStoreId";
        string FProductId = "FProductId";

        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",//注意这里写路径时要用c:\\而不是c:\
                Filter = "Excel97-2003文本文件|*.xls|Excel 2007文件|*.xlsx|所有文件|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fName = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(fName))
            {
                dt = ReadExcelFile(fName, "Sheet3");
                //dt.Rows.RemoveAt(dt.Rows.Count - 1);
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["fdate"].HeaderText = "日期";
                dataGridViewX1.Columns["fbillNo"].HeaderText = "单据编号";
                dataGridViewX1.Columns["fEntryID"].HeaderText = "分录号";
                dataGridViewX1.Columns["fSupplyID"].HeaderText = "购货单位";
                dataGridViewX1.Columns["FDCSPID"].HeaderText = "发货仓库";
                dataGridViewX1.Columns["fitemID"].HeaderText = "产品名称";
                dataGridViewX1.Columns["fQty"].HeaderText = "实发数量";
                dataGridViewX1.Columns["fBatchNo"].HeaderText = "批号";
                dataGridViewX1.Columns["fNote"].HeaderText = "摘要";
                dataGridViewX1.Columns["fSupplyID"].Width = 240;
                dataGridViewX1.Columns["fitemID"].Width = 300;

                dataGridViewX1.Columns[FProductId].HeaderText = "产品编号";
                dataGridViewX1.Columns[FCustomId].HeaderText = " 客户编号";
                dataGridViewX1.Columns[FStoreId].HeaderText = "门店编号";
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                int recCount = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StockBill bill = new StockBill
                    {
                        ///对应关系修改
                        日期 = dt.Rows[i]["fdate"].ToString(),
                        单据编号 = dt.Rows[i]["fbillNo"].ToString(),
                        EntryID = dt.Rows[i]["fEntryID"].ToString(),
                        购货单位 = dt.Rows[i]["fSupplyID"].ToString(),
                        发货仓库 = dt.Rows[i]["FDCSPID"].ToString(),
                        产品名称 = dt.Rows[i]["fitemID"].ToString(),
                        规格型号 = "",
                        实发数量 = float.Parse(dt.Rows[i]["fQty"].ToString()),
                        批号 = dt.Rows[i]["fBatchNo"].ToString(),
                        摘要 = dt.Rows[i]["fNote"].ToString(),
                        FAuxQty = 0,
                        产品编号 = dt.Rows[i][FProductId].ToString(),
                        客户编号 = dt.Rows[i][FCustomId].ToString(),
                        门店编号 = dt.Rows[i][FStoreId].ToString()
                    };

                    //去重复
                    sql = string.Format("Select Count(*) From [icstock] WHERE [单据编号] = '" + bill.单据编号 + "' AND fEntryID = " + bill.EntryID.ToString());
                    object obj = SqlHelper.ExecuteScalar(sql);
                    if (obj != null && int.Parse(obj.ToString()) < 1)
                    {
                        sql = string.Format("INSERT INTO [icstock] ([日期],[单据编号],[FEntryID],[购货单位],[发货仓库] ,[产品名称] ,[规格型号] ,[实发数量] ,[批号] ,[摘要], [FActQty], [客户编号], [门店编号], [产品编号]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}',{10},'{11}', '{12}', '{13}')", bill.日期, bill.单据编号, bill.EntryID, bill.购货单位, bill.发货仓库, bill.产品名称, bill.规格型号, bill.实发数量, bill.批号, bill.摘要, bill.FAuxQty, bill.客户编号, bill.门店编号, bill.产品编号);
                        if (SqlHelper.ExecuteNonQuery(sql) > 0)
                        {
                            recCount++;
                        }
                    }
                }
                Utils.H2(string.Format("共成功导入 {0} 条记录！", recCount.ToString()));
            }

        }
        #endregion

        #region 私有过程

        /// <summary>
        /// 将Excel文件转成DataTable
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="strSheetName">工作簿名</param>
        /// <returns></returns>
        private DataTable ReadExcelFile(string strFileName, string strSheetName)
        {
            if (strFileName != "")
            {
                ////office 2003 
                ////string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                ////office 2007
                ////"Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + 文件选择的路径 + "; Extended Properties=Excel 8.0";
                //string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";  
                //string sql = "select * from [" + strSheetName + "$]";
                ////string sql = "SELECT * FROM OpenDataSource('Microsoft.Jet.OLEDB.4.0','Data Source=" + strFileName + ";Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=False')...Sheet1$";
                //OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                //DataSet ds = new DataSet();
                //try
                //{
                //    da.Fill(ds, "table1");
                //}
                //catch
                //{
                //}
                //return ds.Tables[0];

                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + strFileName + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                OleDbDataAdapter myCommand = null;
                DataTable dt = null;
                sql = string.Format("SELECT * FROM [Sheet3$] ORDER BY fentryID");
                myCommand = new OleDbDataAdapter(sql, strConn);
                dt = new DataTable();
                try
                {
                    myCommand.Fill(dt);
                }
                catch
                {
                }
                return dt;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }

    public class StockBill 
    {
        public string 日期 { get; set; }

        public string 单据编号 { get; set; }

        public string EntryID { get; set; }

        public string 购货单位 { get; set; }

        public string 发货仓库 { get; set; }

        public string 产品名称 { get; set; }

        public string 规格型号 { get; set; }

        public float 实发数量 { get; set; }

        public string 批号 { get; set; }

        public string 摘要 { get; set; }

        public float FAuxQty { get; set; }

        public string 客户编号 { get; set; }

        public string 门店编号 { get; set; }

        public string 产品编号 { get; set; }
    }          
}              
               
               
               
               