﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 生成日期:20090516210414
namespace NewCSharpDemo.Model {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("View_1")]
    public class View_1 {
        
        private struct_View_1 var_struct_View_1;
        
        // 使用空字符串初始化对象
        public View_1() {
            string s = "";
            this.var_struct_View_1 = ((struct_View_1)(Keel.DB.Common.StringToStruct(s.PadRight(this.GetLenght(), ' '), typeof(struct_View_1))));
        }
        
        // 使用指定的字符串初始化对象
        public View_1(string s) {
            this.var_struct_View_1 = ((struct_View_1)(Keel.DB.Common.StringToStruct(s, typeof(struct_View_1))));
        }
        
        [Keel.ORM.DataFieldAttribute("CodFileMd5", "String")]
        public string CodFileMd5 {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_CodFileMd5);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_CodFileMd5 = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(32, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("FullName", "String")]
        public string FullName {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_FullName);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_FullName = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("SoftName", "String")]
        public string SoftName {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_SoftName);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_SoftName = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Version", "String")]
        public string Version {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Version);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Version = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Size", "Int32")]
        public int Size {
            get {
                return int.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Size));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Size = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(10, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Created", "DateTime")]
        public System.DateTime Created {
            get {
                return System.DateTime.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Created));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Created = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(0, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Score_Good", "Int32")]
        public int Score_Good {
            get {
                return int.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Score_Good));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Score_Good = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(10, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Score_Bad", "Int32")]
        public int Score_Bad {
            get {
                return int.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Score_Bad));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Score_Bad = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(10, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Money", "Int32")]
        public int Money {
            get {
                return int.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Money));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Money = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(10, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("UploadDateTime", "DateTime")]
        public System.DateTime UploadDateTime {
            get {
                return System.DateTime.Parse(System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_UploadDateTime));
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_UploadDateTime = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(0, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("PhoneTypes", "String")]
        public string PhoneTypes {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_PhoneTypes);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_PhoneTypes = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("PhoneOS", "String")]
        public string PhoneOS {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_PhoneOS);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_PhoneOS = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Expr1", "String")]
        public string Expr1 {
            get {
                return System.Text.Encoding.Default.GetString(this.var_struct_View_1.ary_Expr1);
            }
            set {
                if (object.Equals(value, null)) {
                    return;
                }
                this.var_struct_View_1.ary_Expr1 = System.Text.Encoding.Default.GetBytes(value.ToString().PadRight(50, ' '));
            }
        }
        
        // 将结构转换为字符串
        public new string ToString() {
            return Keel.DB.Common.StructToString(this.var_struct_View_1);
        }
        
        // 获取以字节为单位的结构总长度
        public int GetLenght() {
            return System.Runtime.InteropServices.Marshal.SizeOf(this.var_struct_View_1);
        }
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi, Pack=1)]
    public struct struct_View_1 {
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=32)]
        public byte[] ary_CodFileMd5;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_FullName;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_SoftName;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_Version;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=10)]
        public byte[] ary_Size;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=0)]
        public byte[] ary_Created;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=10)]
        public byte[] ary_Score_Good;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=10)]
        public byte[] ary_Score_Bad;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=10)]
        public byte[] ary_Money;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=0)]
        public byte[] ary_UploadDateTime;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_PhoneTypes;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_PhoneOS;
        
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=50)]
        public byte[] ary_Expr1;
    }
}
