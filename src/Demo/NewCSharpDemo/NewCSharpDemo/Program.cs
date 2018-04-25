using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewCSharpDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
 
            //Model.tb_codfiles tc = new NewCSharpDemo.Model.tb_codfiles();
            //tc.filemd5 = "filemd5";
            //tc.filepath = "filepath asdjfkasd ";
            //string str = tc.ToString();


            //Model.tb_codfiles tf = new NewCSharpDemo.Model.tb_codfiles(str);

            //if (tc.filemd5 == tf.filemd5)
            //{
            //    Console.WriteLine("");
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
