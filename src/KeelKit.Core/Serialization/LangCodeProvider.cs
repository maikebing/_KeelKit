using System;
using System.Collections.Generic;

namespace KeelKit.Core.Serialization
{
    [Serializable]
    public class LangCodeProvider
    {
        public ProviderInfo CSharp { get; set; }
        public ProviderInfo VBDotNet { get; set; }
        public ProviderInfo IronPython { get; set; }
        public ProviderInfo FSharp { get; set; }
        public ProviderInfo CPP { get; set; }
        public  List<string> OtherProvider { get; set; }
    }
    [Serializable ]
    public class ProviderInfo
    {
        
        public ProviderInfo()
        {

        }
        public ProviderInfo(string pasmfullname, string ploc, string typename)
        {
            this.AsmFullName = pasmfullname;
            this.Location = ploc;
            this.TypeName = typename;
        }
        /// <summary>
        /// 程序集全名称
        /// Microsoft.VisualC.VSCodeProvider, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        /// </summary>
        public string AsmFullName { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Microsoft.VisualC.CppCodeProvider7
        /// </summary>
        public string TypeName { get; set; }
    }
}
