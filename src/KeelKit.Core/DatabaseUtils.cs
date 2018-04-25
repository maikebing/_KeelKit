namespace KeelKit.Core
{
    using ADODB;
    using System;

    public class DatabaseUtils
    {
        public static string ConvertDataType(object typeID)
        {
            string name = "";
            if (typeID is int)
            {
                name = Enum.GetName(typeof(DataTypeEnum), int.Parse(typeID.ToString()));
            }
            else
            {
                name = typeID.ToString();
            }
            switch (name)
            {
                case "adEmpty":
                    return "Object";

                case "adSmallInt":
                    return "Int16";

                case "adInteger":
                    return "Int32";

                case "adSingle":
                    return "Single";

                case "adDouble":
                    return "Double";

                case "adCurrency":
                    return "Decimal";

                case "adDate":
                    return "DateTime";

                case "adBSTR":
                    return "String";

                case "adIDispatch":
                    return "Object";

                case "adError":
                    return "ExternalException";

                case "adBoolean":
                    return "Boolean";

                case "adVariant":
                    return "Object";

                case "adIUnknown":
                    return "Object";

                case "adDecimal":
                    return "Decimal";

                case "adTinyInt":
                    return "Byte";

                case "adUnsignedTinyInt":
                    return "Byte";

                case "adUnsignedSmallInt":
                    return "UInt16";

                case "adUnsignedInt":
                    return "UInt32";

                case "adBigInt":
                    return "Int64";

                case "adUnsignedBigInt":
                    return "UInt64";

                case "adFileTime":
                    return "DateTime";

                case "adGUID":
                    return "Guid";

                case "adBinary":
                    return "Byte[]";

                case "adChar":
                    return "String";

                case "adWChar":
                    return "String";

                case "adNumeric":
                    return "Decimal";

                case "adUserDefined":
                    return "Object";

                case "adDBDate":
                    return "DateTime";

                case "adDBTime":
                    return "DateTime";

                case "adDBTimeStamp":
                    return "DateTime";

                case "adChapter":
                    return "Object";

                case "adPropVariant":
                    return "Object";

                case "adVarNumeric":
                    return "Decimal";

                case "adVarChar":
                    return "byte[]";

                case "adLongVarChar":
                    return "byte[]";

                case "adVarWChar":
                    return "byte[]";

                case "adLongVarWChar":
                    return "byte[]";

                case "adVarBinary":
                    return "byte[]";

                case "adLongVarBinary":
                    return "byte[]";

                case "adArray":
                    return "Object";
            }
            return name;
        }
    }
}

