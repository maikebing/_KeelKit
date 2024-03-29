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
    ///表名称Table_1,字段数目6
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MSG_TABLE_1
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =23)]
        public byte[] sdf;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =1)]
        public byte[] b;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] sd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] dsf;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] sfd;
    }//Table_1
    [DataTable("Table_1")]
    public class Table_1
    {
        MSG_TABLE_1  _MSG_TABLE_1;
        public Table_1(MSG_TABLE_1 ___MSG_TABLE_1)
        {
            _MSG_TABLE_1 = ___MSG_TABLE_1;
        }
        public Table_1()
        {
            Parse("".PadRight(GetLenght(), ' '));
        }
        public Table_1(string s)
        {
            Parse(s);
        }
        public int GetLenght()
        {
            return Marshal.SizeOf(_MSG_TABLE_1);
        }
          //由一个string隐式构造一个Table_1 
          public static implicit operator Table_1(string  s)
         {
             return new Table_1(s);
          }
           //由一个Table_1显式返回一个string
           public static explicit operator string (Table_1 ret)
           {
               return  ret.ToString() ;
           }
        [KeyField("id")]
        public Int32  id
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.id));
            }
            set {
                _MSG_TABLE_1.id= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("sdf")]
        public DateTime  sdf
        {
            get {
                return  DateTime.Parse(Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.sdf));
            }
            set {
                _MSG_TABLE_1.sdf= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(23,' '));
            }
        }
        [DataField("b")]
        public string  b
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.b);
            }
            set {
                _MSG_TABLE_1.b= Encoding.GetEncoding(936).GetBytes(value.PadRight(1,' '));
            }
        }
        [DataField("sd")]
        public Int32  sd
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.sd));
            }
            set {
                _MSG_TABLE_1.sd= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("dsf")]
        public string  dsf
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.dsf);
            }
            set {
                _MSG_TABLE_1.dsf= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        [DataField("sfd")]
        public string  sfd
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TABLE_1.sfd);
            }
            set {
                _MSG_TABLE_1.sfd= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        public override string ToString()
        {
          int rawsize = Marshal.SizeOf(_MSG_TABLE_1);//得到内存大小
          IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存
          Marshal.StructureToPtr(_MSG_TABLE_1, buffer, true);//转换结构
          byte[] rawdatas = new byte[rawsize];
          Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存
          Marshal.FreeHGlobal(buffer); //释放内存
          return Encoding.GetEncoding(936).GetString(rawdatas);
        }
        public  void Parse(string s)
        {
             Type anytype = typeof(MSG_TABLE_1);
             byte[] rawdatas = Encoding.GetEncoding(936).GetBytes(s);
             int rawsize = Marshal.SizeOf(anytype);
             if (rawsize > rawdatas.Length)
                   _MSG_TABLE_1= new MSG_TABLE_1();
             IntPtr buffer = Marshal.AllocHGlobal(rawsize);
             Marshal.Copy(rawdatas, 0, buffer, rawsize);
             object retobj = Marshal.PtrToStructure(buffer, anytype);
             Marshal.FreeHGlobal(buffer);
              _MSG_TABLE_1=(MSG_TABLE_1)retobj;
        }
      }//Table_1
 }//FirstWebDemo.Mode
