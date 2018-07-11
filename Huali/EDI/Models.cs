using System;
namespace Huali.EDI.Model
{

    #region t_ICItem
    /// <summary>
    /// t_ICItem:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_ICItem
    {
        public T_ICItem()
        { }

        #region Model
        private int? _faracctid;
        private string _fbrno;
        private int? _fdeleted;
        private bool _fforsale;
        private string _fhelpcode;
        private int _fitemid;
        private string _fmodel;
        private DateTime? _fmodifytime;
        private string _fname;
        private string _fnumber;
        private int? _fomortize;
        private int? _fomortizescale;
        private int? _fordermethod;
        private decimal? _forderprice;
        private int? _fparentid;
        private decimal? _fperwastage;
        private int? _fplanclass;
        private int? _fplanpricemethod;
        private int? _fpricefixingtype;
        private int? _frp;
        private int? _fsalepricefixingtype;
        private string _fshortnumber;
        private decimal? _fstacost;
        private int? _ftopid;
        private string _falias;
        private string _fapproveno;
        private int? _fauxclassid;
        private int? _fdefaultloc;
        private int? _fdefaultreadyloc;
        private string _fequipmentnum;
        private int? _ferpclsid;
        private string _ffullname;
        private decimal? _fhighlimit;
        private bool _fisequipment;
        private bool _fissparepart;
        private decimal? _flowlimit;
        private int? _forderunitid;
        private int? _fpredeadline;
        private int? _fproductunitid;
        private int? _fqtydecimal;
        private int? _fsaleunitid;
        private decimal? _fseccoefficient;
        private decimal? _fsecinv;
        private int? _fsecunitdecimal;
        private int? _fsecunitid;
        private int? _fserialclassid;
        private int? _fsource;
        private int? _fspid;
        private int? _fspidready;
        private int? _fstoreunitid;
        private int? _ftypeid;
        private int? _funitgroupid;
        private int _funitid;
        private int? _fusestate;
        private string _fabccls;
        private int? _facctid;
        private int? _fadminacctid;
        private int? _fapacctid;
        private bool _fbatchmanager;
        private decimal? _fbatchqty;
        private int? _fbeforeexpire;
        private bool _fbookplan;
        private int? _fcbbmstandardid;
        private int? _fcbrestore;
        private int? _fcheckcycle;
        private int? _fcheckcycunit;
        private bool _fclass;
        private int? _fcostacctid;
        private decimal? _fcostdiffrate;
        private int? _fcostproject;
        private int? _fdaysper;
        private int? _fdepartment;
        private int? _fgoodspec;
        private bool _fiskfperiod;
        private bool _fissale;
        private bool _fissnmanage;
        private bool _fisspecialtax;
        private decimal? _fkfperiod;
        private DateTime? _flastcheckdate;
        private string _fnote;
        private decimal? _foihighlimit;
        private decimal? _foilowlimit;
        private int? _forderrector;
        private decimal? _fpickhighlimit;
        private decimal? _fpicklowlimit;
        private decimal? _fplanprice;
        private int? _fpohghprcmnytype;
        private decimal? _fpohighprice;
        private int? _fpricedecimal;
        private decimal? _fprofitrate;
        private int? _fsaleacctid;
        private decimal? _fsaleprice;
        private int? _fsaletaxacctid;
        private decimal? _fsohighlimit;
        private decimal? _fsolowlimit;
        private decimal? _fsolowprc;
        private int? _fsolowprcmnytype;
        private decimal? _fstockprice;
        private bool _fstocktime;
        private decimal? _ftaxrate;
        private int? _ftrack;
        private decimal? _fwwhghprc;
        private int? _fwwhghprcmnytype;
        private int? _fbackflushspid;
        private int? _fbackflushstockid;
        private decimal? _fbatchangeeconomy;
        private decimal? _fbatchappendqty;
        private decimal? _fbatchsplit;
        private int? _fbatchsplitdays;
        private decimal? _fbatfixeconomy;
        private int? _fcharsourceitemid;
        private string _fcontainername;
        private int? _fctrlstraregy;
        private int? _fctrltype;
        private int? _fcuunitid;
        private decimal? _fdailyconsume;
        private int? _fdefaultroutingid;
        private int? _fdefaultworktypeid;
        private decimal? _ffixleadtime;
        private decimal? _finhighlimit;
        private decimal? _finlowlimit;
        private int? _fisbackflush;
        private int? _fischarsourceitem;
        private bool _fisfixedreorder;
        private int? _fkanbancapability;
        private decimal? _fleadtime;
        private int? _flowestbomcode;
        private bool _fmrpcon;
        private bool _fmrporder;
        private int? _forderinterval;
        private decimal? _forderpoint;
        private int? _fordertrategy;
        private int? _fplanmode;
        private int? _fplanner;
        private int? _fplanpoint;
        private int? _fplantrategy;
        private int? _fproductprincipal;
        private bool _fputinteger;
        private decimal? _fqtymax;
        private decimal? _fqtymin;
        private int? _frequirepoint;
        private int? _ftotaltqq;
        private string _f_101;
        private string _f_102;
        private string _f_103;
        private string _f_104;
        private string _f_105;
        private string _f_106;
        private string _f_107;
        private string _f_108;
        private string _f_109;
        private string _f_110;
        private string _f_111;
        private string _fchartnumber;
        private int? _fcubicmeasure;
        private decimal? _fgrossweight;
        private decimal? _fheight;
        private bool _fisfix;
        private bool _fiskeyitem;
        private decimal? _flength;
        private bool _fmakefile;
        private int? _fmaund;
        private decimal? _fnetweight;
        private decimal? _fsize;
        private bool _fstartservice;
        private int? _fttermofservice;
        private int? _fttermofusefultime;
        private string _fversion;
        private decimal? _fwidth;
        private int? _fcavacctid;
        private int? _fcbappendproject;
        private decimal? _fcbappendrate;
        private int? _fcbrouting;
        private decimal? _fchgfeerate;
        private int? _fcostbomid;
        private int? _fmcvacctid;
        private decimal? _foutmachfee;
        private int? _foutmachfeeproject;
        private int? _fpcvacctid;
        private decimal? _fpiecerate;
        private int? _fpivacctid;
        private int? _fpovacctid;
        private int? _fslacctid;
        private decimal? _fstandardcost;
        private decimal? _fstandardmanhour;
        private decimal? _fstdbatchqty;
        private decimal? _fstdfixfeerate;
        private decimal? _fstdpayrate;
        private int? _fidentifier;
        private int? _finspectionlevel;
        private int? _finspectionproject;
        private int? _fislistcontrol;
        private int? _fotherchkmde;
        private int? _fprochkmde;
        private string _fsampstdcritical;
        private string _fsampstdslight;
        private string _fsampstdstrict;
        private int? _fsochkmde;
        private int? _fstkchkalrm;
        private int? _fstkchkmde;
        private int? _fstkchkprd;
        private int? _fwthdrwchkmde;
        private int? _fwwchkmde;
        private decimal? _fconsumetaxrate;
        private int? _fcubagedecimal;
        private decimal? _fexportrate;
        private string _ffirstunit;
        private decimal? _ffirstunitrate;
        private int? _fhsnumber;
        private decimal? _fimposttaxrate;
        private bool _fismanage;
        private int? _flendecimal;
        private int? _fmanagetype;
        private string _fmodelen;
        private string _fnameen;
        private int? _fpacktype;
        private string _fsecondunit;
        private decimal? _fsecondunitrate;
        private int? _fweightdecimal;
        /// <summary>
        /// 
        /// </summary>
        public int? FARAcctID
        {
            set { _faracctid = value; }
            get { return _faracctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBrNo
        {
            set { _fbrno = value; }
            get { return _fbrno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDeleted
        {
            set { _fdeleted = value; }
            get { return _fdeleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FForSale
        {
            set { _fforsale = value; }
            get { return _fforsale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FHelpCode
        {
            set { _fhelpcode = value; }
            get { return _fhelpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FModel
        {
            set { _fmodel = value; }
            get { return _fmodel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FModifyTime
        {
            set { _fmodifytime = value; }
            get { return _fmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FName
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FNumber
        {
            set { _fnumber = value; }
            get { return _fnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOmortize
        {
            set { _fomortize = value; }
            get { return _fomortize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOmortizeScale
        {
            set { _fomortizescale = value; }
            get { return _fomortizescale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderMethod
        {
            set { _fordermethod = value; }
            get { return _fordermethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOrderPrice
        {
            set { _forderprice = value; }
            get { return _forderprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FParentID
        {
            set { _fparentid = value; }
            get { return _fparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPerWastage
        {
            set { _fperwastage = value; }
            get { return _fperwastage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanClass
        {
            set { _fplanclass = value; }
            get { return _fplanclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanPriceMethod
        {
            set { _fplanpricemethod = value; }
            get { return _fplanpricemethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPriceFixingType
        {
            set { _fpricefixingtype = value; }
            get { return _fpricefixingtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FRP
        {
            set { _frp = value; }
            get { return _frp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSalePriceFixingType
        {
            set { _fsalepricefixingtype = value; }
            get { return _fsalepricefixingtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FShortNumber
        {
            set { _fshortnumber = value; }
            get { return _fshortnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStaCost
        {
            set { _fstacost = value; }
            get { return _fstacost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTopID
        {
            set { _ftopid = value; }
            get { return _ftopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FAlias
        {
            set { _falias = value; }
            get { return _falias; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FApproveNo
        {
            set { _fapproveno = value; }
            get { return _fapproveno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAuxClassID
        {
            set { _fauxclassid = value; }
            get { return _fauxclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultLoc
        {
            set { _fdefaultloc = value; }
            get { return _fdefaultloc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultReadyLoc
        {
            set { _fdefaultreadyloc = value; }
            get { return _fdefaultreadyloc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FEquipmentNum
        {
            set { _fequipmentnum = value; }
            get { return _fequipmentnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FErpClsID
        {
            set { _ferpclsid = value; }
            get { return _ferpclsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FFullName
        {
            set { _ffullname = value; }
            get { return _ffullname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FHighLimit
        {
            set { _fhighlimit = value; }
            get { return _fhighlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsEquipment
        {
            set { _fisequipment = value; }
            get { return _fisequipment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSparePart
        {
            set { _fissparepart = value; }
            get { return _fissparepart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLowLimit
        {
            set { _flowlimit = value; }
            get { return _flowlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderUnitID
        {
            set { _forderunitid = value; }
            get { return _forderunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPreDeadLine
        {
            set { _fpredeadline = value; }
            get { return _fpredeadline; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FProductUnitID
        {
            set { _fproductunitid = value; }
            get { return _fproductunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FQtyDecimal
        {
            set { _fqtydecimal = value; }
            get { return _fqtydecimal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleUnitID
        {
            set { _fsaleunitid = value; }
            get { return _fsaleunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecCoefficient
        {
            set { _fseccoefficient = value; }
            get { return _fseccoefficient; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecInv
        {
            set { _fsecinv = value; }
            get { return _fsecinv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSecUnitDecimal
        {
            set { _fsecunitdecimal = value; }
            get { return _fsecunitdecimal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSecUnitID
        {
            set { _fsecunitid = value; }
            get { return _fsecunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSerialClassID
        {
            set { _fserialclassid = value; }
            get { return _fserialclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSource
        {
            set { _fsource = value; }
            get { return _fsource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSPID
        {
            set { _fspid = value; }
            get { return _fspid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSPIDReady
        {
            set { _fspidready = value; }
            get { return _fspidready; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FStoreUnitID
        {
            set { _fstoreunitid = value; }
            get { return _fstoreunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FUnitGroupID
        {
            set { _funitgroupid = value; }
            get { return _funitgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FUnitID
        {
            set { _funitid = value; }
            get { return _funitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FUseState
        {
            set { _fusestate = value; }
            get { return _fusestate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FABCCls
        {
            set { _fabccls = value; }
            get { return _fabccls; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAcctID
        {
            set { _facctid = value; }
            get { return _facctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAdminAcctID
        {
            set { _fadminacctid = value; }
            get { return _fadminacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAPAcctID
        {
            set { _fapacctid = value; }
            get { return _fapacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FBatchManager
        {
            set { _fbatchmanager = value; }
            get { return _fbatchmanager; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchQty
        {
            set { _fbatchqty = value; }
            get { return _fbatchqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FBeforeExpire
        {
            set { _fbeforeexpire = value; }
            get { return _fbeforeexpire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FBookPlan
        {
            set { _fbookplan = value; }
            get { return _fbookplan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBBmStandardID
        {
            set { _fcbbmstandardid = value; }
            get { return _fcbbmstandardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBRestore
        {
            set { _fcbrestore = value; }
            get { return _fcbrestore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCheckCycle
        {
            set { _fcheckcycle = value; }
            get { return _fcheckcycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCheckCycUnit
        {
            set { _fcheckcycunit = value; }
            get { return _fcheckcycunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FClass
        {
            set { _fclass = value; }
            get { return _fclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostAcctID
        {
            set { _fcostacctid = value; }
            get { return _fcostacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FCostDiffRate
        {
            set { _fcostdiffrate = value; }
            get { return _fcostdiffrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostProject
        {
            set { _fcostproject = value; }
            get { return _fcostproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDaysPer
        {
            set { _fdaysper = value; }
            get { return _fdaysper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDepartment
        {
            set { _fdepartment = value; }
            get { return _fdepartment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FGoodSpec
        {
            set { _fgoodspec = value; }
            get { return _fgoodspec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FISKFPeriod
        {
            set { _fiskfperiod = value; }
            get { return _fiskfperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSale
        {
            set { _fissale = value; }
            get { return _fissale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSnManage
        {
            set { _fissnmanage = value; }
            get { return _fissnmanage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsSpecialTax
        {
            set { _fisspecialtax = value; }
            get { return _fisspecialtax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FKFPeriod
        {
            set { _fkfperiod = value; }
            get { return _fkfperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FLastCheckDate
        {
            set { _flastcheckdate = value; }
            get { return _flastcheckdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOIHighLimit
        {
            set { _foihighlimit = value; }
            get { return _foihighlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOILowLimit
        {
            set { _foilowlimit = value; }
            get { return _foilowlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderRector
        {
            set { _forderrector = value; }
            get { return _forderrector; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPickHighLimit
        {
            set { _fpickhighlimit = value; }
            get { return _fpickhighlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPickLowLimit
        {
            set { _fpicklowlimit = value; }
            get { return _fpicklowlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPlanPrice
        {
            set { _fplanprice = value; }
            get { return _fplanprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOHghPrcMnyType
        {
            set { _fpohghprcmnytype = value; }
            get { return _fpohghprcmnytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPOHighPrice
        {
            set { _fpohighprice = value; }
            get { return _fpohighprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPriceDecimal
        {
            set { _fpricedecimal = value; }
            get { return _fpricedecimal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FProfitRate
        {
            set { _fprofitrate = value; }
            get { return _fprofitrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleAcctID
        {
            set { _fsaleacctid = value; }
            get { return _fsaleacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSalePrice
        {
            set { _fsaleprice = value; }
            get { return _fsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSaleTaxAcctID
        {
            set { _fsaletaxacctid = value; }
            get { return _fsaletaxacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOHighLimit
        {
            set { _fsohighlimit = value; }
            get { return _fsohighlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOLowLimit
        {
            set { _fsolowlimit = value; }
            get { return _fsolowlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSOLowPrc
        {
            set { _fsolowprc = value; }
            get { return _fsolowprc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSOLowPrcMnyType
        {
            set { _fsolowprcmnytype = value; }
            get { return _fsolowprcmnytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStockPrice
        {
            set { _fstockprice = value; }
            get { return _fstockprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FStockTime
        {
            set { _fstocktime = value; }
            get { return _fstocktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FTaxRate
        {
            set { _ftaxrate = value; }
            get { return _ftaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTrack
        {
            set { _ftrack = value; }
            get { return _ftrack; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FWWHghPrc
        {
            set { _fwwhghprc = value; }
            get { return _fwwhghprc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FWWHghPrcMnyType
        {
            set { _fwwhghprcmnytype = value; }
            get { return _fwwhghprcmnytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FBackFlushSPID
        {
            set { _fbackflushspid = value; }
            get { return _fbackflushspid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FBackFlushStockID
        {
            set { _fbackflushstockid = value; }
            get { return _fbackflushstockid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatChangeEconomy
        {
            set { _fbatchangeeconomy = value; }
            get { return _fbatchangeeconomy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchAppendQty
        {
            set { _fbatchappendqty = value; }
            get { return _fbatchappendqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatchSplit
        {
            set { _fbatchsplit = value; }
            get { return _fbatchsplit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FBatchSplitDays
        {
            set { _fbatchsplitdays = value; }
            get { return _fbatchsplitdays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FBatFixEconomy
        {
            set { _fbatfixeconomy = value; }
            get { return _fbatfixeconomy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCharSourceItemID
        {
            set { _fcharsourceitemid = value; }
            get { return _fcharsourceitemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FContainerName
        {
            set { _fcontainername = value; }
            get { return _fcontainername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCtrlStraregy
        {
            set { _fctrlstraregy = value; }
            get { return _fctrlstraregy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCtrlType
        {
            set { _fctrltype = value; }
            get { return _fctrltype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCUUnitID
        {
            set { _fcuunitid = value; }
            get { return _fcuunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FDailyConsume
        {
            set { _fdailyconsume = value; }
            get { return _fdailyconsume; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultRoutingID
        {
            set { _fdefaultroutingid = value; }
            get { return _fdefaultroutingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDefaultWorkTypeID
        {
            set { _fdefaultworktypeid = value; }
            get { return _fdefaultworktypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FFixLeadTime
        {
            set { _ffixleadtime = value; }
            get { return _ffixleadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FInHighLimit
        {
            set { _finhighlimit = value; }
            get { return _finhighlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FInLowLimit
        {
            set { _finlowlimit = value; }
            get { return _finlowlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsBackFlush
        {
            set { _fisbackflush = value; }
            get { return _fisbackflush; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsCharSourceItem
        {
            set { _fischarsourceitem = value; }
            get { return _fischarsourceitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsFixedReOrder
        {
            set { _fisfixedreorder = value; }
            get { return _fisfixedreorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FKanBanCapability
        {
            set { _fkanbancapability = value; }
            get { return _fkanbancapability; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLeadTime
        {
            set { _fleadtime = value; }
            get { return _fleadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FLowestBomCode
        {
            set { _flowestbomcode = value; }
            get { return _flowestbomcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FMRPCon
        {
            set { _fmrpcon = value; }
            get { return _fmrpcon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FMRPOrder
        {
            set { _fmrporder = value; }
            get { return _fmrporder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderInterVal
        {
            set { _forderinterval = value; }
            get { return _forderinterval; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOrderPoint
        {
            set { _forderpoint = value; }
            get { return _forderpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOrderTrategy
        {
            set { _fordertrategy = value; }
            get { return _fordertrategy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanMode
        {
            set { _fplanmode = value; }
            get { return _fplanmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanner
        {
            set { _fplanner = value; }
            get { return _fplanner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanPoint
        {
            set { _fplanpoint = value; }
            get { return _fplanpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPlanTrategy
        {
            set { _fplantrategy = value; }
            get { return _fplantrategy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FProductPrincipal
        {
            set { _fproductprincipal = value; }
            get { return _fproductprincipal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FPutInteger
        {
            set { _fputinteger = value; }
            get { return _fputinteger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FQtyMax
        {
            set { _fqtymax = value; }
            get { return _fqtymax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FQtyMin
        {
            set { _fqtymin = value; }
            get { return _fqtymin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FRequirePoint
        {
            set { _frequirepoint = value; }
            get { return _frequirepoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTotalTQQ
        {
            set { _ftotaltqq = value; }
            get { return _ftotaltqq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_101
        {
            set { _f_101 = value; }
            get { return _f_101; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_102
        {
            set { _f_102 = value; }
            get { return _f_102; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_103
        {
            set { _f_103 = value; }
            get { return _f_103; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_104
        {
            set { _f_104 = value; }
            get { return _f_104; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_105
        {
            set { _f_105 = value; }
            get { return _f_105; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_106
        {
            set { _f_106 = value; }
            get { return _f_106; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_107
        {
            set { _f_107 = value; }
            get { return _f_107; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_108
        {
            set { _f_108 = value; }
            get { return _f_108; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_109
        {
            set { _f_109 = value; }
            get { return _f_109; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_110
        {
            set { _f_110 = value; }
            get { return _f_110; }
        }
        /// <summary>
        ///  助记码二
        /// </summary>
        public string F_111
        {
            set { _f_111 = value; }
            get { return _f_111; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FChartNumber
        {
            set { _fchartnumber = value; }
            get { return _fchartnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCubicMeasure
        {
            set { _fcubicmeasure = value; }
            get { return _fcubicmeasure; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FGrossWeight
        {
            set { _fgrossweight = value; }
            get { return _fgrossweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FHeight
        {
            set { _fheight = value; }
            get { return _fheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsFix
        {
            set { _fisfix = value; }
            get { return _fisfix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsKeyItem
        {
            set { _fiskeyitem = value; }
            get { return _fiskeyitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLength
        {
            set { _flength = value; }
            get { return _flength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FMakeFile
        {
            set { _fmakefile = value; }
            get { return _fmakefile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMaund
        {
            set { _fmaund = value; }
            get { return _fmaund; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FNetWeight
        {
            set { _fnetweight = value; }
            get { return _fnetweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSize
        {
            set { _fsize = value; }
            get { return _fsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FStartService
        {
            set { _fstartservice = value; }
            get { return _fstartservice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTtermOfService
        {
            set { _fttermofservice = value; }
            get { return _fttermofservice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FTtermOfUsefulTime
        {
            set { _fttermofusefultime = value; }
            get { return _fttermofusefultime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FVersion
        {
            set { _fversion = value; }
            get { return _fversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FWidth
        {
            set { _fwidth = value; }
            get { return _fwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCAVAcctID
        {
            set { _fcavacctid = value; }
            get { return _fcavacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBAppendProject
        {
            set { _fcbappendproject = value; }
            get { return _fcbappendproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FCBAppendRate
        {
            set { _fcbappendrate = value; }
            get { return _fcbappendrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCBRouting
        {
            set { _fcbrouting = value; }
            get { return _fcbrouting; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FChgFeeRate
        {
            set { _fchgfeerate = value; }
            get { return _fchgfeerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCostBomID
        {
            set { _fcostbomid = value; }
            get { return _fcostbomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMCVAcctID
        {
            set { _fmcvacctid = value; }
            get { return _fmcvacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FOutMachFee
        {
            set { _foutmachfee = value; }
            get { return _foutmachfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOutMachFeeProject
        {
            set { _foutmachfeeproject = value; }
            get { return _foutmachfeeproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPCVAcctID
        {
            set { _fpcvacctid = value; }
            get { return _fpcvacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FPieceRate
        {
            set { _fpiecerate = value; }
            get { return _fpiecerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPIVAcctID
        {
            set { _fpivacctid = value; }
            get { return _fpivacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOVAcctID
        {
            set { _fpovacctid = value; }
            get { return _fpovacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSLAcctID
        {
            set { _fslacctid = value; }
            get { return _fslacctid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStandardCost
        {
            set { _fstandardcost = value; }
            get { return _fstandardcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStandardManHour
        {
            set { _fstandardmanhour = value; }
            get { return _fstandardmanhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdBatchQty
        {
            set { _fstdbatchqty = value; }
            get { return _fstdbatchqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdFixFeeRate
        {
            set { _fstdfixfeerate = value; }
            get { return _fstdfixfeerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FStdPayRate
        {
            set { _fstdpayrate = value; }
            get { return _fstdpayrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FIdentifier
        {
            set { _fidentifier = value; }
            get { return _fidentifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FInspectionLevel
        {
            set { _finspectionlevel = value; }
            get { return _finspectionlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FInspectionProject
        {
            set { _finspectionproject = value; }
            get { return _finspectionproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FIsListControl
        {
            set { _fislistcontrol = value; }
            get { return _fislistcontrol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FOtherChkMde
        {
            set { _fotherchkmde = value; }
            get { return _fotherchkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FProChkMde
        {
            set { _fprochkmde = value; }
            get { return _fprochkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdCritical
        {
            set { _fsampstdcritical = value; }
            get { return _fsampstdcritical; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdSlight
        {
            set { _fsampstdslight = value; }
            get { return _fsampstdslight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSampStdStrict
        {
            set { _fsampstdstrict = value; }
            get { return _fsampstdstrict; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSOChkMde
        {
            set { _fsochkmde = value; }
            get { return _fsochkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkAlrm
        {
            set { _fstkchkalrm = value; }
            get { return _fstkchkalrm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkMde
        {
            set { _fstkchkmde = value; }
            get { return _fstkchkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FStkChkPrd
        {
            set { _fstkchkprd = value; }
            get { return _fstkchkprd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FWthDrwChkMde
        {
            set { _fwthdrwchkmde = value; }
            get { return _fwthdrwchkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FWWChkMde
        {
            set { _fwwchkmde = value; }
            get { return _fwwchkmde; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FConsumeTaxRate
        {
            set { _fconsumetaxrate = value; }
            get { return _fconsumetaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCubageDecimal
        {
            set { _fcubagedecimal = value; }
            get { return _fcubagedecimal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FExportRate
        {
            set { _fexportrate = value; }
            get { return _fexportrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FFirstUnit
        {
            set { _ffirstunit = value; }
            get { return _ffirstunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FFirstUnitRate
        {
            set { _ffirstunitrate = value; }
            get { return _ffirstunitrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FHSNumber
        {
            set { _fhsnumber = value; }
            get { return _fhsnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FImpostTaxRate
        {
            set { _fimposttaxrate = value; }
            get { return _fimposttaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FIsManage
        {
            set { _fismanage = value; }
            get { return _fismanage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FLenDecimal
        {
            set { _flendecimal = value; }
            get { return _flendecimal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FManageType
        {
            set { _fmanagetype = value; }
            get { return _fmanagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FModelEn
        {
            set { _fmodelen = value; }
            get { return _fmodelen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FNameEn
        {
            set { _fnameen = value; }
            get { return _fnameen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPackType
        {
            set { _fpacktype = value; }
            get { return _fpacktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSecondUnit
        {
            set { _fsecondunit = value; }
            get { return _fsecondunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSecondUnitRate
        {
            set { _fsecondunitrate = value; }
            get { return _fsecondunitrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FWeightDecimal
        {
            set { _fweightdecimal = value; }
            get { return _fweightdecimal; }
        }
        #endregion
    }
#endregion

    #region POInStock
    /// <summary>
    /// POInStock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class POInStock
    {
        public POInStock()
        { }
        #region Model
        private string _fbrno;
        private int _finterid;
        private string _fbillno;
        private int? _fcurrencyid;
        private int _ftrantype;
        private int _fsupplyid;
        private int? _fdeptid;
        private int? _fempid;
        private DateTime _fdate;
        private int? _fstockid;
        private int? _fposterid;
        private int _fcheckerid;
        private int _fbillerid;
        private int? _ffmanagerid;
        private int? _fsmanagerid;
        private string _fcnnbillno;
        private int _fclosed = 0;
        private string _fnote;
        private int? _finvoiceclosed = 0;
        private int _fbclosed = 0;
        private DateTime _fcreatedate;
        private DateTime _fcheckdate;
        private decimal? _fexchangerate;
        private int _fstatus = 0;
        private bool _fcancellation = false;
        private bool _fupstockwhensave = false;
        private int? _fpostyle;
        private int? _fmultichecklevel1;
        private int? _fmultichecklevel2;
        private int? _fmultichecklevel3;
        private int? _fmultichecklevel4;
        private int? _fmultichecklevel5;
        private int? _fmultichecklevel6;
        private DateTime? _fmulticheckdate1;
        private DateTime? _fmulticheckdate2;
        private DateTime? _fmulticheckdate3;
        private DateTime? _fmulticheckdate4;
        private DateTime? _fmulticheckdate5;
        private DateTime? _fmulticheckdate6;
        private int? _fcurchecklevel;
        private int? _frelatebrid;
        private string _fexplanation = "";
        private string _ffetchadd = "";
        private string _fselectbillno = "";
        private int _fseltrantype = 0;
        private int _fchildren = 0;
        private int? _fbrid;
        private int _ftranstatus = 0;
        private int _fareaps = 0;
        private string _frestatus = "";
        private string _fpoordbillno;
        private int? _fmanagetype;
        private int _fbiztype = 0;
        private int _fwwtype = 0;
        private int _fexchangeratetype = 1;
        private int? _faccessorycount = 0;
        private int? _fpomode = 0;
        private int _fprintcount = 0;
        private int _fischeck = 0;
        private string _fheadselfp0341;
        private DateTime? _fheadselfp0342;
        /// <summary>
        /// 
        /// </summary>
        public string FBrNo
        {
            set { _fbrno = value; }
            get { return _fbrno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FInterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBillNo
        {
            set { _fbillno = value; }
            get { return _fbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCurrencyID
        {
            set { _fcurrencyid = value; }
            get { return _fcurrencyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FTranType
        {
            set { _ftrantype = value; }
            get { return _ftrantype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSupplyID
        {
            set { _fsupplyid = value; }
            get { return _fsupplyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDeptID
        {
            set { _fdeptid = value; }
            get { return _fdeptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FEmpID
        {
            set { _fempid = value; }
            get { return _fempid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FDate
        {
            set { _fdate = value; }
            get { return _fdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FStockID
        {
            set { _fstockid = value; }
            get { return _fstockid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPosterID
        {
            set { _fposterid = value; }
            get { return _fposterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FCheckerID
        {
            set { _fcheckerid = value; }
            get { return _fcheckerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FBillerID
        {
            set { _fbillerid = value; }
            get { return _fbillerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FFManagerID
        {
            set { _ffmanagerid = value; }
            get { return _ffmanagerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FSManagerID
        {
            set { _fsmanagerid = value; }
            get { return _fsmanagerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FCnnBillNo
        {
            set { _fcnnbillno = value; }
            get { return _fcnnbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FClosed
        {
            set { _fclosed = value; }
            get { return _fclosed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FInvoiceClosed
        {
            set { _finvoiceclosed = value; }
            get { return _finvoiceclosed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FBClosed
        {
            set { _fbclosed = value; }
            get { return _fbclosed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FCreateDate
        {
            set { _fcreatedate = value; }
            get { return _fcreatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FCheckDate
        {
            set { _fcheckdate = value; }
            get { return _fcheckdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FExchangeRate
        {
            set { _fexchangerate = value; }
            get { return _fexchangerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FStatus
        {
            set { _fstatus = value; }
            get { return _fstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FCancellation
        {
            set { _fcancellation = value; }
            get { return _fcancellation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FUpStockWhenSave
        {
            set { _fupstockwhensave = value; }
            get { return _fupstockwhensave; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOStyle
        {
            set { _fpostyle = value; }
            get { return _fpostyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel1
        {
            set { _fmultichecklevel1 = value; }
            get { return _fmultichecklevel1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel2
        {
            set { _fmultichecklevel2 = value; }
            get { return _fmultichecklevel2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel3
        {
            set { _fmultichecklevel3 = value; }
            get { return _fmultichecklevel3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel4
        {
            set { _fmultichecklevel4 = value; }
            get { return _fmultichecklevel4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel5
        {
            set { _fmultichecklevel5 = value; }
            get { return _fmultichecklevel5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel6
        {
            set { _fmultichecklevel6 = value; }
            get { return _fmultichecklevel6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate1
        {
            set { _fmulticheckdate1 = value; }
            get { return _fmulticheckdate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate2
        {
            set { _fmulticheckdate2 = value; }
            get { return _fmulticheckdate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate3
        {
            set { _fmulticheckdate3 = value; }
            get { return _fmulticheckdate3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate4
        {
            set { _fmulticheckdate4 = value; }
            get { return _fmulticheckdate4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate5
        {
            set { _fmulticheckdate5 = value; }
            get { return _fmulticheckdate5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate6
        {
            set { _fmulticheckdate6 = value; }
            get { return _fmulticheckdate6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FCurCheckLevel
        {
            set { _fcurchecklevel = value; }
            get { return _fcurchecklevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FRelateBrID
        {
            set { _frelatebrid = value; }
            get { return _frelatebrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FExplanation
        {
            set { _fexplanation = value; }
            get { return _fexplanation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FFetchAdd
        {
            set { _ffetchadd = value; }
            get { return _ffetchadd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSelectBillNo
        {
            set { _fselectbillno = value; }
            get { return _fselectbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSelTranType
        {
            set { _fseltrantype = value; }
            get { return _fseltrantype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FChildren
        {
            set { _fchildren = value; }
            get { return _fchildren; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FBrID
        {
            set { _fbrid = value; }
            get { return _fbrid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FTranStatus
        {
            set { _ftranstatus = value; }
            get { return _ftranstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FAreaPS
        {
            set { _fareaps = value; }
            get { return _fareaps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FReStatus
        {
            set { _frestatus = value; }
            get { return _frestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FPOOrdBillNo
        {
            set { _fpoordbillno = value; }
            get { return _fpoordbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FManageType
        {
            set { _fmanagetype = value; }
            get { return _fmanagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FBizType
        {
            set { _fbiztype = value; }
            get { return _fbiztype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FWWType
        {
            set { _fwwtype = value; }
            get { return _fwwtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FExchangeRateType
        {
            set { _fexchangeratetype = value; }
            get { return _fexchangeratetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAccessoryCount
        {
            set { _faccessorycount = value; }
            get { return _faccessorycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPOMode
        {
            set { _fpomode = value; }
            get { return _fpomode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FPrintCount
        {
            set { _fprintcount = value; }
            get { return _fprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FIsCheck
        {
            set { _fischeck = value; }
            get { return _fischeck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FHeadSelfP0341
        {
            set { _fheadselfp0341 = value; }
            get { return _fheadselfp0341; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FHeadSelfP0342
        {
            set { _fheadselfp0342 = value; }
            get { return _fheadselfp0342; }
        }
        #endregion Model

    }
#endregion

    #region POInStockEntry
    /// <summary>
    /// POInStockEntry:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class POInStockEntry
    {
        public POInStockEntry()
        { }
        #region Model
        private string _fbrno;
        private int _finterid;
        private int _fentryid;
        private int _fitemid;
        private decimal _fqty = 0M;
        private decimal _fcommitqty = 0M;
        private decimal _fprice = 0M;
        private decimal _famount = 0M;
        private string _fnote;
        private decimal _finvoiceqty = 0M;
        private decimal _fbcommitqty = 0M;
        private decimal _fqcheckqty = 0M;
        private decimal _fauxqcheckqty = 0M;
        private int _funitid = 0;
        private decimal _fauxbcommitqty = 0M;
        private decimal _fauxcommitqty = 0M;
        private decimal _fauxinvoiceqty = 0M;
        private decimal _fauxprice = 0M;
        private decimal _fauxqty = 0M;
        private int _fsourceentryid = 0;
        private decimal _fqtypass = 0M;
        private decimal _fauxqtypass = 0M;
        private string _fmapnumber = "";
        private string _fmapname = "";
        private string _fbatchno = "";
        private DateTime _fkfdate;
        private int _fkfperiod = 0;
        private int _fdcspid;
        private int _fauxpropid = 0;
        private int _fdcstockid = 0;
        private DateTime? _ffetchdate;
        private decimal _fseccoefficient = 0M;
        private decimal _fsecqty = 0M;
        private decimal _fseccommitqty = 0M;
        private int _fsourcetrantype = 0;
        private int _fsourceinterid = 0;
        private string _fsourcebillno = "";
        private int _fcontractinterid = 0;
        private int _fcontractentryid = 0;
        private string _fcontractbillno = "";
        private int _forderinterid = 0;
        private int _forderentryid = 0;
        private string _forderbillno = "";
        private int _fstockid = 0;
        private DateTime? _fperioddate;
        private decimal _fnotpassqty = 0M;
        private decimal _fnpcommitqty = 0M;
        private decimal _fsamplebreakqty = 0M;
        private decimal _fconpassqty = 0M;
        private decimal _fconcommitqty = 0M;
        private decimal _fauxnotpassqty = 0M;
        private decimal _fauxnpcommitqty = 0M;
        private decimal _fauxsamplebreakqty = 0M;
        private decimal _fauxconpassqty = 0M;
        private decimal _fauxconcommitqty = 0M;
        private decimal _fauxrelateqty = 0M;
        private decimal _frelateqty = 0M;
        private decimal _fbackqty = 0M;
        private decimal _fauxbackqty = 0M;
        private decimal _fsecbackqty = 0M;
        private decimal _fsecconcommitqty = 0M;
        private int _fplanmode = 14036;
        private string _fmtono = "";
        private int _fordertype = 0;
        private int? _fentryaccessorycount = 0;
        private int? _fdeliverynoticeentryid = 0;
        private int? _fdeliverynoticefid = 0;
        private int _fdischarged = 0;
        private int _fcheckmethod = 0;
        private decimal _fscrapqty = 0M;
        private decimal _fauxscrapqty = 0M;
        private decimal _fsecscrapqty = 0M;
        private decimal _fsecconcommiqty = 0M;
        private decimal _fscrapincommitqty = 0M;
        private decimal _fauxscrapincommitqty = 0M;
        private decimal _fsecscrapincommitqty = 0M;
        private decimal _fsecqtypass = 0M;
        private decimal _fsecconpassqty = 0M;
        private decimal _fsecnotpassqty = 0M;
        private decimal _fsecsamplebreakqty = 0M;
        private decimal _fsecrelateqty = 0M;
        private decimal _fsecqcheckqty = 0M;
        private int _fbacktype = 0;
        private int _fdetailid;
        private int _ftime = 0;
        private int _fsampleconclusion = 0;
        private string _fsambillno = "";
        private int _fsaminterid = 0;
        private int _fsamentryid = 0;
        private string _fentryselfp0386;
        /// <summary>
        /// 
        /// </summary>
        public string FBrNo
        {
            set { _fbrno = value; }
            get { return _fbrno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FInterID
        {
            set { _finterid = value; }
            get { return _finterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FEntryID
        {
            set { _fentryid = value; }
            get { return _fentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FQty
        {
            set { _fqty = value; }
            get { return _fqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FCommitQty
        {
            set { _fcommitqty = value; }
            get { return _fcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FPrice
        {
            set { _fprice = value; }
            get { return _fprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAmount
        {
            set { _famount = value; }
            get { return _famount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FNote
        {
            set { _fnote = value; }
            get { return _fnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FInvoiceQty
        {
            set { _finvoiceqty = value; }
            get { return _finvoiceqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FBCommitQty
        {
            set { _fbcommitqty = value; }
            get { return _fbcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FQCheckQty
        {
            set { _fqcheckqty = value; }
            get { return _fqcheckqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQCheckQty
        {
            set { _fauxqcheckqty = value; }
            get { return _fauxqcheckqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FUnitID
        {
            set { _funitid = value; }
            get { return _funitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxBCommitQty
        {
            set { _fauxbcommitqty = value; }
            get { return _fauxbcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxCommitQty
        {
            set { _fauxcommitqty = value; }
            get { return _fauxcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxInvoiceQty
        {
            set { _fauxinvoiceqty = value; }
            get { return _fauxinvoiceqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxPrice
        {
            set { _fauxprice = value; }
            get { return _fauxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQty
        {
            set { _fauxqty = value; }
            get { return _fauxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceEntryID
        {
            set { _fsourceentryid = value; }
            get { return _fsourceentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FQtyPass
        {
            set { _fqtypass = value; }
            get { return _fqtypass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQtyPass
        {
            set { _fauxqtypass = value; }
            get { return _fauxqtypass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FMapNumber
        {
            set { _fmapnumber = value; }
            get { return _fmapnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FMapName
        {
            set { _fmapname = value; }
            get { return _fmapname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBatchNo
        {
            set { _fbatchno = value; }
            get { return _fbatchno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FKFDate
        {
            set { _fkfdate = value; }
            get { return _fkfdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FKFPeriod
        {
            set { _fkfperiod = value; }
            get { return _fkfperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FDCSPID
        {
            set { _fdcspid = value; }
            get { return _fdcspid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FAuxPropID
        {
            set { _fauxpropid = value; }
            get { return _fauxpropid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FDCStockID
        {
            set { _fdcstockid = value; }
            get { return _fdcstockid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FFetchDate
        {
            set { _ffetchdate = value; }
            get { return _ffetchdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCoefficient
        {
            set { _fseccoefficient = value; }
            get { return _fseccoefficient; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQty
        {
            set { _fsecqty = value; }
            get { return _fsecqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCommitQty
        {
            set { _fseccommitqty = value; }
            get { return _fseccommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceTranType
        {
            set { _fsourcetrantype = value; }
            get { return _fsourcetrantype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSourceInterId
        {
            set { _fsourceinterid = value; }
            get { return _fsourceinterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSourceBillNo
        {
            set { _fsourcebillno = value; }
            get { return _fsourcebillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FContractInterID
        {
            set { _fcontractinterid = value; }
            get { return _fcontractinterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FContractEntryID
        {
            set { _fcontractentryid = value; }
            get { return _fcontractentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FContractBillNo
        {
            set { _fcontractbillno = value; }
            get { return _fcontractbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FOrderInterID
        {
            set { _forderinterid = value; }
            get { return _forderinterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FOrderEntryID
        {
            set { _forderentryid = value; }
            get { return _forderentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderBillNo
        {
            set { _forderbillno = value; }
            get { return _forderbillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FStockID
        {
            set { _fstockid = value; }
            get { return _fstockid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FPeriodDate
        {
            set { _fperioddate = value; }
            get { return _fperioddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FNotPassQty
        {
            set { _fnotpassqty = value; }
            get { return _fnotpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FNPCommitQty
        {
            set { _fnpcommitqty = value; }
            get { return _fnpcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSampleBreakQty
        {
            set { _fsamplebreakqty = value; }
            get { return _fsamplebreakqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FConPassQty
        {
            set { _fconpassqty = value; }
            get { return _fconpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FConCommitQty
        {
            set { _fconcommitqty = value; }
            get { return _fconcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxNotPassQty
        {
            set { _fauxnotpassqty = value; }
            get { return _fauxnotpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxNPCommitQty
        {
            set { _fauxnpcommitqty = value; }
            get { return _fauxnpcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxSampleBreakQty
        {
            set { _fauxsamplebreakqty = value; }
            get { return _fauxsamplebreakqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxConPassQty
        {
            set { _fauxconpassqty = value; }
            get { return _fauxconpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxConCommitQty
        {
            set { _fauxconcommitqty = value; }
            get { return _fauxconcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxRelateQty
        {
            set { _fauxrelateqty = value; }
            get { return _fauxrelateqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FRelateQty
        {
            set { _frelateqty = value; }
            get { return _frelateqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FBackQty
        {
            set { _fbackqty = value; }
            get { return _fbackqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxBackQty
        {
            set { _fauxbackqty = value; }
            get { return _fauxbackqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecBackQty
        {
            set { _fsecbackqty = value; }
            get { return _fsecbackqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecConCommitQty
        {
            set { _fsecconcommitqty = value; }
            get { return _fsecconcommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FPlanMode
        {
            set { _fplanmode = value; }
            get { return _fplanmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FMTONo
        {
            set { _fmtono = value; }
            get { return _fmtono; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FOrderType
        {
            set { _fordertype = value; }
            get { return _fordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FEntryAccessoryCount
        {
            set { _fentryaccessorycount = value; }
            get { return _fentryaccessorycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDeliveryNoticeEntryID
        {
            set { _fdeliverynoticeentryid = value; }
            get { return _fdeliverynoticeentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FDeliveryNoticeFID
        {
            set { _fdeliverynoticefid = value; }
            get { return _fdeliverynoticefid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FDischarged
        {
            set { _fdischarged = value; }
            get { return _fdischarged; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FCheckMethod
        {
            set { _fcheckmethod = value; }
            get { return _fcheckmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FScrapQty
        {
            set { _fscrapqty = value; }
            get { return _fscrapqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxScrapQty
        {
            set { _fauxscrapqty = value; }
            get { return _fauxscrapqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecScrapQty
        {
            set { _fsecscrapqty = value; }
            get { return _fsecscrapqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecConCommiqty
        {
            set { _fsecconcommiqty = value; }
            get { return _fsecconcommiqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FScrapInCommitQty
        {
            set { _fscrapincommitqty = value; }
            get { return _fscrapincommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxScrapInCommitQty
        {
            set { _fauxscrapincommitqty = value; }
            get { return _fauxscrapincommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecScrapInCommitQty
        {
            set { _fsecscrapincommitqty = value; }
            get { return _fsecscrapincommitqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQtyPass
        {
            set { _fsecqtypass = value; }
            get { return _fsecqtypass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecConPassQty
        {
            set { _fsecconpassqty = value; }
            get { return _fsecconpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecNotPassQty
        {
            set { _fsecnotpassqty = value; }
            get { return _fsecnotpassqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecSampleBreakQty
        {
            set { _fsecsamplebreakqty = value; }
            get { return _fsecsamplebreakqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecRelateQty
        {
            set { _fsecrelateqty = value; }
            get { return _fsecrelateqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQCheckQty
        {
            set { _fsecqcheckqty = value; }
            get { return _fsecqcheckqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FBackType
        {
            set { _fbacktype = value; }
            get { return _fbacktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FDetailID
        {
            set { _fdetailid = value; }
            get { return _fdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FTime
        {
            set { _ftime = value; }
            get { return _ftime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSampleConclusion
        {
            set { _fsampleconclusion = value; }
            get { return _fsampleconclusion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FSamBillNo
        {
            set { _fsambillno = value; }
            get { return _fsambillno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSamInterID
        {
            set { _fsaminterid = value; }
            get { return _fsaminterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FSamEntryID
        {
            set { _fsamentryid = value; }
            get { return _fsamentryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FEntrySelfP0386
        {
            set { _fentryselfp0386 = value; }
            get { return _fentryselfp0386; }
        }
        #endregion Model

    }
#endregion

}

