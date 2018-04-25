using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keel.DB
{
    public class Connect
    {
        public bool IsMe(string dbnamespace)
        {
            return dbnamespace == "MySql.Data.MySqlClient";
        }
        public Type GetDBType()
        {
            return typeof(MYSQL);
        }
 
    }
}
