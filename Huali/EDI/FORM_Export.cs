using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Ray.Framework.Config;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;

namespace Huali
{
    public partial class FORM_Export : Office2007Form
    {
        public FORM_Export()
        {
            InitializeComponent();
        }

        #region public Ver
        DataTable dt = new DataTable();
        // 使用助记码
        string stockNames = "'CSW','CSW1','RET','EPD','JWI','JQU','JDA'";
        // 使用助记码2
        string stockName1 = "'JQU1','EPD1','JDA1','JWI1','CSW2'";
        #endregion

        #region Event
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (System.DateTime.Now.ToShortTimeString() == textBox2.Text)
            {
                DoExport(System.DateTime.Now.ToShortDateString());
            }
        }

        private void FORM_Export_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DoExport(this.dateTimePicker1.Value.ToShortDateString());
        }
        #endregion

        #region private function
        private void DoExport(string OperateDate)
        {
            string expType = "";

            StringBuilder cmdCP = new StringBuilder();
            cmdCP.Append(" SELECT  POInStock.FHeadSelfP0341 as ORNUM,	'O' as ORGRP,	'O' as ORORIN,	POInStock.FDate as ORCDAT,	POInStock.FCheckDate as ORSELID,	'O' as ORBUYID,	'O' as ORSUNO,	'O' as ORSNAM,	'O' as ORSAD1,	'O' as ORSAD2,	'O' as ORSAD3,	'O' as ORSAD4,	'O' as ORCITY,	'O' as OROCTR,	POInStockEntry.FEntrySelfP0386 as OROLIN,	t_ICItem .FHelpCode  as ORPRDC,	POInStockEntry.fQty as ORRQTY,	'EA' as ORUOM,	SUBSTRING(t_Stock.FName,1,3)  as ORSROM  ");
            cmdCP.Append(" FROM POInStock ");
            cmdCP.Append(" inner join POInStockEntry on POInStock .FInterID = POInStockEntry .FInterID  ");
            cmdCP.Append(" inner join t_ICItem on t_ICItem.FItemID = POInStockEntry.FItemID  ");
            cmdCP.Append(" inner join t_Stock on t_Stock.FItemID = POInStockEntry.FStockID  ");
            cmdCP.Append(" WHERE FHeadSelfP0342 = '" + OperateDate + "'");
            cmdCP.Append(" AND t_Stock.FName in(" + stockNames + ") ");
            cmdCP.Append(" union all ");
            cmdCP.Append(" SELECT  POInStock.FHeadSelfP0341 as ORNUM,	'O' as ORGRP,	'O' as ORORIN,	POInStock.FDate as ORCDAT,	POInStock.FCheckDate as ORSELID,	'O' as ORBUYID,	'O' as ORSUNO,	'O' as ORSNAM,	'O' as ORSAD1,	'O' as ORSAD2,	'O' as ORSAD3,	'O' as ORSAD4,	'O' as ORCITY,	'O' as OROCTR,	POInStockEntry.FEntrySelfP0386 as OROLIN,	t_ICItem .F_111  as ORPRDC,	POInStockEntry.fQty as ORRQTY,	'EA' as ORUOM, SUBSTRING(t_Stock.FName,1,3)  as ORSROM  ");
            cmdCP.Append(" FROM POInStock ");
            cmdCP.Append(" inner join POInStockEntry on POInStock .FInterID = POInStockEntry .FInterID  ");
            cmdCP.Append(" inner join t_ICItem on t_ICItem.FItemID = POInStockEntry.FItemID  ");
            cmdCP.Append(" inner join t_Stock on t_Stock.FItemID = POInStockEntry.FStockID  ");
            cmdCP.Append(" WHERE FHeadSelfP0342 = '" + OperateDate + "'");
            cmdCP.Append(" AND t_Stock.FName in(" + stockName1 + ") ");

            StringBuilder cmdSM = new StringBuilder();
            cmdSM.Append(" select t_ICItem.FHelpCode  ,	SUBSTRING(t_Stock.FName,1,3) ,	ICStockBillEntry.FQty ,	1  as FTranType ,		t_Item_3005.FName ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID 	inner join t_Item_3005 on t_Item_3005.FItemID =  ICStockBill.FHeadSelfc0132 where 	FTranType = 40	and t_Stock.FName in(" + stockNames + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select 	t_ICItem.FHelpCode  ,	SUBSTRING(t_Stock.FName,1,3) ,	ICStockBillEntry.FQty ,	-1  as FTranType ,		t_Item_3005.FName ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID 	inner join t_Item_3005 on t_Item_3005.FItemID =  ICStockBill.FHeadSelfc0232 where 	FTranType = 43	and t_Stock.FName in(" + stockNames + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select 	t_ICItem.FHelpCode  ,	SUBSTRING(t_Stock.FName,1,3) ,	ICStockBillEntry.FQty ,	1  as FTranType ,		'W' ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID where 	FTranType = 41	and t_Stock.FName in(" + stockNames + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select 	t_ICItem.FHelpCode  ,	SUBSTRING(t_Stock.FName,1,3) ,	ICStockBillEntry.FQty ,	-1  as FTranType ,		'W' ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FSCStockID where 	FTranType = 41	and t_Stock.FName in(" + stockNames + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select t_ICItem.F_111  , SUBSTRING(t_Stock.FName,1,3), ICStockBillEntry.FQty ,	1  as FTranType ,		t_Item_3005.FName ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID 	inner join t_Item_3005 on t_Item_3005.FItemID =  ICStockBill.FHeadSelfc0132 where 	FTranType = 40	and t_Stock.FName in(" + stockName1 + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select t_ICItem.F_111  ,	SUBSTRING(t_Stock.FName,1,3), ICStockBillEntry.FQty ,	-1  as FTranType ,		t_Item_3005.FName ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID 	inner join t_Item_3005 on t_Item_3005.FItemID =  ICStockBill.FHeadSelfc0232 where 	FTranType = 43	and t_Stock.FName in(" + stockName1 + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select t_ICItem.F_111  ,	SUBSTRING(t_Stock.FName,1,3), ICStockBillEntry.FQty ,	1  as FTranType ,		'W' ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID where 	FTranType = 41	and t_Stock.FName in(" + stockName1 + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdSM.Append(" union all ");
            cmdSM.Append(" select t_ICItem.F_111  ,	SUBSTRING(t_Stock.FName,1,3), ICStockBillEntry.FQty ,	-1  as FTranType ,		'W' ,	ICStockBill.FDate,	ICStockBill.FBillNo from 	ICStockBill 	inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID 	inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry.FItemID 	inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FSCStockID where 	FTranType = 41	and t_Stock.FName in(" + stockName1 + ") and ICStockBill.FDate = '" + OperateDate + "'");

            StringBuilder cmdSB = new StringBuilder();
            cmdSB.Append("select t_ICItem.FHelpCode, SUBSTRING(t_Stock.FName,1,3)  , sum(ICInventory.FQty)  from ICInventory  ");
            cmdSB.Append(" inner join t_ICItem on t_ICItem.FItemID = ICInventory .FItemID  ");
            cmdSB.Append(" inner join t_Stock on t_Stock.FItemID = ICInventory.FStockID  ");
            cmdSB.Append(" where t_Stock.FName in(" + stockNames + ") ");
            cmdSB.Append(" group by t_ICItem.FHelpCode,t_Stock.FName ");
            cmdSB.Append(" union all ");
            cmdSB.Append("select t_ICItem.F_111,  SUBSTRING(t_Stock.FName,1,3), sum(ICInventory.FQty)  from ICInventory  ");
            cmdSB.Append(" inner join t_ICItem on t_ICItem.FItemID = ICInventory .FItemID  ");
            cmdSB.Append(" inner join t_Stock on t_Stock.FItemID = ICInventory.FStockID  ");
            cmdSB.Append(" where t_Stock.FName in(" + stockName1 + ") ");
            cmdSB.Append(" group by t_ICItem.F_111,t_Stock.FName ");

            StringBuilder cmdCO = new StringBuilder();
            cmdCO.Append(" select ICStockBill.frob, ICStockBill.fdate,ICStockBill.FBillNo,ICStockBillEntry .FEntryID,t_Organization.f_112 ,t_ICItem .FHelpCode,t_Item_3001.FName as OrderType,SUBSTRING(t_Stock.FName,1,3) ,abs(ICStockBillEntry .fqty),abs(ICStockBillEntry.FConsignPrice * 1000/1.17) as UnitPrice ,abs(ICStockBillEntry .fqty * ICStockBillEntry.FConsignPrice * 1000/1.17) as GrossAmount,ICStockBill.fheadselfb0939 as TransactionType,ICStockBill.FHeadSelfA9739 as ReasonCode,	ICSale .FBillNo ,ICStockBillEntry .FEntryID, abs(ICStockBillEntry .fqty * ICStockBillEntry.FConsignPrice * 1000/1.17*0.17) as TaxAmount, 1 as Mormal ");
            cmdCO.Append(" from ICStockBill ");
            cmdCO.Append(" inner join t_Organization on t_Organization .FItemID = ICStockBill .FSupplyID ");
            cmdCO.Append(" inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID ");
            cmdCO.Append(" inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry .FItemID ");
            cmdCO.Append(" inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID ");
            cmdCO.Append(" left join t_Item_3001 on t_Item_3001.FItemID = ICStockBill.FHeadSelfB0154 ");
            cmdCO.Append(" left join ICSale   on ICSale  .FInterID = ICStockBill.FRelateInvoiceID ");
            cmdCO.Append(" where ICStockBill.FTranType = 21 and t_Stock.FName in(" + stockNames + ") and  ICStockBill.FDate = '" + OperateDate + "'");
            cmdCO.Append(" UNION ALL ");
            cmdCO.Append(" select	ICStockBill.frob, 	ICStockBill.fdate, 	ICStockBill.FBillNo,	ICStockBillEntry .FEntryID,	t_Organization.f_112 ,	t_ICItem .FHelpCode,	t_Item_3001.FName  as OrderType,	SUBSTRING(t_Stock.FName,1,3) ,	abs(ICStockBillEntry .fqty),	 0 as UnitPrice  ,	0 as GrossAmount,	ICStockBill.fheadselfb0939 as TransactionType,	ICStockBill.FHeadSelfA9739  as ReasonCode,	ICSale .FBillNo ,	ICStockBillEntry .FEntryID, 0, 0");
            cmdCO.Append(" from ICStockBill ");
            cmdCO.Append(" inner join t_Organization on t_Organization .FItemID = ICStockBill .FSupplyID ");
            cmdCO.Append(" inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID ");
            cmdCO.Append(" inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry .FItemID ");
            cmdCO.Append(" inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID ");
            cmdCO.Append(" left join t_Item_3001 on t_Item_3001.FItemID = ICStockBill.FHeadSelfB0940 ");
            cmdCO.Append(" left join ICSale   on ICSale  .FInterID = ICStockBill.FRelateInvoiceID ");
            cmdCO.Append(" where ICStockBill.FTranType = 29 and t_Stock.FName in(" + stockNames + ") and ICStockBill.FDate = '" + OperateDate + "'");
            cmdCO.Append(" UNION ALL ");
            cmdCO.Append(" select ICStockBill.frob, ICStockBill.fdate,ICStockBill.FBillNo,ICStockBillEntry .FEntryID,t_Organization.f_112 ,t_ICItem .F_111,t_Item_3001.FName as OrderType,  SUBSTRING(t_Stock.FName,1,3), abs(ICStockBillEntry .fqty),abs(ICStockBillEntry.FConsignPrice * 1000/1.17) as UnitPrice ,abs(ICStockBillEntry .fqty * ICStockBillEntry.FConsignPrice * 1000/1.17) as GrossAmount,ICStockBill.fheadselfb0939 as TransactionType,ICStockBill.FHeadSelfA9739 as ReasonCode,	ICSale .FBillNo ,ICStockBillEntry .FEntryID, abs(ICStockBillEntry .fqty * ICStockBillEntry.FConsignPrice * 1000/1.17*0.17) as TaxAmount, 1 as Mormal ");
            cmdCO.Append(" from ICStockBill ");
            cmdCO.Append(" inner join t_Organization on t_Organization .FItemID = ICStockBill .FSupplyID ");
            cmdCO.Append(" inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID ");
            cmdCO.Append(" inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry .FItemID ");
            cmdCO.Append(" inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID ");
            cmdCO.Append(" left join t_Item_3001 on t_Item_3001.FItemID = ICStockBill.FHeadSelfB0154 ");
            cmdCO.Append(" left join ICSale   on ICSale  .FInterID = ICStockBill.FRelateInvoiceID ");
            cmdCO.Append(" where ICStockBill.FTranType = 21 and t_Stock.FName in(" + stockName1 + ") and  ICStockBill.FDate = '" + OperateDate + "'");
            cmdCO.Append(" UNION ALL ");
            cmdCO.Append(" select	ICStockBill.frob, 	ICStockBill.fdate, 	ICStockBill.FBillNo,	ICStockBillEntry .FEntryID,	t_Organization.f_112 ,	t_ICItem .F_111,	t_Item_3001.FName  as OrderType,  SUBSTRING(t_Stock.FName,1,3), abs(ICStockBillEntry .fqty),	 0 as UnitPrice  ,	0 as GrossAmount,	ICStockBill.fheadselfb0939 as TransactionType,	ICStockBill.FHeadSelfA9739  as ReasonCode,	ICSale .FBillNo ,	ICStockBillEntry .FEntryID, 0, 0");
            cmdCO.Append(" from ICStockBill ");
            cmdCO.Append(" inner join t_Organization on t_Organization .FItemID = ICStockBill .FSupplyID ");
            cmdCO.Append(" inner join ICStockBillEntry on ICStockBillEntry.FInterID = ICStockBill.FInterID ");
            cmdCO.Append(" inner join t_ICItem on t_ICItem.FItemID = ICStockBillEntry .FItemID ");
            cmdCO.Append(" inner join t_Stock on t_Stock.FItemID = ICStockBillEntry .FDCStockID ");
            cmdCO.Append(" left join t_Item_3001 on t_Item_3001.FItemID = ICStockBill.FHeadSelfB0940 ");
            cmdCO.Append(" left join ICSale   on ICSale  .FInterID = ICStockBill.FRelateInvoiceID ");
            cmdCO.Append(" where ICStockBill.FTranType = 29 and t_Stock.FName in(" + stockName1 + ") and ICStockBill.FDate = '" + OperateDate + "'");

            cmdCO.Append(" order by  ICStockBill.FBillNo ,ICStockBillEntry.FEntryID ");



            string path = TextBox1.Text;

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }


            expType = "CP"; //进货表

            QueryData(path, expType, cmdCP.ToString());


            expType = "SM"; //销售表

            QueryData(path, expType, cmdSM.ToString());

            expType = "SB"; // '库存

            QueryData(path, expType, cmdSB.ToString());

            expType = "CO"; //客户资料

            QueryData(path, expType, cmdCO.ToString());
        }


        private void QueryData(string path, string expType, string cmdSql)
        {
            if (!string.IsNullOrEmpty(cmdSql))
            {
                dt = SqlHelper.ExecuteDataTable(SqlHelper.GetConnectionString("Kingdee"),cmdSql.ToString());
                dataGridView1.DataSource = dt;
                this.dataGridView1.Refresh();
            }

            string fileName = path + "CNHUALI2D" + expType + getForamteDate("fileName") + ".txt";
            ExpKindeeData2Text(fileName, dt, expType);

            //.ToolStripStatusLabel1.Text = "数据导出已完成！";

            //}

        }

        private void ExpKindeeData2Text(string FileName, DataTable dt, string expType)
        {
            if (File.Exists(FileName) == true)
            {
                if (MessageBox.Show("文件已经存在！是否替换文件？", "系统信息", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(FileName);
                }
            }
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);


            //开始循环表格的内容
            switch (expType)
            {
                case "CP":
                    if (dt.Rows.Count > 0)
                    {
                        for (int cp = 0; cp < dt.Rows.Count; cp++)
                        {
                            m_streamWriter.Write("\"" + dt.Rows[cp][0].ToString() + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "CV" + "\",");
                            //m_streamWriter.Write("\"" + this.dateTimePicker1.Value.ToString("yyyyMMdd") + "\",");
                            m_streamWriter.Write("\"" + System.DateTime.Parse(dt.Rows[cp][4].ToString()).ToString("yyyyMMdd") + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[cp][14].ToString() + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[cp][15].ToString() + "\",");
                            m_streamWriter.Write("\"" + System.Math.Round(decimal.Parse(dt.Rows[cp][16].ToString()), 3).ToString() + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[cp][17].ToString() + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[cp][18].ToString() + "\"");
                            m_streamWriter.WriteLine();
                        }
                    }
                    break;
                case "CO":

                    //写头信息
                    string CORCID = "MSGHDR".PadRight(10);
                    string COLINE = "1".PadLeft(15, '0');
                    string COFDATCOFTIM = getForamteDate("fullDate");
                    string COSRCN = "CNHUALI".PadRight(10);
                    m_streamWriter.Write(CORCID + COLINE + COFDATCOFTIM + COSRCN);
                    m_streamWriter.WriteLine();


                    if (dt.Rows.Count > 0)
                    {
                        for (int co = 0; co < dt.Rows.Count; co++)
                        {
                            //Line 1
                            m_streamWriter.Write("MSGLIN".PadRight(10));
                            //Line 2
                            m_streamWriter.Write((co + 2).ToString().PadLeft(15, '0'));
                            //Line 3
                            m_streamWriter.Write(dt.Rows[co][0].ToString() == "1" ? "S" : "R");
                            //Line 4
                            m_streamWriter.Write(DateTime.Parse(dt.Rows[co][1].ToString()).ToString("yyyyMMdd"));
                            //Line 5
                            m_streamWriter.Write(DateTime.Parse(dt.Rows[co][1].ToString()).ToString("HHmmss"));
                            //Line 6
                            m_streamWriter.Write(dt.Rows[co][2].ToString().PadRight(10));
                            //Line 7
                            m_streamWriter.Write(dt.Rows[co][3].ToString().PadLeft(6, '0'));
                            //Line 8
                            m_streamWriter.Write(dt.Rows[co][4].ToString().PadRight(11));
                            //Line 9
                            m_streamWriter.Write(dt.Rows[co][5].ToString().PadRight(35));
                            //Line 10 & 11
                            //m_streamWriter.Write(dt.Rows[co][6].ToString());
                            //Line 11
                            switch (dt.Rows[co][6].ToString())
                            {
                                case "SI":
                                    m_streamWriter.Write("SI");
                                    m_streamWriter.Write("S");

                                    break;
                                case "SP":
                                    m_streamWriter.Write("SP");
                                    m_streamWriter.Write("S");
                                    break;
                                case "EI":
                                    m_streamWriter.Write("EI");
                                    m_streamWriter.Write("E");
                                    break;
                                case "EO":
                                    m_streamWriter.Write("EO");
                                    m_streamWriter.Write("E");
                                    break;
                                case "SO":
                                    m_streamWriter.Write("SO");
                                    m_streamWriter.Write("T");
                                    break;
                                default:
                                    m_streamWriter.Write("SR");
                                    m_streamWriter.Write("T");
                                    break;
                            }
                            //Line 12
                            m_streamWriter.Write(dt.Rows[co][7].ToString().PadRight(15));
                            //Line 13
                            m_streamWriter.Write(System.Math.Round(decimal.Parse(dt.Rows[co][8].ToString()), 0).ToString().PadLeft(12, '0'));
                            //Line 14
                            m_streamWriter.Write(dt.Rows[co][4].ToString() == "999000" ? "0".ToString().PadLeft(10, '0') : System.Math.Round(decimal.Parse(dt.Rows[co][9].ToString()), 0).ToString().PadLeft(10, '0'));
                            //Line 15
                            m_streamWriter.Write("RMB");
                            //Line 16
                            m_streamWriter.Write(dt.Rows[co][4].ToString() == "999000" ? "0".ToString().PadLeft(15, '0') : System.Math.Round(decimal.Parse(dt.Rows[co][10].ToString()), 0).ToString().PadLeft(15, '0'));
                            //Line 17
                            m_streamWriter.Write("".PadLeft(2, '0'));
                            //Line 18
                            m_streamWriter.Write("".PadLeft(15, '0'));
                            //Line 19
                            m_streamWriter.Write(dt.Rows[co][4].ToString() == "999000" ? "0".ToString().PadLeft(15, '0') : System.Math.Round(decimal.Parse(dt.Rows[co][15].ToString()), 0).ToString().PadLeft(15, '0'));
                            //Line 20 = line 19 + Line 16
                            m_streamWriter.Write(dt.Rows[co][4].ToString() == "999000" ? "0".ToString().PadLeft(15, '0') : System.Math.Round(decimal.Parse(dt.Rows[co][10].ToString()) + decimal.Parse(dt.Rows[co][15].ToString()), 0).ToString().PadLeft(15, '0'));
                            //Line 21 = line 19 + Line 16
                            m_streamWriter.Write(dt.Rows[co][4].ToString() == "999000" ? "0".ToString().PadLeft(15, '0') : System.Math.Round(decimal.Parse(dt.Rows[co][10].ToString()) + decimal.Parse(dt.Rows[co][15].ToString()), 0).ToString().PadLeft(15, '0'));
                            //Line 22
                            string ReasonCode = "";
                            if (dt.Rows[co][11].ToString() == "40393")
                            {
                                ReasonCode = "2000";
                            }
                            else if (dt.Rows[co][11].ToString() == "40394")
                            {
                                ReasonCode = "2480";
                            }
                            else
                            {
                                ReasonCode = "";
                            }
                            m_streamWriter.Write(dt.Rows[co][6].ToString() == "SO" && dt.Rows[co][16].ToString() == "1" ? "".PadRight(5) : ReasonCode.PadRight(5));
                            //Line 23
                            m_streamWriter.Write((dt.Rows[co][6].ToString() == "SAR" || dt.Rows[co][6].ToString() == "SO") && dt.Rows[co][16].ToString() == "1" ? "N" : "Y");
                            //Line 24
                            if (dt.Rows[co][0].ToString() == "-1")
                            {
                                switch (dt.Rows[co][6].ToString())
                                {
                                    case "EI":
                                        m_streamWriter.Write("EXR".PadRight(3));
                                        break;
                                    case "SI":
                                        m_streamWriter.Write("SMR".PadRight(3));
                                        break;
                                    default:
                                        m_streamWriter.Write(dt.Rows[co][6].ToString().PadRight(3));
                                        break;
                                }
                            }
                            else
                            {
                                m_streamWriter.Write("".PadRight(3));
                            }
                            //Line 25
                            m_streamWriter.Write("".PadRight(10));
                            //Line 26
                            m_streamWriter.Write("".ToString().PadLeft(6, '0'));
                            //Line 27
                            m_streamWriter.Write("".PadRight(10));
                            //Line 28
                            m_streamWriter.Write(dt.Rows[co][13].ToString().PadLeft(10, '0'));
                            //Line 29
                            m_streamWriter.Write(dt.Rows[co][13].ToString() != "" ? dt.Rows[co][14].ToString().PadLeft(6, '0') : "".PadLeft(6, '0'));
                            //Line 30
                            m_streamWriter.Write("".ToString().PadLeft(8, '0'));
                            //Line 31
                            m_streamWriter.Write("".ToString().PadLeft(6, '0'));
                            //Line 32
                            m_streamWriter.Write("".ToString().PadLeft(8, '0'));
                            //Line 33
                            m_streamWriter.Write("".ToString().PadLeft(6, '0'));
                            //Line 34
                            m_streamWriter.Write("".ToString().PadLeft(8, '0'));
                            //Line 35
                            m_streamWriter.Write("".ToString().PadLeft(6, '0'));
                            //Line 36
                            m_streamWriter.Write("".ToString().PadLeft(8, '0'));
                            //Line 37
                            m_streamWriter.Write("".ToString().PadLeft(6, '0'));
                            m_streamWriter.WriteLine();
                        }
                    }

                    //写脚信息
                    string CORCID1 = "MSGTRL".PadRight(10);
                    string COLINE1 = (dt.Rows.Count + 2).ToString().PadLeft(15, '0');
                    string COLTOT1 = (dt.Rows.Count + 2).ToString().PadLeft(15, '0');
                    string COSTOT1 = dt.Compute("count(" + dt.Columns[0].ColumnName + ")", dt.Columns[0].ColumnName + "= 1").ToString().PadLeft(15, '0');
                    string CORTOT1 = dt.Compute("count(" + dt.Columns[0].ColumnName + ")", dt.Columns[0].ColumnName + "= -1").ToString().PadLeft(15, '0');
                    string CODTOT1 = dt.Rows.Count.ToString().PadLeft(15, '0');
                    m_streamWriter.Write(CORCID1 + COLINE1 + COLTOT1 + COSTOT1 + CORTOT1 + CODTOT1);

                    break;
                case "SM":
                    if (dt.Rows.Count > 0)
                    {
                        for (int sm = 0; sm < dt.Rows.Count; sm++)
                        {
                            string moveSign = dt.Rows[sm][3].ToString().Trim() == "1" ? "+" : "-";
                            m_streamWriter.Write("\"" + dt.Rows[sm][0].ToString() + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[sm][1].ToString() + "\",");
                            m_streamWriter.Write("\"" + System.Decimal.Round(decimal.Parse(dt.Rows[sm][2].ToString()), 3) + "\",");
                            m_streamWriter.Write("\"" + moveSign + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[sm][4].ToString() + "\",");
                            m_streamWriter.Write("\"" + DateTime.Parse(dt.Rows[sm][5].ToString()).ToString("yyyyMMdd") + "\",");
                            m_streamWriter.Write("\"" + DateTime.Parse(dt.Rows[sm][5].ToString()).ToString("HHmmss") + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[sm][6].ToString() + "\"");
                            m_streamWriter.WriteLine();
                        }
                    }
                    break;
                case "SB":
                    if (dt.Rows.Count > 0)
                    {
                        for (int sb = 0; sb < dt.Rows.Count; sb++)
                        {
                            m_streamWriter.Write("\"" + dt.Rows[sb][0].ToString() + "\",");
                            m_streamWriter.Write("\"" + dt.Rows[sb][1].ToString() + "\",");
                            m_streamWriter.Write("\"" + System.Decimal.Round(decimal.Parse(dt.Rows[sb][2].ToString()), 3) + "\",");
                            m_streamWriter.Write("\"" + DateTime.Now.ToString("yyyyMMdd") + "\",");
                            m_streamWriter.Write("\"" + DateTime.Now.ToString("HHmmss") + "\",");
                            m_streamWriter.Write("\"" + "\"");
                            m_streamWriter.WriteLine();
                        }
                    }
                    break;
                default:
                    break;

            }

            m_streamWriter.Flush();
            m_streamWriter.Close();
            fs.Close();
        }

        private string getForamteDate(string dateType)
        {
            string retVal;
            switch (dateType)
            {
                case "fileName":
                    retVal = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                case "fullDate":
                    retVal = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    break;
                default:
                    retVal = "";
                    break;
            }
            return retVal;

        }
        #endregion

    }
}
