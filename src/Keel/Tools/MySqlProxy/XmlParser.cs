using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
namespace Keel.Tools.MySqlProxy
{
    internal class XmlParser
    {
        XmlDocument xml = new XmlDocument();
        public XmlParser(string context)
        {
            //xml.NodeInserted += new XmlNodeChangedEventHandler(xml_NodeInserted);
            xml.LoadXml(context);

        }
        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        /// <![CDATA[<xml><result v="6.0"><e_i><e_n>1064</e_n><e_d>You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near &apos;3  * from uc_17fengmembers&apos; at line 1</e_d></e_i></result></xml> ]]>
        public MySqlProxyException GetException()
        {
            XmlNode sn = xml.SelectSingleNode("descendant::e_i");
            MySqlProxyException result = null;
            if (sn != null && sn.ChildNodes.Count >= 2)
            {
                string en = sn.SelectSingleNode("descendant::e_n").InnerText;
                string ed = sn.SelectSingleNode("descendant::e_d").InnerText;
                result = new MySqlProxyException(int.Parse(en), ed);


            }
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.chs/fxref_system.xml/html/3e578a48-ef90-7f24-5fc7-257fd645272b.htm"/>
        /// <returns></returns>
        public string get_server_info()
        {

            return readInnerText("s_v"); ;
        }
        public string insert_id
        {
            get
            {
                return readInnerText("i_i");
            }
        }

        public string tunnelversion
        {
            get
            {
                return readAttrib("result", "v");
            }
        }

        public int fieldcount
        {
            get
            {


                string s = readAttrib("f_i", "c");
                int result = 0;
                int.TryParse(s, out result);
                return result;
            }
        }
        public int GetScalar()
        {
            return 0;
        }
        public DataTable GetDataTable()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            int fc = fieldcount;
            if (fc > 0)
            {
                XmlNode sn = xml.SelectSingleNode("descendant::f_i");

                if (sn.ChildNodes.Count == fc)//检查是否一致。
                {
                    for (int i = 0; i < fc; i++)
                    {
                        XmlNode xm = sn.ChildNodes[i];
                        string t = xm.SelectSingleNode("descendant::t").InnerText;
                        if (t.Trim() == "") t = "datatable";
                        if (!ds.Tables.Contains(t))
                        {
                            ds.Tables.Add(t);
                            dt = ds.Tables[t];
                        }
                        string ty = xm.SelectSingleNode("descendant::ty").InnerText;
                        Type sty = GetSysType(ty);

                        ds.Tables[t].Columns.Add(xm.SelectSingleNode("descendant::n").InnerText, sty);

                    }
                }
                XmlNode ri = xml.SelectSingleNode("descendant::r_i");
                if (ri.HasChildNodes)
                {
                    foreach (XmlNode item in ri.ChildNodes)
                    {
                        if (item.HasChildNodes)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < item.ChildNodes.Count; i++)
                            {
                                XmlNode v = item.ChildNodes[i];

                                try
                                {
                                    dr[i] = Convert.ChangeType(v.InnerText, dt.Columns[i].DataType);
                                }
                                catch (Exception)
                                {


                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }

                }
            }
            return dt;
        }
        public Type GetSysType(string mysqltype)
        {
            Type t = typeof(object);
             t =MySQLHelper.GetTypeByByMySqlType  ((MySqlDbType)Enum.Parse(typeof(MySqlDbType), mysqltype, true)  );
            return t;
        }
        public string readAttrib(string itempath, string attname)
        {
            string result = null;
            XmlNode sn = xml.SelectSingleNode("descendant::" + itempath);
            if (sn != null)
                result = sn.Attributes[attname].Value;

            return result;
        }

        public string readInnerText(string itempath)
        {
            string result = null;
            XmlNode sn = xml.SelectSingleNode("descendant::" + itempath);
            if (sn != null)
            {
                result = sn.InnerText;
            }
            return result;
        }
    }
}
