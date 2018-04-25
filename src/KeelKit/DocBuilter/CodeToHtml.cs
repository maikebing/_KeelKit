using System.Diagnostics;
using System.IO;
using System.Text;
using KeelKit.HtmlSyntaxColorizer;
 

namespace KeelKit.Generators
{
 public   class CodeToHtml
    {
     public static  void CopyCodeToHtml(string filename,string lang)
     {
         string html = CopyCodeToStringHtml(filename, lang);
         File.WriteAllText(filename+".html", "<html><body>" + html + "</body></html>",Encoding.Default );
         Process.Start(filename + ".html"); // view in browser
     }

     public  static string CopyCodeToStringHtml(string filename, string lang)
     {
         HtmlWriter w = new HtmlWriter();
         w.ShowLineNumbers = true;
         w.AlternateLineBackground = true;
       
          
         string html = w.GenerateHtml(filename , lang);
         return html;
     }
    }
}
