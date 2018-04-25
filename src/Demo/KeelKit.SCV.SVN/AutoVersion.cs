using System;
using System.Collections.Generic;
using System.Text;
 
namespace KeelKit.SCV
{
    public class AutoVersion
    {
        public static string GetVersion(string path)
        {
            string result = "0";
            string filename = path + "\\.svn\\entries";
            if (System.IO.File.Exists(filename) == false)
            {
                filename = path + "\\_svn\\entries";
            }
            if (System.IO.File.Exists(filename))
            {
                string txt = System.IO.File.ReadAllText(filename);
                string[] ary = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int v = 0;
                int.TryParse(ary[2], out v);
                result = v.ToString().Trim();
            }
            return result;

        }
    }
}
