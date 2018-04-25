namespace CodeDomAssistant.SampleCode
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Sample2 : SampleBase2
    {
        public event DelegateTest DataChanged;

        public Sample2() : base("test")
        {
            base.t = "constructed";
        }

        public virtual void TestDo()
        {
            int num = 0;
            for (bool flag = true; flag; flag = num < 3)
            {
                num++;
            }
        }

        public virtual void TestFor()
        {
            for (int i = 0; i < 5; i++)
            {
                if ((i >= 2) && (i == 3))
                {
                    return;
                }
            }
        }

        public virtual void TestForEach()
        {
            List<string> list = new List<string>();
            list.Add("test1");
            list.Add("test2");
            list.Add("test3");
            IEnumerator enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string current = (string) enumerator.Current;
                if (current == "test2")
                {
                    return;
                }
            }
        }

        public virtual void TestUsing()
        {
            object o = null;
            try
            {
                o = new SampleBase();
                base.t = "done";
            }
            finally
            {
                if ((o != null) && typeof(IDisposable).IsInstanceOfType(o))
                {
                    ((IDisposable) o).Dispose();
                }
            }
        }

        public virtual void TestWhile()
        {
            for (int i = 0; i < 3; i++)
            {
            }
        }

        public virtual string TestProperty
        {
            get
            {
                return base.t;
            }
            set
            {
                base.t = value;
            }
        }

        public delegate void DelegateTest(object sender, EventArgs e);
    }
}

