using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SQL2KDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DAL.Class1.SP_Codsoftitem_Insert("sfad", "safddsaf", "safd", "fasd", 11, DateTime.Now, 12, 343, 22, DateTime.Now, "afsd", "fsda");
            Application.Run(new Form1());
        }
    }
}
