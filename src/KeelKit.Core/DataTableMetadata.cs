
using System;
using System.Collections;
 
namespace KeelKit.Core
{

    public class DataTableMetadata
    {
        private ArrayList fields;
        private string name;
        private string schema;
        private TableType type;

        public DataTableMetadata(string _name)
        {
            this.type = TableType.Table;
            this.Name = _name;
        }

        public DataTableMetadata(string _name, TableType _type) : this(_name)
        {
            this.type = _type;
        }

        public DataFieldMetadata GetDataFieldMetata(string name)
        {
            if (this.Fields != null)
            {
                foreach (DataFieldMetadata metadata in this.Fields)
                {
                    if (metadata.Name == name)
                    {
                        return metadata;
                    }
                }
                return null;
            }
            return null;
        }

        public ArrayList Fields
        {
            get
            {
                return this.fields;
            }
            set
            {
                this.fields = value;
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
                    throw new Exception(value + ",TABLE");
                }
                this.name = value;
            }
        }

        public string Schema
        {
            get
            {
                return this.schema;
            }
            set
            {
                if (!StringUtils.IsValidObjectName(value))
                {
                    throw new Exception(value + ",SCHEMA");
                }
                this.schema = value;
            }
        }

        public TableType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

