using System;

namespace Huali.EDI2.Models
{
    #region SEOutStock
    [Serializable]
    public partial class SEOutStock
    {
        public SEOutStock()
        { }

        #region Model_SEOutStock

        /// <summary>
        /// 
        /// </summary>
        public int FInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSalType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCustID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FExplanation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBrNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FAdd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FEmpID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCheckerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FBillerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FManagerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FInvoiceClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FBClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FDeptID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSettleID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FTranStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FExchangeRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCurrencyID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FCancellation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCurCheckLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FRelateBrID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCheckDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FFetchAdd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSelTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FChildren { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FBrID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FAreaPS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FPOOrdBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FManageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FExchangeRateType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCustAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPrintCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS0238 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS0239 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfS0240 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS1241 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS1242 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS0241 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfS0244 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfS1244 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfS1243 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FHeadSelfS0245 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FHeadSelfS1245 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfS0247 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfS1246 { get; set; }
        #endregion
    }
    #endregion

    #region SEOutStockEntry

    #region SEOutStockEntry : SEOutStockEntryBase
    [Serializable]
    public partial class SEOutStockEntry 
    {
        public SEOutStockEntry() { }

        #region SEOutStockEntry
        /// <summary>
        /// 
        /// </summary>
        public string FBrNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FItemID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FCommitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderInterID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNote { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FInvoiceQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FBCommitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxBCommitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxCommitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxInvoiceQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMapNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMapName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FAuxPropID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FBatchNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCheckDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FExplanation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFetchAdd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FFetchDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCoefficient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCommitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceTranType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceInterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSourceBillNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FContractInterID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FContractEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FContractBillNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FOrderEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderBillNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FStockID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FBackQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxBackQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecBackQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FStdAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FPlanMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMTONo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FStockQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxStockQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecStockQty { get; set; }
        /// <summary>
        /// 有默认值，自动加一
        /// </summary>
        //public int FDetailID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecInvoiceQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FDiffQtyClosed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxStockBillQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FStockBillQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntrySelfS0251 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntrySelfS0252 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntrySelfS0253 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntrySelfS1234 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntrySelfS1235 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEntrySelfS0254 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEntrySelfS1236 { get; set; }
        #endregion

    }
    #endregion



    #endregion

    #region t_Item
    /// <summary>
    /// t_ICItem:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_ICItem
    {
        public T_ICItem()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int? FARAcctID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBrNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FForSale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FHelpCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FItemID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FModel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOmortize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOmortizeScale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOrderPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FParentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPerWastage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanPriceMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPriceFixingType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FRP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSalePriceFixingType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FShortNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStaCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTopID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAlias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FApproveNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FAuxClassID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultLoc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultReadyLoc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEquipmentNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FErpClsID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FHighLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsEquipment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSparePart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLowLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPreDeadLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FProductUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FQtyDecimal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecCoefficient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecInv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSecUnitDecimal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSecUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSerialClassID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSPID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSPIDReady { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FStoreUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FUnitGroupID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FUseState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FABCCls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FAdminAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FAPAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FBatchManager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FBeforeExpire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FBookPlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBBmStandardID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBRestore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCheckCycle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCheckCycUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FCostDiffRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDaysPer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FGoodSpec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FISKFPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSnManage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSpecialTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FKFPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FLastCheckDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNote { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOIHighLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOILowLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderRector { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPickHighLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPickLowLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPlanPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOHghPrcMnyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPOHighPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPriceDecimal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FProfitRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleTaxAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOHighLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOLowLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOLowPrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSOLowPrcMnyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStockPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FStockTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FTaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTrack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FWWHghPrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FWWHghPrcMnyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FBackFlushSPID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FBackFlushStockID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatChangeEconomy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchAppendQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchSplit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FBatchSplitDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatFixEconomy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCharSourceItemID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FContainerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCtrlStraregy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCtrlType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCUUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FDailyConsume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultRoutingID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultWorkTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FFixLeadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FInHighLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FInLowLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsBackFlush { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsCharSourceItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsFixedReOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FKanBanCapability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLeadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FLowestBomCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FMRPCon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FMRPOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderInterVal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOrderPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderTrategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanTrategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FProductPrincipal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FPutInteger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FQtyMax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FQtyMin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FRequirePoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTotalTQQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_101 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_102 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_103 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_104 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_105 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_106 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_107 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_108 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_109 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_110 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_111 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FChartNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCubicMeasure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FGrossWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsFix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsKeyItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FMakeFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMaund { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FNetWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FStartService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTtermOfService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FTtermOfUsefulTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCAVAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBAppendProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FCBAppendRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBRouting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FChgFeeRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostBomID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FMCVAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOutMachFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOutMachFeeProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPCVAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPieceRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPIVAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOVAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSLAcctID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStandardCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStandardManHour { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdBatchQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdFixFeeRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdPayRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FIdentifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FInspectionLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FInspectionProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsListControl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FOtherChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FProChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdCritical { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdSlight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdStrict { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FSOChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkAlrm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkPrd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FWthDrwChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FWWChkMde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FConsumeTaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FCubageDecimal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FExportRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFirstUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FFirstUnitRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FHSNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FImpostTaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsManage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FLenDecimal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FManageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FModelEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNameEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FPackType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSecondUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecondUnitRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? FWeightDecimal { get; set; }

        #endregion Model
    }

    #endregion

}