using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.OleDb;
using Microsoft.SqlServer.Server;

namespace Keel
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TdsDateTime
    {
        public int days;
        public int time;
    }




    internal sealed class MetaType
    {
        // Fields
        public readonly Type ClassType;
        public readonly DbType DbType;
        public readonly int FixedLength;
        public readonly bool Is100Supported;
        public readonly bool Is70Supported;
        public readonly bool Is80Supported;
        public readonly bool Is90Supported;
        public readonly bool IsAnsiType;
        public readonly bool IsBinType;
        public readonly bool IsCharType;
        public readonly bool IsFixed;
        public readonly bool IsLong;
        public readonly bool IsNCharType;
        public readonly bool IsPlp;
        public readonly bool IsSizeInCharacters;
        private static readonly MetaType MetaBigInt = new MetaType(0x13, 0xff, 8, true, false, false, 0x7f, 0x26, "bigint", typeof(long), typeof(SqlInt64), SqlDbType.BigInt, DbType.Int64, 0);
        private static readonly MetaType MetaBinary = new MetaType(0xff, 0xff, -1, false, false, false, 0xad, 0xad, "binary", typeof(byte[]), typeof(SqlBinary), SqlDbType.Binary, DbType.Binary, 2);
        private static readonly MetaType MetaBit = new MetaType(0xff, 0xff, 1, true, false, false, 50, 0x68, "bit", typeof(bool), typeof(SqlBoolean), SqlDbType.Bit, DbType.Boolean, 0);
        private static readonly MetaType MetaChar = new MetaType(0xff, 0xff, -1, false, false, false, 0xaf, 0xaf, "char", typeof(string), typeof(SqlString), SqlDbType.Char, DbType.AnsiStringFixedLength, 7);
        private static readonly MetaType MetaDate = new MetaType(0xff, 0xff, 3, true, false, false, 40, 40, "date", typeof(DateTime), typeof(DateTime), SqlDbType.Date, DbType.Date, 0);
        private static readonly MetaType MetaDateTime = new MetaType(0x17, 3, 8, true, false, false, 0x3d, 0x6f, "datetime", typeof(DateTime), typeof(SqlDateTime), SqlDbType.DateTime, DbType.DateTime, 0);
        private static readonly MetaType MetaDateTime2 = new MetaType(0xff, 7, -1, false, false, false, 0x2a, 0x2a, "datetime2", typeof(DateTime), typeof(DateTime), SqlDbType.DateTime2, DbType.DateTime2, 1);
        public static readonly MetaType MetaDateTimeOffset = new MetaType(0xff, 7, -1, false, false, false, 0x2b, 0x2b, "datetimeoffset", typeof(DateTimeOffset), typeof(DateTimeOffset), SqlDbType.DateTimeOffset, DbType.DateTimeOffset, 1);
        public static readonly MetaType MetaDecimal = new MetaType(0x26, 4, 0x11, true, false, false, 0x6c, 0x6c, "decimal", typeof(decimal), typeof(SqlDecimal), SqlDbType.Decimal, DbType.Decimal, 2);
        private static readonly MetaType MetaFloat = new MetaType(15, 0xff, 8, true, false, false, 0x3e, 0x6d, "float", typeof(double), typeof(SqlDouble), SqlDbType.Float, DbType.Double, 0);
        public static readonly MetaType MetaImage = new MetaType(0xff, 0xff, -1, false, true, false, 0x22, 0x22, "image", typeof(byte[]), typeof(SqlBinary), SqlDbType.Image, DbType.Binary, 0);
        private static readonly MetaType MetaInt = new MetaType(10, 0xff, 4, true, false, false, 0x38, 0x26, "int", typeof(int), typeof(SqlInt32), SqlDbType.Int, DbType.Int32, 0);
        public static readonly MetaType MetaMaxNVarChar = new MetaType(0xff, 0xff, -1, false, true, true, 0xe7, 0xe7, "nvarchar", typeof(string), typeof(SqlString), SqlDbType.NVarChar, DbType.String, 7);
        private static readonly MetaType MetaMaxUdt = new MetaType(0xff, 0xff, -1, false, true, true, 240, 240, "udt", typeof(object), typeof(object), SqlDbType.Udt, DbType.Object, 0);
        public static readonly MetaType MetaMaxVarBinary = new MetaType(0xff, 0xff, -1, false, true, true, 0xa5, 0xa5, "varbinary", typeof(byte[]), typeof(SqlBinary), SqlDbType.VarBinary, DbType.Binary, 2);
        public static readonly MetaType MetaMaxVarChar = new MetaType(0xff, 0xff, -1, false, true, true, 0xa7, 0xa7, "varchar", typeof(string), typeof(SqlString), SqlDbType.VarChar, DbType.AnsiString, 7);
        private static readonly MetaType MetaMoney = new MetaType(0x13, 0xff, 8, true, false, false, 60, 110, "money", typeof(decimal), typeof(SqlMoney), SqlDbType.Money, DbType.Currency, 0);
        private static readonly MetaType MetaNChar = new MetaType(0xff, 0xff, -1, false, false, false, 0xef, 0xef, "nchar", typeof(string), typeof(SqlString), SqlDbType.NChar, DbType.StringFixedLength, 7);
        public static readonly MetaType MetaNText = new MetaType(0xff, 0xff, -1, false, true, false, 0x63, 0x63, "ntext", typeof(string), typeof(SqlString), SqlDbType.NText, DbType.String, 7);
        public static readonly MetaType MetaNVarChar = new MetaType(0xff, 0xff, -1, false, false, false, 0xe7, 0xe7, "nvarchar", typeof(string), typeof(SqlString), SqlDbType.NVarChar, DbType.String, 7);
        private static readonly MetaType MetaReal = new MetaType(7, 0xff, 4, true, false, false, 0x3b, 0x6d, "real", typeof(float), typeof(SqlSingle), SqlDbType.Real, DbType.Single, 0);
        private static readonly MetaType MetaSmallDateTime = new MetaType(0x10, 0, 4, true, false, false, 0x3a, 0x6f, "smalldatetime", typeof(DateTime), typeof(SqlDateTime), SqlDbType.SmallDateTime, DbType.DateTime, 0);
        private static readonly MetaType MetaSmallInt = new MetaType(5, 0xff, 2, true, false, false, 0x34, 0x26, "smallint", typeof(short), typeof(SqlInt16), SqlDbType.SmallInt, DbType.Int16, 0);
        private static readonly MetaType MetaSmallMoney = new MetaType(10, 0xff, 4, true, false, false, 0x7a, 110, "smallmoney", typeof(decimal), typeof(SqlMoney), SqlDbType.SmallMoney, DbType.Currency, 0);
        private static readonly MetaType MetaSmallVarBinary = new MetaType(0xff, 0xff, -1, false, false, false, 0x25, 0xad, ADP.StrEmpty, typeof(byte[]), typeof(SqlBinary), SqlDbType.SmallInt | SqlDbType.Int, DbType.Binary, 2);
        private static readonly MetaType MetaSUDT = new MetaType(0xff, 0xff, -1, false, false, false, 0x1f, 0x1f, "", typeof(SqlDataRecord), typeof(SqlDataRecord), SqlDbType.Structured, DbType.Object, 0);
        private static readonly MetaType MetaTable = new MetaType(0xff, 0xff, -1, false, false, false, 0xf3, 0xf3, "table", typeof(IEnumerable<DbDataRecord>), typeof(IEnumerable<DbDataRecord>), SqlDbType.Structured, DbType.Object, 0);
        public static readonly MetaType MetaText = new MetaType(0xff, 0xff, -1, false, true, false, 0x23, 0x23, "text", typeof(string), typeof(SqlString), SqlDbType.Text, DbType.AnsiString, 0);
        public static readonly MetaType MetaTime = new MetaType(0xff, 7, -1, false, false, false, 0x29, 0x29, "time", typeof(TimeSpan), typeof(TimeSpan), SqlDbType.Time, DbType.Time, 1);
        private static readonly MetaType MetaTimestamp = new MetaType(0xff, 0xff, -1, false, false, false, 0xad, 0xad, "timestamp", typeof(byte[]), typeof(SqlBinary), SqlDbType.Timestamp, DbType.Binary, 2);
        private static readonly MetaType MetaTinyInt = new MetaType(3, 0xff, 1, true, false, false, 0x30, 0x26, "tinyint", typeof(byte), typeof(SqlByte), SqlDbType.TinyInt, DbType.Byte, 0);
        public static readonly MetaType MetaUdt = new MetaType(0xff, 0xff, -1, false, false, true, 240, 240, "udt", typeof(object), typeof(object), SqlDbType.Udt, DbType.Object, 0);
        private static readonly MetaType MetaUniqueId = new MetaType(0xff, 0xff, 0x10, true, false, false, 0x24, 0x24, "uniqueidentifier", typeof(Guid), typeof(SqlGuid), SqlDbType.UniqueIdentifier, DbType.Guid, 0);
        public static readonly MetaType MetaVarBinary = new MetaType(0xff, 0xff, -1, false, false, false, 0xa5, 0xa5, "varbinary", typeof(byte[]), typeof(SqlBinary), SqlDbType.VarBinary, DbType.Binary, 2);
        private static readonly MetaType MetaVarChar = new MetaType(0xff, 0xff, -1, false, false, false, 0xa7, 0xa7, "varchar", typeof(string), typeof(SqlString), SqlDbType.VarChar, DbType.AnsiString, 7);
        private static readonly MetaType MetaVariant = new MetaType(0xff, 0xff, -1, true, false, false, 0x62, 0x62, "sql_variant", typeof(object), typeof(object), SqlDbType.Variant, DbType.Object, 0);
        public static readonly MetaType MetaXml = new MetaType(0xff, 0xff, -1, false, true, true, 0xf1, 0xf1, "xml", typeof(string), typeof(SqlXml), SqlDbType.Xml, DbType.Xml, 0);
        public readonly byte NullableType;
        public readonly byte Precision;
        public readonly byte PropBytes;
        public readonly byte Scale;
        public readonly SqlDbType SqlDbType;
        public readonly Type SqlType;
        public readonly byte TDSType;
        public readonly string TypeName;

        // Methods
        public MetaType(byte precision, byte scale, int fixedLength, bool isFixed, bool isLong, bool isPlp, byte tdsType, byte nullableTdsType, string typeName, Type classType, Type sqlType, SqlDbType sqldbType, DbType dbType, byte propBytes)
        {
            this.Precision = precision;
            this.Scale = scale;
            this.FixedLength = fixedLength;
            this.IsFixed = isFixed;
            this.IsLong = isLong;
            this.IsPlp = isPlp;
            this.TDSType = tdsType;
            this.NullableType = nullableTdsType;
            this.TypeName = typeName;
            this.SqlDbType = sqldbType;
            this.DbType = dbType;
            this.ClassType = classType;
            this.SqlType = sqlType;
            this.PropBytes = propBytes;
            this.IsAnsiType = _IsAnsiType(sqldbType);
            this.IsBinType = _IsBinType(sqldbType);
            this.IsCharType = _IsCharType(sqldbType);
            this.IsNCharType = _IsNCharType(sqldbType);
            this.IsSizeInCharacters = _IsSizeInCharacters(this.SqlDbType);
            this.Is70Supported = _Is70Supported(this.SqlDbType);
            this.Is80Supported = _Is80Supported(this.SqlDbType);
            this.Is90Supported = _Is90Supported(this.SqlDbType);
            this.Is100Supported = _Is100Supported(this.SqlDbType);
        }

        private static bool _Is100Supported(SqlDbType type)
        {
            if ((!_Is90Supported(type) && (SqlDbType.Date != type)) && ((SqlDbType.Time != type) && (SqlDbType.DateTime2 != type)))
            {
                return (SqlDbType.DateTimeOffset == type);
            }
            return true;
        }

        private static bool _Is70Supported(SqlDbType type)
        {
            return (((type != SqlDbType.BigInt) && (type > SqlDbType.BigInt)) && (type <= SqlDbType.VarChar));
        }

        private static bool _Is80Supported(SqlDbType type)
        {
            return ((type >= SqlDbType.BigInt) && (type <= SqlDbType.Variant));
        }

        private static bool _Is90Supported(SqlDbType type)
        {
            if (!_Is80Supported(type) && (SqlDbType.Xml != type))
            {
                return (SqlDbType.Udt == type);
            }
            return true;
        }

        private static bool _IsAnsiType(SqlDbType type)
        {
            if ((type != SqlDbType.Char) && (type != SqlDbType.VarChar))
            {
                return (type == SqlDbType.Text);
            }
            return true;
        }

        private static bool _IsBinType(SqlDbType type)
        {
            if ((((type != SqlDbType.Image) && (type != SqlDbType.Binary)) && ((type != SqlDbType.VarBinary) && (type != SqlDbType.Timestamp))) && (type != SqlDbType.Udt))
            {
                return (type == (SqlDbType.SmallInt | SqlDbType.Int));
            }
            return true;
        }

        private static bool _IsCharType(SqlDbType type)
        {
            if ((((type != SqlDbType.NChar) && (type != SqlDbType.NVarChar)) && ((type != SqlDbType.NText) && (type != SqlDbType.Char))) && ((type != SqlDbType.VarChar) && (type != SqlDbType.Text)))
            {
                return (type == SqlDbType.Xml);
            }
            return true;
        }

        private static bool _IsNCharType(SqlDbType type)
        {
            if (((type != SqlDbType.NChar) && (type != SqlDbType.NVarChar)) && (type != SqlDbType.NText))
            {
                return (type == SqlDbType.Xml);
            }
            return true;
        }

        private static bool _IsNewKatmaiType(SqlDbType type)
        {
            return (SqlDbType.Structured == type);
        }

        private static bool _IsSizeInCharacters(SqlDbType type)
        {
            if (((type != SqlDbType.NChar) && (type != SqlDbType.NVarChar)) && (type != SqlDbType.Xml))
            {
                return (type == SqlDbType.NText);
            }
            return true;
        }

        public static bool _IsVarTime(SqlDbType type)
        {
            if ((type != SqlDbType.Time) && (type != SqlDbType.DateTime2))
            {
                return (type == SqlDbType.DateTimeOffset);
            }
            return true;
        }

        public static TdsDateTime FromDateTime(DateTime dateTime, byte cb)
        {
            SqlDateTime time2;
            TdsDateTime time = new TdsDateTime();
            if (cb == 8)
            {
                time2 = new SqlDateTime(dateTime);
                time.time = time2.TimeTicks;
            }
            else
            {
                time2 = new SqlDateTime(dateTime.AddSeconds(30.0));
                time.time = time2.TimeTicks / SqlDateTime.SQLTicksPerMinute;
            }
            time.days = time2.DayTicks;
            return time;
        }

        public static object GetComValueFromSqlVariant(object sqlVal)
        {
            object obj2 = null;
            if (!ADP.IsNull(sqlVal))
            {
                if (sqlVal is SqlSingle)
                {
                    SqlSingle num7 = (SqlSingle)sqlVal;
                    return num7.Value;
                }
                if (sqlVal is SqlString)
                {
                    SqlString str = (SqlString)sqlVal;
                    return str.Value;
                }
                if (sqlVal is SqlDouble)
                {
                    SqlDouble num6 = (SqlDouble)sqlVal;
                    return num6.Value;
                }
                if (sqlVal is SqlBinary)
                {
                    SqlBinary binary = (SqlBinary)sqlVal;
                    return binary.Value;
                }
                if (sqlVal is SqlGuid)
                {
                    SqlGuid guid = (SqlGuid)sqlVal;
                    return guid.Value;
                }
                if (sqlVal is SqlBoolean)
                {
                    SqlBoolean flag = (SqlBoolean)sqlVal;
                    return flag.Value;
                }
                if (sqlVal is SqlByte)
                {
                    SqlByte num5 = (SqlByte)sqlVal;
                    return num5.Value;
                }
                if (sqlVal is SqlInt16)
                {
                    SqlInt16 num4 = (SqlInt16)sqlVal;
                    return num4.Value;
                }
                if (sqlVal is SqlInt32)
                {
                    SqlInt32 num3 = (SqlInt32)sqlVal;
                    return num3.Value;
                }
                if (sqlVal is SqlInt64)
                {
                    SqlInt64 num2 = (SqlInt64)sqlVal;
                    return num2.Value;
                }
                if (sqlVal is SqlDecimal)
                {
                    SqlDecimal num = (SqlDecimal)sqlVal;
                    return num.Value;
                }
                if (sqlVal is SqlDateTime)
                {
                    SqlDateTime time = (SqlDateTime)sqlVal;
                    return time.Value;
                }
                if (sqlVal is SqlMoney)
                {
                    SqlMoney money = (SqlMoney)sqlVal;
                    return money.Value;
                }
                if (sqlVal is SqlXml)
                {
                    obj2 = ((SqlXml)sqlVal).Value;
                }
            }
            return obj2;
        }

        public static MetaType GetDefaultMetaType()
        {
            return MetaNVarChar;
        }

        public static MetaType GetMaxMetaTypeFromMetaType(MetaType mt)
        {
            SqlDbType sqlDbType = mt.SqlDbType;
            if (sqlDbType <= SqlDbType.NVarChar)
            {
                switch (sqlDbType)
                {
                    case SqlDbType.Binary:
                        goto Label_004F;

                    case SqlDbType.Bit:
                        return mt;

                    case SqlDbType.Char:
                        goto Label_0055;

                    case SqlDbType.NChar:
                    case SqlDbType.NVarChar:
                        return MetaMaxNVarChar;

                    case SqlDbType.NText:
                        return mt;
                }
                return mt;
            }
            switch (sqlDbType)
            {
                case SqlDbType.VarBinary:
                    goto Label_004F;

                case SqlDbType.VarChar:
                    goto Label_0055;

                case SqlDbType.Udt:
                    return MetaMaxUdt;

                default:
                    return mt;
            }
        Label_004F:
            return MetaMaxVarBinary;
        Label_0055:
            return MetaMaxVarChar;
        }

        public static MetaType GetMetaTypeFromDbType(DbType target)
        {
            switch (target)
            {
                case DbType.AnsiString:
                    return MetaVarChar;

                case DbType.Binary:
                    return MetaVarBinary;

                case DbType.Byte:
                    return MetaTinyInt;

                case DbType.Boolean:
                    return MetaBit;

                case DbType.Currency:
                    return MetaMoney;

                case DbType.Date:
                case DbType.DateTime:
                    return MetaDateTime;

                case DbType.Decimal:
                    return MetaDecimal;

                case DbType.Double:
                    return MetaFloat;

                case DbType.Guid:
                    return MetaUniqueId;

                case DbType.Int16:
                    return MetaSmallInt;

                case DbType.Int32:
                    return MetaInt;

                case DbType.Int64:
                    return MetaBigInt;

                case DbType.Object:
                    return MetaVariant;

                case DbType.Single:
                    return MetaReal;

                case DbType.String:
                    return MetaNVarChar;

                case DbType.Time:
                    return MetaDateTime;

                case DbType.AnsiStringFixedLength:
                    return MetaChar;

                case DbType.StringFixedLength:
                    return MetaNChar;

                case DbType.Xml:
                    return MetaXml;

                case DbType.DateTime2:
                    return MetaDateTime2;

                case DbType.DateTimeOffset:
                    return MetaDateTimeOffset;
            }
            throw ADP.DbTypeNotSupported(target, typeof(SqlDbType));
        }

        public static MetaType GetMetaTypeFromSqlDbType(SqlDbType target, bool isMultiValued)
        {
            switch (target)
            {
                case SqlDbType.BigInt:
                    return MetaBigInt;

                case SqlDbType.Binary:
                    return MetaBinary;

                case SqlDbType.Bit:
                    return MetaBit;

                case SqlDbType.Char:
                    return MetaChar;

                case SqlDbType.DateTime:
                    return MetaDateTime;

                case SqlDbType.Decimal:
                    return MetaDecimal;

                case SqlDbType.Float:
                    return MetaFloat;

                case SqlDbType.Image:
                    return MetaImage;

                case SqlDbType.Int:
                    return MetaInt;

                case SqlDbType.Money:
                    return MetaMoney;

                case SqlDbType.NChar:
                    return MetaNChar;

                case SqlDbType.NText:
                    return MetaNText;

                case SqlDbType.NVarChar:
                    return MetaNVarChar;

                case SqlDbType.Real:
                    return MetaReal;

                case SqlDbType.UniqueIdentifier:
                    return MetaUniqueId;

                case SqlDbType.SmallDateTime:
                    return MetaSmallDateTime;

                case SqlDbType.SmallInt:
                    return MetaSmallInt;

                case SqlDbType.SmallMoney:
                    return MetaSmallMoney;

                case SqlDbType.Text:
                    return MetaText;

                case SqlDbType.Timestamp:
                    return MetaTimestamp;

                case SqlDbType.TinyInt:
                    return MetaTinyInt;

                case SqlDbType.VarBinary:
                    return MetaVarBinary;

                case SqlDbType.VarChar:
                    return MetaVarChar;

                case SqlDbType.Variant:
                    return MetaVariant;

                case (SqlDbType.SmallInt | SqlDbType.Int):
                    return MetaSmallVarBinary;

                case SqlDbType.Xml:
                    return MetaXml;

                case SqlDbType.Udt:
                    return MetaUdt;

                case SqlDbType.Structured:
                    if (isMultiValued)
                    {
                        return MetaTable;
                    }
                    return MetaSUDT;

                case SqlDbType.Date:
                    return MetaDate;

                case SqlDbType.Time:
                    return MetaTime;

                case SqlDbType.DateTime2:
                    return MetaDateTime2;

                case SqlDbType.DateTimeOffset:
                    return MetaDateTimeOffset;
            }
            throw new NotSupportedException("此类型不支持");
        }

        public static MetaType GetMetaTypeFromType(Type dataType)
        {
            return GetMetaTypeFromValue(dataType, null, false);
        }

        public static MetaType GetMetaTypeFromValue(object value)
        {
            return GetMetaTypeFromValue(value.GetType(), value, true);
        }

        private static MetaType GetMetaTypeFromValue(Type dataType, object value, bool inferLen)
        {
            switch (Type.GetTypeCode(dataType))
            {
                case TypeCode.Empty:
                    return null;

                case TypeCode.Object:
                    if (dataType != typeof(byte[]))
                    {
                        if (dataType == typeof(Guid))
                        {
                            return MetaUniqueId;
                        }
                        if (dataType == typeof(object))
                        {
                            return MetaVariant;
                        }
                        if (dataType == typeof(SqlBinary))
                        {
                            return MetaVarBinary;
                        }
                        if (dataType == typeof(SqlBoolean))
                        {
                            return MetaBit;
                        }
                        if (dataType == typeof(SqlByte))
                        {
                            return MetaTinyInt;
                        }
                        if (dataType == typeof(SqlBytes))
                        {
                            return MetaVarBinary;
                        }
                        if (dataType != typeof(SqlChars))
                        {
                            if (dataType == typeof(SqlDateTime))
                            {
                                return MetaDateTime;
                            }
                            if (dataType == typeof(SqlDouble))
                            {
                                return MetaFloat;
                            }
                            if (dataType == typeof(SqlGuid))
                            {
                                return MetaUniqueId;
                            }
                            if (dataType == typeof(SqlInt16))
                            {
                                return MetaSmallInt;
                            }
                            if (dataType == typeof(SqlInt32))
                            {
                                return MetaInt;
                            }
                            if (dataType == typeof(SqlInt64))
                            {
                                return MetaBigInt;
                            }
                            if (dataType == typeof(SqlMoney))
                            {
                                return MetaMoney;
                            }
                            if (dataType == typeof(SqlDecimal))
                            {
                                return MetaDecimal;
                            }
                            if (dataType == typeof(SqlSingle))
                            {
                                return MetaReal;
                            }
                            if (dataType == typeof(SqlXml))
                            {
                                return MetaXml;
                            }
                            if (dataType == typeof(XmlReader))
                            {
                                return MetaXml;
                            }
                            if (dataType != typeof(SqlString))
                            {
                                if ((dataType == typeof(IEnumerable<DbDataRecord>)) || (dataType == typeof(DataTable)))
                                {
                                    return MetaTable;
                                }
                                if (dataType == typeof(TimeSpan))
                                {
                                    return MetaTime;
                                }
                                if (dataType == typeof(DateTimeOffset))
                                {
                                    return MetaDateTimeOffset;
                                }
                                if (SqlUdtInfo.TryGetFromType(dataType) == null)
                                {
                                    return null;
                                }
                                return MetaUdt;
                            }
                            if (inferLen)
                            {
                                SqlString str2 = (SqlString)value;
                                if (!str2.IsNull)
                                {
                                    SqlString str = (SqlString)value;
                                    return PromoteStringType(str.Value);
                                }
                            }
                        }
                        return MetaNVarChar;
                    }
                    if (inferLen && (((byte[])value).Length > 0x1f40))
                    {
                        return MetaImage;
                    }
                    return MetaVarBinary;

                case TypeCode.DBNull:
                    return null;

                case TypeCode.Boolean:
                    return MetaBit;

                case TypeCode.Char:
                    return null;

                case TypeCode.SByte:
                    return null;

                case TypeCode.Byte:
                    return MetaTinyInt;

                case TypeCode.Int16:
                    return MetaSmallInt;

                case TypeCode.UInt16:
                    return null;

                case TypeCode.Int32:
                    return MetaInt;

                case TypeCode.UInt32:
                    return null;

                case TypeCode.Int64:
                    return MetaBigInt;

                case TypeCode.UInt64:
                    return null;

                case TypeCode.Single:
                    return MetaReal;

                case TypeCode.Double:
                    return MetaFloat;

                case TypeCode.Decimal:
                    return MetaDecimal;

                case TypeCode.DateTime:
                    return MetaDateTime;

                case TypeCode.String:
                    if (!inferLen)
                    {
                        return MetaNVarChar;
                    }
                    return PromoteStringType((string)value);
            }
            return null;
        }

        public static object GetNullSqlValue(Type sqlType)
        {
            if (sqlType == typeof(SqlSingle))
            {
                return SqlSingle.Null;
            }
            if (sqlType == typeof(SqlString))
            {
                return SqlString.Null;
            }
            if (sqlType == typeof(SqlDouble))
            {
                return SqlDouble.Null;
            }
            if (sqlType == typeof(SqlBinary))
            {
                return SqlBinary.Null;
            }
            if (sqlType == typeof(SqlGuid))
            {
                return SqlGuid.Null;
            }
            if (sqlType == typeof(SqlBoolean))
            {
                return SqlBoolean.Null;
            }
            if (sqlType == typeof(SqlByte))
            {
                return SqlByte.Null;
            }
            if (sqlType == typeof(SqlInt16))
            {
                return SqlInt16.Null;
            }
            if (sqlType == typeof(SqlInt32))
            {
                return SqlInt32.Null;
            }
            if (sqlType == typeof(SqlInt64))
            {
                return SqlInt64.Null;
            }
            if (sqlType == typeof(SqlDecimal))
            {
                return SqlDecimal.Null;
            }
            if (sqlType == typeof(SqlDateTime))
            {
                return SqlDateTime.Null;
            }
            if (sqlType == typeof(SqlMoney))
            {
                return SqlMoney.Null;
            }
            if (sqlType == typeof(SqlXml))
            {
                return SqlXml.Null;
            }
            if (sqlType != typeof(object))
            {
                if (sqlType == typeof(IEnumerable<DbDataRecord>))
                {
                    return DBNull.Value;
                }
                if (sqlType == typeof(DataTable))
                {
                    return DBNull.Value;
                }
                if (sqlType == typeof(DateTime))
                {
                    return DBNull.Value;
                }
                if (sqlType == typeof(TimeSpan))
                {
                    return DBNull.Value;
                }
                if (sqlType == typeof(DateTimeOffset))
                {
                    return DBNull.Value;
                }
            }
            return DBNull.Value;
        }

        public static MetaType GetSqlDataType(int tdsType, uint userType, int length)
        {
            switch (tdsType)
            {
                case 0x7a:
                    return MetaSmallMoney;

                case 0x7f:
                    return MetaBigInt;

                case 0x22:
                    return MetaImage;

                case 0x23:
                    return MetaText;

                case 0x24:
                    return MetaUniqueId;

                case 0x25:
                    return MetaSmallVarBinary;

                case 0x26:
                    if (4 <= length)
                    {
                        if (4 != length)
                        {
                            return MetaBigInt;
                        }
                        return MetaInt;
                    }
                    if (2 == length)
                    {
                        return MetaSmallInt;
                    }
                    return MetaTinyInt;

                case 0x27:
                case 0xa7:
                    return MetaVarChar;

                case 40:
                    return MetaDate;

                case 0x29:
                    return MetaTime;

                case 0x2a:
                    return MetaDateTime2;

                case 0x2b:
                    return MetaDateTimeOffset;

                case 0x2d:
                case 0xad:
                    if (80 != userType)
                    {
                        return MetaBinary;
                    }
                    return MetaTimestamp;

                case 0x2f:
                case 0xaf:
                    return MetaChar;

                case 0x30:
                    return MetaTinyInt;

                case 50:
                case 0x68:
                    return MetaBit;

                case 0x34:
                    return MetaSmallInt;

                case 0x38:
                    return MetaInt;

                case 0x3a:
                    return MetaSmallDateTime;

                case 0x3b:
                    return MetaReal;

                case 60:
                    return MetaMoney;

                case 0x3d:
                    return MetaDateTime;

                case 0x3e:
                    return MetaFloat;

                case 0x62:
                    return MetaVariant;

                case 0x63:
                    return MetaNText;

                case 0x6a:
                case 0x6c:
                    return MetaDecimal;

                case 0x6d:
                    if (4 == length)
                    {
                        return MetaReal;
                    }
                    return MetaFloat;

                case 110:
                    if (4 == length)
                    {
                        return MetaSmallMoney;
                    }
                    return MetaMoney;

                case 0x6f:
                    if (4 == length)
                    {
                        return MetaSmallDateTime;
                    }
                    return MetaDateTime;

                case 0xa5:
                    return MetaVarBinary;

                case 0xef:
                    return MetaNChar;

                case 240:
                    return MetaUdt;

                case 0xf1:
                    return MetaXml;

                case 0xf3:
                    return MetaTable;

                case 0xe7:
                    return MetaNVarChar;
            }
            return null; ;
        }

        public static SqlDbType GetSqlDbTypeFromOleDbType(short dbType, string typeName)
        {
            SqlDbType variant = SqlDbType.Variant;
            OleDbType type2 = (OleDbType)dbType;
            if (type2 <= OleDbType.Filetime)
            {
                switch (type2)
                {
                    case OleDbType.SmallInt:
                    case OleDbType.UnsignedSmallInt:
                        return SqlDbType.SmallInt;

                    case OleDbType.Integer:
                        return SqlDbType.Int;

                    case OleDbType.Single:
                        return SqlDbType.Real;

                    case OleDbType.Double:
                        return SqlDbType.Float;

                    case OleDbType.Currency:
                        return ((typeName == "smallmoney") ? SqlDbType.SmallMoney : SqlDbType.Money);

                    case OleDbType.Date:
                    case OleDbType.Filetime:
                        goto Label_0133;

                    case OleDbType.BSTR:
                        goto Label_01B3;

                    case OleDbType.IDispatch:
                    case OleDbType.Error:
                    case OleDbType.IUnknown:
                    case ((OleDbType)15):
                    case OleDbType.UnsignedInt:
                        return variant;

                    case OleDbType.Boolean:
                        return SqlDbType.Bit;

                    case OleDbType.Variant:
                        return SqlDbType.Variant;

                    case OleDbType.Decimal:
                        goto Label_016B;

                    case OleDbType.TinyInt:
                    case OleDbType.UnsignedTinyInt:
                        return SqlDbType.TinyInt;

                    case OleDbType.BigInt:
                        return SqlDbType.BigInt;
                }
                return variant;
            }
            switch (type2)
            {
                case OleDbType.Binary:
                case OleDbType.VarBinary:
                    return ((typeName == "binary") ? SqlDbType.Binary : SqlDbType.VarBinary);

                case OleDbType.Char:
                case OleDbType.VarChar:
                    return ((typeName == "char") ? SqlDbType.Char : SqlDbType.VarChar);

                case OleDbType.WChar:
                case OleDbType.VarWChar:
                    goto Label_01B3;

                case OleDbType.Numeric:
                    goto Label_016B;

                case (OleDbType.Binary | OleDbType.Single):
                    return SqlDbType.Udt;

                case OleDbType.DBDate:
                    return SqlDbType.Date;

                case OleDbType.DBTime:
                case (OleDbType.Binary | OleDbType.BSTR):
                case (OleDbType.Char | OleDbType.BSTR):
                case OleDbType.PropVariant:
                case OleDbType.VarNumeric:
                case (OleDbType.Binary | OleDbType.Variant):
                case (OleDbType.PropVariant | OleDbType.Single):
                case (OleDbType.VarNumeric | OleDbType.Single):
                case (OleDbType.Binary | OleDbType.TinyInt):
                    return variant;

                case OleDbType.DBTimeStamp:
                    goto Label_0133;

                case (OleDbType.DBDate | OleDbType.BSTR):
                    return SqlDbType.Xml;

                case (OleDbType.Char | OleDbType.TinyInt):
                    return SqlDbType.Time;

                case (OleDbType.WChar | OleDbType.TinyInt):
                    return SqlDbType.DateTimeOffset;

                case OleDbType.Guid:
                    return SqlDbType.UniqueIdentifier;

                case OleDbType.LongVarChar:
                    return SqlDbType.Text;

                case OleDbType.LongVarWChar:
                    return SqlDbType.NText;

                case OleDbType.LongVarBinary:
                    return SqlDbType.Image;

                default:
                    return variant;
            }
        Label_0133:
            switch (typeName)
            {
                case "smalldatetime":
                    return SqlDbType.SmallDateTime;

                case "datetime2":
                    return SqlDbType.DateTime2;

                default:
                    return SqlDbType.DateTime;
            }
        Label_016B:
            return SqlDbType.Decimal;
        Label_01B3:
            return ((typeName == "nchar") ? SqlDbType.NChar : SqlDbType.NVarChar);
        }

        public static object GetSqlValueFromComVariant(object comVal)
        {
            if ((comVal != null) && (DBNull.Value != comVal))
            {
                if (comVal is float)
                {
                    return new SqlSingle((float)comVal);
                }
                if (comVal is string)
                {
                    return new SqlString((string)comVal);
                }
                if (comVal is double)
                {
                    return new SqlDouble((double)comVal);
                }
                if (comVal is byte[])
                {
                    return new SqlBinary((byte[])comVal);
                }
                if (comVal is char)
                {
                    char ch = (char)comVal;
                    return new SqlString(ch.ToString());
                }
                if (comVal is char[])
                {
                    return new SqlChars((char[])comVal);
                }
                if (comVal is Guid)
                {
                    return new SqlGuid((Guid)comVal);
                }
                if (comVal is bool)
                {
                    return new SqlBoolean((bool)comVal);
                }
                if (comVal is byte)
                {
                    return new SqlByte((byte)comVal);
                }
                if (comVal is short)
                {
                    return new SqlInt16((short)comVal);
                }
                if (comVal is int)
                {
                    return new SqlInt32((int)comVal);
                }
                if (comVal is long)
                {
                    return new SqlInt64((long)comVal);
                }
                if (comVal is decimal)
                {
                    return new SqlDecimal((decimal)comVal);
                }
                if (comVal is DateTime)
                {
                    return new SqlDateTime((DateTime)comVal);
                }
                if (comVal is XmlReader)
                {
                    return new SqlXml((XmlReader)comVal);
                }
                if ((comVal is TimeSpan) || (comVal is DateTimeOffset))
                {
                    return comVal;
                }
            }
            return null;
        }

        public static string GetStringFromXml(XmlReader xmlreader)
        {
            SqlXml xml = new SqlXml(xmlreader);
            return xml.Value;
        }

        public static int GetTimeSizeFromScale(byte scale)
        {
            if (scale <= 2)
            {
                return 3;
            }
            if (scale <= 4)
            {
                return 4;
            }
            return 5;
        }

        public static MetaType PromoteStringType(string s)
        {
            if ((s.Length << 1) > 0x1f40)
            {
                return MetaVarChar;
            }
            return MetaNVarChar;
        }

        public static DateTime ToDateTime(int sqlDays, int sqlTime, int length)
        {
            if (length == 4)
            {
                SqlDateTime time2 = new SqlDateTime(sqlDays, sqlTime * SqlDateTime.SQLTicksPerMinute);
                return time2.Value;
            }
            SqlDateTime time = new SqlDateTime(sqlDays, sqlTime);
            return time.Value;
        }

        // Properties
        public bool IsNewKatmaiType
        {
            get
            {
                return _IsNewKatmaiType(this.SqlDbType);
            }
        }

        public bool IsVarTime
        {
            get
            {
                return _IsVarTime(this.SqlDbType);
            }
        }

        public int TypeId
        {
            get
            {
                return 0;
            }
        }
    }
}
