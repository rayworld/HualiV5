using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using HualiHan.Models;
using Ray.Framework.Converter;
using System;
using System.Data;
using System.Windows.Forms;

namespace HualiHan
{
    public partial class frmEDI_SEOutStock : Office2007Form
    {
        public frmEDI_SEOutStock()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private static TemplateType template = TemplateType.Unknow;
        
        #region 事件
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //Check Data
            if (template == TemplateType.日立)
            {
                if (CheckData_RL(dt))
                {
                    //ImportData
                    ImportData_RL(dt, "订单号");
                }
            }
            else if (template == TemplateType.星创)
            {
                if (CheckData_XC(dt))
                {
                    //ImportData
                    ImportData_XC(dt, "订单号");
                }
            }
            else 
            {
                DesktopAlert.Show("不能识别的Excel模板文件！");
            }
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\Users\\Ray\\Desktop";//注意这里写路径时要用c:\\而不是c:\
            dialog.Filter = "Excel2007文件|*.xlsx|Excel2003文件|*.xls|所有文件|*.*";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                this.dataGridViewX1.DataSource = null;
                string fileName = dialog.FileName;
                template = swichTemplateType(fileName);
                Convert2DataTable c2d = new Convert2DataTable();
                //string sheetName = template == TemplateType.日立 ? "门店信息" : "订单明细";
                string sheetName = template == TemplateType.日立 ? "门店信息" : "Sheet1";
                dt = c2d.Excel2DataTable(fileName, sheetName, null, null);
                this.dataGridViewX1.DataSource = dt;
                DesktopAlert.Show("<h2>" + "成功打开Excel文件！ " + "</h2>");
            }
        }

        #endregion
        
        #region 私有过程

        /// <summary>
        /// 选择模板类型
        /// </summary>
        /// <param name="filename">Excel文件名</param>
        /// <returns></returns>
        private TemplateType swichTemplateType(string filename)
        {
            if (filename.Contains("补货订单") == true)
            {
                template = TemplateType.日立;
            }
            else if (filename.Contains("销售订单") == true)
            {
                template = TemplateType.星创;
            }
            else
            {
                template = TemplateType.Unknow;
            }
            return template;
        }

        /// <summary>
        /// 过滤不同单据类型
        /// </summary>
        /// <param name="dt">Excel 数据表</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        private DataTable FilterData(DataTable dt, string where)
        {
            DataRow[] rows = dt.Select(where);
            DataTable tmpdt = dt.Clone();
            foreach (DataRow row in rows)  // 将查询的结果添加到tempdt中； 
            {
                tmpdt.Rows.Add(row.ItemArray);
            }
            return tmpdt;
        }

        /// <summary>
        /// 得到唯一的单号列表
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="billNoFieldName">单号列的名字</param>
        /// <returns></returns>
        private string getDistinctBillNo(DataTable dt, string billNoFieldName)
        {
            string tempBillNo = "";
            string billNo = "";
            string retVal = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                billNo = dt.Rows[i][billNoFieldName].ToString();
                if (billNo != tempBillNo)
                {
                    retVal += billNo + ";";
                    tempBillNo = billNo;
                }
            }

            //去掉最后一个分号
            return retVal.Substring(0, retVal.Length - 1);
        }

        #region 日立

        /// <summary>
        /// 日立导入数据
        /// </summary>
        /// <param name="dt">Excel 数据表</param>
        /// <param name="billNoFieldName">单号列的名字</param>
        /// <returns></returns>
        private bool ImportData_RL(DataTable dt, string billNoFieldName)
        {
            bool retVal = false;

            if (dt.Rows.Count > 0)
            {
                //得到单据号的列表
                string distinctBillNo = getDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //得到一张单数据
                    DataTable tmpdt = FilterData(dt, "订单号 = '" + billNo + "'");

                    //ImportSaleBill
                    InsertSaleBill_RL(tmpdt);
                }
            }
            else
            {
                DesktopAlert.Show("没有可用的数据！");
            }

            return retVal;
        }

        /// <summary>
        /// 检验数据合法性
        /// </summary>
        /// <param name="dt">Excel 数据表</param>
        /// <returns></returns>
        private bool CheckData_RL(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //检查产品代码
                HualiHan.DAL.t_ICItem dICItem = new DAL.t_ICItem();
                string rowNum = dr["序号"].ToString();
                string productNumber = dr["补货产品编号"].ToString();
                string productDegree = dr["近视光度"].ToString();
                int productId = dICItem.getItemIDByFNameFnumber(productNumber, productDegree);
                if (productId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行产品编号不能识别！");
                    retVal = false;
                }
                else
                {
                    dr["补货产品编号"] = productId.ToString();
                }

                //检查门店ID
                string storeNumber = dr["客户编号"].ToString();
                int storeId = dICItem.getCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行客户编号不能识别！");
                    //总店编号检查
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.getCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        DesktopAlert.Show("第" + rowNum + "行总店编号不能识别！");
                        return false;
                    }
                    else
                    {
                        dr["总店代码"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["总店代码"] = storeId.ToString();
                }

                //检查客户ID
                string customNumber = dr["门店编号"].ToString();
                int customId = dICItem.getCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行客户编号不能识别！");
                    return false;
                }
                else
                {
                    dr["客户编号"] = customId.ToString();
                    dr["门店编号"] = dr["总店代码"];
                }
            }
            return retVal;
        }

        /// <summary>
        /// 将一张订单的数据写入数据库
        /// </summary>
        /// <param name="dt">一张订单的数据</param>
        private bool InsertSaleBill_RL(DataTable dt)
        {
            HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
            int interId = dSale.GetMaxFInterID();
            string billNo = dSale.GetMaxFBillNo();
            string sourceBillNo = dt.Rows[0]["订单号"].ToString();
            //已经翻译到名店编号列
            int custId = int.Parse(dt.Rows[0]["客户编号"].ToString());
            int storeId = int.Parse(dt.Rows[0]["门店编号"].ToString());
            string productName = dt.Rows[0]["补货产品名称"].ToString();
            string explanation = string.Format("免费品 {0} 2+1+1", productName);
            HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15326);
            try
            {
                if (dSale.InsertBill(mSale) == true)
                {
                    //DesktopAlert.Show("写主表成功！");

                    //写子表
                    int succ = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                        int itemId = int.Parse(dt.Rows[i]["补货产品编号"].ToString());
                        int entryId = i + 1;                        
                        int stockId = 526;//CSW
                        int qty = int.Parse(dt.Rows[i]["补货数量"].ToString());
                        HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                        decimal price = dicitem.getSalePriceByFItemID(itemId);

                        HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, qty, qty, 0, 0,40311,40635, 255);

                        if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                        {
                            succ += 1;
                        }
                    }
                    if (succ == dt.Rows.Count)
                    {
                        DesktopAlert.Show("<h2>单据号 " + billNo + " ：" + succ + " 条记录导入成功！</h2>");
                        return true;
                    }
                    else
                    {
                        DesktopAlert.Show(billNo + "写子表失败！");
                        return false;
                    }
                }
                else
                {
                    DesktopAlert.Show("写主数据表失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion

        #region 星创

        /// <summary>
        /// 导入数据主程序
        /// </summary>
        /// <param name="dt">Excel 数据表</param>
        /// <param name="billNoFieldName">单号列的名字</param>
        /// <returns></returns>
        private bool ImportData_XC(DataTable dt, string billNoFieldName)
        {
            bool retVal = true;

            if (dt.Rows.Count > 0)
            {
                //得到单据号的列表
                string distinctBillNo = getDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //得到一张单数据
                    DataTable tmpdt = FilterData(dt, billNoFieldName + " = '" + billNo + "'");

                    //处理销售数据
                    InsertSaleBill_XC(tmpdt);

                    //处理赠送数据
                    InsertFreeBill_XC(tmpdt);

                    //处理5P数据
                    Insert5PBill_XC(tmpdt);
                }
            }
            else
            {
                DesktopAlert.Show("没有可用的数据！");
                return false;
            }
            return retVal;
        }

        /// <summary>
        /// 星创赠品订单导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool InsertFreeBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " 赠品 > 0 and 规格 not like '%5P%'");

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["订单号"].ToString();
                //已经翻译到名店编号列
                int custId = int.Parse(tmpdt.Rows[0]["购货单位代码"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["门店代码"].ToString());
                string productName = tmpdt.Rows[0]["收货方部门"].ToString();
                string explanation = string.Format("随货赠送 {0}", productName);
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15322);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("写主表成功！");

                        //写子表
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["仓库"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["赠品"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40526, unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>单据号 " + billNo + " ：" + succ + " 条记录导入成功！</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "写子表失败！");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("写主数据表失败");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("没有可用的数据！");
                return false;
            }
        }

        /// <summary>
        /// 星创5片装订单导入
        /// </summary>
        /// <param name="dt">单据数据</param>
        private bool Insert5PBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " 赠品 > 0 AND 规格 LIKE '%5P%' ");

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["订单号"].ToString();
                //已经翻译到名店编号列
                int custId = int.Parse(tmpdt.Rows[0]["购货单位代码"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["门店代码"].ToString());
                string productName = tmpdt.Rows[0]["收货方部门"].ToString();
                string explanation = string.Format("随货赠送卓效 {0}", productName);
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40393, 15326);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("写主表成功！");

                        //写子表
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["仓库"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["赠品"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, 0, 0, 0, 0, 0, 0, 0, 40311, 40569,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>单据号 " + billNo + " ：" + succ + " 条记录导入成功！</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "写子表失败！");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("写主数据表失败");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("没有可用的数据！");
                return false;
            }
        }

        /// <summary>
        /// 星创销售订单导入
        /// </summary>
        /// <param name="dt"></param>
        private bool InsertSaleBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, "数量 > 0");

            //DesktopAlert.Show(tmpdt.Rows.Count.ToString());

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["订单号"].ToString();
                //已经翻译到名店编号列
                int custId = int.Parse(tmpdt.Rows[0]["购货单位代码"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["门店代码"].ToString());
                string productName = tmpdt.Rows[0]["收货方部门"].ToString();
                //string explanation = string.Format("补货 {0}", productName);
                string explanation = string.Format("{0}", productName);    
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20302, null, 15322);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("写主表成功！");

                        //写子表
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["仓库"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["数量"].ToString());
                            //int cxType = int.Parse(tmpdt.Rows[i]["促销类别"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40470,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>单据号 " + billNo + " ：" + succ + " 条记录导入成功！</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "写子表失败！");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("写主数据表失败");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("没有可用的数据！");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool CheckData_XC(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //检查产品代码
                HualiHan.DAL.t_ICItem dICItem = new DAL.t_ICItem();
                string rowNum = dr["序号"].ToString();
                string sku = dr["SKU"].ToString();
                int productId = dICItem.getItemIDBySKU(sku);
                if (productId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行产品编号不能识别！");
                    retVal = false;
                }
                else
                {
                    dr["SKU"] = productId.ToString();
                }

                //检查门店ID
                string storeNumber = dr["门店代码"].ToString();
                int storeId = dICItem.getCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行门店代码不能识别！");
                    //总店编号检查
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.getCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        DesktopAlert.Show("第" + rowNum + "行总店编号不能识别！");
                        return false;
                    }
                    else
                    {
                        dr["门店代码"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["门店代码"] = storeId.ToString();
                }

                //检查客户ID
                string customNumber = dr["购货单位代码"].ToString();
                int customId = dICItem.getCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行客户编号不能识别！");
                    return false;
                }
                else
                {
                    dr["购货单位代码"] = customId.ToString();                    
                }

                //仓库编号
                string stockName = dr["仓库"].ToString();
                int stockId = dICItem.getStockIDByFName(stockName);
                if (stockId == 0)
                {
                    DesktopAlert.Show("第" + rowNum + "行仓库编号不能识别！");
                    return false;
                }
                else
                {
                    dr["仓库"] = stockId.ToString();
                }

                //促销类别
                string cuxiaoType = dr["促销类别"].ToString();
                HualiHan.DAL.SEOutStockEntry dEntry = new DAL.SEOutStockEntry();
                int cxType = dEntry.getInterIDByFName(cuxiaoType);
                dr["促销类别"] = cxType.ToString();
            }
            return retVal;
        }
        #endregion

        #region 生成对象

        /// <summary>
        /// 生成主表对象
        /// </summary>
        /// <param name="interId">内部ID</param>
        /// <param name="billNo">单号</param>
        /// <param name="storeId">门店ID</param>
        /// <param name="explanation">说明</param>
        /// <param name="sourceBillNo">EDI原单号</param>
        /// <param name="customId">客户编号</param>
        /// <param name="areaPS">areaPS:20303</param>
        /// <param name="HeadSelfS0238">2048.2000</param>
        /// <param name="HeadSelfS0239">sp.so</param>
        /// <returns></returns>
        private HualiHan.Models.SEOutStock BuildSaleModel(int interId, string billNo, int storeId, string explanation, string sourceBillNo, int customId, int areaPS, int? HeadSelfS0238, int HeadSelfS0239)
        {
            //公共当前日期
            DateTime currDate = DateTime.Now.Date;

            HualiHan.Models.SEOutStock mSale = new SEOutStock();
            HualiHan.DAL.SEOutStock dSale = new HualiHan.DAL.SEOutStock();
            mSale.FInterID = interId;
            mSale.FBillNo = billNo;
            mSale.FTranType = 83;
            mSale.FSalType = 101;
            mSale.FCustID = customId;//爱尔康市场部
            mSale.FExplanation = explanation;
            mSale.FBrNo = "0";
            mSale.FDate = currDate;
            mSale.FStockID = null;
            mSale.FAdd = null;
            mSale.FNote = null;
            mSale.FEmpID = 39426;
            mSale.FCheckerID = null;
            mSale.FBillerID = 16454;
            mSale.FManagerID = 0;
            mSale.FClosed = 0;
            mSale.FInvoiceClosed = 0;
            mSale.FBClosed = 0;
            mSale.FDeptID = 271;
            mSale.FSettleID = 0;
            mSale.FTranStatus = 0;
            mSale.FExchangeRate = 1;
            mSale.FCurrencyID = 1;
            mSale.FStatus = 0;
            mSale.FCancellation = false;
            mSale.FMultiCheckLevel1 = null;
            mSale.FMultiCheckLevel2 = null;
            mSale.FMultiCheckLevel3 = null;
            mSale.FMultiCheckLevel4 = null;
            mSale.FMultiCheckLevel5 = null;
            mSale.FMultiCheckLevel6 = null;
            mSale.FMultiCheckDate1 = null;
            mSale.FMultiCheckDate2 = null;
            mSale.FMultiCheckDate3 = null;
            mSale.FMultiCheckDate4 = null;
            mSale.FMultiCheckDate5 = null;
            mSale.FMultiCheckDate6 = null;
            mSale.FCurCheckLevel = null;
            mSale.FRelateBrID = 0;
            mSale.FCheckDate = null;
            mSale.FFetchAdd = "";
            mSale.FSelTranType = 0;
            mSale.FChildren = 0;
            mSale.FBrID = null;
            ///mSale.FAreaPS = 20303;
            mSale.FAreaPS = areaPS;
            mSale.FPOOrdBillNo = null;
            mSale.FManageType = 0;
            mSale.FExchangeRateType = 1;
            mSale.FCustAddress = null;
            mSale.FPrintCount = 0;
            //2480
            ///mSale.FHeadSelfS0238 = 40394;
            mSale.FHeadSelfS0238 = HeadSelfS0238;
            //sp
            ///mSale.FHeadSelfS0239 = 15326;
            mSale.FHeadSelfS0239 = HeadSelfS0239;
            //?
            mSale.FHeadSelfS0240 = sourceBillNo;
            mSale.FHeadSelfS1241 = null;
            mSale.FHeadSelfS1242 = null;
            // 门店编号
            mSale.FHeadSelfS0241 = storeId;
            mSale.FHeadSelfS0244 = "";
            mSale.FHeadSelfS1244 = null;
            mSale.FHeadSelfS1243 = null;
            mSale.FHeadSelfS0245 = currDate;
            mSale.FHeadSelfS1245 = null;
            mSale.FHeadSelfS0247 = "";
            mSale.FHeadSelfS1246 = null;

            return mSale;
        }

        /// <summary>
        /// 生成明细表对象
        /// </summary>
        /// <param name="finterid">内部ID</param>
        /// <param name="fentryid">序号</param>
        /// <param name="fitemid">产品ID</param>
        /// <param name="fstockid">仓库ID</param>
        /// <param name="AuxCommitQty"></param>
        /// <param name="AuxStockBillQty"></param>
        /// <param name="AuxStockQty"></param>
        /// <param name="CommitQty"></param>
        /// <param name="price"></param>
        /// <param name="qty"></param>
        /// <param name="StockBillQty"></param>
        /// <param name="StockQty"></param>
        /// <param name="EntrySelfS0252"></param>
        /// <param name="EntrySelfS0253"></param>
        /// <returns></returns>
        private HualiHan.Models.SEOutStockEntry BuildSaleEntryModel(int finterid, int fentryid, int fitemid, int fstockid, decimal qty, decimal price, decimal CommitQty, decimal AuxCommitQty, decimal StockQty, decimal AuxStockQty, decimal AuxStockBillQty, decimal StockBillQty, int EntrySelfS0252, int EntrySelfS0253,int UnitID)
        {
            /// 公共数量
            decimal currQty = qty;
            /// 公共价格
            decimal currPrice = price;
            /// 公共当前时间
            DateTime currDate = DateTime.Now.Date;

            HualiHan.Models.SEOutStockEntry mSaleEntry = new SEOutStockEntry();
            mSaleEntry.FInterID = finterid;
            mSaleEntry.FEntryID = fentryid;
            mSaleEntry.FItemID = fitemid;
            mSaleEntry.FStockID = fstockid;
            mSaleEntry.FBrNo = "0";
            mSaleEntry.FQty = currQty;
            mSaleEntry.FCommitQty = CommitQty;
            mSaleEntry.FPrice = currPrice;
            mSaleEntry.FAmount = currQty * currPrice;
            mSaleEntry.FOrderInterID = "0";
            mSaleEntry.FDate = null;
            mSaleEntry.FNote = "";
            mSaleEntry.FInvoiceQty = 0;
            mSaleEntry.FBCommitQty = 0;
            mSaleEntry.FUnitID = UnitID;
            mSaleEntry.FAuxBCommitQty = 0;
            mSaleEntry.FAuxCommitQty = AuxCommitQty;
            mSaleEntry.FAuxInvoiceQty = 0;
            mSaleEntry.FAuxPrice = currPrice;
            mSaleEntry.FAuxQty = currQty;
            mSaleEntry.FSourceEntryID = 0;
            mSaleEntry.FMapNumber = "";
            mSaleEntry.FMapName = "";
            mSaleEntry.FAuxPropID = 0;
            mSaleEntry.FBatchNo = "";
            mSaleEntry.FCheckDate = null;
            mSaleEntry.FExplanation = "";
            mSaleEntry.FFetchAdd = "";
            mSaleEntry.FFetchDate = currDate;
            mSaleEntry.FMultiCheckDate1 = null;
            mSaleEntry.FMultiCheckDate2 = null;
            mSaleEntry.FMultiCheckDate3 = null;
            mSaleEntry.FMultiCheckDate4 = null;
            mSaleEntry.FMultiCheckDate5 = null;
            mSaleEntry.FMultiCheckDate6 = null;
            mSaleEntry.FSecCoefficient = 0;
            mSaleEntry.FSecQty = 0;
            mSaleEntry.FSecCommitQty = 0;
            mSaleEntry.FSourceTranType = 0;
            mSaleEntry.FSourceInterId = 0;
            mSaleEntry.FSourceBillNo = "";
            mSaleEntry.FContractInterID = 0;
            mSaleEntry.FContractEntryID = 0;
            mSaleEntry.FContractBillNo = "";
            mSaleEntry.FOrderEntryID = 0;
            mSaleEntry.FOrderBillNo = "";
            mSaleEntry.FBackQty = 0;
            mSaleEntry.FAuxBackQty = 0;
            mSaleEntry.FSecBackQty = 0;
            mSaleEntry.FStdAmount = currPrice * currQty;
            mSaleEntry.FPlanMode = 14036;
            mSaleEntry.FMTONo = "";
            mSaleEntry.FStockQty = StockQty;
            mSaleEntry.FAuxStockQty = AuxStockQty;
            mSaleEntry.FSecStockQty = 0;
            mSaleEntry.FSecInvoiceQty = 0;
            mSaleEntry.FDiffQtyClosed = 0;
            mSaleEntry.FAuxStockBillQty = AuxStockBillQty;
            mSaleEntry.FStockBillQty = StockBillQty;
            mSaleEntry.FEntrySelfS0251 = null;
            //mSaleEntry.FEntrySelfS0252 = 40311;
            mSaleEntry.FEntrySelfS0252 = EntrySelfS0252;
            //mSaleEntry.FEntrySelfS0253 = 40635;
            mSaleEntry.FEntrySelfS0253 = EntrySelfS0253;
            mSaleEntry.FEntrySelfS1234 = null;
            mSaleEntry.FEntrySelfS1235 = null;
            //mSaleEntry.FEntrySelfS0254 = "视康镜片";
            mSaleEntry.FEntrySelfS0254 = "";
            mSaleEntry.FEntrySelfS1236 = null;

            return mSaleEntry;
        }
        #endregion

        #endregion

    }

    public enum TemplateType 
    {
        日立,
        星创,
        Unknow,
    }
}