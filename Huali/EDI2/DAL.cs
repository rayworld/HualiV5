using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Ray.Framework.DBUtility;
using Huali.EDI2.Models;

namespace Huali.EDI2.DAL
{
    #region SEOutStock
    /// <summary>
    /// 数据访问类:SEOutStock
    /// </summary>
    public partial class SEOutStock
    {
        string sql = "";
        private static readonly string conn = SqlHelper.GetConnectionString("Kingdee");


        public SEOutStock()
        { }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool InsertBill(Huali.EDI2.Models.SEOutStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SEOutStock(");
            strSql.Append("FBrNo,FInterID,FBillNo,FTranType,FSalType,FCustID,FDate,FStockID,FAdd,FNote,FEmpID,FCheckerID,FBillerID,FManagerID,FClosed,FInvoiceClosed,FBClosed,FDeptID,FSettleID,FTranStatus,FExchangeRate,FCurrencyID,FStatus,FCancellation,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FRelateBrID,FCheckDate,FExplanation,FFetchAdd,FSelTranType,FChildren,FBrID,FAreaPS,FPOOrdBillNo,FManageType,FExchangeRateType,FCustAddress,FPrintCount,FHeadSelfS0238,FHeadSelfS0239,FHeadSelfS0240,FHeadSelfS1241,FHeadSelfS1242,FHeadSelfS0241,FHeadSelfS0244,FHeadSelfS1244,FHeadSelfS1243,FHeadSelfS0245,FHeadSelfS1245,FHeadSelfS0247,FHeadSelfS1246)");
            strSql.Append(" values (");
            strSql.Append("@FBrNo,@FInterID,@FBillNo,@FTranType,@FSalType,@FCustID,@FDate,@FStockID,@FAdd,@FNote,@FEmpID,@FCheckerID,@FBillerID,@FManagerID,@FClosed,@FInvoiceClosed,@FBClosed,@FDeptID,@FSettleID,@FTranStatus,@FExchangeRate,@FCurrencyID,@FStatus,@FCancellation,@FMultiCheckLevel1,@FMultiCheckLevel2,@FMultiCheckLevel3,@FMultiCheckLevel4,@FMultiCheckLevel5,@FMultiCheckLevel6,@FMultiCheckDate1,@FMultiCheckDate2,@FMultiCheckDate3,@FMultiCheckDate4,@FMultiCheckDate5,@FMultiCheckDate6,@FCurCheckLevel,@FRelateBrID,@FCheckDate,@FExplanation,@FFetchAdd,@FSelTranType,@FChildren,@FBrID,@FAreaPS,@FPOOrdBillNo,@FManageType,@FExchangeRateType,@FCustAddress,@FPrintCount,@FHeadSelfS0238,@FHeadSelfS0239,@FHeadSelfS0240,@FHeadSelfS1241,@FHeadSelfS1242,@FHeadSelfS0241,@FHeadSelfS0244,@FHeadSelfS1244,@FHeadSelfS1243,@FHeadSelfS0245,@FHeadSelfS1245,@FHeadSelfS0247,@FHeadSelfS1246)");
            SqlParameter[] parameters = {
					new SqlParameter("@FBrNo", SqlDbType.VarChar,10),
					new SqlParameter("@FInterID", SqlDbType.Int,4),
					new SqlParameter("@FBillNo", SqlDbType.NVarChar,255),
					new SqlParameter("@FTranType", SqlDbType.SmallInt,2),
					new SqlParameter("@FSalType", SqlDbType.Int,4),
					new SqlParameter("@FCustID", SqlDbType.Int,4),
					new SqlParameter("@FDate", SqlDbType.DateTime),
					new SqlParameter("@FStockID", SqlDbType.Int,4),
					new SqlParameter("@FAdd", SqlDbType.Char,255),
					new SqlParameter("@FNote", SqlDbType.Char,255),
					new SqlParameter("@FEmpID", SqlDbType.Int,4),
					new SqlParameter("@FCheckerID", SqlDbType.Int,4),
					new SqlParameter("@FBillerID", SqlDbType.Int,4),
					new SqlParameter("@FManagerID", SqlDbType.Int,4),
					new SqlParameter("@FClosed", SqlDbType.Int,4),
					new SqlParameter("@FInvoiceClosed", SqlDbType.SmallInt,2),
					new SqlParameter("@FBClosed", SqlDbType.SmallInt,2),
					new SqlParameter("@FDeptID", SqlDbType.Int,4),
					new SqlParameter("@FSettleID", SqlDbType.Int,4),
					new SqlParameter("@FTranStatus", SqlDbType.Int,4),
					new SqlParameter("@FExchangeRate", SqlDbType.Float,8),
					new SqlParameter("@FCurrencyID", SqlDbType.Int,4),
					new SqlParameter("@FStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@FCancellation", SqlDbType.Bit,1),
					new SqlParameter("@FMultiCheckLevel1", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckLevel2", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckLevel3", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckLevel4", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckLevel5", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckLevel6", SqlDbType.Int,4),
					new SqlParameter("@FMultiCheckDate1", SqlDbType.DateTime),
					new SqlParameter("@FMultiCheckDate2", SqlDbType.DateTime),
					new SqlParameter("@FMultiCheckDate3", SqlDbType.DateTime),
					new SqlParameter("@FMultiCheckDate4", SqlDbType.DateTime),
					new SqlParameter("@FMultiCheckDate5", SqlDbType.DateTime),
					new SqlParameter("@FMultiCheckDate6", SqlDbType.DateTime),
					new SqlParameter("@FCurCheckLevel", SqlDbType.Int,4),
					new SqlParameter("@FRelateBrID", SqlDbType.Int,4),
					new SqlParameter("@FCheckDate", SqlDbType.DateTime),
					new SqlParameter("@FExplanation", SqlDbType.NVarChar,255),
					new SqlParameter("@FFetchAdd", SqlDbType.NVarChar,255),
					new SqlParameter("@FSelTranType", SqlDbType.Int,4),
					new SqlParameter("@FChildren", SqlDbType.Int,4),
					new SqlParameter("@FBrID", SqlDbType.Int,4),
					new SqlParameter("@FAreaPS", SqlDbType.Int,4),
					new SqlParameter("@FPOOrdBillNo", SqlDbType.NVarChar,255),
					new SqlParameter("@FManageType", SqlDbType.Int,4),
					new SqlParameter("@FExchangeRateType", SqlDbType.Int,4),
					new SqlParameter("@FCustAddress", SqlDbType.Int,4),
					new SqlParameter("@FPrintCount", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0238", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0239", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0240", SqlDbType.VarChar,255),
					new SqlParameter("@FHeadSelfS1241", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS1242", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0241", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0244", SqlDbType.VarChar,255),
					new SqlParameter("@FHeadSelfS1244", SqlDbType.VarChar,255),
					new SqlParameter("@FHeadSelfS1243", SqlDbType.Int,4),
					new SqlParameter("@FHeadSelfS0245", SqlDbType.DateTime),
					new SqlParameter("@FHeadSelfS1245", SqlDbType.DateTime),
					new SqlParameter("@FHeadSelfS0247", SqlDbType.VarChar,255),
					new SqlParameter("@FHeadSelfS1246", SqlDbType.VarChar,255)};
            parameters[0].Value = model.FBrNo;
            parameters[1].Value = model.FInterID;
            parameters[2].Value = model.FBillNo;
            parameters[3].Value = model.FTranType;
            parameters[4].Value = model.FSalType;
            parameters[5].Value = model.FCustID;
            parameters[6].Value = model.FDate;
            parameters[7].Value = DBNull.Value;
            parameters[8].Value = DBNull.Value;
            parameters[9].Value = DBNull.Value;
            parameters[10].Value = model.FEmpID;
            parameters[11].Value = DBNull.Value;
            parameters[12].Value = model.FBillerID;
            parameters[13].Value = model.FManagerID;
            parameters[14].Value = model.FClosed;
            parameters[15].Value = model.FInvoiceClosed;
            parameters[16].Value = model.FBClosed;
            parameters[17].Value = model.FDeptID;
            parameters[18].Value = model.FSettleID;
            parameters[19].Value = model.FTranStatus;
            parameters[20].Value = model.FExchangeRate;
            parameters[21].Value = model.FCurrencyID;
            parameters[22].Value = model.FStatus;
            parameters[23].Value = model.FCancellation;
            parameters[24].Value = DBNull.Value;
            parameters[25].Value = DBNull.Value;
            parameters[26].Value = DBNull.Value;
            parameters[27].Value = DBNull.Value;
            parameters[28].Value = DBNull.Value;
            parameters[29].Value = DBNull.Value;
            parameters[30].Value = DBNull.Value;
            parameters[31].Value = DBNull.Value;
            parameters[32].Value = DBNull.Value;
            parameters[33].Value = DBNull.Value;
            parameters[34].Value = DBNull.Value;
            parameters[35].Value = DBNull.Value;
            parameters[36].Value = DBNull.Value;
            parameters[37].Value = model.FRelateBrID;
            parameters[38].Value = DBNull.Value;
            parameters[39].Value = model.FExplanation;
            parameters[40].Value = model.FFetchAdd;
            parameters[41].Value = model.FSelTranType;
            parameters[42].Value = model.FChildren;
            parameters[43].Value = DBNull.Value;
            parameters[44].Value = model.FAreaPS;
            parameters[45].Value = DBNull.Value;
            parameters[46].Value = model.FManageType;
            parameters[47].Value = model.FExchangeRateType;
            parameters[48].Value = DBNull.Value;
            parameters[49].Value = model.FPrintCount;
            if (model.FHeadSelfS0238 != null) 
            {
                parameters[50].Value = model.FHeadSelfS0238;
            }
            else
            {
                parameters[50].Value = DBNull.Value;
            }
            //parameters[50].Value = model.FHeadSelfS0238 == null ? DBNull.Value : model.FHeadSelfS0238;
            parameters[51].Value = model.FHeadSelfS0239;
            parameters[52].Value = model.FHeadSelfS0240;
            parameters[53].Value = DBNull.Value;
            parameters[54].Value = DBNull.Value;
            parameters[55].Value = model.FHeadSelfS0241;
            parameters[56].Value = model.FHeadSelfS0244;
            parameters[57].Value = DBNull.Value;
            parameters[58].Value = DBNull.Value;
            parameters[59].Value = model.FHeadSelfS0245;
            parameters[60].Value = DBNull.Value;
            parameters[61].Value = model.FHeadSelfS0247;
            parameters[62].Value = DBNull.Value;

            int rows = SqlHelper.ExecuteNonQuery(conn, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 取得最大收料单单据编号
        /// 单据类型,这里主要区分是不是导入，导入的数据单据以DR开头
        /// </summary>
        /// <returns></returns>
        public string GetMaxFBillNo()
        {
            sql = string.Format("SELECT MAX(FBillNo) FROM SEOutStock WHERE FBillNo LIKE 'DROut%'");
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            string currBillNo = "";
            currBillNo = obj.ToString() == "" ? "DROut000000" : obj.ToString();

            return "DROut" + (int.Parse(currBillNo.Substring(5)) + 1).ToString().PadLeft(6, '0');
        }

        /// <summary>
        /// 取得最大单据编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxFInterID()
        {
            sql = string.Format("UPDATE ICMaxNum SET FMaxNum = FMaxNum + 1 WHERE FTableName = 'SEOutStock'");
            if (SqlHelper.ExecuteNonQuery(conn,sql) > 0)
            {
                sql = "SELECT FMaxNum FROM ICMaxNum WHERE FTableName = 'SEOutStock'";
                object obj = SqlHelper.ExecuteScalar(conn, sql);
                return obj != null ? int.Parse(obj.ToString()) : 0;
            }
            return 0;
        }


        #endregion

    }
    #endregion

    #region SEOutStockEntry

    /// <summary>
    /// 数据访问类:SEOutStockEntry
    /// </summary>
    public partial class SEOutStockEntry
    {
        private static readonly string conn = SqlHelper.GetConnectionString("Kingdee");

        public SEOutStockEntry()
        { }
        #region  BasicMethod

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertBillEntry(Huali.EDI2.Models.SEOutStockEntry model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SEOutStockEntry(");
            strSql.Append("FBrNo,FInterID,FEntryID,FItemID,FQty,FCommitQty,FPrice,FAmount,FOrderInterID,FDate,FNote,FInvoiceQty,FBCommitQty,FUnitID,FAuxBCommitQty,FAuxCommitQty,FAuxInvoiceQty,FAuxPrice,FAuxQty,FSourceEntryID,FMapNumber,FMapName,FAuxPropID,FBatchNo,FCheckDate,FExplanation,FFetchAdd,FFetchDate,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FSecCoefficient,FSecQty,FSecCommitQty,FSourceTranType,FSourceInterId,FSourceBillNo,FContractInterID,FContractEntryID,FContractBillNo,FOrderEntryID,FOrderBillNo,FStockID,FBackQty,FAuxBackQty,FSecBackQty,FStdAmount,FPlanMode,FMTONo,FStockQty,FAuxStockQty,FSecStockQty,FSecInvoiceQty,FDiffQtyClosed,FAuxStockBillQty,FStockBillQty,FEntrySelfS0251,FEntrySelfS0252,FEntrySelfS0253,FEntrySelfS1234,FEntrySelfS1235,FEntrySelfS0254,FEntrySelfS1236)");
            strSql.Append(" values (");
            strSql.Append("@FBrNo,@FInterID,@FEntryID,@FItemID,@FQty,@FCommitQty,@FPrice,@FAmount,@FOrderInterID,@FDate,@FNote,@FInvoiceQty,@FBCommitQty,@FUnitID,@FAuxBCommitQty,@FAuxCommitQty,@FAuxInvoiceQty,@FAuxPrice,@FAuxQty,@FSourceEntryID,@FMapNumber,@FMapName,@FAuxPropID,@FBatchNo,@FCheckDate,@FExplanation,@FFetchAdd,@FFetchDate,@FMultiCheckDate1,@FMultiCheckDate2,@FMultiCheckDate3,@FMultiCheckDate4,@FMultiCheckDate5,@FMultiCheckDate6,@FSecCoefficient,@FSecQty,@FSecCommitQty,@FSourceTranType,@FSourceInterId,@FSourceBillNo,@FContractInterID,@FContractEntryID,@FContractBillNo,@FOrderEntryID,@FOrderBillNo,@FStockID,@FBackQty,@FAuxBackQty,@FSecBackQty,@FStdAmount,@FPlanMode,@FMTONo,@FStockQty,@FAuxStockQty,@FSecStockQty,@FSecInvoiceQty,@FDiffQtyClosed,@FAuxStockBillQty,@FStockBillQty,@FEntrySelfS0251,@FEntrySelfS0252,@FEntrySelfS0253,@FEntrySelfS1234,@FEntrySelfS1235,@FEntrySelfS0254,@FEntrySelfS1236)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@FBrNo", SqlDbType.VarChar,10),
                    new SqlParameter("@FInterID", SqlDbType.Int,4),
                    new SqlParameter("@FEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FItemID", SqlDbType.Int,4),
                    new SqlParameter("@FQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FOrderInterID", SqlDbType.VarChar,30),
                    new SqlParameter("@FDate", SqlDbType.DateTime),
                    new SqlParameter("@FNote", SqlDbType.Char,255),
                    new SqlParameter("@FInvoiceQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FBCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FUnitID", SqlDbType.Int,4),
                    new SqlParameter("@FAuxBCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxInvoiceQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSourceEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FMapNumber", SqlDbType.VarChar,80),
                    new SqlParameter("@FMapName", SqlDbType.NVarChar,256),
                    new SqlParameter("@FAuxPropID", SqlDbType.Int,4),
                    new SqlParameter("@FBatchNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FCheckDate", SqlDbType.DateTime),
                    new SqlParameter("@FExplanation", SqlDbType.NVarChar,255),
                    new SqlParameter("@FFetchAdd", SqlDbType.NVarChar,255),
                    new SqlParameter("@FFetchDate", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate1", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate2", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate3", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate4", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate5", SqlDbType.DateTime),
                    new SqlParameter("@FMultiCheckDate6", SqlDbType.DateTime),
                    new SqlParameter("@FSecCoefficient", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSourceTranType", SqlDbType.Int,4),
                    new SqlParameter("@FSourceInterId", SqlDbType.Int,4),
                    new SqlParameter("@FSourceBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FContractInterID", SqlDbType.Int,4),
                    new SqlParameter("@FContractEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FContractBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FOrderEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FOrderBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FStockID", SqlDbType.Int,4),
                    new SqlParameter("@FBackQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxBackQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecBackQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FStdAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FPlanMode", SqlDbType.Int,4),
                    new SqlParameter("@FMTONo", SqlDbType.NVarChar,50),
                    new SqlParameter("@FStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecInvoiceQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FDiffQtyClosed", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxStockBillQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FStockBillQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FEntrySelfS0251", SqlDbType.Int,4),
                    new SqlParameter("@FEntrySelfS0252", SqlDbType.Int,4),
                    new SqlParameter("@FEntrySelfS0253", SqlDbType.Int,4),
                    new SqlParameter("@FEntrySelfS1234", SqlDbType.Int,4),
                    new SqlParameter("@FEntrySelfS1235", SqlDbType.Int,4),
                    new SqlParameter("@FEntrySelfS0254", SqlDbType.VarChar,255),
                    new SqlParameter("@FEntrySelfS1236", SqlDbType.VarChar,255)};
            parameters[0].Value = model.FBrNo;
            parameters[1].Value = model.FInterID;
            parameters[2].Value = model.FEntryID;
            parameters[3].Value = model.FItemID;
            parameters[4].Value = model.FQty;
            parameters[5].Value = model.FCommitQty;
            parameters[6].Value = model.FPrice;
            parameters[7].Value = model.FAmount;
            parameters[8].Value = model.FOrderInterID;
            //parameters[9].Value = model.FDate;
            parameters[9].Value = DBNull.Value;
            parameters[10].Value = model.FNote;
            parameters[11].Value = model.FInvoiceQty;
            parameters[12].Value = model.FBCommitQty;
            parameters[13].Value = model.FUnitID;
            parameters[14].Value = model.FAuxBCommitQty;
            parameters[15].Value = model.FAuxCommitQty;
            parameters[16].Value = model.FAuxInvoiceQty;
            parameters[17].Value = model.FAuxPrice;
            parameters[18].Value = model.FAuxQty;
            parameters[19].Value = model.FSourceEntryID;
            parameters[20].Value = model.FMapNumber;
            parameters[21].Value = model.FMapName;
            parameters[22].Value = model.FAuxPropID;
            parameters[23].Value = model.FBatchNo;
            //parameters[24].Value = model.FCheckDate;
            parameters[24].Value = DBNull.Value;
            parameters[25].Value = model.FExplanation;
            parameters[26].Value = model.FFetchAdd;
            parameters[27].Value = model.FFetchDate;
            //parameters[28].Value = model.FMultiCheckDate1;
            //parameters[29].Value = model.FMultiCheckDate2;
            //parameters[30].Value = model.FMultiCheckDate3;
            //parameters[31].Value = model.FMultiCheckDate4;
            //parameters[32].Value = model.FMultiCheckDate5;
            parameters[33].Value = DBNull.Value;
            parameters[28].Value = DBNull.Value;
            parameters[29].Value = DBNull.Value;
            parameters[30].Value = DBNull.Value;
            parameters[31].Value = DBNull.Value;
            parameters[32].Value = DBNull.Value;
            parameters[33].Value = DBNull.Value;
            parameters[34].Value = model.FSecCoefficient;
            parameters[35].Value = model.FSecQty;
            parameters[36].Value = model.FSecCommitQty;
            parameters[37].Value = model.FSourceTranType;
            parameters[38].Value = model.FSourceInterId;
            parameters[39].Value = model.FSourceBillNo;
            parameters[40].Value = model.FContractInterID;
            parameters[41].Value = model.FContractEntryID;
            parameters[42].Value = model.FContractBillNo;
            parameters[43].Value = model.FOrderEntryID;
            parameters[44].Value = model.FOrderBillNo;
            parameters[45].Value = model.FStockID;
            parameters[46].Value = model.FBackQty;
            parameters[47].Value = model.FAuxBackQty;
            parameters[48].Value = model.FSecBackQty;
            parameters[49].Value = model.FStdAmount;
            parameters[50].Value = model.FPlanMode;
            parameters[51].Value = model.FMTONo;
            parameters[52].Value = model.FStockQty;
            parameters[53].Value = model.FAuxStockQty;
            parameters[54].Value = model.FSecStockQty;
            parameters[55].Value = model.FSecInvoiceQty;
            parameters[56].Value = model.FDiffQtyClosed;
            parameters[57].Value = model.FAuxStockBillQty;
            parameters[58].Value = model.FStockBillQty;
            //parameters[59].Value = model.FEntrySelfS0251;
            parameters[59].Value = DBNull.Value;
            //parameters[60].Value = model.FEntrySelfS0252;
            if (model.FEntrySelfS0252 == 0)
            {
                parameters[60].Value = DBNull.Value;
            }
            else
            {
                parameters[60].Value = model.FEntrySelfS0252;
            }
            parameters[61].Value = model.FEntrySelfS0253;
            //parameters[62].Value = model.FEntrySelfS1234;
            //parameters[63].Value = model.FEntrySelfS1235;
            parameters[62].Value = DBNull.Value;
            parameters[63].Value = DBNull.Value;
            parameters[64].Value = model.FEntrySelfS0254;
            //parameters[65].Value = model.FEntrySelfS1236;
            parameters[65].Value = DBNull.Value;

            int rows = SqlHelper.ExecuteNonQuery(conn, strSql.ToString(), parameters);
            if (rows > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 促销类别
        /// </summary>
        /// <param name="fNumber">产品代码前4位</param>
        /// <param name="fName">近视光度</param>
        /// <returns></returns>
        public int GetInterIDByFName(string fName)
        {
            string sql = string.Format("select FInterID from t_SubMessage where FName = '{0}'", fName);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }



        #endregion  ExtensionMethod
    }
    #endregion

    #region t_ICItem

	/// <summary>
	/// 数据访问类:t_ICItem
	/// </summary>
	public partial class T_ICItem
	{
        private static readonly string conn = SqlHelper.GetConnectionString("Kingdee");

        public T_ICItem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FARAcctID,FBrNo,FDeleted,FForSale,FHelpCode,FItemID,FModel,FModifyTime,FName,FNumber,FOmortize,FOmortizeScale,FOrderMethod,FOrderPrice,FParentID,FPerWastage,FPlanClass,FPlanPriceMethod,FPriceFixingType,FRP,FSalePriceFixingType,FShortNumber,FStaCost,FTopID,FAlias,FApproveNo,FAuxClassID,FDefaultLoc,FDefaultReadyLoc,FEquipmentNum,FErpClsID,FFullName,FHighLimit,FIsEquipment,FIsSparePart,FLowLimit,FOrderUnitID,FPreDeadLine,FProductUnitID,FQtyDecimal,FSaleUnitID,FSecCoefficient,FSecInv,FSecUnitDecimal,FSecUnitID,FSerialClassID,FSource,FSPID,FSPIDReady,FStoreUnitID,FTypeID,FUnitGroupID,FUnitID,FUseState,FABCCls,FAcctID,FAdminAcctID,FAPAcctID,FBatchManager,FBatchQty,FBeforeExpire,FBookPlan,FCBBmStandardID,FCBRestore,FCheckCycle,FCheckCycUnit,FClass,FCostAcctID,FCostDiffRate,FCostProject,FDaysPer,FDepartment,FGoodSpec,FISKFPeriod,FIsSale,FIsSnManage,FIsSpecialTax,FKFPeriod,FLastCheckDate,FNote,FOIHighLimit,FOILowLimit,FOrderRector,FPickHighLimit,FPickLowLimit,FPlanPrice,FPOHghPrcMnyType,FPOHighPrice,FPriceDecimal,FProfitRate,FSaleAcctID,FSalePrice,FSaleTaxAcctID,FSOHighLimit,FSOLowLimit,FSOLowPrc,FSOLowPrcMnyType,FStockPrice,FStockTime,FTaxRate,FTrack,FWWHghPrc,FWWHghPrcMnyType,FBackFlushSPID,FBackFlushStockID,FBatChangeEconomy,FBatchAppendQty,FBatchSplit,FBatchSplitDays,FBatFixEconomy,FCharSourceItemID,FContainerName,FCtrlStraregy,FCtrlType,FCUUnitID,FDailyConsume,FDefaultRoutingID,FDefaultWorkTypeID,FFixLeadTime,FInHighLimit,FInLowLimit,FIsBackFlush,FIsCharSourceItem,FIsFixedReOrder,FKanBanCapability,FLeadTime,FLowestBomCode,FMRPCon,FMRPOrder,FOrderInterVal,FOrderPoint,FOrderTrategy,FPlanMode,FPlanner,FPlanPoint,FPlanTrategy,FProductPrincipal,FPutInteger,FQtyMax,FQtyMin,FRequirePoint,FTotalTQQ,F_101,F_102,F_103,F_104,F_105,F_106,F_107,F_108,F_109,F_110,F_111,FChartNumber,FCubicMeasure,FGrossWeight,FHeight,FIsFix,FIsKeyItem,FLength,FMakeFile,FMaund,FNetWeight,FSize,FStartService,FTtermOfService,FTtermOfUsefulTime,FVersion,FWidth,FCAVAcctID,FCBAppendProject,FCBAppendRate,FCBRouting,FChgFeeRate,FCostBomID,FMCVAcctID,FOutMachFee,FOutMachFeeProject,FPCVAcctID,FPieceRate,FPIVAcctID,FPOVAcctID,FSLAcctID,FStandardCost,FStandardManHour,FStdBatchQty,FStdFixFeeRate,FStdPayRate,FIdentifier,FInspectionLevel,FInspectionProject,FIsListControl,FOtherChkMde,FProChkMde,FSampStdCritical,FSampStdSlight,FSampStdStrict,FSOChkMde,FStkChkAlrm,FStkChkMde,FStkChkPrd,FWthDrwChkMde,FWWChkMde,FConsumeTaxRate,FCubageDecimal,FExportRate,FFirstUnit,FFirstUnitRate,FHSNumber,FImpostTaxRate,FIsManage,FLenDecimal,FManageType,FModelEn,FNameEn,FPackType,FSecondUnit,FSecondUnitRate,FWeightDecimal ");
			strSql.Append(" FROM t_ICItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.ExecuteDataTable(conn, strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FARAcctID,FBrNo,FDeleted,FForSale,FHelpCode,FItemID,FModel,FModifyTime,FName,FNumber,FOmortize,FOmortizeScale,FOrderMethod,FOrderPrice,FParentID,FPerWastage,FPlanClass,FPlanPriceMethod,FPriceFixingType,FRP,FSalePriceFixingType,FShortNumber,FStaCost,FTopID,FAlias,FApproveNo,FAuxClassID,FDefaultLoc,FDefaultReadyLoc,FEquipmentNum,FErpClsID,FFullName,FHighLimit,FIsEquipment,FIsSparePart,FLowLimit,FOrderUnitID,FPreDeadLine,FProductUnitID,FQtyDecimal,FSaleUnitID,FSecCoefficient,FSecInv,FSecUnitDecimal,FSecUnitID,FSerialClassID,FSource,FSPID,FSPIDReady,FStoreUnitID,FTypeID,FUnitGroupID,FUnitID,FUseState,FABCCls,FAcctID,FAdminAcctID,FAPAcctID,FBatchManager,FBatchQty,FBeforeExpire,FBookPlan,FCBBmStandardID,FCBRestore,FCheckCycle,FCheckCycUnit,FClass,FCostAcctID,FCostDiffRate,FCostProject,FDaysPer,FDepartment,FGoodSpec,FISKFPeriod,FIsSale,FIsSnManage,FIsSpecialTax,FKFPeriod,FLastCheckDate,FNote,FOIHighLimit,FOILowLimit,FOrderRector,FPickHighLimit,FPickLowLimit,FPlanPrice,FPOHghPrcMnyType,FPOHighPrice,FPriceDecimal,FProfitRate,FSaleAcctID,FSalePrice,FSaleTaxAcctID,FSOHighLimit,FSOLowLimit,FSOLowPrc,FSOLowPrcMnyType,FStockPrice,FStockTime,FTaxRate,FTrack,FWWHghPrc,FWWHghPrcMnyType,FBackFlushSPID,FBackFlushStockID,FBatChangeEconomy,FBatchAppendQty,FBatchSplit,FBatchSplitDays,FBatFixEconomy,FCharSourceItemID,FContainerName,FCtrlStraregy,FCtrlType,FCUUnitID,FDailyConsume,FDefaultRoutingID,FDefaultWorkTypeID,FFixLeadTime,FInHighLimit,FInLowLimit,FIsBackFlush,FIsCharSourceItem,FIsFixedReOrder,FKanBanCapability,FLeadTime,FLowestBomCode,FMRPCon,FMRPOrder,FOrderInterVal,FOrderPoint,FOrderTrategy,FPlanMode,FPlanner,FPlanPoint,FPlanTrategy,FProductPrincipal,FPutInteger,FQtyMax,FQtyMin,FRequirePoint,FTotalTQQ,F_101,F_102,F_103,F_104,F_105,F_106,F_107,F_108,F_109,F_110,F_111,FChartNumber,FCubicMeasure,FGrossWeight,FHeight,FIsFix,FIsKeyItem,FLength,FMakeFile,FMaund,FNetWeight,FSize,FStartService,FTtermOfService,FTtermOfUsefulTime,FVersion,FWidth,FCAVAcctID,FCBAppendProject,FCBAppendRate,FCBRouting,FChgFeeRate,FCostBomID,FMCVAcctID,FOutMachFee,FOutMachFeeProject,FPCVAcctID,FPieceRate,FPIVAcctID,FPOVAcctID,FSLAcctID,FStandardCost,FStandardManHour,FStdBatchQty,FStdFixFeeRate,FStdPayRate,FIdentifier,FInspectionLevel,FInspectionProject,FIsListControl,FOtherChkMde,FProChkMde,FSampStdCritical,FSampStdSlight,FSampStdStrict,FSOChkMde,FStkChkAlrm,FStkChkMde,FStkChkPrd,FWthDrwChkMde,FWWChkMde,FConsumeTaxRate,FCubageDecimal,FExportRate,FFirstUnit,FFirstUnitRate,FHSNumber,FImpostTaxRate,FIsManage,FLenDecimal,FManageType,FModelEn,FNameEn,FPackType,FSecondUnit,FSecondUnitRate,FWeightDecimal ");
			strSql.Append(" FROM t_ICItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.ExecuteDataTable(conn, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_ICItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = SqlHelper.ExecuteScalar(conn, strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.FStockTime desc");
			}
			strSql.Append(")AS Row, T.*  from t_ICItem T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SqlHelper.ExecuteDataTable(conn, strSql.ToString());
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 由日立产品代码和近视光度得到产品编号
        /// </summary>
        /// <param name="fNumber">产品代码前4位</param>
        /// <param name="fName">近视光度</param>
        /// <returns></returns>
        public int GetItemIDByFNameFnumber(string fNumber,string fName)
        {
            string sql = string.Format("SELECT FItemID FROM t_icitem WHERE FNumber LIKE  '{0}%' AND RIGHT(FName, 4) = '{1}'",fNumber,fName.PadLeft(4,'0'));
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        /// <summary>
        /// 由SKU得到产品编号
        /// </summary>
        /// <param name="fNumber">产品代码前4位</param>
        /// <param name="fName">近视光度</param>
        /// <returns>产品编号</returns>
        public int GetItemIDBySKU(string sku)
        {
            string sql = string.Format("SELECT FItemID FROM t_icitem WHERE FHelpCode = '{0}' or F_111 = '{0}'", sku);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        /// <summary>
        /// 由日立客户代码得到客户编号/门店编号
        /// </summary>
        /// <param name="fNumber"></param>
        /// <returns>客户编号/门店编号</returns>
        public int GetCustIDByFnumber(string fNumber)
        {
            string sql = string.Format("SELECT fItemID FROM t_Organization WHERE FNumber = '{0}'",fNumber);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        /// <summary>
        /// 由仓库名称得到仓库编号
        /// </summary>
        /// <param name="FName">仓库名称</param>
        /// <returns>仓库编号</returns>
        public int GetStockIDByFName(string fname)
        {
            string sql = string.Format("SELECT fItemID FROM t_stock WHERE t_stock.FName = '{0}'", fname);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        /// <summary>
        /// 由产品编号得到销售价格
        /// </summary>
        /// <param name="itemId">产品编号</param>
        /// <returns>销售价格</returns>
        public decimal GetSalePriceByFItemID(int itemId)
        {
            string sql = string.Format("SELECT FSalePrice FROM t_icitem WHERE FItemID = {0}",itemId);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? decimal.Parse(obj.ToString()) : 0;
        }

        /// <summary>
        /// 通过物料ID得到单位ID
        /// </summary>
        /// <param name="itemid">物料ID</param>
        /// <returns>单位ID</returns>        
        public int GetUnitIDByitemID(int itemid)
        {
            string sql = string.Format("SELECT FUnitID FROM t_ICItem WHERE  FItemID = {0}", itemid);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

		#endregion  ExtensionMethod
	}

    #endregion

}