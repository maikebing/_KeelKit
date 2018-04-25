using System;
using System.Collections.Generic;
using System.Text;

namespace KeelKit.Core.Serialization
{
    [Serializable]
    public class TypeMap
    {
        public string UsingAsmDllFile { get; set; }
        public string LableControlType { get; set; }
        public string String_ControlType { get; set; }
        public string Decimal_ControlType { get; set; }
       
        public string DateTime_ControlType { get; set; }
    }
}
