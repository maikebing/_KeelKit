namespace CodeDomAssistant
{
    using RemoteLoader;
    using System;
    using System.Data;
    using System.IO;

    public class DynProvider
    {
        public static DataSet GetAssemblyInfo()
        {
            DataSet set = new DataSet();
            set.DataSetName = "AssemblyDataSet";
            DataTable table = set.Tables.Add("Assembly");
            table.Columns.Add("Load", typeof(bool));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Path", typeof(string));
            table.Columns.Add("IsGAC", typeof(bool));
            table.Columns.Add("HasProvider", typeof(bool));
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CodeDomAssistant");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str2 = Path.Combine(path, "AssemblyData.xml");
            if (File.Exists(str2))
            {
                set.ReadXml(str2);
            }
            set.AcceptChanges();
            return set;
        }

        public static void MergeGAC(DataSet assemblydata, bool refreshcache, Progress progress)
        {
            AppDomain domain = null;
            try
            {
                AppDomainSetup info = new AppDomainSetup();
                info.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                domain = AppDomain.CreateDomain("FindCodeDomProviders", null, info);
                RemoteLoaderFactory factory = (RemoteLoaderFactory) domain.CreateInstance("RemoteLoader", "RemoteLoader.RemoteLoaderFactory").Unwrap();
                foreach (string str2 in Directory.GetDirectories(Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), @"assembly\GAC")))
                {
                    if (progress != null)
                    {
                        progress.Message = string.Format("Scanning GAC: {0}", Path.GetFileName(str2));
                        progress.Notify();
                    }
                    foreach (string str3 in Directory.GetDirectories(str2))
                    {
                        foreach (string str4 in Directory.GetFiles(str3, "*.dll"))
                        {
                            DataRow[] rowArray = assemblydata.Tables[0].Select(string.Format("Path = '{0}'", str4));
                            if ((rowArray.Length == 0) || refreshcache)
                            {
                                string assemblyName = factory.GetAssemblyName(str4);
                                if (assemblyName != null)
                                {
                                    bool flag = factory.IsSubclassOfCodeDomProvider(str4);
                                    DataRow row = null;
                                    if (rowArray.Length == 0)
                                    {
                                        row = assemblydata.Tables[0].NewRow();
                                    }
                                    else
                                    {
                                        row = rowArray[0];
                                    }
                                    row = assemblydata.Tables[0].NewRow();
                                    row["Load"] = false;
                                    row["Name"] = assemblyName;
                                    row["Path"] = str4;
                                    row["IsGAC"] = true;
                                    row["HasProvider"] = flag;
                                    if (rowArray.Length == 0)
                                    {
                                        assemblydata.Tables[0].Rows.Add(row);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
            }
        }

        public static void MergeLocal(DataSet assemblydata, string assemblyfile, Progress progress)
        {
            DataRow row = null;
            bool flag = false;
            AppDomain domain = null;
            try
            {
                if (progress != null)
                {
                    progress.Message = string.Format("Scanning DLL: {0}", Path.GetFileName(assemblyfile));
                    progress.Notify();
                }
                AppDomainSetup info = new AppDomainSetup();
                info.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                domain = AppDomain.CreateDomain("TestCodeDomProviders", null, info);
                RemoteLoaderFactory factory = (RemoteLoaderFactory) domain.CreateInstance("RemoteLoader", "RemoteLoader.RemoteLoaderFactory").Unwrap();
                string assemblyName = factory.GetAssemblyName(assemblyfile);
                if (assemblyName != null)
                {
                    flag = factory.IsSubclassOfCodeDomProvider(assemblyfile);
                    DataRow[] rowArray = assemblydata.Tables[0].Select(string.Format("Path = '{0}'", assemblyfile));
                    if (rowArray.Length == 0)
                    {
                        row = assemblydata.Tables[0].NewRow();
                    }
                    else
                    {
                        row = rowArray[0];
                    }
                    row["Load"] = false;
                    row["Name"] = assemblyName;
                    row["Path"] = assemblyfile;
                    row["IsGAC"] = false;
                    row["HasProvider"] = flag;
                    if (rowArray.Length == 0)
                    {
                        assemblydata.Tables[0].Rows.Add(row);
                    }
                }
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
            }
        }

        public static void SaveAssemblyInfo(DataSet assemblydata)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CodeDomAssistant");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.Combine(path, "AssemblyData.xml");
            assemblydata.WriteXml(fileName);
            assemblydata.AcceptChanges();
        }
    }
}

