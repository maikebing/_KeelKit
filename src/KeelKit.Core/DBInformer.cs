using ADODB;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Data.OleDb;
namespace KeelKit.Core
{
   
 

    public class DBInformer
    {
        private string connectionString;
        private string defaultDatabase;
        private string htkey;
        private static Hashtable metadataCache = Hashtable.Synchronized(new Hashtable());
        private ADODB.Properties properties;
        private Connection tempConn;

        public DBInformer(string connString) : this(connString, null)
        {
        }

        public DBInformer(string connString, string database)
        {
            this.tempConn = null;
            this.connectionString = connString;
            this.defaultDatabase = database;
            this.htkey = connString + ":";
            if (database != null)
            {
                this.htkey = this.htkey + database + ":";
            }
        }

        public static void ClearCache()
        {
            lock (metadataCache)
            {
                metadataCache.Clear();
            }
        }

        public static string ConvertDataType(object typeID)
        {
            switch (Enum.GetName(typeof(DataTypeEnum), int.Parse(typeID.ToString())))
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
            return "";
        }
        public   string ConvertDataType2DBType(string  typeID)
        {
            switch (Enum.GetName(typeof(DataTypeEnum), int.Parse(typeID )))
            {
                case "adEmpty":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Empty );

                case "adSmallInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.SmallInt );

                case "adInteger":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Integer );

                case "adSingle":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Single );

                case "adDouble":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Double);

                case "adCurrency":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Currency );

                case "adDate":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Date );

                case "adBSTR":
                    return Enum.GetName(typeof(OleDbType), OleDbType.BSTR  );

                case "adIDispatch":
                    return Enum.GetName(typeof(OleDbType), OleDbType.IDispatch  );

                case "adError":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Error );

                case "adBoolean":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Boolean );

                case "adVariant":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Variant   );

                case "adIUnknown":
                    return Enum.GetName(typeof(OleDbType), OleDbType.IUnknown  );

                case "adDecimal":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Decimal );

                case "adTinyInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.TinyInt   );

                case "adUnsignedTinyInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.UnsignedTinyInt);

                case "adUnsignedSmallInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.UnsignedSmallInt );

                case "adUnsignedInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.UnsignedInt );

                case "adBigInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.BigInt );

                case "adUnsignedBigInt":
                    return Enum.GetName(typeof(OleDbType), OleDbType.UnsignedBigInt  );

                case "adFileTime":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Filetime  );

                case "adGUID":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Guid );

                case "adBinary":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Binary );

                case "adChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Char  );

                case "adWChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.WChar  );

                case "adNumeric":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Decimal );

                case "adUserDefined":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Variant);

                case "adDBDate":
                    return Enum.GetName(typeof(OleDbType), OleDbType.DBDate  );

                case "adDBTime":
                          return Enum.GetName(typeof(OleDbType), OleDbType.DBTime );

                case "adDBTimeStamp":
                    return Enum.GetName(typeof(OleDbType), OleDbType.DBTimeStamp );

                case "adChapter":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Variant );

                case "adPropVariant":
                    return Enum.GetName(typeof(OleDbType), OleDbType.PropVariant);

                case "adVarNumeric":
                    return Enum.GetName(typeof(OleDbType), OleDbType.VarNumeric );

                case "adVarChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.VarChar );

                case "adLongVarChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.LongVarChar );

                case "adVarWChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.VarWChar );

                case "adLongVarWChar":
                    return Enum.GetName(typeof(OleDbType), OleDbType.LongVarWChar);

                case "adVarBinary":
                    return Enum.GetName(typeof(OleDbType), OleDbType.VarBinary );

                case "adLongVarBinary":
                    return Enum.GetName(typeof(OleDbType), OleDbType.LongVarBinary);

                case "adArray":
                    return Enum.GetName(typeof(OleDbType), OleDbType.Variant  );
            }
            return Enum.GetName(typeof(OleDbType), OleDbType.Variant);
        }

        public static DataTable ConvertRecordset(Recordset rs)
        {
            DataTable table = null;
            int num;
            if (rs != null)
            {
                Hashtable hashtable = new Hashtable();
                table = new DataTable();
                for (num = 0; num < rs.Fields.Count; num++)
                {
                    string name = rs.Fields[num].Name;
                    if (!table.Columns.Contains(name))
                    {
                        table.Columns.Add(name);
                    }
                    else
                    {
                        if (hashtable[name] != null)
                        {
                            hashtable[name] = int.Parse(hashtable[name].ToString()) + 1;
                        }
                        else
                        {
                            hashtable[name] = "1";
                        }
                        table.Columns.Add(name + "_" + hashtable[name]);
                    }
                }
            }
            if (!rs.EOF)
            {
                object[,] objArray = (object[,]) rs.GetType().InvokeMember("GetRows", BindingFlags.InvokeMethod, null, rs, new object[0]);
                int length = objArray.GetLength(1);
                int num3 = objArray.GetLength(0);
                for (num = 0; num < length; num++)
                {
                    object[] values = new object[num3];
                    for (int i = 0; i < num3; i++)
                    {
                        values[i] = objArray[i, num];
                    }
                    table.Rows.Add(values);
                }
            }
            return table;
        }

        public static Connection CreateConnection(string connectionString)
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { connectionString });
            return target;
        }

        public override bool Equals(object obj)
        {
            if ((obj != null) && (obj is DBInformer))
            {
                DBInformer informer = obj as DBInformer;
                if ((informer.ConnectionString != null) && informer.ConnectionString.Equals(this.ConnectionString))
                {
                    if (informer.DefaultDatabase != null)
                    {
                        return informer.DefaultDatabase.Equals(this.DefaultDatabase);
                    }
                    return (this.DefaultDatabase == null);
                }
                return false;
            }
            return false;
        }

        public DataTable ExecuteSql(string sql)
        {
            object obj2;
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            Recordset rs = target.Execute(sql, out obj2, -1);
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        public DataTable ExecuteSql(string sql, int samples)
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            Recordset rs = new RecordsetClass();
            rs.Open(sql, target, CursorTypeEnum.adOpenForwardOnly, LockTypeEnum.adLockReadOnly, -1);
            rs.PageSize = samples;
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        private void FreeTempConnection()
        {
            this.tempConn.Close();
        }

        public DataTable GetCatalogs()
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            this.properties = target.Properties;
            Recordset rs = (Recordset) target.GetType().InvokeMember("OpenSchema", BindingFlags.InvokeMethod, null, target, new object[] { SchemaEnum.adSchemaCatalogs });
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        public DataTableMetadata GetDataTableMetadata(string name)
        {
            DataTableMetadata metadata;
            Hashtable userTables = this.GetUserTables();
            name = name.ToUpper();
            if (userTables.ContainsKey(name))
            {
                metadata = (DataTableMetadata) userTables[name];
                if (metadata.Fields == null)
                {
                    metadata.Fields = this.GetTableColumns(name);
                }
                return metadata;
            }
            Hashtable userViews = this.GetUserViews();
            if (userViews.ContainsKey(name))
            {
                metadata = (DataTableMetadata) userViews[name];
                if (metadata.Fields == null)
                {
                    metadata.Fields = this.GetTableColumns(name);
                }
                return metadata;
            }
            return null;
        }

        public DataTable GetForeignKeys(string tableName)
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            object[] objArray = new object[3];
            Recordset rs = (Recordset) target.GetType().InvokeMember("OpenSchema", BindingFlags.InvokeMethod, null, target, new object[] { SchemaEnum.adSchemaForeignKeys, objArray });
            rs.Filter = "FK_TABLE_NAME = '" + tableName + "'";
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public DataTable GetPrimaryKeys(string tableName)
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            object[] objArray2 = new object[3];
            objArray2[2] = tableName;
            object[] objArray = objArray2;
            Recordset rs = (Recordset) target.GetType().InvokeMember("OpenSchema", BindingFlags.InvokeMethod, null, target, new object[] { SchemaEnum.adSchemaPrimaryKeys, objArray });
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        public DataTable GetProcedures()
        {
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            Recordset rs = (Recordset) target.GetType().InvokeMember("OpenSchema", BindingFlags.InvokeMethod, null, target, new object[] { SchemaEnum.adSchemaProcedures });
            DataTable table = ConvertRecordset(rs);
            rs.Close();
            target.Close();
            return table;
        }

        public DataFieldMetadata[] GetRecordsetSchema(string query)
        {
            string[] names = Enum.GetNames(typeof(DataTypeEnum));
            Array values = Enum.GetValues(typeof(DataTypeEnum));
            Recordset recordset = this.ReturnRecordSet(query);
            DataFieldMetadata[] metadataArray = new DataFieldMetadata[recordset.Fields.Count];
            for (int i = 0; i < recordset.Fields.Count; i++)
            {
                int index = Array.IndexOf<string>(names, recordset.Fields[i].Type.ToString());
                object obj2 = values.GetValue(index);
                metadataArray[i] = new DataFieldMetadata("tempTable", recordset.Fields[i].Name, obj2);
                metadataArray[i].Size = recordset.Fields[i].DefinedSize;
            }
            recordset.Close();
            this.FreeTempConnection();
            return metadataArray;
        }

        public ArrayList GetTableColumns(string tableName)
        {
            if (metadataCache.ContainsKey(this.htkey + ":" + tableName + ":Columns"))
            {
                return (ArrayList) metadataCache[this.htkey + ":" + tableName + ":Columns"];
            }
            Connection target = new ConnectionClass();
            target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            string str = tableName;
            if (tableName.IndexOf(".") > 0)
            {
                string[] strArray = tableName.Split(new char[] { '.' });
                if (strArray.Length == 2)
                {
                    str = strArray[1];
                }
            }
            object[] objArray3 = new object[4];
            objArray3[2] = tableName;
            object[] objArray = objArray3;
            objArray3 = new object[3];
            objArray3[2] = str;
            object[] restrictions = objArray3;
            Recordset recordset = target.OpenSchema(SchemaEnum.adSchemaColumns, restrictions, Missing.Value);
            ArrayList list = new ArrayList();
            while (!recordset.EOF)
            {
                string str2 = recordset.Fields["COLUMN_NAME"].Value.ToString();
                DataFieldMetadata metadata = new DataFieldMetadata(recordset.Fields["TABLE_NAME"].Value.ToString(), recordset.Fields["COLUMN_NAME"].Value.ToString(), recordset.Fields["DATA_TYPE"].Value.ToString());
                if (recordset.Fields["CHARACTER_MAXIMUM_LENGTH"].Value != null)
                {
                    string s = recordset.Fields["CHARACTER_MAXIMUM_LENGTH"].Value.ToString();
                    if (s != string.Empty)
                    {
                        metadata.Size = int.Parse(s);
                    }
                }
                try
                {
                    metadata.IsNullable = bool.Parse(recordset.Fields["IS_NULLABLE"].Value.ToString());
                }
                catch
                {
                    metadata.IsNullable = false;
                }
                list.Add(metadata);
                recordset.MoveNext();
            }
            metadataCache.Add(this.htkey + ":" + tableName + ":Columns", list);
            recordset.Close();
            target.Close();
            return list;
        }

        public DataTable GetTablePrivileges()
        {
            try
            {
                Connection connection = new ConnectionClass();
                connection.Open(this.connectionString, null, null, 0);
                if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
                {
                    connection.DefaultDatabase = this.defaultDatabase;
                }
                object[] objArray2 = new object[3];
                objArray2[2] = "TABLES_PRIVILEGES";
                object[] objArray = objArray2;
                Recordset rs = connection.OpenSchema(SchemaEnum.adSchemaTablePrivileges, Missing.Value, Missing.Value);
                DataTable table = ConvertRecordset(rs);
                rs.Close();
                connection.Close();
                return table;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return new DataTable();
        }

        public Hashtable GetUserTables()
        {
            if (metadataCache.ContainsKey(this.htkey + "Tables"))
            {
                return (Hashtable) metadataCache[this.htkey + "Tables"];
            }
            Connection connection = new ConnectionClass();
            connection.Open(this.connectionString, null, null, 0);
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                connection.DefaultDatabase = this.defaultDatabase;
            }
            Recordset recordset = connection.OpenSchema(SchemaEnum.adSchemaTables, Missing.Value, Missing.Value);
            if (!recordset.BOF)
            {
                recordset.Filter = "TABLE_TYPE='TABLE'";
            }
            Hashtable hashtable = new Hashtable();
            while (!recordset.EOF)
            {
                object obj2 = recordset.Fields["TABLE_SCHEMA"].Value;
                string str = recordset.Fields["TABLE_NAME"].Value.ToString();
                if (!(((obj2 == null) || !(obj2.ToString().Trim() != "")) || obj2.ToString().ToLower().Equals("dbo")))
                {
                    str = obj2.ToString() + "." + str;
                }
                DataTableMetadata metadata = new DataTableMetadata(str);
                if (obj2 != null)
                {
                    metadata.Schema = obj2.ToString();
                }
                hashtable[metadata.Name.ToUpper()] = metadata;
                recordset.MoveNext();
            }
            metadataCache[this.htkey + "Tables"] = hashtable;
            recordset.Close();
            connection.Close();
            return hashtable;
        }

        public Hashtable GetUserViews()
        {
            if (metadataCache.ContainsKey(this.htkey + "Views"))
            {
                return (Hashtable) metadataCache[this.htkey + "Views"];
            }
            Connection target = new ConnectionClass();
            target.Open(this.connectionString, null, null, 0);
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                target.DefaultDatabase = this.defaultDatabase;
            }
            Recordset recordset = (Recordset) target.GetType().InvokeMember("OpenSchema", BindingFlags.InvokeMethod, null, target, new object[] { SchemaEnum.adSchemaTables });
            if (!recordset.BOF)
            {
                recordset.Filter = "TABLE_TYPE='VIEW'";
            }
            Hashtable hashtable = new Hashtable();
            while (!recordset.EOF)
            {
                object obj2 = recordset.Fields["TABLE_SCHEMA"].Value;
                string str = recordset.Fields["TABLE_NAME"].Value.ToString();
                if ((obj2 != null) && (obj2.ToString().Trim() != ""))
                {
                    str = obj2.ToString() + "." + str;
                }
                DataTableMetadata metadata = new DataTableMetadata(str, TableType.View);
                hashtable[metadata.Name.ToUpper()] = metadata;
                recordset.MoveNext();
            }
            metadataCache[this.htkey + "Views"] = hashtable;
            recordset.Close();
            target.Close();
            return hashtable;
        }

        private Recordset ReturnRecordSet(string sql)
        {
            object obj2;
            this.tempConn = new ConnectionClass();
            Connection tempConn = this.tempConn;
            tempConn.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, tempConn, new object[] { this.connectionString });
            if ((this.defaultDatabase != null) && (this.defaultDatabase != ""))
            {
                tempConn.DefaultDatabase = this.defaultDatabase;
            }
            return tempConn.Execute(sql, out obj2, -1);
        }

        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public string DefaultDatabase
        {
            get
            {
                return this.defaultDatabase;
            }
            set
            {
                this.defaultDatabase = value;
            }
        }

        public Hashtable MetadataCache
        {
            get
            {
                return metadataCache;
            }
        }

        public ADODB.Properties Properties
        {
            get
            {
                if (this.properties == null)
                {
                    Connection target = new ConnectionClass();
                    target.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, target, new object[] { this.connectionString });
                    this.properties = target.Properties;
                    target.Close();
                }
                return this.properties;
            }
        }
    }
}

