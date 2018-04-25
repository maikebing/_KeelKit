using System;

namespace KeelKit.Serialization
{
    [Serializable ]
    public  class ClcSetting

    {
        public bool NoEmptyLine { get; set; }
        public bool NoRemLine { get; set; }
        public bool NoDesingerFile { get; set; }
        public string  NoExts { get; set; }
    }
}
