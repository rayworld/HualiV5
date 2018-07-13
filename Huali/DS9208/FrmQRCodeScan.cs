using DevComponents.DotNetBar;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System;
using System.Data;
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
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");

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
                    object obj = SqlHelper.ExecuteScalar(conn, sql);
                    int recCount = obj != null ? int.Parse(obj.ToString()) : 0;
                    if (recCount > 0)
                    {
                        //DataTable dtmaster = SqlHelper.ExcuteDataTable("select top 1 [日期],[购货单位],[发货仓库],[摘要] from icstock where [单据编号] ='" + billNo + "' and [FActQty] < [实发数量]");
                        sql = string.Format("SELECT TOP 1 [日期],[购货单位],[发货仓库],[摘要] FROM icstock WHERE [单据编号] ='{0}' AND [FActQty] < [实发数量]", billNo);
                        DataTable dtmaster = SqlHelper.ExecuteDataTable(conn, sql);
                        textBoxX2.Text = dtmaster.Rows[0][0].ToString();
                        textBoxX3.Text = dtmaster.Rows[0][1].ToString();
                        textBoxX4.Text = dtmaster.Rows[0][2].ToString();

                        //dt = SqlHelper.ExcuteDataTable("select [fEntryID] as 分录号,[产品名称],[批号],[实发数量] as 应发,[FActQty] as 实发  from icstock where [单据编号] ='" + billNo + "' and [FActQty] < [实发数量] order by fEntryID");
                        sql = string.Format("SELECT [fEntryID] AS 分录号,[产品名称],[批号],[实发数量] AS 应发,[FActQty] AS 实发  FROM icstock WHERE [单据编号] ='{0}' AND [FActQty] < [实发数量] ORDER BY fEntryID", billNo);
                        dt = SqlHelper.ExecuteDataTable(conn, sql);
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
                        Utils.H2("无数据，请检查单据编号的输入!");
                    }
                }
                else
                {
                    Utils.H2("请检查单据编号的输入!");
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
                        Utils.H2("二维码为空！");
                        return;
                    }

                    if (mingQRCode.Length != 9)
                    {
                        Utils.H2("二维码长度不正确！");
                        return;
                    }

                    if (IsNumber(mingQRCode) == false)
                    {
                        Utils.H2("二维码未能正确识别！");
                        return;
                    }

                    //单据编号和分录编号不为空
                    if (billNo == "" || entryID == "")
                    {
                        Utils.H2("请先输入出库单编号，选择明细分录！");
                        return;
                    }

                    //查重
                    int index = mingQRCodes.IndexOf(mingQRCode);
                    if (index > -1)
                    {
                        Utils.H2("此二维码录入重复！");
                        return;
                    }
                    mingQRCodes += mingQRCode + ";";

                    //写入T_QRCode
                    //billNo = billNo.Substring(0, 1) + billNo.Substring(4);
                    InsertQRCode2T_QRCode(mingQRCode, billNo, entryID);
                    //更新icstock
                    UpdateICStockByActQty(billNo, entryID);



                    //更新状态栏
                    currVal++;
                    dataGridViewX1.SelectedRows[0].Cells[5].Value = currVal;

                    if (currVal == maxVal)//此分录已经完成
                    {
                        dataGridViewX1.Rows.Remove(dataGridViewX1.SelectedRows[0]);
                        //此出库单已经全部录入完成
                        if (dataGridViewX1.Rows.Count == 0)
                        {
                            Utils.H2("此出库单已经全部录入完成！");
                        }
                        else//此分录已经全部录入完成
                        {
                            dataGridViewX1.Rows[0].Selected = true;
                            Utils.H2("此分录已经全部录入完成！");
                        }
                        //清空二维码录入记录
                        mingQRCodes = "";
                    }
                }
                else
                {
                    Utils.H2("二维码数量超过范围！");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mingQRCode"></param>
        /// <param name="billNo"></param>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public int InsertQRCode2T_QRCode(string mingQRCode, string billNo, string EntryID)
        {
            string tableName = "t_QRCode" + mingQRCode.Substring(0, 4);
            string EntryNo = billNo + EntryID.PadLeft(4, '0');
            //return SqlHelper.ExecuteSql("INSERT INTO [" + tableName + "] ([FQRCode],[FEntryID]) VALUES('" + mingQRCode + "','" + EntryNo + "')");
            sql = string.Format("INSERT INTO [{0}] ([FQRCode],[FEntryID]) VALUES('{1}','{2}')", tableName, mingQRCode, EntryNo);
            return SqlHelper.ExecuteNonQuery(conn, sql);
        }

        /// <summary>
        /// 更新主表数量
        /// </summary>
        /// <param name="billNo"></param>
        /// <param name="EntryID"></param>
        /// <returns></returnsT
        public int UpdateICStockByActQty(string billNo, string EntryID)
        {
            //return SqlHelper.ExecuteSql("UPDATE [icstock] SET [FActQty] = [FActQty] + 1 WHERE  [单据编号] = '" + billNo + "' and  [FEntryID] =" + EntryID);
            sql = string.Format("UPDATE [icstock] SET [FActQty] = [FActQty] + 1 WHERE  [单据编号] = '{0}' AND [FEntryID] = {1}" , billNo, EntryID.ToString());
            return SqlHelper.ExecuteNonQuery(conn, sql);
        }

        #endregion

    }
}
