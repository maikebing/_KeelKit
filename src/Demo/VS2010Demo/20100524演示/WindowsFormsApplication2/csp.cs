﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 此文件由KeelKit自动生成 生成器版本:0.0.0.0 生成日期:20100524122539
namespace WindowsFormsApplication2 {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("csp")]
    [System.SerializableAttribute()]
    public class csp {
        
        private int _id;
        
        public const string fn_id = "id";
        
        private int _uid;
        
        public const string fn_uid = "uid";
        
        private int _install;
        
        public const string fn_install = "install";
        
        private int _click;
        
        public const string fn_click = "click";
        
        // <summary>
        //实例化一个
        //</summary>csp
        public csp() {
        }
        
        /// <summary>
        ///实例化一个csp，并填写所有字段的值
        ///(3个)
        ///</summary>
        public csp(int param_uid, int param_install, int param_click) {
            this.uid = param_uid;
            this.install = param_install;
            this.click = param_click;
        }
        
        [Keel.ORM.KeyFieldAttribute("id", "Int32")]
        public int id {
            get {
                return this._id;
            }
            set {
                this._id = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("uid", "Int32")]
        public int uid {
            get {
                return this._uid;
            }
            set {
                this._uid = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("install", "Int32")]
        public int install {
            get {
                return this._install;
            }
            set {
                this._install = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("click", "Int32")]
        public int click {
            get {
                return this._click;
            }
            set {
                this._click = value;
            }
        }
    }
}
