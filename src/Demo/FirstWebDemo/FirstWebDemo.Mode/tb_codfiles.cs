//By KeelKit.Generator.Grove   CreateDate:2009-07-07 18:31:34
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using Grove.ORM;
namespace FirstWebDemo.Mode
{
    /// <summary>
    ///表名称tb_codfiles,字段数目2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MSG_TB_CODFILES
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =32)]
        public byte[] filemd5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =20)]
        public byte[] filepath;
    }//tb_codfiles
    [DataTable("tb_codfiles")]
    public class tb_codfiles
    {
        MSG_TB_CODFILES  _MSG_TB_CODFILES;
        public tb_codfiles(MSG_TB_CODFILES ___MSG_TB_CODFILES)
        {
            _MSG_TB_CODFILES = ___MSG_TB_CODFILES;
        }
        public tb_codfiles()
        {
            Parse("".PadRight(GetLenght(), ' '));
        }
        public tb_codfiles(string s)
        {
            Parse(s);
        }
        public int GetLenght()
        {
            return Marshal.SizeOf(_MSG_TB_CODFILES);
        }
          //由一个string隐式构造一个tb_codfiles 
          public static implicit operator tb_codfiles(string  s)
         {
             return new tb_codfiles(s);
          }
           //由一个tb_codfiles显式返回一个string
           public static explicit operator string (tb_codfiles ret)
           {
               return  ret.ToString() ;
           }
        [KeyField("filemd5")]
        public string  filemd5
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODFILES.filemd5);
            }
            set {
                _MSG_TB_CODFILES.filemd5= Encoding.GetEncoding(936).GetBytes(value.PadRight(32,' '));
            }
        }
        [DataField("filepath")]
        public string  filepath
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODFILES.filepath);
            }
            set {
                _MSG_TB_CODFILES.filepath= Encoding.GetEncoding(936).GetBytes(value.PadRight(20,' '));
            }
        }
        public override string ToString()
        {
          int rawsize = Marshal.SizeOf(_MSG_TB_CODFILES);//得到内存大小
          IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存
          Marshal.StructureToPtr(_MSG_TB_CODFILES, buffer, true);//转换结构
          byte[] rawdatas = new byte[rawsize];
          Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存
          Marshal.FreeHGlobal(buffer); //释放内存
          return Encoding.GetEncoding(936).GetString(rawdatas);
        }
        public  void Parse(string s)
        {
             Type anytype = typeof(MSG_TB_CODFILES);
             byte[] rawdatas = Encoding.GetEncoding(936).GetBytes(s);
             int rawsize = Marshal.SizeOf(anytype);
             if (rawsize > rawdatas.Length)
                   _MSG_TB_CODFILES= new MSG_TB_CODFILES();
             IntPtr buffer = Marshal.AllocHGlobal(rawsize);
             Marshal.Copy(rawdatas, 0, buffer, rawsize);
             object retobj = Marshal.PtrToStructure(buffer, anytype);
             Marshal.FreeHGlobal(buffer);
              _MSG_TB_CODFILES=(MSG_TB_CODFILES)retobj;
        }
      }//tb_codfiles
 }//FirstWebDemo.Mode
