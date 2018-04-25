using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keel.DB
{
    internal class Remote: IDatabase 
    {
        object obj = null;
        Type tp = null;
        public Remote(string connectstring,Type t)
        {
            ConnectString = connectstring;
            obj = Activator.CreateInstance(t, connectstring);
            tp = t;
        }
        public System.Data.Common.DbProviderFactory GetProviderFactory()
        {
            return tp.InvokeMember("GetProviderFactory",
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, 
                                    obj,
                                    new object[] { }
                                    ) as System.Data.Common.DbProviderFactory;

        }

        public string  ConnectString { get; set; }

        public Type PasteType(string dbtypestring)
        {
            return (Type)tp.InvokeMember("PasteType",
                                   System.Reflection.BindingFlags.InvokeMethod,
                                   null,
                                   obj,
                                   new object[] { dbtypestring }
                                   ) ;
        }

        public System.Data.DbType PasteDBType(string dbtypestring)
        {
            return (System.Data.DbType)tp.InvokeMember("PasteDBType",
                                 System.Reflection.BindingFlags.InvokeMethod,
                                 null,
                                 obj,
                                 new object[] { dbtypestring }
                                 ) ;
        }

        public System.Data.DbType PasteType(Type t)
        {
            return (System.Data.DbType)tp.InvokeMember("PasteType",
                                 System.Reflection.BindingFlags.InvokeMethod,
                                 null,
                                 obj,
                                 new object[] { t }
                                 ) ;
        }

        public string GetIdentifierEndChar()
        {
            return tp.InvokeMember("GetIdentifierEndChar",
                         System.Reflection.BindingFlags.InvokeMethod,
                         null,
                         obj,
                         new object[] {   }
                         ) as string;
        }

        public string GetIdentifierStartChar()
        {
            return tp.InvokeMember("GetIdentifierStartChar",
                         System.Reflection.BindingFlags.InvokeMethod,
                         null,
                         obj,
                         new object[] { }
                         ) as string;
        }

        public string GetParamIdentifierChar()
        {
            return tp.InvokeMember("GetParamIdentifierChar",
                           System.Reflection.BindingFlags.InvokeMethod,
                           null,
                           obj,
                           new object[] { }
                           ) as string;
        }
    }
}
