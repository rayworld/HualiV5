using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmQRCodeScan : Office2007Form
    {
        
        public FrmQRCodeScan()
        {
            InitializeComponent();
        }

        string mingQRCodes = "";
        string sql = "";
        private static readonly string connALiClouds = SqlHelper.GetConnectionString("ALiClouds");
        //private static readonly string connTest = SqlHelper.GetConnectionString("AliTest");
        public static string Data_Source = AppDomain.CurrentDomain.BaseDirectory + "QRCode1.accdb";
        private static readonly string connAccess = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ Data_Source + ";Persist Security Info=False;";
        DataTable dt = (DataTable)null;
       
        #region 事件
        /// <summary>                                                                           
        /// 用户输入新的出库单号并确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            ////用户按下回车键
            if (e.KeyCode == Keys.Enter)
            {
                //清空选项，
                dataGridViewX1.DataSource = (DataTable)null;
                dataGridViewX1.Rows.Clear();
                dataGridViewX1.Columns.Clear();
                //单据编号为数字
                if (!string.IsNullOrEmpty(textBoxX1.Text) && IsNumber(textBoxX1.Text))
                {
                    //清空二维码列表，
                    mingQRCodes = "";
                    //得到单据编号
                    string billType = comboBoxEx2.SelectedIndex == 0 ? "XOUT" : "QOUT";
                    string billNo = billType + textBoxX1.Text;
                    //收到单据分录信息
                    //int recCount = int.Parse(SqlHelper.GetSingle("select count(*) from icstock where [单据编号] ='" + billNo + "' and [FActQty] < [实发数量]",null).ToString());
                    sql = string.Format("SELECT COUNT(*) FROM icstock WHERE [单据编号] ='{0}' AND [FActQty] < [实发数量]", billNo);
                    object obj = SqlHelper.ExecuteScalar(connALiClouds, sql);
                    int recCount = obj != null ? int.Parse(obj.ToString()) : 0;
                    if (recCount > 0)
                    {
                        //DataTable dtmaster = SqlHelper.ExcuteDataTable("select top 1 [日期],[购货单位],[发货仓库],[摘要] from icstock where [单据编号] ='" + billNo + "' and [FActQty] < [实发数量]");
                        sql = string.Format("SELECT TOP 1 [日期],[购货单位],[发货仓库],[摘要] FROM icstock WHERE [单据编号] ='{0}' AND [FActQty] < [实发数量]", billNo);
                        DataTable dtmaster = SqlHelper.ExecuteDataTable(connALiClouds, sql);
                        textBoxX2.Text = dtmaster.Rows[0][0].ToString();
                        textBoxX3.Text = dtmaster.Rows[0][1].ToString();
                        textBoxX4.Text = dtmaster.Rows[0][2].ToString();

                        //dt = SqlHelper.ExcuteDataTable("select [fEntryID] as 分录号,[产品名称],[批号],[实发数量] as 应发,[FActQty] as 实发  from icstock where [单据编号] ='" + billNo + "' and [FActQty] < [实发数量] order by fEntryID");
                        sql = string.Format("SELECT [fEntryID] AS 分录号,[产品名称],[批号],[实发数量] AS 应发,[FActQty] AS 实发  FROM icstock WHERE [单据编号] ='{0}' AND [FActQty] < [实发数量] ORDER BY fEntryID", billNo);
                        dt = SqlHelper.ExecuteDataTable(connALiClouds, sql);
                        dataGridViewX1.DataSource = dt;
                        DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn
                        {
                            HeaderText = "选择"
                        };
                        dataGridViewX1.Columns.Insert(0, newColumn);
                        dataGridViewX1.Columns["产品名称"].Width = 400;
                        dataGridViewX1.Rows[0].Selected = true;
                        //
                        textBoxItem1.Focus();
                    }
                    else
                    {
                        CustomDesktopAlert.H2("无数据，请检查单据编号的输入!");
                    }
                }
                else
                {
                    CustomDesktopAlert.H2("请检查单据编号的输入!");
                }
            }
        }


        /// <summary>
        /// 程序启动时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            comboBoxEx2.SelectedIndex = 0;
            textBoxItem1.TextBoxWidth = 200;
            expandableSplitter1.Left = dataGridViewX1.Width;
            expandableSplitter1.Expanded = false;
        }

        /// <summary>
        /// 拆单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewX1.RowCount - 1; i > -1; i--)
            {
                if (dataGridViewX1.Rows[i].Cells[0].EditedFormattedValue.ToString() != "True")
                {
                    dataGridViewX1.Rows.Remove(dataGridViewX1.Rows[i]);
                }
            }
            dataGridViewX1.Rows[0].Selected = true;
            textBoxItem1.Focus();
        }

        private void TextBoxItem1_KeyDown(object sender, KeyEventArgs e)
        {
            //用户按下回车键
            if (e.KeyCode == Keys.Enter)
            {
                //如果已经扫描二维码个数小于该分录总数，则继续扫描，
                int maxVal = int.Parse(dataGridViewX1.SelectedRows[0].Cells[4].Value.ToString());
                int currVal = int.Parse(dataGridViewX1.SelectedRows[0].Cells[5].Value.ToString());

                if (currVal < maxVal)
                {
                    //去掉回车换行符
                    string QRCode = textBoxItem1.Text.Trim().Replace(" ", "").Replace("\n", "").Replace("\r\n", "");
                    //揭秘成明码
                    string mingQRCode = EncryptHelper.Decrypt(QRCode);
                    //显示明码
                    labelItem2.Text = mingQRCode;

                    //扫描窗口重新获得焦点
                    textBoxItem1.Text = "";
                    labelItem2.Text = "";
                    textBoxItem1.Focus();

                    //显示状态信息
                    string billType = comboBoxEx2.SelectedIndex == 0 ? "XOUT" : "QOUT";
                    string billNo = billType + textBoxX1.Text;
                    string entryID = dataGridViewX1.SelectedRows[0].Cells[1].Value.ToString();

                    //限定二维码信息
                    if (string.IsNullOrEmpty(mingQRCode))
                    {
                        CustomDesktopAlert.H2("二维码为空！");
                        return;
                    }

                    if (mingQRCode.Length != 9)
                    {
                        CustomDesktopAlert.H2("二维码长度不正确！");
                        return;
                    }

                    if (IsNumber(mingQRCode) == false)
                    {
                        CustomDesktopAlert.H2("二维码未能正确识别！");
                        return;
                    }

                    //单据编号和分录编号不为空
                    if (billNo == "" || entryID == "")
                    {
                        CustomDesktopAlert.H2("请先输入出库单编号，选择明细分录！");
                        return;
                    }

                    //查重
                    int index = mingQRCodes.IndexOf(mingQRCode);
                    if (index > -1)
                    {
                        CustomDesktopAlert.H2("此二维码录入重复！");
                        return;
                    }
                    mingQRCodes += mingQRCode + ";";

                    //写入T_QRCode
                    //billNo = billNo.Substring(0, 1) + billNo.Substring(4);
                    ///InsertQRCode2T_QRCode(mingQRCode, billNo, entryID);
                    //更新icstock
                    ///UpdateICStockByActQty(billNo, entryID);
                    //写入T_QRCode
                    InsertQRCode2Access(mingQRCode, billNo, entryID);


                    //更新状态栏
                    currVal++;
                    dataGridViewX1.SelectedRows[0].Cells[5].Value = currVal;

                    if (currVal == maxVal)//此分录已经完成
                    {
                        UpdateQRCode2AliCloud();
                        dataGridViewX1.Rows.Remove(dataGridViewX1.SelectedRows[0]);
                        //此出库单已经全部录入完成
                        if (dataGridViewX1.Rows.Count == 0)
                        {
                            CustomDesktopAlert.H2("此出库单已经全部录入完成！");
                        }
                        else//此分录已经全部录入完成
                        {
                            dataGridViewX1.Rows[0].Selected = true;
                            CustomDesktopAlert.H2("此分录已经全部录入完成！");
                        }
                        //清空二维码录入记录
                        mingQRCodes = "";
                    }
                }
                else
                {
                    CustomDesktopAlert.H2("二维码数量超过范围！");
                    return;
                }
            }
        }

        /// <summary>
        /// 用户重新选择了分录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            mingQRCodes = "";
            textBoxItem1.Focus();

        }

        private void ExpandableSplitter1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            panelEx2.Width = expandableSplitter1.Expanded == true ? 360 : 0;
            dataGridViewX1.Width = this.Width - panelEx2.Width;
        } 

        #endregion

        #region 私有过程

        /// <summary>  
        /// 判读字符串是否为数值型
        /// </summary>  
        /// <param name="strNumber">字符串</param>  
        /// <returns>是否</returns>  
        public static bool IsNumber(string strNumber)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^-?\d+\.?\d*$");
            return r.IsMatch(strNumber);
        }

        #region Unused
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mingQRCode"></param>
        ///// <param name="billNo"></param>
        ///// <param name="EntryID"></param>
        ///// <returns></returns>
        //public int InsertQRCode2T_QRCode(string mingQRCode, string billNo, string EntryID)
        //{
        //    string tableName = "t_QRCode" + mingQRCode.Substring(0, 4);
        //    string EntryNo = billNo + EntryID.PadLeft(4, '0');
        //    //return SqlHelper.ExecuteSql("INSERT INTO [" + tableName + "] ([FQRCode],[FEntryID]) VALUES('" + mingQRCode + "','" + EntryNo + "')");
        //    sql = string.Format("INSERT INTO [{0}] ([FQRCode],[FEntryID]) VALUES('{1}','{2}')", tableName, mingQRCode, EntryNo);
        //    return SqlHelper.ExecuteNonQuery(conn, sql);
        //}

        ///// <summary>
        ///// 更新主表数量
        ///// </summary>
        ///// <param name="billNo"></param>
        ///// <param name="EntryID"></param>
        ///// <returns></returnsT
        //public int UpdateICStockByActQty(string billNo, string EntryID)
        //{
        //    //return SqlHelper.ExecuteSql("UPDATE [icstock] SET [FActQty] = [FActQty] + 1 WHERE  [单据编号] = '" + billNo + "' and  [FEntryID] =" + EntryID);
        //    sql = string.Format("UPDATE [icstock] SET [FActQty] = [FActQty] + 1 WHERE  [单据编号] = '{0}' AND [FEntryID] = {1}", billNo, EntryID.ToString());
        //    return SqlHelper.ExecuteNonQuery(conn, sql);
        //}
        #endregion
    
    /// <summary>
    /// 更新主表数量
    /// </summary>
    /// <param name="BillNoEntryID">订单号/分录号</param>
    /// <param name="Qty">数量</param>
    /// <returns></returns>
    public int UpdateCloudQty(string BillNoEntryID, int Qty)
        {            
            string billNo = BillNoEntryID.Substring(0, 10);
            string entryID = int.Parse(BillNoEntryID.Substring(10, 4)).ToString();

            //return SqlHelper.ExecuteSql("UPDATE [icstock] SET [FActQty] = [FActQty] + 1 WHERE  [单据编号] = '" + billNo + "' and  [FEntryID] =" + EntryID);
            sql = string.Format("UPDATE [icstock] SET [FActQty] = [FActQty] + {0} WHERE  [单据编号] = '{1}' AND [FEntryID] = {2}" , Qty, billNo, entryID);
            return SqlHelper.ExecuteNonQuery(connALiClouds, sql);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateQRCode2AliCloud()
        {
            //取得所有的缓存数据
            DataTable dtAllData = new DataTable();
            dtAllData = AccessHelper.ExecuteDataTable(connAccess, "SELECT [FCodeID],[FQRCode], [FBillNoEntryId] FROM T_QRCODE");
            
            //得到唯一的单据行号
            string[] DistinctBillNo = GetDistinctBillNo(dtAllData, "FBillNoEntryId").Split(';');
            
            //对每一行进行处理
            foreach (string billNo in DistinctBillNo)
            {
                //过滤只留下一行数据
                DataTable dtFilteredData = FilterData(dtAllData, "FBillNoEntryId = '" + billNo + "'");

                //生成插入语句
                sql = BuildDetailSql(dtFilteredData);

                //写入云
                int ret = SqlHelper.ExecuteNonQuery(connALiClouds, sql);

                //如果返回值等于一行数据的个数，表示该行数据已经到云
                if (ret == dtFilteredData.Rows.Count)
                {
                    // 更新主表中已扫个数
                    string billNoEntryID = dtFilteredData.Rows[0]["FBillNoEntryId"].ToString();
                    int retUpdateQty = UpdateCloudQty(billNoEntryID, ret);
                    //更新成功
                    if (retUpdateQty > 0)
                    {
                        //删除ACCESS数据库中的该行数据
                        sql = string.Format("Delete from t_QRCode where FBillNoEntryId = '{0}'" , billNoEntryID);
                        int retInt = AccessHelper.ExecuteNonQuery(connAccess, sql);
                        if (retInt == ret)
                        {
                            //删除成功，则是上传成功
                            CustomDesktopAlert.H2("数据上传成功！");
                        }
                        else
                        {
                            //删除失败，则是上传失败
                            CustomDesktopAlert.H2("数据上传失败！");
                        }
                    }
                    else
                    {
                        //更新个数失败
                        CustomDesktopAlert.H2("更新主表失败！");
                    }                    
                }
                else
                {
                    CustomDesktopAlert.H2("保存数据出错！");
                }
            }


        }

        /// <summary>
        /// 过程用时测试
        /// </summary>
        private void ElapsedTest()
        {            
            /// Only for Test
            Stopwatch st = new Stopwatch();
            st.Start();
            string s = EncryptHelper.Decrypt("7zJ4H8PZhiZBVZE5AX03Xg==");
            st.Stop();
            CustomDesktopAlert.H2("耗时为：" + st.ElapsedMilliseconds + "毫秒");
            ///
        }

        /// <summary>
        /// 生成测试用数据
        /// </summary>
        /// <returns></returns>
        private DataTable BuildTestData()
        {
            DataTable retDataTable = new DataTable();
            retDataTable.Columns.Add("mingQRCode", Type.GetType("System.String"));
            retDataTable.Columns.Add("EntryID", System.Type.GetType("System.String"));

            for (int i = 0; i < 3; i++)
            {
                DataRow dr = retDataTable.NewRow();
                dr["mingQRCode"] = "180000206";
                dr["entryID"] = "QOUT0114170001";
                retDataTable.Rows.Add(dr);
            }

            return retDataTable;
        }

        /// <summary>
        /// 生成插入明细表的SQL语句
        /// </summary>
        /// <param name="dtFilteredData">数据源</param>
        /// <returns></returns>
        private string BuildDetailSql(DataTable dtFilteredData)
        {
            string retSql = "";
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dtFilteredData.Rows)
            {
                string tableName = dr["FQRCode"].ToString().Substring(0, 4);
                sb.Append("INSERT INTO [dbo].[t_QRCode" + tableName + "]([FQRCode],[FEntryID])");
                //for Test
                //sb.Append("INSERT INTO [dbo].[t_QRCode1800]([FQRCode],[FEntryID])");
                sb.Append(" VALUES ");
                sb.Append("('" + dr["FQRCode"] + "','" + dr["FBillNoEntryId"] + "');");
            }
            retSql = sb.ToString();
            retSql = retSql.Substring(0, retSql.Length - 1);
            return retSql;
        }

        /// <summary>
        /// 将唯一码保存到MS ACCESS 缓存
        /// </summary>
        /// <param name="mingQRCode"></param>
        /// <param name="billNo"></param>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public int InsertQRCode2Access(string mingQRCode, string billNo, string EntryID)
        {

            string tableName = "t_QRCode";
            string EntryNo = billNo + EntryID.PadLeft(4, '0');

            sql = string.Format("INSERT INTO [{0}] ([FQRCode],[FBillNoEntryID]) VALUES('{1}','{2}')", tableName, mingQRCode, EntryNo);
            int retInt = AccessHelper.ExecuteNonQuery(connAccess, sql);
            return retInt;
        }

        /// <summary>
        /// 得到唯一的单号列表
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="billNoFieldName">单号列的名字</param>
        /// <returns></returns>
        private string GetDistinctBillNo(DataTable dt, string billNoFieldName)
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

        #endregion
    }
}
