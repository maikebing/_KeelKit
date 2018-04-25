using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CodeDomAssistant.SampleCode
{
    public class SampleBase : IDisposable
    {
        protected string t;

        public SampleBase()
        {
        }

        public SampleBase(string t)
            : this()
        {
            this.t = t;
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            t = "disposed";
        }

        #endregion
    }

    public class Sample : SampleBase
    {
        public delegate void DelegateTest(object sender, EventArgs e);

        public event DelegateTest DataChanged;

        public Sample()
             : base("test")
        {
            t = "constructed";
        }

        public void TestFor()
        {
            for (int x = 0; x < 5; x++)
            {
                if (x < 2)
                    continue;

                if (x == 3)
                    break;
            }
        }

        public void TestForEach()
        {
            List<string> mylist = new List<string>();
            mylist.Add("test1");
            mylist.Add("test2");
            mylist.Add("test3");

            foreach (string t in mylist)
            {
                if (t == "test2")
                    break;
            }
        }

        public void TestDo()
        {
            int x = 0;
            do
            {
                x++;
            }
            while (x < 3);
        }

        public void TestWhile()
        {
            int x = 0;
            while (x < 3)
            {
                x++;
            }
        }

        public void TestUsing()
        {
            using (new SampleBase())
            {
                t = "done";
            }
        }

        public string TestProperty
        {
            get { return t; }
            set { t = value; }
        }
    }
}
