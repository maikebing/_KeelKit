using System;
using System.Collections.Generic;
using System.Text;

namespace Keel.Tools.MySqlProxy
{
    internal  class PHPInput
    {
        private  const string _connect_info = "<connect_info><host>{0}</host><user>{1}</user><password>{2}</password><db>{3}</db><charset>{4}</charset><port>{5}</port></connect_info>";

        private const string _query_info = "<query_info><query b='{0}' e='{1}'>{2}</query><querylen>{3}</querylen></query_info>";
        private static  string  host_;

        public static  string  host
        {
            get { return host_; }
            set { host_ = value; }
        }

        private static  string  user_;

        public static  string  user
        {
            get { return user_; }
            set { user_ = value; }
        }

        private  static string  password_;

        public static  string  password
        {
            get { return password_; }
            set { password_ = value; }
        }

        private  static string  db_;

        public static  string  db
        {
            get { return db_; }
            set { db_ = value; }
        }

        private static  string  charset_;

        public static  string  charset
        {
            get { return charset_; }
            set { charset_ = value; }
        }

        private  static string  port_;

        public static  string  port
        {
            get { return port_; }
            set { port_ = value; }
        }

        private static  bool  b_;

        public static  bool  b
        {
            get { return b_; }
            set { b_ = value; }
        }

        private  static bool  e_;

        public  static bool  e
        {
            get { return e_; }
            set { e_ = value; }
        }

        private  static string  query_;

        public static  string  query
        {
            get { return query_; }
            set { query_ = value; }
        }
        private static  bool  isinit_;

        public static  bool  isinit
        {
            get { return isinit_; }
            set { isinit_ = value; }
        }
	
       
            
        public static void init(string _host,string _user,string _password,string _db)
        {
            host = _host;
            user = _user;
            password = _password;
            db = _db;
            port = "3306";
            charset = "utf8";
            b = false ;
            e = true ;

        }
        public static string getxml(string _query)
        {
            return getxml(_query, b, e);
        }
        public static string getxml(string _query,bool _b,bool _e )
        {
            query = _query;
            string connect_info = string.Format(_connect_info, host, user, password, db, charset, port);
            byte[] buffer=System.Text.Encoding.UTF8.GetBytes(query );
            string query_info = string.Format(_query_info, _b?"1":"0", _e?"1":"0",Convert.ToBase64String(buffer ), buffer.Length );
            string xmlcontext = string.Format("<xml>{0}{1}</xml>", connect_info, query_info);
            return xmlcontext;
        }
    }
}
