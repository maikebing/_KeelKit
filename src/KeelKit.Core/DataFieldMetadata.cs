using System;
 
namespace KeelKit.Core
{
   
  

    public class DataFieldMetadata
    {
        private object defaultValueStr;
        private string fieldType;
        private string formatStr;
        private string name;
        private bool nullable;
        private int size;
        private string table;
        private object typeID;

        public DataFieldMetadata(string _table, string _name, object _typeID)
        {
            this.nullable = true;
            this.Name = _name;
            this.typeID = _typeID;
            this.Table = _table;
        }

        public DataFieldMetadata(string _table, string _name, object _typeID, short _size) : this(_table, _name, _typeID)
        {
            this.size = _size;
        }

        public override string ToString()
        {
            return this.name;
        }

        public object DefaultValueStr
        {
            get
            {
                return this.defaultValueStr;
            }
            set
            {
                this.defaultValueStr = value;
            }
        }

        public string FieldType
        {
            get
            {
                if (this.fieldType == null)
                {
                    this.fieldType = DatabaseUtils.ConvertDataType(this.TypeID);
                }
                return this.fieldType;
            }
        }

        public string FormatStr
        {
            get
            {
                return this.formatStr;
            }
            set
            {
                this.formatStr = value;
            }
        }

        public bool IsNullable
        {
            get
            {
                return this.nullable;
            }
            set
            {
                this.nullable = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!StringUtils.IsValidObjectName(value))
                {
                    throw new Exception(value + ",FIELD");
                }
                this.name = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public string Table
        {
            get
            {
                return this.table;
            }
            set
            {
                if (!StringUtils.IsValidObjectName(value))
                {
                    throw new Exception(value + ",TABLE");
                }
                this.table = value;
            }
        }

        public object TypeID
        {
            get
            {
                return this.typeID;
            }
            set
            {
                this.TypeID = value;
            }
        }
    }
}

