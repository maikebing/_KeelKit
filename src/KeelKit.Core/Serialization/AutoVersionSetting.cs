using System;
using System.IO;

namespace KeelKit.Serialization
{
    public enum VersionType
    {
        Counter,
        SCV,
        NoControl
	}
       public enum VersionKind
    {
       Default,
          KVT

	}

    [Serializable]
    public class AutoVersionSetting
    {
        public bool Enable { get; set; }
        public string ProjectBase { get; set; }
        public VersionKind Kind { get; set; }
        public bool RndBuildRev { get; set; }
        public bool OneVersion { get; set; }
        public string  major { get; set; } 
        public string  minor { get; set; }
        public string build { get; set; }
        public string revision { get; set; }
        public VersionType buildVerType { get; set; }
        public VersionType revisionVerType { get; set; }
        public SearchOption searchOption { get; set; }

    }
}
