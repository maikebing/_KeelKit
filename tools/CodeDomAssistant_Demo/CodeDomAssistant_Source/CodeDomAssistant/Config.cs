namespace CodeDomAssistant
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;

    public class Config
    {
        private Hashtable settings = new Hashtable();

        public Config()
        {
            this.loadSettings();
        }

        public bool GetBoolValue(string itemName)
        {
            object obj2 = this.settings[itemName];
            if (obj2 == null)
            {
                return false;
            }
            string str = obj2.ToString();
            if (str.Length == 0)
            {
                return false;
            }
            return bool.Parse(str);
        }

        public string[] GetStringList(string listName)
        {
            List<string> list = new List<string>();
            object obj2 = this.settings[listName];
            if (obj2 == null)
            {
                return list.ToArray();
            }
            string str = obj2.ToString();
            if (str.Length == 0)
            {
                return list.ToArray();
            }
            return str.Split(new char[] { ',' });
        }

        public void loadSettings()
        {
            this.settings.Clear();
            foreach (string str in ConfigurationManager.AppSettings.AllKeys)
            {
                this.settings.Add(str, ConfigurationManager.AppSettings[str]);
            }
        }

        public void saveSettings()
        {
            string path = Application.StartupPath + @"\App.config";
            if (File.Exists(path))
            {
                this.saveSettings(path);
            }
            else
            {
                path = Application.ExecutablePath + ".config";
                if (File.Exists(path))
                {
                    this.saveSettings(path);
                    path = Application.StartupPath + @"\..\..\App.config";
                    if (File.Exists(path))
                    {
                        this.saveSettings(path);
                    }
                }
                else
                {
                    path = Application.StartupPath + @"\App.config";
                    this.saveSettings(path);
                }
            }
        }

        public void saveSettings(string path)
        {
            XmlElement element = null;
            string strA = string.Empty;
            XmlDocument document = new XmlDocument();
            if (File.Exists(path))
            {
                document.Load(path);
            }
            XmlNodeList list = document.SelectNodes("configuration/appSettings/add");
            foreach (string str2 in this.settings.Keys)
            {
                bool flag = false;
                foreach (XmlNode node in list)
                {
                    element = (XmlElement) node;
                    strA = element.GetAttribute("key").ToString();
                    if (string.Compare(strA, str2) == 0)
                    {
                        element.SetAttribute("value", this.settings[strA].ToString());
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    XmlNode newChild = document.SelectSingleNode("configuration/appSettings");
                    if (newChild == null)
                    {
                        XmlNode node3 = document.SelectSingleNode("configuration");
                        if (node3 != null)
                        {
                            newChild = document.CreateElement("appSettings");
                            node3.AppendChild(newChild);
                        }
                    }
                    if (newChild != null)
                    {
                        XmlElement element2 = document.CreateElement("add");
                        element2.Attributes.Append(document.CreateAttribute("key"));
                        element2.Attributes.Append(document.CreateAttribute("value"));
                        element2.SetAttribute("key", str2);
                        element2.SetAttribute("value", this.settings[str2].ToString());
                        newChild.AppendChild(element2);
                    }
                }
            }
            document.Save(path);
        }

        public void SetStringList(string listName, string[] list)
        {
            string str = string.Empty;
            foreach (string str2 in list)
            {
                if (str.Length != 0)
                {
                    str = str + ",";
                }
                str = str + str2;
            }
            this.settings[listName] = str;
        }

        public string this[string itemName]
        {
            get
            {
                object obj2 = this.settings[itemName];
                if (obj2 == null)
                {
                    return string.Empty;
                }
                return obj2.ToString();
            }
            set
            {
                if (this.settings[itemName] == null)
                {
                    this.settings.Add(itemName, value);
                }
                else
                {
                    this.settings[itemName] = value;
                }
            }
        }

        public string this[int index]
        {
            get
            {
                object obj2 = this.settings[index];
                if (obj2 == null)
                {
                    return string.Empty;
                }
                return obj2.ToString();
            }
        }
    }
}

