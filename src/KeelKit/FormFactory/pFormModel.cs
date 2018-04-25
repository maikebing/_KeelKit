using System;
using System.ComponentModel;
using System.Reflection;

namespace KeelKit.Property
{
    [Serializable]
    [DefaultPropertyAttribute("Name")]
    public  class pFormModel
    {
        public string Name { get; set; }

        private  string  _ControlStringType="System.Windows.Forms.TextBox";
        [DefaultValue("System.Windows.Forms.TextBox")] 
        public string ControlStringType
        {
            get
            {
                return _ControlStringType;
            }
            set
            {
                if (System.IO.File.Exists(AsmFile))
                {
                    ControlType = Assembly.LoadFile(AsmFile).GetType(_ControlStringType, false, true);
                }
                else
                {
                    ControlType = Type.GetType(_ControlStringType);
                }
               
            }
        }
       
        public string AsmFile { get; set; }
      
        public Type ControlType { get; set; }
    }
}
