﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 此文件由KeelKit自动生成 生成器版本:0.0.0.0
namespace AccessDemo {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("QUESTIONTYPE")]
    public class QUESTIONTYPE {
        
        private int _ID;
        
        public const string fn_ID = "ID";
        
        private string _TypeName;
        
        public const string fn_TypeName = "TypeName";
        
        // <summary>
        //实例化一个
        //</summary>QUESTIONTYPE
        public QUESTIONTYPE() {
        }
        
        /// <summary>
        ///实例化一个QUESTIONTYPE，并填写所有字段的值
        ///(1个)
        ///</summary>
        public QUESTIONTYPE(string param_TypeName) {
            this.TypeName = param_TypeName;
        }
        
        [Keel.ORM.KeyFieldAttribute("ID", "Int32")]
        public int ID {
            get {
                return this._ID;
            }
            set {
                this._ID = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("TypeName", "StringFixedLength")]
        public string TypeName {
            get {
                return this._TypeName;
            }
            set {
                this._TypeName = value;
            }
        }
    }
}
