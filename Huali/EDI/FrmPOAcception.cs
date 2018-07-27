using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Ray.Framework.DBUtility;
using System;
using System.Data;
using System.Text;

namespace Huali.EDI
{
    public partial class FrmPOAcception : Office2007Form 
    {
        public FrmPOAcception()
        {
            InitializeComponent();
        }
        private static readonly string conn = SqlHelper.GetConnectionString("Kingdee");

        #region 事件
        /// <summary>
        /// 浏览数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            // 使用助记码
            string stockNames = "'CSW','CSW1','RET','EPD','JWI','JQU','JDA'";
            // 使用助记码2
            string stockName1 = "'JQU1','EPD1','JDA1','JWI1','CSW2'";

            string AlconNo = textBox1 .Text ;
            StringBuilder cmdCP = new StringBuilder();
            cmdCP.Append(" SELECT  POInStock.FHeadSelfP0341 as ORNUM,	'O' as ORGRP,	'CV' as ORORIN,	POInStock.FDate as ORCDAT,	'O' as ORSELID,	'O' as ORBUYID,	'O' as ORSUNO,	'O' as ORSNAM,	'O' as ORSAD1,	'O' as ORSAD2,	'O' as ORSAD3,	'O' as ORSAD4,	'O' as ORCITY,	'O' as OROCTR,	POInStockEntry.FEntrySelfP0386 as OROLIN,	t_ICItem .FHelpCode  as ORPRDC,	POInStockEntry.fQty as ORRQTY,	'EA' as ORUOM,	t_Stock.FName  as ORSROM  ");
            cmdCP.Append(" FROM POInStock ");
            cmdCP.Append(" inner join POInStockEntry on POInStock .FInterID = POInStockEntry .FInterID  ");
            cmdCP.Append(" inner join t_ICItem on t_ICItem.FItemID = POInStockEntry.FItemID  ");
            cmdCP.Append(" inner join t_Stock on t_Stock.FItemID = POInStockEntry.FStockID  ");
            cmdCP.Append(" WHERE FHeadSelfP0341 = '" + AlconNo + "'");
            cmdCP.Append(" AND t_Stock.FName =(" + stockNames + ") ");
            cmdCP.Append(" union all ");
            cmdCP.Append(" SELECT  POInStock.FHeadSelfP0341 as ORNUM,	'O' as ORGRP,	'CV' as ORORIN,	POInStock.FDate as ORCDAT,	'O' as ORSELID,	'O' as ORBUYID,	'O' as ORSUNO,	'O' as ORSNAM,	'O' as ORSAD1,	'O' as ORSAD2,	'O' as ORSAD3,	'O' as ORSAD4,	'O' as ORCITY,	'O' as OROCTR,	POInStockEntry.FEntrySelfP0386 as OROLIN,	t_ICItem .F_111  as ORPRDC,	POInStockEntry.fQty as ORRQTY,	'EA' as ORUOM,	t_Stock.FName  as ORSROM  ");
            cmdCP.Append(" FROM POInStock ");
            cmdCP.Append(" inner join POInStockEntry on POInStock .FInterID = POInStockEntry .FInterID  ");
            cmdCP.Append(" inner join t_ICItem on t_ICItem.FItemID = POInStockEntry.FItemID  ");
            cmdCP.Append(" inner join t_Stock on t_Stock.FItemID = POInStockEntry.FStockID  ");
            cmdCP.Append(" WHERE FHeadSelfP0341 = '" + AlconNo + "'");
            cmdCP.Append(" AND t_Stock.FName in(" + stockName1 + ") ");
            DataTable dt = SqlHelper.ExecuteDataTable(conn,cmdCP.ToString());
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 更新收到日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            string AlconNo = textBox1.Text;
            string arriveDate = DateTime.Now.ToShortDateString();
            StringBuilder PoAcception = new StringBuilder();
            PoAcception.Append("update POInStock set FHeadSelfP0342 = '" + arriveDate + "'" + " WHERE FHeadSelfP0341 = '" + AlconNo + "'");

            int retval = SqlHelper.ExecuteNonQuery(conn,PoAcception.ToString());
            if( retval > 0)
            {
                //MessageBox.Show("确认成功 " + retval + " 单！");
                CustomDesktopAlert.H2("确认成功 " + retval + " 单！");

            }
            else
            {
                //MessageBox.Show("确认失败！");
                CustomDesktopAlert.H2("确认失败！");
            }
        }
        #endregion

    }
}
