using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TransactionDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Keel.DBHelper<tb_user> t = new Keel.DBHelper<tb_user>();
            t.TransactionBegin();
            tb_user tx=new tb_user();
            tx.username ="asfdasd123344";
            t.Insert(tx);
            t.TransactionCommit();

            t.TransactionBegin();
            tx.email = "sadfasdf";
            t.Update(tx);
            t.TransactionCommit();
            tx.password = "asdf1111111111";
            t.Update(tx);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
