﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.20506.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 生成日期:20090524152035
namespace Model {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("View_1")]
    public class View_1 {
        
        private string _CodFileMd5;
        
        private string _FullName;
        
        private string _SoftName;
        
        private string _Version;
        
        private int _Size;
        
        private System.DateTime _Created;
        
        private int _Score_Good;
        
        private int _Score_Bad;
        
        private int _Money;
        
        private System.DateTime _UploadDateTime;
        
        private string _PhoneTypes;
        
        private string _PhoneOS;
        
        private string _Expr1;
        
        [Keel.ORM.DataFieldAttribute("CodFileMd5", "String")]
        public string CodFileMd5 {
            get {
                return this._CodFileMd5;
            }
            set {
                this._CodFileMd5 = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("FullName", "String")]
        public string FullName {
            get {
                return this._FullName;
            }
            set {
                this._FullName = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("SoftName", "String")]
        public string SoftName {
            get {
                return this._SoftName;
            }
            set {
                this._SoftName = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Version", "String")]
        public string Version {
            get {
                return this._Version;
            }
            set {
                this._Version = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Size", "Int32")]
        public int Size {
            get {
                return this._Size;
            }
            set {
                this._Size = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Created", "DateTime")]
        public System.DateTime Created {
            get {
                return this._Created;
            }
            set {
                this._Created = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Score_Good", "Int32")]
        public int Score_Good {
            get {
                return this._Score_Good;
            }
            set {
                this._Score_Good = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Score_Bad", "Int32")]
        public int Score_Bad {
            get {
                return this._Score_Bad;
            }
            set {
                this._Score_Bad = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Money", "Int32")]
        public int Money {
            get {
                return this._Money;
            }
            set {
                this._Money = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("UploadDateTime", "DateTime")]
        public System.DateTime UploadDateTime {
            get {
                return this._UploadDateTime;
            }
            set {
                this._UploadDateTime = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("PhoneTypes", "String")]
        public string PhoneTypes {
            get {
                return this._PhoneTypes;
            }
            set {
                this._PhoneTypes = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("PhoneOS", "String")]
        public string PhoneOS {
            get {
                return this._PhoneOS;
            }
            set {
                this._PhoneOS = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Expr1", "String")]
        public string Expr1 {
            get {
                return this._Expr1;
            }
            set {
                this._Expr1 = value;
            }
        }
    }
}
