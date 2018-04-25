using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keel
{
    public class KeelContext
    {
        internal DBOperator<IDatabase> dbo;
        public KeelContext()
            : this(Keel.DB.Common.NowDataBase)
        {

        }
        public KeelContext(IDatabase idb)
        {
            dbo = new DBOperator<IDatabase>(idb);
        }

    }
}
