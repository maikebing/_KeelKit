using System;

namespace KeelKit.Core.Serialization
{
    [Serializable]
    public class NUnitSetting
    {
        public bool Enable { get; set; }
        public string NUnitRoot { get; set; }
        public string NunitProject { get; set; }
    }
}
