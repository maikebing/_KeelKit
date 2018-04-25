using System;
using System.Collections.Generic;
using System.IO;
using Keel;
using KeelKit.Generators;
using Microsoft.Office.Interop.Word;

namespace KeelKit.DocBuilter
{
    internal sealed class DBDocBuilder
    {
        //仅供参考
        private static string tablenamenow = null;
        private static bool FindByTableName(SQLTableInfo di)
        {
            if (tablenamenow == null || di == null) return false;
            return di.t_tablename.ToLower () == tablenamenow.ToLower ().Trim();
        }
        public static string[] DocFormat = new string[]{
            "Word",        
            "HTML",
            "PDF",
            "Text"};
        public enum eDocFormat
        {
            Word,
            HTML,
            PDF,
            Text
        }
        public static List<SQLTableName> GetSQLTableNameList()
        {
            return ModelGengerator.GetSQLTableNameList();
        }

        public static string BuilingDoc()
        {

            FileInfo fi = new FileInfo(Common.chDTE.Solution.FullName);
            if (fi.Exists == false) return null;
            string filename = fi.DirectoryName + "\\DBDOC_" + fi.Name.Replace(fi.Extension, "");
            string header = Kit.SlnKeel.DBDoc_Header;
            string datatables = Kit.SlnKeel.DBDoc_DataTables;
            EnvDTE.Project pjt = Kit.GetProjectModel();
    
            filename = BuildToWord(filename, header, datatables, ModelGengerator.GetSqlTableInfoList ());

            return filename;
        }
        private static Object Nothing = System.Reflection.Missing.Value;
        private static string BuildToWord(string wordfilename, string docheader, string datatables, List<SQLTableInfo> tableinfos)
        {
            object filename = wordfilename + ".doc";  //文件保存路径
            try
            {


                //创建Word文档
                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application() ;
                Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                string h = docheader;
                if (h != null && h.Trim() != "")
                {
                    //添加页眉
                    WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
                    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
                    WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(h);
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐
                    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;//跳出页眉设置
                }
                WordApp.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距
                List<SQLTableInfo> dbix = tableinfos;
                string[] lsttab = datatables.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in lsttab)
                {
                    tablenamenow = item;
                    Common.ShowInfo(string.Format("正在生成表{0}的文档,请稍候...", tablenamenow));
                    Predicate<SQLTableInfo> pdbi = new Predicate<SQLTableInfo>(FindByTableName);
                    List<SQLTableInfo> lstdb = dbix.FindAll(pdbi);
                    bool ok = CreateTableInfo(WordApp, WordDoc, lstdb);
                }
                WordDoc.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();//“落款”
                WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                object format = Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat;
                WordDoc.SaveAs(ref filename, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);

#pragma warning disable    467
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);

#pragma warning restore    467
                WordApp = null;

                Common.ShowInfo("恭喜，文档生成并成功保存");
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                Common.ShowInfo("抱歉:调用外部组件异常!(可能未安装MS Word)!");
            }
            catch (Exception eee)
            {
                filename = null;

                Common.ShowInfo(string.Format("文档生成过程中遇到未预料的错误:{0}", eee.Message));
            }

            return filename as string;
        }

        private static bool CreateTableInfo(Microsoft.Office.Interop.Word.Application WordApp, Microsoft.Office.Interop.Word.Document WordDoc, List<SQLTableInfo> lstdb)
        {

            if (lstdb != null)
            {
                //移动焦点并换行
                object count = lstdb.Count + 10;
                object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                WordApp.Selection.TypeParagraph();//插入段落

                //文档中创建表格
                Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, lstdb.Count + 4, 11, ref Nothing, ref Nothing);
                //设置表格样式
                newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                //newTable.Columns[1].Width = 100f;
                //newTable.Columns[2].Width = 220f;
                //newTable.Columns[3].Width = 105f;


                //填充表格内容
                newTable.Cell(1, 1).Range.Text = string.Format("表{0}", tablenamenow);
                newTable.Cell(1, 1).Range.Bold = 2;//设置单元格中字体为粗体
                //合并单元格
                newTable.Cell(1, 1).Merge(newTable.Cell(1, 11));
                WordApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//垂直居中
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//水平居中

                //填充表格内容
                newTable.Cell(2, 1).Range.Text = string.Format("共有{0}个字段", lstdb.Count);
                newTable.Cell(2, 1).Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorDarkBlue;//设置单元格内字体颜色
                //合并单元格
                newTable.Cell(2, 1).Merge(newTable.Cell(2, 11));
                newTable.AllowAutoFit = true;

                WordApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable.Cell(3, 1).Range.Text = "字段名";
                newTable.Cell(3, 2).Range.Text = "类型";
                newTable.Cell(3, 3).Range.Text = "标识";
                newTable.Cell(3, 4).Range.Text = "主键";
                newTable.Cell(3, 5).Range.Text = "字段长度";
                newTable.Cell(3, 6).Range.Text = "字段描述";
                newTable.Cell(3, 7).Range.Text = "保留位";
                newTable.Cell(3, 8).Range.Text = "默认值";
                newTable.Cell(3, 9).Range.Text = "允许为空";
                newTable.Cell(3, 10).Range.Text = "字节长度";
                newTable.Cell(3, 11).Range.Text = "自动计算";

                string t_tabledesc_ = null;
                int row = 3;
                foreach (var fied in lstdb)
                {
                    if (t_tabledesc_ == null) t_tabledesc_ = (string )fied.t_tabledesc ;
                    row += 1;
                    newTable.Cell(row, 1).Range.Text = fied.t_fieldname;
                    newTable.Cell(row, 2).Range.Text = fied.t_fieldtype;
                    newTable.Cell(row, 3).Range.Text = fied.t_identity;
                    newTable.Cell(row, 4).Range.Text = fied.t_tablekey;
                    newTable.Cell(row, 5).Range.Text =  fied.t_fieldlenght.ToString ();
                    newTable.Cell(row, 6).Range.Text = (string)fied.t_fielddesc ;
                    newTable.Cell(row, 7).Range.Text =  fied.t_fieldscale.ToString();
                    newTable.Cell(row, 8).Range.Text = fied.t_fielddefaultvalue;
                    newTable.Cell(row, 9).Range.Text = fied.t_fieldcannull;
                    newTable.Cell(row, 10).Range.Text =  fied.t_fieldbitcount.ToString();
                    newTable.Cell(row, 11).Range.Text = fied.t_fieldiscomputed;
                }

                Common.ShowInfo(string.Format("恭喜!表{0}的文档生成完毕!", tablenamenow));

                newTable.Cell(lstdb.Count + 4, 1).Range.Text = "说明:" + t_tabledesc_;
                newTable.Cell(lstdb.Count + 4, 1).Merge(newTable.Cell(lstdb.Count + 4, 11));
                //移动焦点并换行
                  count = lstdb.Count + 10;
                  WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                WordApp.Selection.TypeParagraph();//插入段落

            }
            return true;
        }
    }
}
