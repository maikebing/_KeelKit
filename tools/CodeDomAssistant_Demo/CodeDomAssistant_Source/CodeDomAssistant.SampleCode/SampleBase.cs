namespace CodeDomAssistant.SampleCode
{
    using System;

    public class SampleBase : IDisposable
    {
        protected string t;

        public SampleBase()
        {
        }

        public SampleBase(string t) : this()
        {
            this.t = t;
        }

        void IDisposable.Dispose()
        {
            this.t = "disposed";
        }
    }
}

