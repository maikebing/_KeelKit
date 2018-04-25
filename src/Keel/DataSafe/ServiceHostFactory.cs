using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Xml;

namespace Keel.DataSafe
{
   

    [TypeForwardedFrom("System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class ServiceHostFactory : ServiceHostFactoryBase
    {
        // Fields
        private Collection<string> referencedAssemblies = new Collection<string>();

        // Methods
        internal void AddAssemblyReference(string assemblyName)
        {
            this.referencedAssemblies.Add(assemblyName);
        }
        void log(string text)
        {
            string logfile = new System.IO.FileInfo(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile).DirectoryName + "\\log.log";
            text = DateTime.Now.ToString ()+ "----------------------------------" + Environment.NewLine + text+Environment.NewLine ;

            System.IO.File.AppendAllText(logfile, text);
        }
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            log("CreateServiceHost的CreateServiceHost：" + constructorString);
            Type serviceType = Type.GetType(constructorString, false);

            if (serviceType == null)
            {
                log("没有得到serviceType");
                List<Assembly> assemblies = new List<Assembly>(AppDomain.CurrentDomain.GetAssemblies());
                List<string> fss = new List<string>(System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"));
 
                fss.AddRange(System.IO.Directory.GetFiles(new System.IO.FileInfo(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile).DirectoryName, "*.dll", System.IO.SearchOption.AllDirectories ));
                foreach (var item in fss.ToArray())
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFile(item);
                        assemblies.Add(asm);
                    }
                    catch (Exception ex)
                    {
                        log("加载文件" + item + "时遇到错误" + ex.Message);
                    }
                }

                for (int i = 0; i < assemblies.ToArray().Length; i++)
                {
                    try
                    {
                        serviceType = assemblies[i].GetType(constructorString, false);
                        if (serviceType != null)
                        {
                            log("在程序集" + assemblies[i].FullName + "中尝试创建类型" + constructorString + "成功类型是:" + serviceType.FullName );
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        log("在程序集" + assemblies[i].FullName + "中尝试创建类型" + constructorString+"时遇到异常" + ex.Message);
                    }
                }
            }
            else
            {
                log("serviceType的完整名称是:" + serviceType.FullName);
            }
            log ("创建类型"+constructorString+":"+(serviceType==null ?"失败":"成功"));
            return this.CreateServiceHost(serviceType, baseAddresses);
        }
        static string key =null ;//  "JggkieIw7JM=";
        static string iv = null;//  "XdTkT85fZ0U=";
        protected virtual ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            //服务地址

            ServiceHost host = new ServiceHost(serviceType, baseAddresses);
        
            if (key == null && iv == null)
            {
                try
                {
                   key= Keel.Internal.KeelHackHelper.ReadKeelHack("KeelWCFDataSafe_Key");
                   iv= Keel.Internal.KeelHackHelper.ReadKeelHack("KeelWCFDataSafe_IV");
                }
                catch (Exception)
                {
                    key = "JggkieIw7JM=";
                    iv = "XdTkT85fZ0U=";

                }
                Console.WriteLine("key" + key);
                Console.WriteLine("iv" + iv);
            }
       
             
            host.AddServiceEndpoint(serviceType.GetInterfaces()[0], new KeelDataSafeBinding (key ,iv ) ,"");
            if (host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
            {
                System.ServiceModel.Description.ServiceMetadataBehavior svcMetaBehavior = new System.ServiceModel.Description.ServiceMetadataBehavior();
                svcMetaBehavior.HttpGetEnabled = true;
                svcMetaBehavior.HttpGetUrl = new Uri(baseAddresses[0].OriginalString + "?wsdl");// new Uri("http://127.0.0.1:8001/Mex");
                host.Description.Behaviors.Add(svcMetaBehavior);
            }
            host.Opened += new EventHandler(delegate(object obj, EventArgs e)
            {
                Console.WriteLine("服务已经启动！");
            });
            return host;
        }
    }


}