using System;
using System.Configuration;
using System.Reflection;
using System.Xml;
using Keel.DB;

namespace Keel.Internal
{
    public class KeelHackHelper
    {
        /// <summary>
        /// 读取名称为 ConnectionString的 链接字符串
        /// </summary>
        /// <returns></returns>
        public static IDatabase ReadConnectionString()
        {
            return ReadConnectionString("ConnectionString");
        }
        /// <summary>
        /// 读取指定名称的链接字符串
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public static IDatabase ReadConnectionString(string ConnectionString)
        {
            IDatabase result = null;
            XmlNodeList xnx = null; XmlNode xnl = null;
            string ss = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            ConfigXmlDocument cxd = new System.Configuration.ConfigXmlDocument();
            cxd.Load(ss);
            xnx = cxd.SelectNodes("descendant::configuration/connectionStrings/add");
            for (int i = 0; i < xnx.Count; i++)
            {
                if (xnx[i].Attributes["name"].Value.Contains("Properties.Settings." + ConnectionString)) //for c#
                {
                    xnl = xnx[i];
                    break;
                }
                else if (xnx[i].Attributes["name"].Value.Contains("My.MySettings." + ConnectionString))// for vb
                {
                    xnl = xnx[i];
                    break;

                }
            }

            ;// = cxd.SelectSingleNode("descendant::configuration/connectionStrings/add[@name='" + appnamespace + ".Properties.Settings.ConnectionString']");
            if (xnl != null && xnl.Attributes["providerName"] != null && xnl.Attributes["connectionString"] != null)
            {
                result = Common.GetIDatabaseByNamespace(xnl.Attributes["providerName"].Value, xnl.Attributes["connectionString"].Value);
            }
            return result;

        }
        /// <summary>
        /// 读取指定名称的配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReadKeelHack(string key)
        {

            string ss = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            ConfigXmlDocument cxd = new System.Configuration.ConfigXmlDocument();
            cxd.Load(ss);
            return ReadConfig(cxd, key);

        }
        /// <summary>
        /// 读取默认的KeelHack实例
        /// </summary>
        /// <returns></returns>
        public static IKeelHack GetKeelHack()
        {
            IKeelHack result = null;
            string ss = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            ConfigXmlDocument cxd = new System.Configuration.ConfigXmlDocument();
            cxd.Load(ss);
            string keelhackpath = System.AppDomain.CurrentDomain.SetupInformation.PrivateBinPath + "\\" + ReadConfig(cxd, "KeelHack");
            if (System.IO.File.Exists(keelhackpath))
            {
                Assembly asm = System.Reflection.Assembly.LoadFile(keelhackpath);
                Type t = asm.GetType("Keel.KeelHack", false, true);
                result = (IKeelHack)Activator.CreateInstance(t);
            }
            return result;
        }

        private static string ReadConfig(ConfigXmlDocument cxd, string configname)
        {
            string result = "";
            XmlNodeList xnx;
            xnx = cxd.SelectNodes("descendant::configuration/applicationSettings");
            if (xnx.Count > 0)
            {
                for (int i = 0; i < xnx.Count; i++)
                {
                    if (xnx[i].ChildNodes.Count > 0)
                    {
                        for (int ix = 0; ix < xnx[i].ChildNodes.Count; ix++)
                        {
                            XmlElement xn = (XmlElement)xnx[i].ChildNodes[ix];
                            if (xn.Name.Contains("Properties.Settings") || xn.Name.Contains("My.MySettings")) //for c#
                            {
                                for (int iy = 0; iy < xnx[i].ChildNodes[ix].ChildNodes.Count; iy++)
                                {
                                    XmlElement xy = (XmlElement)xnx[i].ChildNodes[ix].ChildNodes[iy];
                                    if (xy.Attributes["name"].Value == configname)
                                    {
                                        result = xy.InnerText;
                                        goto end;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            end:
            return result;
        }
    }
}
