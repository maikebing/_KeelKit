using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Data.SqlTypes;
using System.Security.Permissions;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Data.Common;
using System.Transactions;
using Microsoft.Win32;
using System.Security;
using System.Threading;

namespace Keel
{
    internal sealed class ADP
    {
        // Fields
        private static readonly Type AccessViolationType = typeof(AccessViolationException);
        public const string Append = "Append";
        public const string BeginExecuteNonQuery = "BeginExecuteNonQuery";
        public const string BeginExecuteReader = "BeginExecuteReader";
        public const string BeginExecuteXmlReader = "BeginExecuteXmlReader";
        public const string BeginTransaction = "BeginTransaction";
        public const string Cancel = "Cancel";
        public const string ChangeDatabase = "ChangeDatabase";
        public static readonly int CharSize = 2;
        public const string Clone = "Clone";
        public const string CommandTimeout = "CommandTimeout";
        public const string CommitTransaction = "CommitTransaction";
        public const CompareOptions compareOptions = (CompareOptions.IgnoreWidth | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreCase);
        public const string ConnectionString = "ConnectionString";
        public const string DataSetColumn = "DataSetColumn";
        public const string DataSetTable = "DataSetTable";
        public const int DecimalMaxPrecision = 0x1d;
        public const int DecimalMaxPrecision28 = 0x1c;
        public const int DefaultCommandTimeout = 30;
        public const int DefaultConnectionTimeout = 15;
        public const string Delete = "Delete";
        public const string DeleteCommand = "DeleteCommand";
        public const string DeriveParameters = "DeriveParameters";
        public const string EndExecuteNonQuery = "EndExecuteNonQuery";
        public const string EndExecuteReader = "EndExecuteReader";
        public const string EndExecuteXmlReader = "EndExecuteXmlReader";
        public const string ExecuteNonQuery = "ExecuteNonQuery";
        public const string ExecuteReader = "ExecuteReader";
        public const string ExecuteRow = "ExecuteRow";
        public const string ExecuteScalar = "ExecuteScalar";
        public const string ExecuteSqlScalar = "ExecuteSqlScalar";
        public const string ExecuteXmlReader = "ExecuteXmlReader";
        public const float FailoverTimeoutStep = 0.08f;
        public const string Fill = "Fill";
        public const string FillPage = "FillPage";
        public const string FillSchema = "FillSchema";
        public const string GetBytes = "GetBytes";
        public const string GetChars = "GetChars";
        public const string GetOleDbSchemaTable = "GetOleDbSchemaTable";
        public const string GetProperties = "GetProperties";
        public const string GetSchema = "GetSchema";
        public const string GetSchemaTable = "GetSchemaTable";
        public const string GetServerTransactionLevel = "GetServerTransactionLevel";
        private static readonly string hexDigits = "0123456789abcdef";
        public const string Insert = "Insert";
        public static readonly IntPtr InvalidPtr = new IntPtr(-1);
        public static readonly bool IsPlatformNT5 = (IsWindowsNT && (Environment.OSVersion.Version.Major >= 5));
        public static readonly bool IsWindowsNT = (PlatformID.Win32NT == Environment.OSVersion.Platform);
        public static readonly HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);
        private static readonly Type NullReferenceType = typeof(NullReferenceException);
        public const string Open = "Open";
        private static readonly Type OutOfMemoryType = typeof(OutOfMemoryException);
        public const string Parameter = "Parameter";
        public const string ParameterBuffer = "buffer";
        public const string ParameterCount = "count";
        public const string ParameterDestinationType = "destinationType";
        public const string ParameterName = "ParameterName";
        public const string ParameterOffset = "offset";
        public const string ParameterService = "Service";
        public const string ParameterSetPosition = "set_Position";
        public const string ParameterTimeout = "Timeout";
        public const string ParameterUserData = "UserData";
        public const string Prepare = "Prepare";
        public static readonly int PtrSize = IntPtr.Size;
        public static readonly IntPtr PtrZero = new IntPtr(0);
        public const string QuoteIdentifier = "QuoteIdentifier";
        public const string Read = "Read";
        public static readonly IntPtr RecordsUnaffected = new IntPtr(-1);
        public const string Remove = "Remove";
        public const string RollbackTransaction = "RollbackTransaction";
        public const string SaveTransaction = "SaveTransaction";
        private static readonly Type SecurityType = typeof(SecurityException);
        public const string SetProperties = "SetProperties";
        public const string SourceColumn = "SourceColumn";
        public const string SourceTable = "SourceTable";
        public const string SourceVersion = "SourceVersion";
        private static readonly Type StackOverflowType = typeof(StackOverflowException);
        public static readonly string StrEmpty = "";
        private static readonly Type ThreadAbortType = typeof(ThreadAbortException);
        public const string UnquoteIdentifier = "UnquoteIdentifier";
        public const string Update = "Update";
        public const string UpdateCommand = "UpdateCommand";
        public const string UpdateRows = "UpdateRows";

        private static void TraceExceptionAsReturnValue(Exception e)
        {
            e = null;
        }

        public static ArgumentException Argument(string error)
        {
            ArgumentException e = new ArgumentException(error);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentException Argument(string error, Exception inner)
        {
            ArgumentException e = new ArgumentException(error, inner);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentException Argument(string error, string parameter)
        {
            ArgumentException e = new ArgumentException(error, parameter);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentException Argument(string error, string parameter, Exception inner)
        {
            ArgumentException e = new ArgumentException(error, parameter, inner);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentNullException ArgumentNull(string parameter)
        {
            ArgumentNullException e = new ArgumentNullException(parameter);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentNullException ArgumentNull(string parameter, string error)
        {
            ArgumentNullException e = new ArgumentNullException(parameter, error);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName)
        {
            ArgumentOutOfRangeException e = new ArgumentOutOfRangeException(parameterName);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentOutOfRangeException ArgumentOutOfRange(string message, string parameterName)
        {
            ArgumentOutOfRangeException e = new ArgumentOutOfRangeException(parameterName, message);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static ArgumentOutOfRangeException ArgumentOutOfRange(string message, string parameterName, object value)
        {
            ArgumentOutOfRangeException e = new ArgumentOutOfRangeException(parameterName, value, message);
            TraceExceptionAsReturnValue(e);
            return e;
        }



        public static string BuildQuotedString(string quotePrefix, string quoteSuffix, string unQuotedString)
        {
            StringBuilder builder = new StringBuilder();
            if (!IsEmpty(quotePrefix))
            {
                builder.Append(quotePrefix);
            }
            if (!IsEmpty(quoteSuffix))
            {
                builder.Append(unQuotedString.Replace(quoteSuffix, quoteSuffix + quoteSuffix));
                builder.Append(quoteSuffix);
            }
            else
            {
                builder.Append(unQuotedString);
            }
            return builder.ToString();
        }

        public static void BuildSchemaTableInfoTableNames(string[] columnNameArray)
        {
            Dictionary<string, int> hash = new Dictionary<string, int>(columnNameArray.Length);
            int length = columnNameArray.Length;
            for (int i = columnNameArray.Length - 1; 0 <= i; i--)
            {
                string key = columnNameArray[i];
                if ((key != null) && (0 < key.Length))
                {
                    int num5;
                    key = key.ToLower(CultureInfo.InvariantCulture);
                    if (hash.TryGetValue(key, out num5))
                    {
                        length = Math.Min(length, num5);
                    }
                    hash[key] = i;
                }
                else
                {
                    columnNameArray[i] = StrEmpty;
                    length = i;
                }
            }
            int uniqueIndex = 1;
            for (int j = length; j < columnNameArray.Length; j++)
            {
                string str2 = columnNameArray[j];
                if (str2.Length == 0)
                {
                    columnNameArray[j] = "Column";
                    uniqueIndex = GenerateUniqueName(hash, ref columnNameArray[j], j, uniqueIndex);
                }
                else
                {
                    str2 = str2.ToLower(CultureInfo.InvariantCulture);
                    if (j != hash[str2])
                    {
                        GenerateUniqueName(hash, ref columnNameArray[j], j, 1);
                    }
                }
            }
        }

        public static byte[] ByteArrayFromString(string hexString, string dataTypeName)
        {
            if ((hexString.Length & 1) != 0)
            {
                return null;
            }
            char[] chArray = hexString.ToCharArray();
            byte[] buffer = new byte[hexString.Length / 2];
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            for (int i = 0; i < hexString.Length; i += 2)
            {
                int index = hexDigits.IndexOf(char.ToLower(chArray[i], invariantCulture));
                int num2 = hexDigits.IndexOf(char.ToLower(chArray[i + 1], invariantCulture));
                if ((index < 0) || (num2 < 0))
                {
                    return null;
                }
                buffer[i / 2] = (byte)((index << 4) | num2);
            }
            return buffer;
        }

        public static void CheckArgumentLength(Array value, string parameterName)
        {
            CheckArgumentNull(value, parameterName);
            if (value.Length == 0)
            {
                //  throw new Exception (("ADP_EmptyArray", new object[] { parameterName }));
            }
        }

        public static void CheckArgumentLength(string value, string parameterName)
        {
            CheckArgumentNull(value, parameterName);
            if (value.Length == 0)
            {
                throw new Exception(("ADP_EmptyString"));
            }
        }

        public static void CheckArgumentNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw ArgumentNull(parameterName);
            }
        }

        //public static void CheckVersionMDAC(bool ifodbcelseoledb)
        //{
        //    string fileVersion;
        //    int fileMinorPart;
        //    int fileMajorPart;
        //    int fileBuildPart;
        //    try
        //    {
        //        fileVersion = (string) LocalMachineRegistryValue(@"Software\Microsoft\DataAccess", "FullInstallVer");
        //        if (IsEmpty(fileVersion))
        //        {
        //            string filename = (string) ClassesRootRegistryValue(@"CLSID\{2206CDB2-19C1-11D1-89E0-00C04FD7A829}\InprocServer32", StrEmpty);
        //            FileVersionInfo versionInfo = GetVersionInfo(filename);
        //            fileMajorPart = versionInfo.FileMajorPart;
        //            fileMinorPart = versionInfo.FileMinorPart;
        //            fileBuildPart = versionInfo.FileBuildPart;
        //            fileVersion = versionInfo.FileVersion;
        //        }
        //        else
        //        {
        //            string[] strArray = fileVersion.Split(new char[] { '.' });
        //            fileMajorPart = int.Parse(strArray[0], NumberStyles.None, CultureInfo.InvariantCulture);
        //            fileMinorPart = int.Parse(strArray[1], NumberStyles.None, CultureInfo.InvariantCulture);
        //            fileBuildPart = int.Parse(strArray[2], NumberStyles.None, CultureInfo.InvariantCulture);
        //            int.Parse(strArray[3], NumberStyles.None, CultureInfo.InvariantCulture);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        if (!IsCatchableExceptionType(exception))
        //        {
        //            throw;
        //        }

        //    }
        //    if ((fileMajorPart < 2) || ((fileMajorPart == 2) && ((fileMinorPart < 60) || ((fileMinorPart == 60) && (fileBuildPart < 0x197e)))))
        //    {
        //        if (ifodbcelseoledb)
        //        {
        //            throw DataAdapter( "Odbc_MDACWrongVersion" );
        //        }
        //        throw DataAdapter( "OleDb_MDACWrongVersion" );
        //    }
        //}

        public static object ClassesRootRegistryValue(string subkey, string queryvalue)
        {
            object obj2;
            new RegistryPermission(RegistryPermissionAccess.Read, @"HKEY_CLASSES_ROOT\" + subkey).Assert();
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(subkey, false))
                {
                    return ((key != null) ? key.GetValue(queryvalue) : null);
                }
            }
            catch (SecurityException)
            {

                obj2 = null;
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
            return obj2;
        }

        //public static Exception ClosedConnectionError()
        //{
        //    return new Exception (("ADP_ClosedConnectionError"));
        //}

        //public static IndexOutOfRangeException CollectionIndexInt32(int index, Type collection, int count)
        //{
        //    return new IndexOutOfRangeException (("ADP_CollectionIndexInt32"));
        //}

        //public static IndexOutOfRangeException CollectionIndexString(Type itemType, string propertyName, string propertyValue, Type collection)
        //{
        //    return new IndexOutOfRangeException (("ADP_CollectionIndexString"));
        //}



        //public static Exception CollectionNameIsNotUnique(string collectionName)
        //{
        //    return new Exception (("MDF_CollectionNameISNotUnique "));
        //}

        //public static ArgumentNullException CollectionNullValue(string parameter, Type collection, Type itemType)
        //{
        //    return new ArgumentNullException(("ADP_CollectionNullValue"));
        //}

        //public static ArgumentException CollectionRemoveInvalidObject(Type itemType, ICollection collection)
        //{
        //    return new ArgumentNullException (("ADP_CollectionRemoveInvalidObject" ));
        //}

        //public static Exception CollectionUniqueValue(Type itemType, string propertyName, string propertyValue)
        //{
        //    return new Exception (("ADP_CollectionUniqueValue" ));
        //}

        //public static Exception ColumnsAddNullAttempt(string parameter)
        //{
        //    return CollectionNullValue(parameter, typeof(DataColumnMappingCollection), typeof(DataColumnMapping));
        //}



        //public static Exception ColumnsDataSetColumn(string cacheColumn)
        //{
        //    return CollectionIndexString(typeof(DataColumnMapping), "DataSetColumn", cacheColumn, typeof(DataColumnMappingCollection));
        //}

        //public static Exception ColumnsIndexInt32(int index, IColumnMappingCollection collection)
        //{
        //    return CollectionIndexInt32(index, collection.GetType(), collection.Count);
        //}

        //public static Exception ColumnsIndexSource(string srcColumn)
        //{
        //    return CollectionIndexString(typeof(DataColumnMapping), "SourceColumn", srcColumn, typeof(DataColumnMappingCollection));
        //}

        //public static Exception ColumnsIsNotParent(ICollection collection)
        //{
        //    return ParametersIsNotParent(typeof(DataColumnMapping), collection);
        //}

        //public static Exception ColumnsIsParent(ICollection collection)
        //{
        //    return ParametersIsParent(typeof(DataColumnMapping), collection);
        //}

        //public static Exception ColumnsUniqueSourceColumn(string srcColumn)
        //{
        //    return CollectionUniqueValue(typeof(DataColumnMapping), "SourceColumn", srcColumn);
        //}

        //public static InvalidOperationException CommandAsyncOperationCompleted()
        //{
        //    return new InvalidOperationException(("SQL_AsyncOperationCompleted"));
        //}

        //public static Exception CommandTextRequired(string method)
        //{
        //    return new InvalidOperationException(("ADP_CommandTextRequired"));
        //}

        //public static bool CompareInsensitiveInvariant(string strvalue, string strconst)
        //{
        //    return (0 == CultureInfo.InvariantCulture.CompareInfo.Compare(strvalue, strconst, CompareOptions.IgnoreCase));
        //}

        //public static InvalidOperationException ComputerNameEx(int lastError)
        //{
        //    return new InvalidOperationException(("ADP_ComputerNameEx"));
        //}

        //public static ConfigurationException ConfigBaseElementsOnly(XmlNode node)
        //{
        //    return new ConfigurationException("ConfigBaseElementsOnly");
        //}

        //public static ConfigurationException ConfigBaseNoChildNodes(XmlNode node)
        //{
        //    return new ConfigurationException("ConfigBaseNoChildNodes");
        //}

        //public static InvalidOperationException ConfigProviderInvalid()
        //{
        //    return new InvalidOperationException(("ConfigProviderInvalid"));
        //}

        //public static ConfigurationException ConfigProviderMissing()
        //{
        //    return new ConfigurationException("ConfigProviderMissing");
        //}



        //public static ConfigurationException ConfigProviderNotInstalled()
        //{
        //    return new ConfigurationException("ConfigProviderNotInstalled");
        //}



        //public static ConfigurationException ConfigSectionsUnique(string sectionName)
        //{
        //    return new ConfigurationException("ConfigSectionsUnique");
        //}





        //public static ConfigurationException ConfigUnrecognizedElement(XmlNode node)
        //{
        //    return new ConfigurationException("ConfigUnrecognizedElement");
        //}

        //public static ConfigurationException Configuration(string message)
        //{
        //    ConfigurationException e = new ConfigurationErrorsException(message);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ConfigurationException Configuration(string message, XmlNode node)
        //{
        //    ConfigurationException e = new ConfigurationErrorsException(message;
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}




        public static Exception ConnectionIsDisabled(Exception InnerException)
        {
            return new InvalidOperationException(("ADP_ConnectionIsDisabled"), InnerException);
        }

        public static InvalidOperationException ConnectionRequired(string method)
        {
            return new InvalidOperationException(("ADP_ConnectionRequired"));
        }

        public static InvalidOperationException ConnectionRequired_Res(string method)
        {
            return new InvalidOperationException(("ADP_ConnectionRequired_" + method));
        }

        //private static string ConnectionStateMsg(ConnectionState state)
        //{
        //    switch (state)
        //    {
        //        case ConnectionState.Closed:
        //        case (ConnectionState.Broken | ConnectionState.Connecting):
        //            return Res.GetString("ADP_ConnectionStateMsg_Closed");

        //        case ConnectionState.Open:
        //            return Res.GetString("ADP_ConnectionStateMsg_Open");

        //        case ConnectionState.Connecting:
        //            return Res.GetString("ADP_ConnectionStateMsg_Connecting");

        //        case (ConnectionState.Executing | ConnectionState.Open):
        //            return Res.GetString("ADP_ConnectionStateMsg_OpenExecuting");

        //        case (ConnectionState.Fetching | ConnectionState.Open):
        //            return Res.GetString("ADP_ConnectionStateMsg_OpenFetching");
        //    }
        //    return Res.GetString("ADP_ConnectionStateMsg", new object[] { state.ToString() });
        //}

        //public static ArgumentException ConnectionStringSyntax(int index)
        //{
        //    return new Exception (("ADP_ConnectionStringSyntax"));
        //}

        //public static ArgumentException ConvertFailed(Type fromType, Type toType, Exception innerException)
        //{
        //    return new Exception (("SqlConvert_ConvertFailed"));
        //}

        public static DataException Data(string message)
        {
            DataException e = new DataException(message);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static InvalidOperationException DataAdapter(string error)
        {
            return InvalidOperation(error);
        }

        public static InvalidOperationException DataAdapter(string error, Exception inner)
        {
            return InvalidOperation(error, inner);
        }

        public static Exception DatabaseNameTooLong()
        {
            return new Exception(("ADP_DatabaseNameTooLong"));
        }

        private static InvalidOperationException DataMapping(string error)
        {
            return InvalidOperation(error);
        }

        public static Exception DataReaderClosed(string method)
        {
            return new InvalidOperationException(("ADP_DataReaderClosed"));
        }

        public static Exception DataReaderNoData()
        {
            return new InvalidOperationException(("ADP_DataReaderNoData"));
        }

        public static Exception DataTableDoesNotExist(string collectionName)
        {
            return new Exception(("MDF_DataTableDoesNotExist"));
        }

        public static Exception DbRecordReadOnly(string methodname)
        {
            return new InvalidOperationException(("ADP_DbRecordReadOnly"));
        }

        public static ArgumentException DbTypeNotSupported(DbType type, Type enumtype)
        {
            return new ArgumentException(("ADP_DbTypeNotSupported"));
        }

        public static Exception DelegatedTransactionPresent()
        {
            return new InvalidOperationException(("ADP_DelegatedTransactionPresent"));
        }

        //public static Exception DeriveParametersNotSupported(IDbCommand value)
        //{
        //    return DataAdapter(Res.GetString("ADP_DeriveParametersNotSupported", new object[] { value.GetType().Name, value.CommandType.ToString() }));
        //}

        //public static ArgumentException DoubleValuedProperty(string propertyName, string value1, string value2)
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_DoubleValuedProperty", new object[] { propertyName, value1, value2 }));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        public static int DstCompare(string strA, string strB)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreWidth | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreCase);
        }

        public static InvalidOperationException DynamicSQLJoinUnsupported()
        {
            return new InvalidOperationException(("ADP_DynamicSQLJoinUnsupported"));
        }

        public static InvalidOperationException DynamicSQLNestedQuote(string name, string quote)
        {
            return new InvalidOperationException(("ADP_DynamicSQLNestedQuote"));
        }

        public static InvalidOperationException DynamicSQLNoKeyInfoDelete()
        {
            return new InvalidOperationException(("ADP_DynamicSQLNoKeyInfoDelete"));
        }

        public static InvalidOperationException DynamicSQLNoKeyInfoRowVersionDelete()
        {
            return new InvalidOperationException(("ADP_DynamicSQLNoKeyInfoRowVersionDelete"));
        }

        public static InvalidOperationException DynamicSQLNoKeyInfoRowVersionUpdate()
        {
            return new InvalidOperationException(("ADP_DynamicSQLNoKeyInfoRowVersionUpdate"));
        }

        public static InvalidOperationException DynamicSQLNoKeyInfoUpdate()
        {
            return new InvalidOperationException(("ADP_DynamicSQLNoKeyInfoUpdate"));
        }

        public static InvalidOperationException DynamicSQLNoTableInfo()
        {
            return new InvalidOperationException(("ADP_DynamicSQLNoTableInfo"));
        }

        public static Exception EmptyDatabaseName()
        {
            return new Exception(("ADP_EmptyDatabaseName"));
        }

        public static void EscapeSpecialCharacters(string unescapedString, StringBuilder escapedString)
        {
            foreach (char ch in unescapedString)
            {
                if (@".$^{[(|)*+?\]".IndexOf(ch) >= 0)
                {
                    escapedString.Append(@"\");
                }
                escapedString.Append(ch);
            }
        }

        //public static Exception EvenLengthLiteralValue(string argumentName)
        //{
        //    return new Exception (("ADP_EvenLengthLiteralValue"), argumentName);
        //}

        //public static Exception ExceedsMaxDataLength(long specifiedLength, long maxLength)
        //{
        //    return IndexOutOfRange(Res.GetString("SQL_ExceedsMaxDataLength", new object[] { specifiedLength.ToString(CultureInfo.InvariantCulture), maxLength.ToString(CultureInfo.InvariantCulture) }));
        //}

        public static Exception FillChapterAutoIncrement()
        {
            return new InvalidOperationException(("ADP_FillChapterAutoIncrement"));
        }

        public static Exception FillRequires(string parameter)
        {
            return ArgumentNull(parameter);
        }

        //public static Exception FillRequiresSourceTableName(string parameter)
        //{
        //    return new Exception (("ADP_FillRequiresSourceTableName"), parameter);
        //}

        //public static Exception FillSchemaRequiresSourceTableName(string parameter)
        //{
        //    return new Exception (("ADP_FillSchemaRequiresSourceTableName"), parameter);
        //}

        public static Delegate FindBuilder(MulticastDelegate mcd)
        {
            if (mcd != null)
            {
                Delegate[] invocationList = mcd.GetInvocationList();
                for (int i = 0; i < invocationList.Length; i++)
                {
                    if (invocationList[i].Target is DbCommandBuilder)
                    {
                        return invocationList[i];
                    }
                }
            }
            return null;
        }

        public static string FixUpDecimalSeparator(string numericString, bool formatLiteral, string decimalSeparator, char[] exponentSymbols)
        {
            if (numericString.IndexOfAny(exponentSymbols) == -1)
            {
                if (IsEmpty(decimalSeparator))
                {
                    decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                }
                if (formatLiteral)
                {
                    return numericString.Replace(".", decimalSeparator);
                }
                return numericString.Replace(decimalSeparator, ".");
            }
            return numericString;
        }

        private static int GenerateUniqueName(Dictionary<string, int> hash, ref string columnName, int index, int uniqueIndex)
        {
            while (true)
            {
                string str2 = columnName + uniqueIndex.ToString(CultureInfo.InvariantCulture);
                string key = str2.ToLower(CultureInfo.InvariantCulture);
                if (!hash.ContainsKey(key))
                {
                    columnName = str2;
                    hash.Add(key, index);
                    return uniqueIndex;
                }
                uniqueIndex++;
            }
        }

        //public static string GetComputerNameDnsFullyQualified()
        //{
        //    int bufferSize = 0x100;
        //    if (IsPlatformNT5)
        //    {
        //        SafeNativeMethods.GetComputerNameEx(3, null, ref bufferSize);
        //        StringBuilder nameBuffer = new StringBuilder(bufferSize);
        //        bufferSize = nameBuffer.Capacity;
        //        if (SafeNativeMethods.GetComputerNameEx(3, nameBuffer, ref bufferSize) == 0)
        //        {
        //            throw ComputerNameEx(Marshal.GetLastWin32Error());
        //        }
        //        return nameBuffer.ToString();
        //    }
        //    return MachineName();
        //}

        [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static int GetCurrentThreadId()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        public static Transaction GetCurrentTransaction()
        {
            return Transaction.Current;
        }

        public static Stream GetFileStream(string filename)
        {
            Stream stream=null ;
            new FileIOPermission(FileIOPermissionAccess.Read, filename).Assert();
            try
            {
                stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
               if (stream !=null ) stream.Dispose();
            }
            return stream;
        }

        [FileIOPermission(SecurityAction.Assert, AllFiles = FileIOPermissionAccess.PathDiscovery)]
        public static string GetFullPath(string filename)
        {
            return Path.GetFullPath(filename);
        }

        public static IDtcTransaction GetOletxTransaction(Transaction transaction)
        {
            IDtcTransaction dtcTransaction = null;
            if (null != transaction)
            {
                dtcTransaction = TransactionInterop.GetDtcTransaction(transaction);
            }
            return dtcTransaction;
        }

        public static FileVersionInfo GetVersionInfo(string filename)
        {
            FileVersionInfo versionInfo;
            new FileIOPermission(FileIOPermissionAccess.Read, filename).Assert();
            try
            {
                versionInfo = FileVersionInfo.GetVersionInfo(filename);
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
            return versionInfo;
        }

        //public static Stream GetXmlStream(string value, string errorString)
        //{
        //    Stream fileStream;
        //    string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
        //    if (runtimeDirectory == null)
        //    {
        //       // throw ConfigUnableToLoadXmlMetaDataFile(errorString);
        //    }
        //    StringBuilder builder = new StringBuilder((runtimeDirectory.Length + @"config\".Length) + value.Length);
        //    builder.Append(runtimeDirectory);
        //    builder.Append(@"config\");
        //    builder.Append(value);
        //    string filename = builder.ToString();
        //    if (GetFullPath(filename) != filename)
        //    {
        //        throw ConfigUnableToLoadXmlMetaDataFile(errorString);
        //    }
        //    try
        //    {
        //        fileStream = GetFileStream(filename);
        //    }
        //    catch (Exception exception)
        //    {
        //        if (!IsCatchableExceptionType(exception))
        //        {
        //            throw;
        //        }
        //        throw ConfigUnableToLoadXmlMetaDataFile(errorString);
        //    }
        //    return fileStream;
        //}

        //public static Stream GetXmlStreamFromValues(string[] values, string errorString)
        //{
        //    if (values.Length != 1)
        //    {
        //        throw ConfigWrongNumberOfValues(errorString);
        //    }
        //    return GetXmlStream(values[0], errorString);
        //}

        //public static Exception HexDigitLiteralValue(string argumentName)
        //{
        //    return new Exception (("ADP_HexDigitLiteralValue"), argumentName);
        //}

        //public static ArgumentException IncorrectAsyncResult()
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_IncorrectAsyncResult"), "AsyncResult");
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        public static Exception IncorrectNumberOfDataSourceInformationRows()
        {
            return new Exception(("MDF_IncorrectNumberOfDataSourceInformationRows"));
        }

        public static IndexOutOfRangeException IndexOutOfRange(int value)
        {
            IndexOutOfRangeException e = new IndexOutOfRangeException(value.ToString(CultureInfo.InvariantCulture));
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static IndexOutOfRangeException IndexOutOfRange(string error)
        {
            IndexOutOfRangeException e = new IndexOutOfRangeException(error);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static Exception InternalConnectionError(ConnectionError internalError)
        {
            return new InvalidOperationException(("ADP_InternalConnectionError"));
        }

        public static Exception InternalError(InternalErrorCode internalError)
        {
            return new InvalidOperationException(("ADP_InternalProviderError"));
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static IntPtr IntPtrOffset(IntPtr pbase, int offset)
        {
            if (4 == PtrSize)
            {
                return (IntPtr)(pbase.ToInt32() + offset);
            }
            return (IntPtr)(pbase.ToInt64() + offset);
        }

        public static int IntPtrToInt32(IntPtr value)
        {
            if (4 == PtrSize)
            {
                return (int)value;
            }
            long num = (long)value;
            num = Math.Min(0x7fffffffL, num);
            return (int)Math.Max(-2147483648L, num);
        }

        //public static ArgumentOutOfRangeException InvalidAcceptRejectRule(AcceptRejectRule value)
        //{
        //    return InvalidEnumerationValue(typeof(AcceptRejectRule), (int) value);
        //}

        //public static ArgumentException InvalidArgumentLength(string argumentName, int limit)
        //{
        //    return new Exception (("ADP_InvalidArgumentLength", new object[] { argumentName, limit }));
        //}

        public static Exception InvalidArgumentValue(string methodName)
        {
            return new Exception(("ADP_InvalidArgumentValue"));
        }

        //public static IndexOutOfRangeException InvalidBufferSizeOrIndex(int numBytes, int bufferIndex)
        //{
        //    return IndexOutOfRange(Res.GetString("SQL_InvalidBufferSizeOrIndex", new object[] { numBytes.ToString(CultureInfo.InvariantCulture), bufferIndex.ToString(CultureInfo.InvariantCulture) }));
        //}

        public static InvalidCastException InvalidCast()
        {
            InvalidCastException e = new InvalidCastException();
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static InvalidCastException InvalidCast(string error)
        {
            return InvalidCast(error, null);
        }

        public static InvalidCastException InvalidCast(string error, Exception inner)
        {
            InvalidCastException e = new InvalidCastException(error, inner);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        //public static ArgumentOutOfRangeException InvalidCatalogLocation(CatalogLocation value)
        //{
        //    return InvalidEnumerationValue(typeof(CatalogLocation), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidCommandBehavior(CommandBehavior value)
        //{
        //    return InvalidEnumerationValue(typeof(CommandBehavior), (int) value);
        //}

        //public static Exception InvalidCommandTimeout(int value)
        //{
        //    return new Exception (("ADP_InvalidCommandTimeout", new object[] { value.ToString(CultureInfo.InvariantCulture) }), "CommandTimeout");
        //}

        //public static ArgumentOutOfRangeException InvalidCommandType(CommandType value)
        //{
        //    return InvalidEnumerationValue(typeof(CommandType), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidConflictOptions(ConflictOption value)
        //{
        //    return InvalidEnumerationValue(typeof(ConflictOption), (int) value);
        //}



        //public static Exception InvalidConnectionOptionValue(string key, Exception inner)
        //{
        //    return new Exception (("ADP_InvalidConnectionOptionValue", new object[] { key }), inner);
        //}

        //public static Exception InvalidConnectionOptionValueLength(string key, int limit)
        //{
        //    return new Exception (("ADP_InvalidConnectionOptionValueLength", new object[] { key, limit }));
        //}

        public static Exception InvalidConnectTimeoutValue()
        {
            return new Exception(("ADP_InvalidConnectTimeoutValue"));
        }

        public static InvalidOperationException InvalidDataDirectory()
        {
            return new InvalidOperationException(("ADP_InvalidDataDirectory"));
        }

        //public static Exception InvalidDataLength(long length)
        //{
        //    return IndexOutOfRange(Res.GetString("SQL_InvalidDataLength", new object[] { length.ToString(CultureInfo.InvariantCulture) }));
        //}

        //public static ArgumentOutOfRangeException InvalidDataRowState(DataRowState value)
        //{
        //    return InvalidEnumerationValue(typeof(DataRowState), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidDataRowVersion(DataRowVersion value)
        //{
        //    return InvalidEnumerationValue(typeof(DataRowVersion), (int) value);
        //}

        //public static ArgumentException InvalidDataType(TypeCode typecode)
        //{
        //    return new Exception (("ADP_InvalidDataType", new object[] { typecode.ToString() }));
        //}

        //public static InvalidOperationException InvalidDateTimeDigits(string dataTypeName)
        //{
        //    return new InvalidOperationException(("ADP_InvalidDateTimeDigits", new object[] { dataTypeName }));
        //}

        //public static ArgumentOutOfRangeException InvalidDestinationBufferIndex(int maxLen, int dstOffset, string parameterName)
        //{
        //    return ArgumentOutOfRange(Res.GetString("ADP_InvalidDestinationBufferIndex", new object[] { maxLen.ToString(CultureInfo.InvariantCulture), dstOffset.ToString(CultureInfo.InvariantCulture) }), parameterName);
        //}

        //public static ArgumentOutOfRangeException InvalidEnumerationValue(Type type, int value)
        //{
        //    return ArgumentOutOfRange(Res.GetString("ADP_InvalidEnumerationValue", new object[] { type.Name, value.ToString(CultureInfo.InvariantCulture) }), type.Name);
        //}

        public static Exception InvalidFormatValue()
        {
            return new Exception(("ADP_InvalidFormatValue"));
        }

        //public static Exception InvalidImplicitConversion(Type fromtype, string totype)
        //{
        //    return InvalidCast(Res.GetString("ADP_InvalidImplicitConversion", new object[] { fromtype.Name, totype }));
        //}

        //public static ArgumentOutOfRangeException InvalidIsolationLevel(System.Data.IsolationLevel value)
        //{
        //    return InvalidEnumerationValue(typeof(System.Transactions.IsolationLevel), (int) value);
        //}

        //public static ArgumentException InvalidKeyname(string parameterName)
        //{
        //    return new Exception (("ADP_InvalidKey"), parameterName);
        //}

        //public static ArgumentOutOfRangeException InvalidKeyRestrictionBehavior(KeyRestrictionBehavior value)
        //{
        //    return InvalidEnumerationValue(typeof(KeyRestrictionBehavior), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidLoadOption(LoadOption value)
        //{
        //    return InvalidEnumerationValue(typeof(LoadOption), (int) value);
        //}

        //public static InvalidOperationException InvalidMaximumScale(string dataTypeName)
        //{
        //    return new InvalidOperationException(("ADP_InvalidMaximumScale", new object[] { dataTypeName }));
        //}

        //public static Exception InvalidMaxRecords(string parameter, int max)
        //{
        //    return new Exception (("ADP_InvalidMaxRecords", new object[] { max.ToString(CultureInfo.InvariantCulture) }), parameter);
        //}

        public static Exception InvalidMetaDataValue()
        {
            return new Exception(("ADP_InvalidMetaDataValue"));
        }

        //public static ArgumentException InvalidMinMaxPoolSizeValues()
        //{
        //    return new Exception (("ADP_InvalidMinMaxPoolSizeValues"));
        //}

        //public static ArgumentOutOfRangeException InvalidMissingMappingAction(MissingMappingAction value)
        //{
        //    return InvalidEnumerationValue(typeof(MissingMappingAction), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidMissingSchemaAction(MissingSchemaAction value)
        //{
        //    return InvalidEnumerationValue(typeof(MissingSchemaAction), (int) value);
        //}

        //public static ArgumentException InvalidMultipartName(string property, string value)
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_InvalidMultipartName", new object[] { Res.GetString(property), value }));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ArgumentException InvalidMultipartNameIncorrectUsageOfQuotes(string property, string value)
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_InvalidMultipartNameQuoteUsage", new object[] { Res.GetString(property), value }));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ArgumentException InvalidMultipartNameToManyParts(string property, string value, int limit)
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_InvalidMultipartNameToManyParts", new object[] { Res.GetString(property), value, limit }));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ArgumentException InvalidOffsetValue(int value)
        //{
        //    return new Exception (("ADP_InvalidOffsetValue", new object[] { value.ToString(CultureInfo.InvariantCulture) }));
        //}

        public static InvalidOperationException InvalidOperation(string error)
        {
            InvalidOperationException e = new InvalidOperationException(error);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        public static InvalidOperationException InvalidOperation(string error, Exception inner)
        {
            InvalidOperationException e = new InvalidOperationException(error, inner);
            TraceExceptionAsReturnValue(e);
            return e;
        }

        //public static ArgumentOutOfRangeException InvalidParameterDirection(ParameterDirection value)
        //{
        //    return InvalidEnumerationValue(typeof(ParameterDirection), (int) value);
        //}

        //public static Exception InvalidParameterType(IDataParameterCollection collection, Type parameterType, object invalidValue)
        //{
        //    return CollectionInvalidType(collection.GetType(), parameterType, invalidValue);
        //}

        //public static ArgumentOutOfRangeException InvalidPermissionState(PermissionState value)
        //{
        //    return InvalidEnumerationValue(typeof(PermissionState), (int) value);
        //}

        //public static ArgumentException InvalidPrefixSuffix()
        //{
        //    ArgumentException e = new ArgumentException(Res.GetString("ADP_InvalidPrefixSuffix"));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ArgumentException InvalidRestrictionValue(string collectionName, string restrictionName, string restrictionValue)
        //{
        //    return new Exception (("MDF_InvalidRestrictionValue", new object[] { collectionName, restrictionName, restrictionValue }));
        //}

        //public static ArgumentOutOfRangeException InvalidRule(Rule value)
        //{
        //    return InvalidEnumerationValue(typeof(Rule), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidSchemaType(SchemaType value)
        //{
        //    return InvalidEnumerationValue(typeof(SchemaType), (int) value);
        //}

        //public static Exception InvalidSeekOrigin(string parameterName)
        //{
        //    return ArgumentOutOfRange(Res.GetString("ADP_InvalidSeekOrigin"), parameterName);
        //}

        //public static ArgumentException InvalidSizeValue(int value)
        //{
        //    return new Exception (("ADP_InvalidSizeValue", new object[] { value.ToString(CultureInfo.InvariantCulture) }));
        //}

        //public static ArgumentOutOfRangeException InvalidSourceBufferIndex(int maxLen, long srcOffset, string parameterName)
        //{
        //    return ArgumentOutOfRange(Res.GetString("ADP_InvalidSourceBufferIndex", new object[] { maxLen.ToString(CultureInfo.InvariantCulture), srcOffset.ToString(CultureInfo.InvariantCulture) }), parameterName);
        //}

        //public static Exception InvalidSourceColumn(string parameter)
        //{
        //    return new Exception (("ADP_InvalidSourceColumn"), parameter);
        //}

        //public static Exception InvalidSourceTable(string parameter)
        //{
        //    return new Exception (("ADP_InvalidSourceTable"), parameter);
        //}

        //public static Exception InvalidStartRecord(string parameter, int start)
        //{
        //    return new Exception (("ADP_InvalidStartRecord", new object[] { start.ToString(CultureInfo.InvariantCulture) }), parameter);
        //}

        //public static ArgumentOutOfRangeException InvalidStatementType(StatementType value)
        //{
        //    return InvalidEnumerationValue(typeof(StatementType), (int) value);
        //}

        //public static ArgumentException InvalidUDL()
        //{
        //    return new Exception (("ADP_InvalidUDL"));
        //}

        //public static ArgumentOutOfRangeException InvalidUpdateRowSource(UpdateRowSource value)
        //{
        //    return InvalidEnumerationValue(typeof(UpdateRowSource), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidUpdateStatus(UpdateStatus value)
        //{
        //    return InvalidEnumerationValue(typeof(UpdateStatus), (int) value);
        //}

        //public static ArgumentOutOfRangeException InvalidUserDefinedTypeSerializationFormat(Format value)
        //{
        //    return InvalidEnumerationValue(typeof(Format), (int) value);
        //}

        //public static ArgumentException InvalidValue(string parameterName)
        //{
        //    return new Exception (("ADP_InvalidValue"), parameterName);
        //}

        //public static Exception InvalidXml()
        //{
        //    return new Exception (("MDF_InvalidXml"));
        //}

        //public static Exception InvalidXMLBadVersion()
        //{
        //    return new Exception (("ADP_InvalidXMLBadVersion"));
        //}

        //public static Exception InvalidXmlInvalidValue(string collectionName, string columnName)
        //{
        //    return new Exception (("MDF_InvalidXmlInvalidValue", new object[] { collectionName, columnName }));
        //}

        //public static Exception InvalidXmlMissingColumn(string collectionName, string columnName)
        //{
        //    return new Exception (("MDF_InvalidXmlMissingColumn", new object[] { collectionName, columnName }));
        //}

        public static bool IsCatchableExceptionType(Exception e)
        {
            Type c = e.GetType();
            return (((((c != StackOverflowType) && (c != OutOfMemoryType)) && ((c != ThreadAbortType) && (c != NullReferenceType))) && (c != AccessViolationType)) && !SecurityType.IsAssignableFrom(c));
        }

        public static bool IsCatchableOrSecurityExceptionType(Exception e)
        {
            Type type = e.GetType();
            return ((((type != StackOverflowType) && (type != OutOfMemoryType)) && ((type != ThreadAbortType) && (type != NullReferenceType))) && (type != AccessViolationType));
        }

        public static bool IsDirection(IDataParameter value, ParameterDirection condition)
        {
            return (condition == (condition & value.Direction));
        }

        public static bool IsEmpty(string str)
        {
            if (str != null)
            {
                return (0 == str.Length);
            }
            return true;
        }

        public static bool IsEmptyArray(string[] array)
        {
            if (array != null)
            {
                return (0 == array.Length);
            }
            return true;
        }

        public static bool IsNull(object value)
        {
            if ((value == null) || (DBNull.Value == value))
            {
                return true;
            }
            INullable nullable = value as INullable;
            return ((nullable != null) && nullable.IsNull);
        }

        public static bool IsNull(object value, out bool isINullable)
        {
            INullable nullable = value as INullable;
            isINullable = null != nullable;
            if ((!isINullable || !nullable.IsNull) && (value != null))
            {
                return (DBNull.Value == value);
            }
            return true;
        }

        //[MethodImpl(MethodImplOptions.NoInlining)]
        //public static bool IsSysTxEqualSysEsTransaction()
        //{
        //    return ((!ContextUtil.IsInTransaction && (null == Transaction.Current)) || (ContextUtil.IsInTransaction && (Transaction.Current == ContextUtil.SystemTransaction)));
        //}

        //public static ArgumentException KeywordNotSupported(string keyword)
        //{
        //    return new Exception (("ADP_KeywordNotSupported", new object[] { keyword }));
        //}

        //public static Exception LiteralValueIsInvalid(string dataTypeName)
        //{
        //    return new Exception (("ADP_LiteralValueIsInvalid", new object[] { dataTypeName }));
        //}

        public static object LocalMachineRegistryValue(string subkey, string queryvalue)
        {
            object obj2;
            new RegistryPermission(RegistryPermissionAccess.Read, @"HKEY_LOCAL_MACHINE\" + subkey).Assert();
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey, false))
                {
                    return ((key != null) ? key.GetValue(queryvalue) : null);
                }
            }
            catch (SecurityException)
            {

                obj2 = null;
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
            return obj2;
        }

        public static Exception LocalTransactionPresent()
        {
            return new InvalidOperationException(("ADP_LocalTransactionPresent"));
        }

        public static string MachineName()
        {
            string machineName;
            PermissionSet set = new PermissionSet(PermissionState.None);
            set.AddPermission(new EnvironmentPermission(PermissionState.Unrestricted));
            set.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
            set.Assert();
            try
            {
                machineName = Environment.MachineName;
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
            return machineName;
        }

        //public static InvalidOperationException MethodCalledTwice(string method)
        //{
        //    InvalidOperationException e = new InvalidOperationException(Res.GetString("ADP_CalledTwice"));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static NotImplementedException MethodNotImplemented(string methodName)
        //{
        //    NotImplementedException e = new NotImplementedException(methodName);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static Exception MismatchedAsyncResult(string expectedMethod, string gotMethod)
        //{
        //    return new InvalidOperationException(("ADP_MismatchedAsyncResult", new object[] { expectedMethod, gotMethod }));
        //}

        //public static InvalidOperationException MissingColumnMapping(string srcColumn)
        //{
        //    return DataMapping(Res.GetString("ADP_MissingColumnMapping", new object[] { srcColumn }));
        //}

        //public static Exception MissingConnectionOptionValue(string key, string requiredAdditionalKey)
        //{
        //    return new Exception (("ADP_MissingConnectionOptionValue", new object[] { key, requiredAdditionalKey }));
        //}

        //public static InvalidOperationException MissingDataReaderFieldType(int index)
        //{
        //    return DataAdapter(Res.GetString("ADP_MissingDataReaderFieldType", new object[] { index }));
        //}

        public static Exception MissingDataSourceInformationColumn()
        {
            return new Exception(("MDF_MissingDataSourceInformationColumn"));
        }

        public static Exception MissingRestrictionColumn()
        {
            return new Exception(("MDF_MissingRestrictionColumn"));
        }

        public static Exception MissingRestrictionRow()
        {
            return new Exception(("MDF_MissingRestrictionRow"));
        }

        public static InvalidOperationException MissingSelectCommand(string method)
        {
            return new InvalidOperationException(("ADP_MissingSelectCommand"));
        }

        public static InvalidOperationException MissingSourceCommand()
        {
            return new InvalidOperationException(("ADP_MissingSourceCommand"));
        }

        public static InvalidOperationException MissingSourceCommandConnection()
        {
            return new InvalidOperationException(("ADP_MissingSourceCommandConnection"));
        }

        public static InvalidOperationException MissingTableMapping(string srcTable)
        {
            return new InvalidOperationException(("ADP_MissingTableMapping"));
        }

        public static InvalidOperationException MissingTableMappingDestination(string dstTable)
        {
            return new InvalidOperationException(("ADP_MissingTableMappingDestination"));
        }





        //public static bool NeedManualEnlistment()
        //{
        //    if (IsWindowsNT)
        //    {
        //        bool flag = !InOutOfProcHelper.InProc;
        //        if ((flag && !IsSysTxEqualSysEsTransaction()) || (!flag && (null != Transaction.Current)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public static Exception NegativeParameter(string parameterName)
        //{
        //    return new InvalidOperationException(("ADP_NegativeParameter", new object[] { parameterName }));
        //}

        //public static Exception NoColumns()
        //{
        //    return new Exception (("MDF_NoColumns"));
        //}

        //public static InvalidOperationException NoConnectionString()
        //{
        //    return new InvalidOperationException(("ADP_NoConnectionString"));
        //}

        //public static Exception NonSeqByteAccess(long badIndex, long currIndex, string method)
        //{
        //    return new InvalidOperationException(("ADP_NonSeqByteAccess", new object[] { badIndex.ToString(CultureInfo.InvariantCulture), currIndex.ToString(CultureInfo.InvariantCulture), method }));
        //}

        //public static InvalidOperationException NonSequentialColumnAccess(int badCol, int currCol)
        //{
        //    return new InvalidOperationException(("ADP_NonSequentialColumnAccess", new object[] { badCol.ToString(CultureInfo.InvariantCulture), currCol.ToString(CultureInfo.InvariantCulture) }));
        //}

        //public static InvalidOperationException NoQuoteChange()
        //{
        //    return new InvalidOperationException(("ADP_NoQuoteChange"));
        //}

        //public static Exception NoStoredProcedureExists(string sproc)
        //{
        //    return new InvalidOperationException(("ADP_NoStoredProcedureExists", new object[] { sproc }));
        //}

        //public static Exception NotADataColumnMapping(object value)
        //{
        //    return CollectionInvalidType(typeof(DataColumnMappingCollection), typeof(DataColumnMapping), value);
        //}

        //public static Exception NotADataTableMapping(object value)
        //{
        //    return CollectionInvalidType(typeof(DataTableMappingCollection), typeof(DataTableMapping), value);
        //}

        //public static Exception NotAPermissionElement()
        //{
        //    return new Exception (("ADP_NotAPermissionElement"));
        //}

        //public static NotImplementedException NotImplemented(string error)
        //{
        //    NotImplementedException e = new NotImplementedException(error);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static Exception NotRowType()
        //{
        //    return new InvalidOperationException(("ADP_NotRowType"));
        //}

        //public static NotSupportedException NotSupported()
        //{
        //    NotSupportedException e = new NotSupportedException();
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static NotSupportedException NotSupported(string error)
        //{
        //    NotSupportedException e = new NotSupportedException(error);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static ArgumentOutOfRangeException NotSupportedCommandBehavior(CommandBehavior value, string method)
        //{
        //    return NotSupportedEnumerationValue(typeof(CommandBehavior), value.ToString(), method);
        //}

        //public static ArgumentOutOfRangeException NotSupportedEnumerationValue(Type type, string value, string method)
        //{
        //    return ArgumentOutOfRange(Res.GetString("ADP_NotSupportedEnumerationValue", new object[] { type.Name, value, method }), type.Name);
        //}

        //public static ArgumentOutOfRangeException NotSupportedStatementType(StatementType value, string method)
        //{
        //    return NotSupportedEnumerationValue(typeof(StatementType), value.ToString(), method);
        //}

        //public static ArgumentOutOfRangeException NotSupportedUserDefinedTypeSerializationFormat(Format value, string method)
        //{
        //    return NotSupportedEnumerationValue(typeof(Format), value.ToString(), method);
        //}

        //public static Exception NumericToDecimalOverflow()
        //{
        //    return InvalidCast(Res.GetString("ADP_NumericToDecimalOverflow"));
        //}

        //public static ObjectDisposedException ObjectDisposed(object instance)
        //{
        //    ObjectDisposedException e = new ObjectDisposedException(instance.GetType().Name);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static Exception OffsetOutOfRangeException()
        //{
        //    return new InvalidOperationException(("ADP_OffsetOutOfRangeException"));
        //}

        //public static InvalidOperationException OnlyOneTableForStartRecordOrMaxRecords()
        //{
        //    return DataAdapter(Res.GetString("ADP_OnlyOneTableForStartRecordOrMaxRecords"));
        //}

        //public static Exception OpenConnectionPropertySet(string property, ConnectionState state)
        //{
        //    return new InvalidOperationException(("ADP_OpenConnectionPropertySet", new object[] { property, ConnectionStateMsg(state) }));
        //}

        //public static InvalidOperationException OpenConnectionRequired(string method, ConnectionState state)
        //{
        //    return new InvalidOperationException(("ADP_OpenConnectionRequired", new object[] { method, ConnectionStateMsg(state) }));
        //}

        //public static Exception OpenReaderExists()
        //{
        //    return OpenReaderExists(null);
        //}

        //public static Exception OpenReaderExists(Exception e)
        //{
        //    return new InvalidOperationException(("ADP_OpenReaderExists"), e);
        //}

        //public static OverflowException Overflow(string error)
        //{
        //    return Overflow(error, null);
        //}

        //public static OverflowException Overflow(string error, Exception inner)
        //{
        //    OverflowException e = new OverflowException(error, inner);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static Exception ParallelTransactionsNotSupported(IDbConnection obj)
        //{
        //    return new InvalidOperationException(("ADP_ParallelTransactionsNotSupported", new object[] { obj.GetType().Name }));
        //}

        //public static Exception ParameterConversionFailed(object value, Type destType, Exception inner)
        //{
        //    Exception exception;
        //    string message = Res.GetString("ADP_ParameterConversionFailed", new object[] { value.GetType().Name, destType.Name });
        //    if (inner is ArgumentException)
        //    {
        //        exception = new ArgumentException(message, inner);
        //    }
        //    else if (inner is FormatException)
        //    {
        //        exception = new FormatException(message, inner);
        //    }
        //    else if (inner is InvalidCastException)
        //    {
        //        exception = new InvalidCastException(message, inner);
        //    }
        //    else if (inner is OverflowException)
        //    {
        //        exception = new OverflowException(message, inner);
        //    }
        //    else
        //    {
        //        exception = inner;
        //    }
        //    TraceExceptionAsReturnValue(exception);
        //    return exception;
        //}

        //public static Exception ParameterNull(string parameter, IDataParameterCollection collection, Type parameterType)
        //{
        //    return CollectionNullValue(parameter, collection.GetType(), parameterType);
        //}

        ////public static ArgumentException ParametersIsNotParent(Type parameterType, ICollection collection)
        ////{
        ////    return new Exception (("ADP_CollectionIsNotParent", new object[] { parameterType.Name, collection.GetType().Name }));
        ////}

        ////public static ArgumentException ParametersIsParent(Type parameterType, ICollection collection)
        ////{
        ////    return new Exception (("ADP_CollectionIsNotParent", new object[] { parameterType.Name, collection.GetType().Name }));
        ////}

        //public static Exception ParametersMappingIndex(int index, IDataParameterCollection collection)
        //{
        //    return CollectionIndexInt32(index, collection.GetType(), collection.Count);
        //}

        //public static Exception ParametersSourceIndex(string parameterName, IDataParameterCollection collection, Type parameterType)
        //{
        //    return CollectionIndexString(parameterType, "ParameterName", parameterName, collection.GetType());
        //}

        //public static ArgumentException ParameterValueOutOfRange(SqlDecimal value)
        //{
        //    return new Exception (("ADP_ParameterValueOutOfRange", new object[] { value.ToString() }));
        //}

        //public static ArgumentException ParameterValueOutOfRange(decimal value)
        //{
        //    return new Exception (("ADP_ParameterValueOutOfRange", new object[] { value.ToString((IFormatProvider) null) }));
        //}

        //public static Exception PermissionTypeMismatch()
        //{
        //    return new Exception (("ADP_PermissionTypeMismatch"));
        //}

        //public static Exception PooledOpenTimeout()
        //{
        //    return new InvalidOperationException(("ADP_PooledOpenTimeout"));
        //}

        //public static Exception PrepareParameterScale(IDbCommand cmd, string type)
        //{
        //    return new InvalidOperationException(("ADP_PrepareParameterScale", new object[] { cmd.GetType().Name, type }));
        //}

        //public static Exception PrepareParameterSize(IDbCommand cmd)
        //{
        //    return new InvalidOperationException(("ADP_PrepareParameterSize", new object[] { cmd.GetType().Name }));
        //}

        //public static Exception PrepareParameterType(IDbCommand cmd)
        //{
        //    return new InvalidOperationException(("ADP_PrepareParameterType", new object[] { cmd.GetType().Name }));
        //}

        //public static PlatformNotSupportedException PropertyNotSupported(string property)
        //{
        //    PlatformNotSupportedException e = new PlatformNotSupportedException(Res.GetString("ADP_PropertyNotSupported", new object[] { property }));
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //private static InvalidOperationException Provider(string error)
        //{
        //    return InvalidOperation(error);
        //}

        //public static Exception QueryFailed(string collectionName, Exception e)
        //{
        //    return new InvalidOperationException(("MDF_QueryFailed"), e);
        //}

        //public static InvalidOperationException QuotePrefixNotSet(string method)
        //{
        //    return new InvalidOperationException(("ADP_QuotePrefixNotSet"));
        //}

        //public static bool RemoveStringQuotes(string quotePrefix, string quoteSuffix, string quotedString, out string unquotedString)
        //{
        //    int num;
        //    int num2;
        //    if (quotePrefix == null)
        //    {
        //        num = 0;
        //    }
        //    else
        //    {
        //        num = quotePrefix.Length;
        //    }
        //    if (quoteSuffix == null)
        //    {
        //        num2 = 0;
        //    }
        //    else
        //    {
        //        num2 = quoteSuffix.Length;
        //    }
        //    if ((num2 + num) == 0)
        //    {
        //        unquotedString = quotedString;
        //        return true;
        //    }
        //    if (quotedString == null)
        //    {
        //        unquotedString = quotedString;
        //        return false;
        //    }
        //    int length = quotedString.Length;
        //    if (length < (num + num2))
        //    {
        //        unquotedString = quotedString;
        //        return false;
        //    }
        //    if ((num > 0) && !quotedString.StartsWith(quotePrefix, StringComparison.Ordinal))
        //    {
        //        unquotedString = quotedString;
        //        return false;
        //    }
        //    if (num2 > 0)
        //    {
        //        if (!quotedString.EndsWith(quoteSuffix, StringComparison.Ordinal))
        //        {
        //            unquotedString = quotedString;
        //            return false;
        //        }
        //        unquotedString = quotedString.Substring(num, length - (num + num2)).Replace(quoteSuffix + quoteSuffix, quoteSuffix);
        //    }
        //    else
        //    {
        //        unquotedString = quotedString.Substring(num, length - num);
        //    }
        //    return true;
        //}

        //public static InvalidOperationException ResultsNotAllowedDuringBatch()
        //{
        //    return DataAdapter(Res.GetString("ADP_ResultsNotAllowedDuringBatch"));
        //}

        //public static DataException RowUpdatedErrors()
        //{
        //    return Data(Res.GetString("ADP_RowUpdatedErrors"));
        //}

        //public static DataException RowUpdatingErrors()
        //{
        //    return Data(Res.GetString("ADP_RowUpdatingErrors"));
        //}

        public static DataRow[] SelectAdapterRows(DataTable dataTable, bool sorted)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            DataRowCollection rows = dataTable.Rows;
            foreach (DataRow row3 in rows)
            {
                DataRowState rowState = row3.RowState;
                if (rowState != DataRowState.Added)
                {
                    if (rowState == DataRowState.Deleted)
                    {
                        goto Label_0048;
                    }
                    if (rowState == DataRowState.Modified)
                    {
                        goto Label_004E;
                    }
                }
                else
                {
                    num++;
                }
                continue;
            Label_0048:
                num2++;
                continue;
            Label_004E:
                num3++;
            }
            DataRow[] rowArray = new DataRow[(num + num2) + num3];
            if (sorted)
            {
                num3 = num + num2;
                num2 = num;
                num = 0;
                foreach (DataRow row in rows)
                {
                    DataRowState state = row.RowState;
                    if (state != DataRowState.Added)
                    {
                        if (state == DataRowState.Deleted)
                        {
                            goto Label_00CA;
                        }
                        if (state == DataRowState.Modified)
                        {
                            goto Label_00D5;
                        }
                    }
                    else
                    {
                        rowArray[num++] = row;
                    }
                    continue;
                Label_00CA:
                    rowArray[num2++] = row;
                    continue;
                Label_00D5:
                    rowArray[num3++] = row;
                }
                return rowArray;
            }
            int num4 = 0;
            foreach (DataRow row2 in rows)
            {
                if ((row2.RowState & (DataRowState.Modified | DataRowState.Deleted | DataRowState.Added)) != 0)
                {
                    rowArray[num4++] = row2;
                    if (num4 == rowArray.Length)
                    {
                        return rowArray;
                    }
                }
            }
            return rowArray;
        }

        //public static ArgumentException SingleValuedProperty(string propertyName, string value)
        //{
        //    ArgumentException e = new ArgumentException("ADP_SingleValuedProperty", new object[] { propertyName, value });
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        public static int SrcCompare(string strA, string strB)
        {
            if (!(strA == strB))
            {
                return 1;
            }
            return 0;
        }

        public static Exception StreamClosed(string method)
        {
            return new InvalidOperationException(("ADP_StreamClosed"));
        }

        public static int StringLength(string inputString)
        {
            if (inputString == null)
            {
                return 0;
            }
            return inputString.Length;
        }

        //public static Exception TablesAddNullAttempt(string parameter)
        //{
        //    return CollectionNullValue(parameter, typeof(DataTableMappingCollection), typeof(DataTableMapping));
        //}

        //public static Exception TablesDataSetTable(string cacheTable)
        //{
        //    return CollectionIndexString(typeof(DataTableMapping), "DataSetTable", cacheTable, typeof(DataTableMappingCollection));
        //}

        //public static Exception TablesIndexInt32(int index, ITableMappingCollection collection)
        //{
        //    return CollectionIndexInt32(index, collection.GetType(), collection.Count);
        //}

        //public static Exception TablesIsNotParent(ICollection collection)
        //{
        //    return ParametersIsNotParent(typeof(DataTableMapping), collection);
        //}

        //public static Exception TablesIsParent(ICollection collection)
        //{
        //    return ParametersIsParent(typeof(DataTableMapping), collection);
        //}

        //public static Exception TablesSourceIndex(string srcTable)
        //{
        //    return CollectionIndexString(typeof(DataTableMapping), "SourceTable", srcTable, typeof(DataTableMappingCollection));
        //}

        //public static Exception TablesUniqueSourceTable(string srcTable)
        //{
        //    return CollectionUniqueValue(typeof(DataTableMapping), "SourceTable", srcTable);
        //}

        [DllImport("kernel32.dll")]
        public static extern void GetSystemTimeAsFileTime(out long lpSystemTimeAsFileTime);

        public static long TimerCurrent()
        {
            long lpSystemTimeAsFileTime = 0L;
            GetSystemTimeAsFileTime(out lpSystemTimeAsFileTime);
            return lpSystemTimeAsFileTime;
        }

        //public static void TimerCurrent(out long ticks)
        //{
        //    SafeNativeMethods.GetSystemTimeAsFileTime(out ticks);
        //}

        public static long TimerFromSeconds(int seconds)
        {
            return (seconds * 0x989680L);
        }

        public static bool TimerHasExpired(long timerExpire)
        {
            return (TimerCurrent() > timerExpire);
        }

        public static long TimerRemaining(long timerExpire)
        {
            long num2 = TimerCurrent();
            return (timerExpire - num2);
        }

        public static long TimerRemainingMilliseconds(long timerExpire)
        {
            return TimerToMilliseconds(TimerRemaining(timerExpire));
        }

        public static long TimerRemainingSeconds(long timerExpire)
        {
            return TimerToSeconds(TimerRemaining(timerExpire));
        }

        public static long TimerToMilliseconds(long timerValue)
        {
            return (timerValue / 0x2710L);
        }

        private static long TimerToSeconds(long timerValue)
        {
            return (timerValue / 0x989680L);
        }

        public static Exception TooManyRestrictions(string collectionName)
        {
            return new Exception(("MDF_TooManyRestrictions"));
        }


        //public static void TraceExceptionAsReturnValue(Exception e)
        //{
        //    TraceException("<comm.ADP.TraceException|ERR|THROW> '%ls'\n", e);
        //}

        //public static void TraceExceptionForCapture(Exception e)
        //{
        //    TraceException("<comm.ADP.TraceException|ERR|CATCH> '%ls'\n", e);
        //}

        //public static void TraceExceptionWithoutRethrow(Exception e)
        //{
        //    TraceException("<comm.ADP.TraceException|ERR|CATCH> '%ls'\n", e);
        //}

        //public static Exception TransactionCompleted()
        //{
        //    return DataAdapter(Res.GetString("ADP_TransactionCompleted"));
        //}

        //public static InvalidOperationException TransactionConnectionMismatch()
        //{
        //    return Provider(Res.GetString("ADP_TransactionConnectionMismatch"));
        //}

        public static Exception TransactionPresent()
        {
            return new InvalidOperationException(("ADP_TransactionPresent"));
        }

        //public static InvalidOperationException TransactionRequired(string method)
        //{
        //    return Provider(Res.GetString("ADP_TransactionRequired"));
        //}

        //public static Exception TransactionZombied(IDbTransaction obj)
        //{
        //    return new InvalidOperationException(("ADP_TransactionZombied", new object[] { obj.GetType().Name }));
        //}

        //public static TypeLoadException TypeLoad(string error)
        //{
        //    TypeLoadException e = new TypeLoadException(error);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        ////public static ArgumentException UdlFileError(Exception inner)
        ////{
        ////    return new Exception (("ADP_UdlFileError"), inner);
        ////}

        //public static Exception UnableToBuildCollection(string collectionName)
        //{
        //    return new Exception (("MDF_UnableToBuildCollection"));
        //}

        //public static InvalidOperationException UnableToCreateBooleanLiteral()
        //{
        //    return new InvalidOperationException(("ADP_UnableToCreateBooleanLiteral"));
        //}

        //public static Exception UndefinedCollection(string collectionName)
        //{
        //    return new Exception (("MDF_UndefinedCollection"));
        //}

        //public static Exception UndefinedPopulationMechanism(string populationMechanism)
        //{
        //    return new Exception (("MDF_UndefinedPopulationMechanism", new object[] { populationMechanism }));
        //}

        //public static Exception UninitializedParameterSize(int index, Type dataType)
        //{
        //    return new InvalidOperationException(("ADP_UninitializedParameterSize", new object[] { index.ToString(CultureInfo.InvariantCulture), dataType.Name }));
        //}

        //public static ArgumentException UnknownDataType(Type dataType)
        //{
        //    return new Exception (("ADP_UnknownDataType", new object[] { dataType.FullName }));
        //}

        //public static ArgumentException UnknownDataTypeCode(Type dataType, TypeCode typeCode)
        //{
        //    object[] args = new object[] { ((int) typeCode).ToString(CultureInfo.InvariantCulture), dataType.FullName };
        //    return new Exception (("ADP_UnknownDataTypeCode", args));
        //}

        //public static Exception UnsupportedNativeDataTypeOleDb(string dataTypeName)
        //{
        //    return new Exception (("ADP_UnsupportedNativeDataTypeOleDb", new object[] { dataTypeName }));
        //}

        //public static Exception UnsupportedVersion(string collectionName)
        //{
        //    return new Exception (("MDF_UnsupportedVersion"));
        //}

        //public static ArgumentException UnwantedStatementType(StatementType statementType)
        //{
        //    return new Exception (("ADP_UnwantedStatementType", new object[] { statementType.ToString() }));
        //}

        //public static Exception UpdateConcurrencyViolation(StatementType statementType, int affected, int expected, DataRow[] dataRows)
        //{
        //    string str;
        //    switch (statementType)
        //    {
        //        case StatementType.Update:
        //            str = "ADP_UpdateConcurrencyViolation_Update";
        //            break;

        //        case StatementType.Delete:
        //            str = "ADP_UpdateConcurrencyViolation_Delete";
        //            break;

        //        case StatementType.Batch:
        //            str = "ADP_UpdateConcurrencyViolation_Batch";
        //            break;

        //        default:
        //            throw InvalidStatementType(statementType);
        //    }
        //    DBConcurrencyException e = new DBConcurrencyException(Res.GetString(str, new object[] { affected.ToString(CultureInfo.InvariantCulture), expected.ToString(CultureInfo.InvariantCulture) }), null, dataRows);
        //    TraceExceptionAsReturnValue(e);
        //    return e;
        //}

        //public static InvalidOperationException UpdateConnectionRequired(StatementType statementType, bool isRowUpdatingCommand)
        //{
        //    string str;
        //    if (isRowUpdatingCommand)
        //    {
        //        str = "ADP_ConnectionRequired_Clone";
        //    }
        //    else
        //    {
        //        switch (statementType)
        //        {
        //            case StatementType.Insert:
        //                str = "ADP_ConnectionRequired_Insert";
        //                goto Label_004C;

        //            case StatementType.Update:
        //                str = "ADP_ConnectionRequired_Update";
        //                goto Label_004C;

        //            case StatementType.Delete:
        //                str = "ADP_ConnectionRequired_Delete";
        //                goto Label_004C;

        //            case StatementType.Batch:
        //                str = "ADP_ConnectionRequired_Batch";
        //                break;
        //        }
        //        throw InvalidStatementType(statementType);
        //    }
        //Label_004C:
        //    return new InvalidOperationException((str));
        //}

        //public static ArgumentException UpdateMismatchRowTable(int i)
        //{
        //    return new Exception (("ADP_UpdateMismatchRowTable", new object[] { i.ToString(CultureInfo.InvariantCulture) }));
        //}

        //public static InvalidOperationException UpdateOpenConnectionRequired(StatementType statementType, bool isRowUpdatingCommand, ConnectionState state)
        //{
        //    string str;
        //    if (isRowUpdatingCommand)
        //    {
        //        str = "ADP_OpenConnectionRequired_Clone";
        //    }
        //    else
        //    {
        //        switch (statementType)
        //        {
        //            case StatementType.Insert:
        //                str = "ADP_OpenConnectionRequired_Insert";
        //                goto Label_0042;

        //            case StatementType.Update:
        //                str = "ADP_OpenConnectionRequired_Update";
        //                goto Label_0042;

        //            case StatementType.Delete:
        //                str = "ADP_OpenConnectionRequired_Delete";
        //                goto Label_0042;
        //        }
        //        throw InvalidStatementType(statementType);
        //    }
        //Label_0042:;
        //    return new InvalidOperationException((str, new object[] { ConnectionStateMsg(state) }));
        //}

        //public static InvalidOperationException UpdateRequiresCommand(StatementType statementType, bool isRowUpdatingCommand)
        //{
        //    string str;
        //    if (isRowUpdatingCommand)
        //    {
        //        str = "ADP_UpdateRequiresCommandClone";
        //    }
        //    else
        //    {
        //        switch (statementType)
        //        {
        //            case StatementType.Select:
        //                str = "ADP_UpdateRequiresCommandSelect";
        //                goto Label_004C;

        //            case StatementType.Insert:
        //                str = "ADP_UpdateRequiresCommandInsert";
        //                goto Label_004C;

        //            case StatementType.Update:
        //                str = "ADP_UpdateRequiresCommandUpdate";
        //                goto Label_004C;

        //            case StatementType.Delete:
        //                str = "ADP_UpdateRequiresCommandDelete";
        //                goto Label_004C;
        //        }
        //        throw InvalidStatementType(statementType);
        //    }
        //Label_004C:
        //    return new InvalidOperationException((str));
        //}

        //public static ArgumentNullException UpdateRequiresDataTable(string parameter)
        //{
        //    return ArgumentNull(parameter);
        //}

        //public static ArgumentNullException UpdateRequiresNonNullDataSet(string parameter)
        //{
        //    return ArgumentNull(parameter);
        //}

        //public static InvalidOperationException UpdateRequiresSourceTable(string defaultSrcTableName)
        //{
        //    return new InvalidOperationException(("ADP_UpdateRequiresSourceTable", new object[] { defaultSrcTableName }));
        //}

        //public static InvalidOperationException UpdateRequiresSourceTableName(string srcTable)
        //{
        //    return new InvalidOperationException(("ADP_UpdateRequiresSourceTableName", new object[] { srcTable }));
        //}

        //public static void ValidateCommandBehavior(CommandBehavior value)
        //{
        //    if ((value < CommandBehavior.Default) || ((CommandBehavior.CloseConnection | CommandBehavior.SequentialAccess | CommandBehavior.SingleRow | CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly | CommandBehavior.SingleResult) < value))
        //    {
        //        throw InvalidCommandBehavior(value);
        //    }
        //}

        //public static ArgumentException VersionDoesNotSupportDataType(string typeName)
        //{
        //    return new Exception (("ADP_VersionDoesNotSupportDataType", new object[] { typeName }));
        //}

        //public static Exception WrongType(Type got, Type expected)
        //{
        //    return new Exception (("SQL_WrongType", new object[] { got.ToString(), expected.ToString() }));
        //}

        // Nested Types
        internal enum ConnectionError
        {
            BeginGetConnectionReturnsNull,
            GetConnectionReturnsNull,
            ConnectionOptionsMissing,
            CouldNotSwitchToClosedPreviouslyOpenedState
        }

        internal enum InternalErrorCode
        {
            AttemptingToConstructReferenceCollectionOnStaticObject = 12,
            AttemptingToEnlistTwice = 13,
            AttemptingToPoolOnRestrictedToken = 8,
            ConvertSidToStringSidWReturnedNull = 10,
            CreateObjectReturnedNull = 5,
            CreateReferenceCollectionReturnedNull = 14,
            InvalidBuffer = 30,
            InvalidParserState1 = 0x15,
            InvalidParserState2 = 0x16,
            InvalidParserState3 = 0x17,
            InvalidSmiCall = 0x29,
            NameValuePairNext = 20,
            NewObjectCannotBePooled = 6,
            NonPooledObjectUsedMoreThanOnce = 7,
            PooledObjectHasOwner = 3,
            PooledObjectInPoolMoreThanOnce = 4,
            PooledObjectWithoutPool = 15,
            PushingObjectSecondTime = 2,
            SqlDependencyCommandHashIsNotAssociatedWithNotification = 0x35,
            SqlDependencyObtainProcessDispatcherFailureObjectHandle = 50,
            SqlDependencyProcessDispatcherFailureAppDomain = 0x34,
            SqlDependencyProcessDispatcherFailureCreateInstance = 0x33,
            UnexpectedWaitAnyResult = 0x10,
            UnimplementedSMIMethod = 40,
            UnknownTransactionFailure = 60,
            UnpooledObjectHasOwner = 0,
            UnpooledObjectHasWrongOwner = 1
        }
    }
}
