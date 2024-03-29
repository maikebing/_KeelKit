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
    ///表名称tb_codsoftitem,字段数目12
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MSG_TB_CODSOFTITEM
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =32)]
        public byte[] CodFileMd5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] FullName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] SoftName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] Version;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] Size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =23)]
        public byte[] Created;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] Score_Good;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] Score_Bad;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =10)]
        public byte[] Money;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =23)]
        public byte[] UploadDateTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] PhoneTypes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =50)]
        public byte[] PhoneOS;
    }//tb_codsoftitem
    [DataTable("tb_codsoftitem")]
    public class tb_codsoftitem
    {
        MSG_TB_CODSOFTITEM  _MSG_TB_CODSOFTITEM;
        public tb_codsoftitem(MSG_TB_CODSOFTITEM ___MSG_TB_CODSOFTITEM)
        {
            _MSG_TB_CODSOFTITEM = ___MSG_TB_CODSOFTITEM;
        }
        public tb_codsoftitem()
        {
            Parse("".PadRight(GetLenght(), ' '));
        }
        public tb_codsoftitem(string s)
        {
            Parse(s);
        }
        public int GetLenght()
        {
            return Marshal.SizeOf(_MSG_TB_CODSOFTITEM);
        }
          //由一个string隐式构造一个tb_codsoftitem 
          public static implicit operator tb_codsoftitem(string  s)
         {
             return new tb_codsoftitem(s);
          }
           //由一个tb_codsoftitem显式返回一个string
           public static explicit operator string (tb_codsoftitem ret)
           {
               return  ret.ToString() ;
           }
        [DataField("CodFileMd5")]
        public string  CodFileMd5
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.CodFileMd5);
            }
            set {
                _MSG_TB_CODSOFTITEM.CodFileMd5= Encoding.GetEncoding(936).GetBytes(value.PadRight(32,' '));
            }
        }
        [DataField("FullName")]
        public string  FullName
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.FullName);
            }
            set {
                _MSG_TB_CODSOFTITEM.FullName= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        [DataField("SoftName")]
        public string  SoftName
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.SoftName);
            }
            set {
                _MSG_TB_CODSOFTITEM.SoftName= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        [DataField("Version")]
        public string  Version
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Version);
            }
            set {
                _MSG_TB_CODSOFTITEM.Version= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        [DataField("Size")]
        public Int32  Size
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Size));
            }
            set {
                _MSG_TB_CODSOFTITEM.Size= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("Created")]
        public DateTime  Created
        {
            get {
                return  DateTime.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Created));
            }
            set {
                _MSG_TB_CODSOFTITEM.Created= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(23,' '));
            }
        }
        [DataField("Score_Good")]
        public Int32  Score_Good
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Score_Good));
            }
            set {
                _MSG_TB_CODSOFTITEM.Score_Good= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("Score_Bad")]
        public Int32  Score_Bad
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Score_Bad));
            }
            set {
                _MSG_TB_CODSOFTITEM.Score_Bad= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("Money")]
        public Int32  Money
        {
            get {
                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.Money));
            }
            set {
                _MSG_TB_CODSOFTITEM.Money= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(10,' '));
            }
        }
        [DataField("UploadDateTime")]
        public DateTime  UploadDateTime
        {
            get {
                return  DateTime.Parse(Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.UploadDateTime));
            }
            set {
                _MSG_TB_CODSOFTITEM.UploadDateTime= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight(23,' '));
            }
        }
        [DataField("PhoneTypes")]
        public string  PhoneTypes
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.PhoneTypes);
            }
            set {
                _MSG_TB_CODSOFTITEM.PhoneTypes= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        [DataField("PhoneOS")]
        public string  PhoneOS
        {
            get {
                return Encoding.GetEncoding(936).GetString(_MSG_TB_CODSOFTITEM.PhoneOS);
            }
            set {
                _MSG_TB_CODSOFTITEM.PhoneOS= Encoding.GetEncoding(936).GetBytes(value.PadRight(50,' '));
            }
        }
        public override string ToString()
        {
          int rawsize = Marshal.SizeOf(_MSG_TB_CODSOFTITEM);//得到内存大小
          IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存
          Marshal.StructureToPtr(_MSG_TB_CODSOFTITEM, buffer, true);//转换结构
          byte[] rawdatas = new byte[rawsize];
          Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存
          Marshal.FreeHGlobal(buffer); //释放内存
          return Encoding.GetEncoding(936).GetString(rawdatas);
        }
        public  void Parse(string s)
        {
             Type anytype = typeof(MSG_TB_CODSOFTITEM);
             byte[] rawdatas = Encoding.GetEncoding(936).GetBytes(s);
             int rawsize = Marshal.SizeOf(anytype);
             if (rawsize > rawdatas.Length)
                   _MSG_TB_CODSOFTITEM= new MSG_TB_CODSOFTITEM();
             IntPtr buffer = Marshal.AllocHGlobal(rawsize);
             Marshal.Copy(rawdatas, 0, buffer, rawsize);
             object retobj = Marshal.PtrToStructure(buffer, anytype);
             Marshal.FreeHGlobal(buffer);
              _MSG_TB_CODSOFTITEM=(MSG_TB_CODSOFTITEM)retobj;
        }
      }//tb_codsoftitem
 }//FirstWebDemo.Mode
