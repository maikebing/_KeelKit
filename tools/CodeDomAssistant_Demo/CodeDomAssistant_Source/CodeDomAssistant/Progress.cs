namespace CodeDomAssistant
{
    using System;
    using System.Runtime.CompilerServices;

    public class Progress
    {
        private int maxprogresscount;
        private string message = string.Empty;
        private int progresscount;

        public event NotifyProgessHandler NotifyProgress;

        public void Notify()
        {
            if (this.NotifyProgress != null)
            {
                this.NotifyProgress(this);
            }
        }

        public int MaxProgressCount
        {
            get
            {
                return this.maxprogresscount;
            }
            set
            {
                this.maxprogresscount = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public int ProgressCount
        {
            get
            {
                return this.progresscount;
            }
            set
            {
                this.progresscount = value;
            }
        }
    }
}

