namespace CodeDomAssistant.SampleCode
{
    using System;

    public class SampleBase2 : IDisposable
    {
        protected string t;

        public SampleBase2()
        {
        }

        public SampleBase2(string t) : this()
        {
            this.t = t;
        }

        void IDisposable.Dispose()
        {
            this.t = "disposed";
        }
    }
}

