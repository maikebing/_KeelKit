using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Keel
{
    internal enum OleDbHResult
    {
        CO_E_CLASSSTRING = -2147221005,
        CO_E_NOTINITIALIZED = -2147221008,
        DB_E_ABORTLIMITREACHED = -2147217871,
        DB_E_ALREADYINITIALIZED = -2147217838,
        DB_E_ASYNCNOTSUPPORTED = -2147217771,
        DB_E_BADACCESSORFLAGS = -2147217850,
        DB_E_BADACCESSORHANDLE = -2147217920,
        DB_E_BADACCESSORTYPE = -2147217845,
        DB_E_BADBINDINFO = -2147217912,
        DB_E_BADBOOKMARK = -2147217906,
        DB_E_BADCHAPTER = -2147217914,
        DB_E_BADCOLUMNID = -2147217903,
        DB_E_BADCOMMANDFLAGS = -2147217780,
        DB_E_BADCOMMANDID = -2147217802,
        DB_E_BADCOMPAREOP = -2147217881,
        DB_E_BADCONSTRAINTFORM = -2147217800,
        DB_E_BADCONSTRAINTID = -2147217781,
        DB_E_BADCONSTRAINTTYPE = -2147217801,
        DB_E_BADCONVERTFLAG = -2147217828,
        DB_E_BADCOPY = -2147217863,
        DB_E_BADDEFERRABILITY = -2147217799,
        DB_E_BADDYNAMICERRORID = -2147217830,
        DB_E_BADHRESULT = -2147217832,
        DB_E_BADINDEXID = -2147217806,
        DB_E_BADINITSTRING = -2147217805,
        DB_E_BADLOCKMODE = -2147217905,
        DB_E_BADLOOKUPID = -2147217831,
        DB_E_BADMATCHTYPE = -2147217792,
        DB_E_BADORDINAL = -2147217835,
        DB_E_BADPARAMETERNAME = -2147217827,
        DB_E_BADPRECISION = -2147217862,
        DB_E_BADPROPERTYVALUE = -2147217852,
        DB_E_BADRATIO = -2147217902,
        DB_E_BADRECORDNUM = -2147217854,
        DB_E_BADREGIONHANDLE = -2147217878,
        DB_E_BADROWHANDLE = -2147217916,
        DB_E_BADSCALE = -2147217861,
        DB_E_BADSOURCEHANDLE = -2147217840,
        DB_E_BADSTARTPOSITION = -2147217890,
        DB_E_BADSTATUSVALUE = -2147217880,
        DB_E_BADSTORAGEFLAG = -2147217882,
        DB_E_BADSTORAGEFLAGS = -2147217849,
        DB_E_BADTABLEID = -2147217860,
        DB_E_BADTYPE = -2147217859,
        DB_E_BADTYPENAME = -2147217872,
        DB_E_BADUPDATEDELETERULE = -2147217782,
        DB_E_BADVALUES = -2147217901,
        DB_E_BOOKMARKSKIPPED = -2147217853,
        DB_E_BYREFACCESSORNOTSUPPORTED = -2147217848,
        DB_E_CANCELED = -2147217842,
        DB_E_CANNOTCONNECT = -2147217770,
        DB_E_CANNOTFREE = -2147217894,
        DB_E_CANNOTRESTART = -2147217896,
        DB_E_CANTCANCEL = -2147217899,
        DB_E_CANTCONVERTVALUE = -2147217913,
        DB_E_CANTFETCHBACKWARDS = -2147217884,
        DB_E_CANTFILTER = -2147217825,
        DB_E_CANTORDER = -2147217824,
        DB_E_CANTSCROLLBACKWARDS = -2147217879,
        DB_E_CANTTRANSLATE = -2147217869,
        DB_E_CHAPTERNOTRELEASED = -2147217841,
        DB_E_COMMANDNOTPERSISTED = -2147217817,
        DB_E_CONCURRENCYVIOLATION = -2147217864,
        DB_E_COSTLIMIT = -2147217907,
        DB_E_DATAOVERFLOW = -2147217833,
        DB_E_DELETEDROW = -2147217885,
        DB_E_DIALECTNOTSUPPORTED = -2147217898,
        DB_E_DROPRESTRICTED = -2147217776,
        DB_E_DUPLICATECOLUMNID = -2147217858,
        DB_E_DUPLICATECONSTRAINTID = -2147217767,
        DB_E_DUPLICATEDATASOURCE = -2147217897,
        DB_E_DUPLICATEID = -2147217816,
        DB_E_DUPLICATEINDEXID = -2147217868,
        DB_E_DUPLICATETABLEID = -2147217857,
        DB_E_ERRORSINCOMMAND = -2147217900,
        DB_E_ERRORSOCCURRED = -2147217887,
        DB_E_GOALREJECTED = -2147217892,
        DB_E_INDEXINUSE = -2147217866,
        DB_E_INTEGRITYVIOLATION = -2147217873,
        DB_E_INVALID = -2147217851,
        DB_E_INVALIDTRANSITION = -2147217876,
        DB_E_LIMITREJECTED = -2147217909,
        DB_E_MAXPENDCHANGESEXCEEDED = -2147217836,
        DB_E_MISMATCHEDPROVIDER = -2147217803,
        DB_E_MULTIPLESTATEMENTS = -2147217874,
        DB_E_MULTIPLESTORAGE = -2147217826,
        DB_E_NEWLYINSERTED = -2147217893,
        DB_E_NOAGGREGATION = -2147217886,
        DB_E_NOCOLUMN = -2147217819,
        DB_E_NOCOMMAND = -2147217908,
        DB_E_NOINDEX = -2147217867,
        DB_E_NOLOCALE = -2147217855,
        DB_E_NONCONTIGUOUSRANGE = -2147217877,
        DB_E_NOPROVIDERSREGISTERED = -2147217804,
        DB_E_NOQUERY = -2147217889,
        DB_E_NOSOURCEOBJECT = -2147217775,
        DB_E_NOTABLE = -2147217865,
        DB_E_NOTAREFERENCECOLUMN = -2147217910,
        DB_E_NOTASUBREGION = -2147217875,
        DB_E_NOTCOLLECTION = -2147217773,
        DB_E_NOTFOUND = -2147217895,
        DB_E_NOTPREPARED = -2147217846,
        DB_E_NOTREENTRANT = -2147217888,
        DB_E_NOTSUPPORTED = -2147217837,
        DB_E_NULLACCESSORNOTSUPPORTED = -2147217847,
        DB_E_OBJECTCREATIONLIMITREACHED = -2147217815,
        DB_E_OBJECTMISMATCH = -2147217779,
        DB_E_OBJECTOPEN = -2147217915,
        DB_E_OUTOFSPACE = -2147217766,
        DB_E_PARAMNOTOPTIONAL = -2147217904,
        DB_E_PARAMUNAVAILABLE = -2147217839,
        DB_E_PENDINGCHANGES = -2147217834,
        DB_E_PENDINGINSERT = -2147217829,
        DB_E_REOLEDBNLY = -2147217772,
        DB_E_REOLEDBNLYACCESSOR = -2147217918,
        DB_E_RESOURCEEXISTS = -2147217768,
        DB_E_RESOURCELOCKED = -2147217774,
        DB_E_RESOURCEOUTOFSCOPE = -2147217778,
        DB_E_ROWLIMITEXCEEDED = -2147217919,
        DB_E_ROWSETINCOMMAND = -2147217870,
        DB_E_ROWSNOTRELEASED = -2147217883,
        DB_E_SCHEMAVIOLATION = -2147217917,
        DB_E_TABLEINUSE = -2147217856,
        DB_E_TIMEOUT = -2147217769,
        DB_E_UNSUPPORTEDCONVERSION = -2147217891,
        DB_E_WRITEONLYACCESSOR = -2147217844,
        DB_S_ASYNCHRONOUS = 0x40ed0,
        DB_S_BADROWHANDLE = 0x40ed3,
        DB_S_BOOKMARKSKIPPED = 0x40ec3,
        DB_S_BUFFERFULL = 0x40ec8,
        DB_S_CANTRELEASE = 0x40eca,
        DB_S_COLUMNSCHANGED = 0x40ed1,
        DB_S_COLUMNTYPEMISMATCH = 0x40ec1,
        DB_S_COMMANDREEXECUTED = 0x40ec7,
        DB_S_DELETEDROW = 0x40ed4,
        DB_S_DIALECTIGNORED = 0x40ecd,
        DB_S_ENDOFROWSET = 0x40ec6,
        DB_S_ERRORSOCCURRED = 0x40eda,
        DB_S_ERRORSRETURNED = 0x40ed2,
        DB_S_GOALCHANGED = 0x40ecb,
        DB_S_LOCKUPGRADED = 0x40ed8,
        DB_S_MULTIPLECHANGES = 0x40edc,
        DB_S_NONEXTROWSET = 0x40ec5,
        DB_S_NORESULT = 0x40ec9,
        DB_S_NOROWSPECIFICCOLUMNS = 0x40edd,
        DB_S_NOTSINGLETON = 0x40ed7,
        DB_S_PARAMUNAVAILABLE = 0x40edb,
        DB_S_PROPERTIESCHANGED = 0x40ed9,
        DB_S_ROWLIMITEXCEEDED = 0x40ec0,
        DB_S_STOPLIMITREACHED = 0x40ed6,
        DB_S_TOOMANYCHANGES = 0x40ed5,
        DB_S_TYPEINFOOVERRIDDEN = 0x40ec2,
        DB_S_UNWANTEDOPERATION = 0x40ecc,
        DB_S_UNWANTEDPHASE = 0x40ece,
        DB_S_UNWANTEDREASON = 0x40ecf,
        DB_SEC_E_AUTH_FAILED = -2147217843,
        DB_SEC_E_PERMISSIONDENIED = -2147217911,
        DB_SEC_E_SAFEMODE_DENIED = -2147217765,
        E_ABORT = -2147467260,
        E_ACCESSDENIED = -2147024891,
        E_FAIL = -2147467259,
        E_HANDLE = -2147024890,
        E_INVALIDARG = -2147024809,
        E_NOINTERFACE = -2147467262,
        E_NOTIMPL = -2147467263,
        E_OUTOFMEMORY = -2147024882,
        E_POINTER = -2147467261,
        E_UNEXPECTED = -2147418113,
        MD_E_BADCOORDINATE = -2147217822,
        MD_E_BADTUPLE = -2147217823,
        MD_E_INVALIDAXIS = -2147217821,
        MD_E_INVALIDCELLRANGE = -2147217820,
        REGDB_E_CLASSNOTREG = -2147221164,
        S_FALSE = 1,
        S_OK = 0,
        SEC_E_BADTRUSTEEID = -2147217814,
        SEC_E_INVALIDACCESSENTRY = -2147217807,
        SEC_E_INVALIDACCESSENTRYLIST = -2147217809,
        SEC_E_INVALIDOBJECT = -2147217811,
        SEC_E_INVALIDOWNER = -2147217808,
        SEC_E_NOMEMBERSHIPSUPPORT = -2147217812,
        SEC_E_NOOWNER = -2147217810,
        SEC_E_NOTRUSTEEID = -2147217813,
        STG_E_ABNORMALAPIEXIT = -2147286790,
        STG_E_ACCESSDENIED = -2147287035,
        STG_E_BADBASEADDRESS = -2147286768,
        STG_E_CANTSAVE = -2147286781,
        STG_E_DISKISWRITEPROTECTED = -2147287021,
        STG_E_DOCFILECORRUPT = -2147286775,
        STG_E_EXTANTMARSHALLINGS = -2147286776,
        STG_E_FILEALREADYEXISTS = -2147286960,
        STG_E_FILENOTFOUND = -2147287038,
        STG_E_INCOMPLETE = -2147286527,
        STG_E_INSUFFICIENTMEMORY = -2147287032,
        STG_E_INUSE = -2147286784,
        STG_E_INVALIDFLAG = -2147286785,
        STG_E_INVALIDFUNCTION = -2147287039,
        STG_E_INVALIDHANDLE = -2147287034,
        STG_E_INVALIDHEADER = -2147286789,
        STG_E_INVALIDNAME = -2147286788,
        STG_E_INVALIDPARAMETER = -2147286953,
        STG_E_INVALIDPOINTER = -2147287031,
        STG_E_LOCKVIOLATION = -2147287007,
        STG_E_MEDIUMFULL = -2147286928,
        STG_E_NOMOREFILES = -2147287022,
        STG_E_NOTCURRENT = -2147286783,
        STG_E_NOTFILEBASEDSTORAGE = -2147286777,
        STG_E_OLDDLL = -2147286779,
        STG_E_OLDFORMAT = -2147286780,
        STG_E_PATHNOTFOUND = -2147287037,
        STG_E_PROPSETMISMATCHED = -2147286800,
        STG_E_READFAULT = -2147287010,
        STG_E_REVERTED = -2147286782,
        STG_E_SEEKERROR = -2147287015,
        STG_E_SHAREREQUIRED = -2147286778,
        STG_E_SHAREVIOLATION = -2147287008,
        STG_E_TERMINATED = -2147286526,
        STG_E_TOOMANYOPENFILES = -2147287036,
        STG_E_UNIMPLEMENTEDFUNCTION = -2147286786,
        STG_E_UNKNOWN = -2147286787,
        STG_E_WRITEFAULT = -2147287011,
        STG_S_BLOCK = 0x30201,
        STG_S_CONVERTED = 0x30200,
        STG_S_MONITORING = 0x30203,
        STG_S_RETRYNOW = 0x30202,
        XACT_E_ABORTED = -2147168231,
        XACT_E_ALREADYINPROGRESS = -2147168232,
        XACT_E_ALREADYOTHERSINGLEPHASE = -2147168256,
        XACT_E_CANTRETAIN = -2147168255,
        XACT_E_CLERKEXISTS = -2147168127,
        XACT_E_CLERKNOTFOUND = -2147168128,
        XACT_E_COMMITFAILED = -2147168254,
        XACT_E_COMMITPREVENTED = -2147168253,
        XACT_E_CONNECTION_DENIED = -2147168227,
        XACT_E_CONNECTION_DOWN = -2147168228,
        XACT_E_DEST_TMNOTAVAILABLE = -2147168222,
        XACT_E_FIRST = -2147168256,
        XACT_E_HEURISTICABORT = -2147168252,
        XACT_E_HEURISTICCOMMIT = -2147168251,
        XACT_E_HEURISTICDAMAGE = -2147168250,
        XACT_E_HEURISTICDANGER = -2147168249,
        XACT_E_INDOUBT = -2147168234,
        XACT_E_INVALIDCOOKIE = -2147168235,
        XACT_E_INVALIDLSN = -2147168124,
        XACT_E_ISOLATIONLEVEL = -2147168248,
        XACT_E_LAST = -2147168222,
        XACT_E_LOGFULL = -2147168230,
        XACT_E_NOASYNC = -2147168247,
        XACT_E_NOENLIST = -2147168246,
        XACT_E_NOIMPORTOBJECT = -2147168236,
        XACT_E_NOISORETAIN = -2147168245,
        XACT_E_NORESOURCE = -2147168244,
        XACT_E_NOTCURRENT = -2147168243,
        XACT_E_NOTIMEOUT = -2147168233,
        XACT_E_NOTRANSACTION = -2147168242,
        XACT_E_NOTSUPPORTED = -2147168241,
        XACT_E_RECOVERYINPROGRESS = -2147168126,
        XACT_E_REENLISTTIMEOUT = -2147168226,
        XACT_E_REPLAYREQUEST = -2147168123,
        XACT_E_TIP_CONNECT_FAILED = -2147168225,
        XACT_E_TIP_PROTOCOL_ERROR = -2147168224,
        XACT_E_TIP_PULL_FAILED = -2147168223,
        XACT_E_TMNOTAVAILABLE = -2147168229,
        XACT_E_TRANSACTIONCLOSED = -2147168125,
        XACT_E_UNKNOWNRMGRID = -2147168240,
        XACT_E_WRONGSTATE = -2147168239,
        XACT_E_WRONGUOW = -2147168238,
        XACT_E_XTIONEXISTS = -2147168237,
        XACT_S_ABORTING = 0x4d008,
        XACT_S_ALLNORETAIN = 0x4d007,
        XACT_S_ASYNC = 0x4d000,
        XACT_S_DEFECT = 0x4d001,
        XACT_S_FIRST = 0x4d000,
        XACT_S_LAST = 0x4d009,
        XACT_S_MADECHANGESCONTENT = 0x4d005,
        XACT_S_MADECHANGESINFORM = 0x4d006,
        XACT_S_OKINFORM = 0x4d004,
        XACT_S_REOLEDBNLY = 0x4d002,
        XACT_S_SINGLEPHASE = 0x4d009,
        XACT_S_SOMENORETAIN = 0x4d003
    }


    internal enum DBBindStatus
    {
        OK,
        BADORDINAL,
        UNSUPPORTEDCONVERSION,
        BADBINDINFO,
        BADSTORAGEFLAGS,
        NOINTERFACE,
        MULTIPLESTORAGE
    }



    internal enum DBStatus
    {
        S_OK,
        E_BADACCESSOR,
        E_CANTCONVERTVALUE,
        S_ISNULL,
        S_TRUNCATED,
        E_SIGNMISMATCH,
        E_DATAOVERFLOW,
        E_CANTCREATE,
        E_UNAVAILABLE,
        E_PERMISSIONDENIED,
        E_INTEGRITYVIOLATION,
        E_SCHEMAVIOLATION,
        E_BADSTATUS,
        S_DEFAULT,
        S_CELLEMPTY,
        S_IGNORE,
        E_DOESNOTEXIST,
        E_INVALIDURL,
        E_RESOURCELOCKED,
        E_RESOURCEEXISTS,
        E_CANNOTCOMPLETE,
        E_VOLUMENOTFOUND,
        E_OUTOFSPACE,
        S_CANNOTDELETESOURCE,
        E_READONLY,
        E_RESOURCEOUTOFSCOPE,
        S_ALREADYEXISTS,
        E_CANCELED,
        E_NOTCOLLECTION,
        S_ROWSETCOLUMN
    }





    internal static class ODB
    {
        // Fields
        internal const string _Add = "add";
        internal const string _Keyword = "keyword";
        internal const string _Name = "name";
        internal const string _Value = "value";
        internal const int ADODB_AlreadyClosedError = -2146824584;
        internal const int ADODB_NextResultError = -2146825037;
        internal const string Asynchronous_Processing = "asynchronous processing";
        internal const string AttachDBFileName = "attachdbfilename";
        internal const int CacheIncrement = 10;
        internal const string CHARACTER_MAXIMUM_LENGTH = "CHARACTER_MAXIMUM_LENGTH";
        internal const int CLSCTX_ALL = 0x17;
        internal static Guid CLSID_DataLinks = new Guid(0x2206cdb2, 0x19c1, 0x11d1, 0x89, 0xe0, 0, 0xc0, 0x4f, 0xd7, 0xa8, 0x29);
        internal static readonly Guid CLSID_MSDASQL = new Guid(0xc8b522cb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal const string COLUMN_NAME = "COLUMN_NAME";
        internal const string Connect_Timeout = "connect timeout";
        internal const string Current_Catalog = "current catalog";
        internal const string Data_Source = "data source";
        internal const string DATA_TYPE = "DATA_TYPE";
        internal const string DataLinks_CLSID = @"CLSID\{2206CDB2-19C1-11D1-89E0-00C04FD7A829}\InprocServer32";
        internal const uint DB_ALL_EXCEPT_LIKE = 3;
        internal static readonly IntPtr DB_INVALID_HACCESSOR = ADP.PtrZero;
        internal const uint DB_LIKE_ONLY = 2;
        internal static readonly IntPtr DB_NULL_HCHAPTER = ADP.PtrZero;
        internal static readonly IntPtr DB_NULL_HROW = ADP.PtrZero;
        internal const uint DB_SEARCHABLE = 4;
        internal const uint DB_UNSEARCHABLE = 1;
        internal const int DBACCESSOR_PARAMETERDATA = 4;
        internal const int DBACCESSOR_ROWDATA = 2;
        internal static readonly object DBCOL_SPECIALCOL = new Guid(0xc8b52232, 0x5cf3, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal const string DBCOLUMN_BASECATALOGNAME = "DBCOLUMN_BASECATALOGNAME";
        internal const string DBCOLUMN_BASECOLUMNNAME = "DBCOLUMN_BASECOLUMNNAME";
        internal const string DBCOLUMN_BASESCHEMANAME = "DBCOLUMN_BASESCHEMANAME";
        internal const string DBCOLUMN_BASETABLENAME = "DBCOLUMN_BASETABLENAME";
        internal const string DBCOLUMN_COLUMNSIZE = "DBCOLUMN_COLUMNSIZE";
        internal const string DBCOLUMN_FLAGS = "DBCOLUMN_FLAGS";
        internal const string DBCOLUMN_GUID = "DBCOLUMN_GUID";
        internal const string DBCOLUMN_IDNAME = "DBCOLUMN_IDNAME";
        internal const string DBCOLUMN_ISAUTOINCREMENT = "DBCOLUMN_ISAUTOINCREMENT";
        internal const string DBCOLUMN_ISUNIQUE = "DBCOLUMN_ISUNIQUE";
        internal const string DBCOLUMN_KEYCOLUMN = "DBCOLUMN_KEYCOLUMN";
        internal const string DBCOLUMN_NAME = "DBCOLUMN_NAME";
        internal const string DBCOLUMN_NUMBER = "DBCOLUMN_NUMBER";
        internal const string DBCOLUMN_PRECISION = "DBCOLUMN_PRECISION";
        internal const string DBCOLUMN_PROPID = "DBCOLUMN_PROPID";
        internal const string DBCOLUMN_SCALE = "DBCOLUMN_SCALE";
        internal const string DBCOLUMN_TYPE = "DBCOLUMN_TYPE";
        internal const string DBCOLUMN_TYPEINFO = "DBCOLUMN_TYPEINFO";
        internal const int DBCOLUMNFLAGS_ISBOOKMARK = 1;
        internal const int DBCOLUMNFLAGS_ISFIXEDLENGTH = 0x10;
        internal const int DBCOLUMNFLAGS_ISLONG = 0x80;
        internal const int DBCOLUMNFLAGS_ISLONG_DBCOLUMNFLAGS_ISSTREAM = 0x80080;
        internal const int DBCOLUMNFLAGS_ISNULLABLE = 0x20;
        internal const int DBCOLUMNFLAGS_ISNULLABLE_DBCOLUMNFLAGS_MAYBENULL = 0x60;
        internal const int DBCOLUMNFLAGS_ISROW = 0x200000;
        internal const int DBCOLUMNFLAGS_ISROWID_DBCOLUMNFLAGS_ISROWVER = 0x300;
        internal const int DBCOLUMNFLAGS_ISROWSET = 0x100000;
        internal const int DBCOLUMNFLAGS_ISROWSET_DBCOLUMNFLAGS_ISROW = 0x300000;
        internal const int DBCOLUMNFLAGS_WRITE_DBCOLUMNFLAGS_WRITEUNKNOWN = 12;
        internal static Guid DBGUID_DEFAULT = new Guid(0xc8b521fb, 0x5cf3, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid DBGUID_ROW = new Guid(0xc8b522f7, 0x5cf3, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid DBGUID_ROWDEFAULTSTREAM = new Guid(0xc733ab7, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid DBGUID_ROWSET = new Guid(0xc8b522f6, 0x5cf3, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal const string DbInfoKeywords = "DbInfoKeywords";
        internal const int DBKIND_GUID = 6;
        internal const int DBKIND_GUID_NAME = 0;
        internal const int DBKIND_GUID_PROPID = 1;
        internal const int DBKIND_NAME = 2;
        internal const int DBKIND_PGUID_NAME = 3;
        internal const int DBKIND_PGUID_PROPID = 4;
        internal const int DBKIND_PROPID = 5;
        internal const int DBLITERAL_CATALOG_SEPARATOR = 3;
        internal const int DBLITERAL_QUOTE_PREFIX = 15;
        internal const int DBLITERAL_QUOTE_SUFFIX = 0x1c;
        internal const int DBLITERAL_SCHEMA_SEPARATOR = 0x1b;
        internal const int DBLITERAL_TABLE_NAME = 0x11;
        internal const string DBMS_Version = "dbms version";
        internal const int DBPARAMTYPE_INPUT = 1;
        internal const int DBPARAMTYPE_INPUTOUTPUT = 2;
        internal const int DBPARAMTYPE_OUTPUT = 3;
        internal const int DBPARAMTYPE_RETURNVALUE = 4;
        internal const int DBPROP_ACCESSORDER = 0xe7;
        internal const int DBPROP_AUTH_CACHE_AUTHINFO = 5;
        internal const int DBPROP_AUTH_ENCRYPT_PASSWORD = 6;
        internal const int DBPROP_AUTH_INTEGRATED = 7;
        internal const int DBPROP_AUTH_MASK_PASSWORD = 8;
        internal const int DBPROP_AUTH_PASSWORD = 9;
        internal const int DBPROP_AUTH_PERSIST_ENCRYPTED = 10;
        internal const int DBPROP_AUTH_PERSIST_SENSITIVE_AUTHINFO = 11;
        internal const int DBPROP_AUTH_USERID = 12;
        internal const int DBPROP_CATALOGLOCATION = 0x16;
        internal const int DBPROP_COMMANDTIMEOUT = 0x22;
        internal const int DBPROP_CONNECTIONSTATUS = 0xf4;
        internal const int DBPROP_CURRENTCATALOG = 0x25;
        internal const int DBPROP_DATASOURCENAME = 0x26;
        internal const int DBPROP_DBMSNAME = 40;
        internal const int DBPROP_DBMSVER = 0x29;
        internal const int DBPROP_GROUPBY = 0x2c;
        internal const int DBPROP_HIDDENCOLUMNS = 0x102;
        internal const int DBPROP_IColumnsRowset = 0x7b;
        internal const int DBPROP_IDENTIFIERCASE = 0x2e;
        internal const int DBPROP_INIT_ASYNCH = 200;
        internal const int DBPROP_INIT_BINDFLAGS = 270;
        internal const int DBPROP_INIT_CATALOG = 0xe9;
        internal const int DBPROP_INIT_DATASOURCE = 0x3b;
        internal const int DBPROP_INIT_GENERALTIMEOUT = 0x11c;
        internal const int DBPROP_INIT_HWND = 60;
        internal const int DBPROP_INIT_IMPERSONATION_LEVEL = 0x3d;
        internal const int DBPROP_INIT_LCID = 0xba;
        internal const int DBPROP_INIT_LOCATION = 0x3e;
        internal const int DBPROP_INIT_LOCKOWNER = 0x10f;
        internal const int DBPROP_INIT_MODE = 0x3f;
        internal const int DBPROP_INIT_OLEDBSERVICES = 0xf8;
        internal const int DBPROP_INIT_PROMPT = 0x40;
        internal const int DBPROP_INIT_PROTECTION_LEVEL = 0x41;
        internal const int DBPROP_INIT_PROVIDERSTRING = 160;
        internal const int DBPROP_INIT_TIMEOUT = 0x42;
        internal const int DBPROP_IRow = 0x107;
        internal const int DBPROP_MAXROWS = 0x49;
        internal const int DBPROP_MULTIPLERESULTS = 0xc4;
        internal const int DBPROP_ORDERBYCOLUNSINSELECT = 0x55;
        internal const int DBPROP_PROVIDERFILENAME = 0x60;
        internal const int DBPROP_QUOTEDIDENTIFIERCASE = 100;
        internal const int DBPROP_RESETDATASOURCE = 0xf7;
        internal const int DBPROP_SQLSUPPORT = 0x6d;
        internal const int DBPROP_UNIQUEROWS = 0xee;
        internal const int DBPROPFLAGS_SESSION = 0x1000;
        internal const int DBPROPFLAGS_WRITE = 0x400;
        internal const int DBPROPOPTIONS_OPTIONAL = 1;
        internal const int DBPROPOPTIONS_REQUIRED = 0;
        internal const int DBPROPSTATUS_BADCOLUMN = 4;
        internal const int DBPROPSTATUS_BADOPTION = 3;
        internal const int DBPROPSTATUS_BADVALUE = 2;
        internal const int DBPROPSTATUS_CONFLICTING = 8;
        internal const int DBPROPSTATUS_NOTALLSETTABLE = 5;
        internal const int DBPROPSTATUS_NOTAVAILABLE = 9;
        internal const int DBPROPSTATUS_NOTSET = 7;
        internal const int DBPROPSTATUS_NOTSETTABLE = 6;
        internal const int DBPROPSTATUS_NOTSUPPORTED = 1;
        internal const int DBPROPSTATUS_OK = 0;
        internal const int DBPROPVAL_AO_RANDOM = 2;
        internal const int DBPROPVAL_CL_END = 2;
        internal const int DBPROPVAL_CL_START = 1;
        internal const int DBPROPVAL_CS_COMMUNICATIONFAILURE = 2;
        internal const int DBPROPVAL_CS_INITIALIZED = 1;
        internal const int DBPROPVAL_CS_UNINITIALIZED = 0;
        internal const int DBPROPVAL_GB_COLLATE = 0x10;
        internal const int DBPROPVAL_GB_CONTAINS_SELECT = 4;
        internal const int DBPROPVAL_GB_EQUALS_SELECT = 2;
        internal const int DBPROPVAL_GB_NO_RELATION = 8;
        internal const int DBPROPVAL_GB_NOT_SUPPORTED = 1;
        internal const int DBPROPVAL_IC_LOWER = 2;
        internal const int DBPROPVAL_IC_MIXED = 8;
        internal const int DBPROPVAL_IC_SENSITIVE = 4;
        internal const int DBPROPVAL_IC_UPPER = 1;
        internal const int DBPROPVAL_IN_ALLOWNULL = 0;
        internal const int DBPROPVAL_MR_NOTSUPPORTED = 0;
        internal const int DBPROPVAL_OS_AGR_AFTERSESSION = 8;
        internal const int DBPROPVAL_OS_CLIENTCURSOR = 4;
        internal const int DBPROPVAL_OS_RESOURCEPOOLING = 1;
        internal const int DBPROPVAL_OS_TXNENLISTMENT = 2;
        internal const int DBPROPVAL_RD_RESETALL = -1;
        internal const int DBPROPVAL_SQL_ESCAPECLAUSES = 0x100;
        internal const int DBPROPVAL_SQL_ODBC_MINIMUM = 1;
        internal static readonly IntPtr DBRESULTFLAG_DEFAULT = IntPtr.Zero;
        internal const string DefaultDescription_MSDASQL = "microsoft ole db provider for odbc drivers";
        internal static readonly char[] ErrorTrimCharacters;
        internal const int ExecutedIMultipleResults = 0;
        internal const int ExecutedIRow = 2;
        internal const int ExecutedIRowset = 1;
        internal const string File_Name = "file name";
        internal static Guid IID_ICommandText = new Guid(0xc733a27, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IDBCreateCommand = new Guid(0xc733a1d, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IDBCreateSession = new Guid(0xc733a5d, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IDBInitialize = new Guid(0xc733a8b, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IMultipleResults = new Guid(0xc733a90, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IRow = new Guid(0xc733ab4, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IRowset = new Guid(0xc733a7c, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_ISQLErrorInfo = new Guid(0xc733a74, 0x2a1c, 0x11ce, 0xad, 0xe5, 0, 170, 0, 0x44, 0x77, 0x3d);
        internal static Guid IID_IUnknown = new Guid(0, 0, 0, 0xc0, 0, 0, 0, 0, 0, 0, 70);
        internal static Guid IID_NULL = Guid.Empty;
        internal const string INDEX_NAME = "INDEX_NAME";
        internal const string Initial_Catalog = "initial catalog";
        internal const int InternalStateClosed = 0;
        internal const int InternalStateConnecting = 2;
        internal const int InternalStateExecuting = 5;
        internal const int InternalStateExecutingNot = -5;
        internal const int InternalStateFetching = 9;
        internal const int InternalStateFetchingNot = -9;
        internal const int InternalStateOpen = 1;
        internal const string IS_NULLABLE = "IS_NULLABLE";
        internal const string Keyword = "Keyword";
        internal const int LargeDataSize = 0x2000;
        internal const int MaxProgIdLength = 0xff;
        internal const string MSDASQL = "msdasql";
        internal const string MSDASQLdot = "msdasql.";
        internal const string NULLS = "NULLS";
        internal const string NUMERIC_PRECISION = "NUMERIC_PRECISION";
        internal const string NUMERIC_SCALE = "NUMERIC_SCALE";
        //internal static readonly int OffsetOf_tagDBBINDING_obValue = Marshal.OffsetOf(typeof(tagDBBINDING), "obValue").ToInt32();
        //internal static readonly int OffsetOf_tagDBBINDING_wType = Marshal.OffsetOf(typeof(tagDBBINDING), "wType").ToInt32();
        //internal static readonly int OffsetOf_tagDBLITERALINFO_it = Marshal.OffsetOf(typeof(tagDBLITERALINFO), "it").ToInt32();
        //internal static readonly int OffsetOf_tagDBPROP_Status = Marshal.OffsetOf(typeof(tagDBPROP), "dwStatus").ToInt32();
        //internal static readonly int OffsetOf_tagDBPROP_Value = Marshal.OffsetOf(typeof(tagDBPROP), "vValue").ToInt32();
        //internal static readonly int OffsetOf_tagDBPROPIDSET_PropertySet = Marshal.OffsetOf(typeof(tagDBPROPIDSET), "guidPropertySet").ToInt32();
        //internal static readonly int OffsetOf_tagDBPROPINFO_Value = Marshal.OffsetOf(typeof(tagDBPROPINFO), "vValue").ToInt32();
        //internal static readonly int OffsetOf_tagDBPROPSET_Properties = Marshal.OffsetOf(typeof(tagDBPROPSET), "rgProperties").ToInt32();
        internal const string OLEDB_SERVICES = "OLEDB_SERVICES";
        internal const string ORDINAL_POSITION = "ORDINAL_POSITION";
        internal const string ORDINAL_POSITION_ASC = "ORDINAL_POSITION ASC";
        internal const string PARAMETER_NAME = "PARAMETER_NAME";
        internal const string PARAMETER_TYPE = "PARAMETER_TYPE";
        internal const int ParameterDirectionFlag = 3;
        internal const string Password = "password";
        internal const string Persist_Security_Info = "persist security info";
        internal const int PrepareICommandText = 3;
        internal const string PRIMARY_KEY = "PRIMARY_KEY";
        internal const string Properties = "Properties";
        internal const string Provider = "provider";
        internal const string Pwd = "pwd";
        internal const string RestrictionSupport = "RestrictionSupport";
        internal const string Schema = "Schema";
        internal const string SchemaGuids = "SchemaGuids";
        internal static readonly int SizeOf_Guid = Marshal.SizeOf(typeof(Guid));
        //internal static readonly int SizeOf_tagDBBINDING = Marshal.SizeOf(typeof(tagDBBINDING));
        //internal static readonly int SizeOf_tagDBCOLUMNINFO = Marshal.SizeOf(typeof(tagDBCOLUMNINFO));
        //internal static readonly int SizeOf_tagDBLITERALINFO = Marshal.SizeOf(typeof(tagDBLITERALINFO));
        //internal static readonly int SizeOf_tagDBPROP = Marshal.SizeOf(typeof(tagDBPROP));
        //internal static readonly int SizeOf_tagDBPROPIDSET = Marshal.SizeOf(typeof(tagDBPROPIDSET));
        //internal static readonly int SizeOf_tagDBPROPINFO = Marshal.SizeOf(typeof(tagDBPROPINFO));
        //internal static readonly int SizeOf_tagDBPROPINFOSET = Marshal.SizeOf(typeof(tagDBPROPINFOSET));
        //internal static readonly int SizeOf_tagDBPROPSET = Marshal.SizeOf(typeof(tagDBPROPSET));
        internal static readonly int SizeOf_Variant = (8 + (2 * ADP.PtrSize));
        internal const string TYPE_NAME = "TYPE_NAME";
        internal const string UNIQUE = "UNIQUE";
        internal const string User_ID = "user id";
        internal const short VARIANT_FALSE = 0;
        internal const short VARIANT_TRUE = -1;

        // Methods
        static ODB()
        {
            char[] chArray = new char[3];
            chArray[0] = '\r';
            chArray[1] = '\n';
            ErrorTrimCharacters = chArray;
        }

        internal static ArgumentException AsynchronousNotSupported()
        {
            return ADP.Argument("OleDb_AsynchronousNotSupported");
        }

        internal static InvalidOperationException BadAccessor()
        {
            return ADP.DataAdapter("OleDb_BadAccessor");
        }

        internal static Exception BadStatus_ParamAcc(int index, DBBindStatus status)
        {
            return ADP.DataAdapter("OleDb_BadStatus_ParamAcc");
        }

        internal static InvalidOperationException BadStatusRowAccessor(int i, DBBindStatus rowStatus)
        {
            return ADP.DataAdapter("OleDb_BadStatusRowAccessor");
        }

        internal static InvalidCastException CantConvertValue()
        {
            return ADP.InvalidCast("OleDb_CantConvertValue");
        }

        internal static InvalidOperationException CantCreate(Type type)
        {
            return ADP.DataAdapter("OleDb_CantCreate");
        }

        internal static Exception CommandParameterStatus(string value, Exception inner)
        {
            if (ADP.IsEmpty(value))
            {
                return inner;
            }
            return ADP.InvalidOperation(value, inner);
        }

        internal static void CommandParameterStatus(StringBuilder builder, int index, DBStatus status)
        {
            switch (status)
            {
                case DBStatus.S_OK:
                case DBStatus.S_ISNULL:
                case DBStatus.S_IGNORE:
                    return;

                case DBStatus.E_BADACCESSOR:
                    builder.Append("OleDb_CommandParameterBadAccessor");
                    builder.Append(Environment.NewLine);
                    return;

                case DBStatus.E_CANTCONVERTVALUE:
                    builder.Append("OleDb_CommandParameterCantConvertValue");
                    builder.Append(Environment.NewLine);
                    return;

                case DBStatus.E_SIGNMISMATCH:
                    builder.Append("OleDb_CommandParameterSignMismatch");
                    builder.Append(Environment.NewLine);
                    return;

                case DBStatus.E_DATAOVERFLOW:
                    builder.Append("OleDb_CommandParameterDataOverflow");
                    builder.Append(Environment.NewLine);
                    return;

                case DBStatus.E_UNAVAILABLE:
                    builder.Append("OleDb_CommandParameterUnavailable");
                    builder.Append(Environment.NewLine);
                    return;

                case DBStatus.S_DEFAULT:
                    builder.Append("OleDb_CommandParameterDefault");
                    builder.Append(Environment.NewLine);
                    return;
            }
            builder.Append("OleDb_CommandParameterError");
            builder.Append(Environment.NewLine);
        }

        internal static InvalidOperationException CommandTextNotSupported(string provider, Exception inner)
        {
            return ADP.DataAdapter("OleDb_CommandTextNotSupported");
        }

        internal static InvalidCastException ConversionRequired()
        {
            return ADP.InvalidCast();
        }

        internal static InvalidOperationException DataOverflow(Type type)
        {
            return ADP.DataAdapter("OleDb_DataOverflow");
        }

        internal static InvalidOperationException DBBindingGetVector()
        {
            return ADP.InvalidOperation("OleDb_DBBindingGetVector");
        }

        internal static string ELookup(OleDbHResult hr)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(hr.ToString());
            if ((0 < builder.Length) && char.IsDigit(builder[0]))
            {
                builder.Length = 0;
            }
            builder.Append("(0x");
            builder.Append(((int)hr).ToString("X8", CultureInfo.InvariantCulture));
            builder.Append(")");
            return builder.ToString();
        }

        internal static string FailedGetDescription(OleDbHResult errorcode)
        {
            return "OleDb_FailedGetDescription";
        }

        internal static string FailedGetSource(OleDbHResult errorcode)
        {
            return "OleDb_FailedGetSource";
        }

        internal static ArgumentException Fill_EmptyRecord(string parameter, Exception innerException)
        {
            return ADP.Argument("OleDb_Fill_EmptyRecord");
        }

        internal static ArgumentException Fill_EmptyRecordSet(string parameter, Exception innerException)
        {
            return ADP.Argument("OleDb_Fill_EmptyRecordSet");
        }

        internal static ArgumentException Fill_NotADODB(string parameter)
        {
            return ADP.Argument("OleDb_Fill_NotADODB");
        }

        //internal static OleDbHResult GetErrorDescription(UnsafeNativeMethods.IErrorInfo errorInfo, OleDbHResult hresult, out string message)
        //{
        //    Bid.Trace("<oledb.IErrorInfo.GetDescription|API|OS>\n");
        //    OleDbHResult description = errorInfo.GetDescription(out message);
        //    Bid.Trace("<oledb.IErrorInfo.GetDescription|API|OS|RET> %08X{HRESULT}, Message='%ls'\n", description, message);
        //    if ((description < OleDbHResult.S_OK) && ADP.IsEmpty(message))
        //    {
        //        message = FailedGetDescription(description) + Environment.NewLine + ELookup(hresult);
        //    }
        //    if (ADP.IsEmpty(message))
        //    {
        //        message = ELookup(hresult);
        //    }
        //    return description;
        //}

        internal static InvalidOperationException GVtUnknown(int wType)
        {
            return ADP.DataAdapter("OleDb_GVtUnknown");
        }

        internal static InvalidOperationException IDBInfoNotSupported()
        {
            return ADP.InvalidOperation("OleDb_IDBInfoNotSupported");
        }

        //internal static Exception InvalidOleDbType(OleDbType value)
        //{
        //    return ADP.InvalidEnumerationValue(typeof(OleDbType), (int) value);
        //}

        internal static ArgumentException InvalidProviderSpecified()
        {
            return ADP.Argument("OleDb_InvalidProviderSpecified");
        }

        internal static ArgumentException InvalidRestrictionsDbInfoKeywords(string parameter)
        {
            return ADP.Argument("OleDb_InvalidRestrictionsDbInfoKeywords" + parameter);
        }

        internal static ArgumentException InvalidRestrictionsDbInfoLiteral(string parameter)
        {
            return ADP.Argument("OleDb_InvalidRestrictionsDbInfoLiteral" + parameter);
        }

        internal static ArgumentException InvalidRestrictionsSchemaGuids(string parameter)
        {
            return ADP.Argument("OleDb_InvalidRestrictionsSchemaGuids" + parameter);
        }

        internal static ArgumentException ISourcesRowsetNotSupported()
        {
            throw ADP.Argument("OleDb_ISourcesRowsetNotSupported");
        }

        internal static InvalidOperationException MDACNotAvailable(Exception inner)
        {
            return ADP.DataAdapter("OleDb_MDACNotAvailable" + inner.Message);
        }

        internal static ArgumentException MSDASQLNotSupported()
        {
            return ADP.Argument("OleDb_MSDASQLNotSupported");
        }

        //internal static OleDbException NoErrorInformation(string provider, OleDbHResult hr, Exception inner)
        //{
        //    OleDbException exception;
        //    if (!ADP.IsEmpty(provider))
        //    {
        //        exception = new OleDbException("OleDb_NoErrorInformation2");
        //    }
        //    else
        //    {
        //        exception = new OleDbException("OleDb_NoErrorInformation", new object[] { ELookup(hr) }), hr, inner);
        //    }
        //    ADP.TraceExceptionAsReturnValue(exception);
        //    return exception;
        //}

        internal static string NoErrorMessage(OleDbHResult errorcode)
        {
            return "OleDb_NoErrorMessage";
        }

        internal static ArgumentException NoProviderSpecified()
        {
            return ADP.Argument("OleDb_NoProviderSpecified");
        }

        internal static Exception NoProviderSupportForParameters(string provider, Exception inner)
        {
            return ADP.DataAdapter("OleDb_NoProviderSupportForParameters");
        }

        internal static Exception NoProviderSupportForSProcResetParameters(string provider)
        {
            return ADP.DataAdapter("OleDb_NoProviderSupportForSProcResetParameters");
        }

        internal static ArgumentException NotSupportedSchemaTable(Guid schema, OleDbConnection connection)
        {
            return ADP.Argument("OleDb_NotSupportedSchemaTable");
        }

        internal static InvalidOperationException PossiblePromptNotUserInteractive()
        {
            return ADP.DataAdapter("OleDb_PossiblePromptNotUserInteractive");
        }

        internal static Exception PropsetSetFailure(string value, Exception inner)
        {
            if (ADP.IsEmpty(value))
            {
                return inner;
            }
            return ADP.InvalidOperation(value, inner);
        }

        //internal static void PropsetSetFailure(StringBuilder builder, string description, OleDbPropertyStatus status)
        //{
        //    switch (status)
        //    {
        //        case OleDbPropertyStatus.NotSupported:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyNotSupported", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.BadValue:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyBadValue", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.BadOption:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyBadOption", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.BadColumn:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyBadColumn", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.NotAllSettable:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyNotAllSettable", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.NotSettable:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyNotSettable", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.NotSet:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyNotSet", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.Conflicting:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyConflicting", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.NotAvailable:
        //            if (0 < builder.Length)
        //            {
        //                builder.Append(Environment.NewLine);
        //            }
        //            builder.Append("OleDb_PropertyNotAvailable", new object[] { description }));
        //            return;

        //        case OleDbPropertyStatus.Ok:
        //            return;
        //    }
        //    if (0 < builder.Length)
        //    {
        //        builder.Append(Environment.NewLine);
        //    }
        //    object[] args = new object[] { ((int) status).ToString(CultureInfo.InvariantCulture) };
        //    builder.Append("OleDb_PropertyStatusUnknown", args));
        //}

        internal static InvalidOperationException ProviderUnavailable(string provider, Exception inner)
        {
            return ADP.DataAdapter("OleDb_ProviderUnavailable");
        }

        internal static ArgumentException SchemaRowsetsNotSupported(string provider)
        {
            return ADP.Argument("OleDb_SchemaRowsetsNotSupported");
        }

        internal static InvalidOperationException SignMismatch(Type type)
        {
            return ADP.DataAdapter("OleDb_SignMismatch");
        }

        internal static InvalidOperationException SVtUnknown(int wType)
        {
            return ADP.DataAdapter("OleDb_SVtUnknown");
        }

        internal static InvalidOperationException ThreadApartmentState(Exception innerException)
        {
            return ADP.InvalidOperation("OleDb_ThreadApartmentState");
        }

        internal static InvalidOperationException TransactionsNotSupported(string provider, Exception inner)
        {
            return ADP.DataAdapter("OleDb_TransactionsNotSupported");
        }

        internal static InvalidOperationException Unavailable(Type type)
        {
            return ADP.DataAdapter("OleDb_Unavailable");
        }

        internal static InvalidOperationException UnexpectedStatusValue(DBStatus status)
        {
            return ADP.DataAdapter("OleDb_UnexpectedStatusValue");
        }

        internal static Exception UninitializedParameters(int index, OleDbType dbtype)
        {
            return ADP.InvalidOperation("OleDb_UninitializedParameters");
        }
    }



}
