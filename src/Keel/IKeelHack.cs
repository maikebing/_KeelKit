using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keel
{
     public  interface  IKeelHack
    {
        string DBProviderName { get;  }
        string DBConnectionString { get;  }
    }
}
