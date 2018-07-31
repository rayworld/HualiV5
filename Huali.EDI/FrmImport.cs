using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Huali.EDI.DAL;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Huali.EDI
{
    public partial class FrmImport : Office2007Form
    {
        public FrmImport()
        {
            InitializeComponent();
        }

        #region public Var
        DataTable dt = new DataTable();
        string FileType = "";
        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.ToLower().EndsWith(".txt"))
                {
                    FileType = "TXT";
                    dt = ReadTextFile(openFileDialog1.FileName);
                }
                else if (openFileDialog1.FileName.ToLower().EndsWith(".xls"))
                {
                    FileType = "XLS";
                    dt = ReadExcelFile(openFileDialog1.FileName, "Sheet1");
                }
                else
                {
                    FileType = "";
                }
                //MessageBox.Show(FileType);
                //DesktopAlert.Show(FileType);
                dataGridView1.DataSource = dt;
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "e://Temp";//注意这里写路径时要用c://而不是c:/
            openFileDialog1.Filter = "文本文件|*.txt|Excel 文件|*.xls|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.FileName = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导入IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileType != "" && dt.Rows.Count > 0)
            {
                if (FileType == "TXT")
                {
                    Text2DB(dt); //导入OP                
                }
                else
                {
                    Excel2DB(dt); //采购订单
                }
            }
        }

        #endregion

        #region Private Function

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
                //office 2003 
                //string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                //office 2007
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";  
                string sql = "select f0, f1 ,f2, f3, f4, f5, f6, f7, f8, [注册证号] as f9 from [" + strSheetName + "$]";
                //string sql = "SELECT * FROM OpenDataSource('Microsoft.Jet.OLEDB.4.0','Data Source=" + strFileName + ";Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=False')...Sheet1$";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "table1");
                }
                catch
                {
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将TXT文件转成DataTable
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        private DataTable ReadTextFile(string FileName)
        {
            if (!System.IO.File.Exists(FileName))
            {
                return null;
            }
            DataTable dtData = new DataTable();
            string[] strRows = System.IO.File.ReadAllLines(FileName);
            for (int intRow = 0; intRow < strRows.Length; intRow++)
            {

                string[] strCols = strRows[intRow].Split(',');
                if (intRow == 0)
                {
                    for (int intCol = 0; intCol < strCols.Length; intCol++)
                    {
                        //创建列
                        dtData.Columns.Add(new DataColumn("F" + intCol.ToString()));
                    }
                }
                DataRow drNew = dtData.NewRow();
                for (int intCol = 0; intCol < strCols.Length; intCol++)
                {
                    strCols[intCol] = strCols[intCol].Replace("\"", "");

                    drNew["F" + intCol.ToString()] = strCols[intCol].Trim();
                }
                dtData.Rows.Add(drNew);
            }
            return dtData;
        }

        /// <summary>
        /// TXT文件导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        private bool Text2DB(DataTable dt)
        {
            bool retVal = true;
            string pKey = "";//alcon 单号
            int fInterID = 0;//内联ID,外键
            int fEntryID = 0;
            int successCount = 0;
            string fBillNo = "";//金蝶收货单号

            Huali.EDI.DAL.T_ICItem dalICItem = new EDI.DAL.T_ICItem();
            Huali.EDI.DAL.PoInStock dalPOInStock = new EDI.DAL.PoInStock();
            Huali.EDI.DAL.PoInStockEntry dalPOInStockEntry = new EDI.DAL.PoInStockEntry();
            Huali.EDI.Model.T_ICItem mICItem = new EDI.Model.T_ICItem();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //alcon 单号
                string fAlconBillNo = dt.Rows[i][0].ToString();


                //单据日期
                DateTime fdate = DateTime.Parse(dt.Rows[i][3].ToString().Substring(0, 4) + "-" + dt.Rows[i][3].ToString().Substring(4, 2) + "-" + dt.Rows[i][3].ToString().Substring(6));
                //Alcon产品代码
                string fAlconItemID = dt.Rows[i][15].ToString();
                //数量
                decimal fQty = decimal.Parse(dt.Rows[i][16].ToString());
                //价格
                decimal fPrice = 0;
                //Alcon行号
                string fEntrySelfP0386 = dt.Rows[i][14].ToString();
                //仓库Id 武汉 alcon:1165
                int fStockID = 0;
                switch (dt.Rows[i][18].ToString())
                {
                    case "CSW":
                        fStockID = (int)StockName.CSW;
                        break;
                    case "RET":
                        fStockID = (int)StockName.RET;
                        break;
                    case "EPD":
                        fStockID = (int)StockName.EPD;
                        break;
                    case "JWI":
                        fStockID = (int)StockName.JWI;
                        break;
                    case "JQU":
                        fStockID = (int)StockName.JQU;
                        break;
                    case "JDA":
                        fStockID = (int)StockName.JDA;
                        break;
                    default:
                        fStockID = (int)StockName.CSW;
                        break;
                }

                if (dalICItem.Exists(fAlconItemID) == true)
                {
                    if (pKey != fAlconBillNo)
                    {
                        pKey = fAlconBillNo;

                        //金蝶收货单号
                        string MaxBillNo = dalPOInStock.GetMaxFBillNo();
                        if (string.IsNullOrEmpty(MaxBillNo))
                        {
                            fBillNo = "DR000001";
                        }
                        else
                        {
                            fBillNo = "DR" + (int.Parse(MaxBillNo.Substring(2)) + 1).ToString().PadLeft(6, '0');
                        }

                        //内联编号
                        string MaxFInterID = dalPOInStock.GetMaxFInterID();
                        if (string.IsNullOrEmpty(MaxFInterID))
                        {
                            fInterID = 1142;
                        }
                        else
                        {
                            fInterID = int.Parse(MaxFInterID) + 1;
                        }

                        //写master表
                        if (dalPOInStock.InsertPoInStock(fInterID, fBillNo, fdate, pKey) == true)
                        {
                            fEntryID = 1;
                        }
                    }

                    //写Detail表
                    //在ICItem得到商品信息
                    mICItem = dalICItem.GetModel(fAlconItemID);
                    //金蝶商品编号
                    int fItemID = mICItem.FItemID;
                    //单位编号
                    int fUnitID = mICItem.FUnitID;//单位ID
                    //有效期
                    //decimal fKFPeriod = mICItem.FKFPeriod;
                    //decimal fKFPeriod = DBNull.Value;

                    if (dalPOInStockEntry.InsertPoInStockEntry(fInterID, fEntryID, fItemID, fQty, fPrice, fQty * fPrice, fUnitID, fPrice, fQty, new DateTime(2200, 12, 31), 0, fStockID, new DateTime(2200, 12, 31), fEntrySelfP0386, fQty, fQty, "", 0,0) == true)
                    {
                        fEntryID++;
                        successCount++;
                    }
                }
                else
                {
                    //MessageBox.Show(fAlconItemID + "产品编号不存在！");
                    CustomDesktopAlert.H2(fAlconItemID + "产品编号不存在！");
                    dataGridView1.Rows[i].Selected = true;
                }
            }

            CustomDesktopAlert.H2("总共有 " + dt.Rows.Count.ToString() + " 条记录," + "导入失败 " + (dt.Rows.Count - successCount).ToString() + " 条！");
            //DesktopAlert.Show("<h2>" + "总共有 " + dt.Rows.Count.ToString() + " 条记录," + "导入失败 " + (dt.Rows.Count - successCount).ToString() + " 条！" + "</h2>");
            return retVal;
        }

        #region "OK"
        /// <summary>
        /// EXCEL文件导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool Excel2DB(DataTable dt)
        {
            bool retVal = false;
            string pKey = "";//alcon 单号
            int fInterID = 0;//内联ID,外键
            int fEntryID = 0;
            int successCount = 0;
            string fBillNo = "";//金蝶收货单号

            Huali.EDI.DAL.T_ICItem dalICItem = new EDI.DAL.T_ICItem();
            Huali.EDI.DAL.PoInStock dalPOInStock = new EDI.DAL.PoInStock();
            Huali.EDI.DAL.PoInStockEntry dalPOInStockEntry = new EDI.DAL.PoInStockEntry();
            Huali.EDI.DAL.T_AuxItem dalAuxItem = new T_AuxItem();
            Huali.EDI.Model.T_ICItem mICItem = new EDI.Model.T_ICItem();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //alcon 单号
                string fAlconBillNo = dt.Rows[i][0].ToString();


                //单据日期
                //DateTime fdate = DateTime.Parse(dt.Rows[i][3].ToString().Substring(0, 4) + "-" + dt.Rows[i][3].ToString().Substring(4, 2) + "-" + dt.Rows[i][3].ToString().Substring(6));
                DateTime fdate = System.DateTime.Now;
                //Alcon产品代码
                string fAlconItemID = dt.Rows[i][8].ToString();
                //数量
                decimal fQty = decimal.Parse(dt.Rows[i][4].ToString());
                //有效期至
                DateTime fPeriodDate = DateTime.Parse(dt.Rows[i][6].ToString().Substring(0, 4) + "-" + dt.Rows[i][6].ToString().Substring(4, 2) + "-" + dt.Rows[i][6].ToString().Substring(6));

                //批号
                string fBatchNo = dt.Rows[i][3].ToString();
                //价格
                decimal fPrice = 0;
                //Alcon行号
                string fEntrySelfP0386 = "";
                //仓库Id
                int fStockID = 0;
                switch (dt.Rows[i][7].ToString())
                {
                    case "CSW":
                        fStockID = (int)StockName.CSW;
                        break;
                    case "RET":
                        fStockID = (int)StockName.RET;
                        break;
                    case "EPD":
                        fStockID = (int)StockName.EPD;
                        break;
                    case "JWI":
                        fStockID = (int)StockName.JWI;
                        break;
                    case "JQU":
                        fStockID = (int)StockName.JQU;
                        break;
                    case "JDA":
                        fStockID = (int)StockName.JDA;
                        break;
                    default:
                        fStockID = (int)StockName.CSW;
                        break;
                }
                //注册证号
                int fAuxPropID = dalAuxItem.GetAuxPropIDByKey(dt.Rows[i][9].ToString());
                if (fAuxPropID == 0)
                {
                    CustomDesktopAlert.H2("第" + (i+ 1).ToString() + "行的注册证号无效！");
                }

                if (dalICItem.Exists(fAlconItemID) == true)
                {
                    if (pKey != fAlconBillNo)
                    {
                        pKey = fAlconBillNo;

                        //金蝶收货单号
                        if (string.IsNullOrEmpty(dalPOInStock.GetMaxFBillNo()))
                        {
                            fBillNo = "DA000001";
                        }
                        else
                        {
                            fBillNo = "DA" + (int.Parse(dalPOInStock.GetMaxFBillNo().Substring(2)) + 1).ToString().PadLeft(6, '0');
                        }

                        //内联编号
                        if (string.IsNullOrEmpty(dalPOInStock.GetMaxFInterID()))
                        {
                            fInterID = 1142;
                        }
                        else
                        {
                            fInterID = int.Parse(dalPOInStock.GetMaxFInterID()) + 1;
                        }

                        //写master表
                        if (dalPOInStock.InsertPoInStock(fInterID, fBillNo, fdate, pKey) == true)
                        {
                            fEntryID = 1;
                        }
                    }

                    //写Detail表
                    //在ICItem得到商品信息
                    mICItem = dalICItem.GetModel(fAlconItemID);
                    //金蝶商品编号
                    int fItemID = mICItem.FItemID;
                    //单位编号
                    int fUnitID = mICItem.FUnitID;//单位ID
                    //有效期
                    int fKFPeriod = (int)mICItem.FKFPeriod;
                    //decimal fKFPeriod = DBNull.Value;

                    DateTime fKFDate = fPeriodDate.AddDays(-fKFPeriod);

                    if (dalPOInStockEntry.InsertPoInStockEntry(fInterID, fEntryID, fItemID, fQty, fPrice, fQty * fPrice, fUnitID, fPrice, fQty, fKFDate, fKFPeriod, fStockID, fPeriodDate, fEntrySelfP0386, fQty, fQty, fBatchNo, 1, fAuxPropID) == true)
                    {
                        fEntryID++;
                        successCount++;
                    }
                    else
                    {
                        CustomDesktopAlert.H2("!!!");
                    }
                }
                else
                {
                    //MessageBox.Show(fAlconItemID + "产品编号不存在！");
                    CustomDesktopAlert.H2("产品编号不存在！");
                    dataGridView1.Rows[i].Selected = true;

                }
            }

            //MessageBox.Show("总共有 " + dt.Rows.Count.ToString() + " 条记录,导入失败 " + (dt.Rows.Count - successCount).ToString() + " 条！");
            CustomDesktopAlert.H2("总共有 " + dt.Rows.Count.ToString() + " 条记录,导入失败 " + (dt.Rows.Count - successCount).ToString() + " 条！");
            return retVal;
        }
        #endregion

        #endregion
        
    }
}
