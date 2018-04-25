namespace CodeDomAssistant.SampleCode
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Sample : SampleBase
    {
        public event DelegateTest DataChanged;

        public Sample() : base("test")
        {
            base.t = "constructed";
        }

        public void TestDo()
        {
            int num = 0;
            do
            {
                num++;
            }
            while (num < 3);
        }

        public void TestFor()
        {
            for (int i = 0; i < 5; i++)
            {
                if ((i >= 2) && (i == 3))
                {
                    return;
                }
            }
        }

        public void TestForEach()
        {
            List<string> list = new List<string>();
            list.Add("test1");
            list.Add("test2");
            list.Add("test3");
            foreach (string str in list)
            {
                if (str == "test2")
                {
                    break;
                }
            }
        }

        public void TestUsing()
        {
            using (new SampleBase())
            {
                base.t = "done";
            }
        }

        public void TestWhile()
        {
            for (int i = 0; i < 3; i++)
            {
            }
        }

        public string TestProperty
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

