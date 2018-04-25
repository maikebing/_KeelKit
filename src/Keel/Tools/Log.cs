using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keel.Tools
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    public static class Log
    {
        /// <summary>
        /// 写入错误信息
        /// </summary>
        /// <param name="rem"></param>
        /// <param name="ex"></param>
        public static void WriteError(string rem, Exception ex)
        {

            string context = rem + "\r\n" + ex.Message + "\r\n" + ex.Source;
            WriteInfo(context);

        }
        /// <summary>
        /// 写入最基本的日志信息
        /// </summary>
        /// <param name="context"></param>
        public static void WriteInfo(string context)
        {
            lock (context)
            {
                try
                {
                    System.IO.File.AppendAllText(System.Reflection.Assembly.GetEntryAssembly().Location + DateTime.Now.ToString("yyyymmdd") + ".log", "\r\n__start__\r\n" + context + "\r\n___end___\r\n");
                }
                catch (Exception)
                {


                }
            }
        }

    }
}
