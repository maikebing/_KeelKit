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
    
    
    [Keel.ORM.DataTableAttribute("QUESTION")]
    public class QUESTION {
        
        private string _answer;
        
        public const string fn_answer = "answer";
        
        private string _Category;
        
        public const string fn_Category = "Category";
        
        private string _content;
        
        public const string fn_content = "content";
        
        private int _ID;
        
        public const string fn_ID = "ID";
        
        private int _level;
        
        public const string fn_level = "level";
        
        private string _reference;
        
        public const string fn_reference = "reference";
        
        private string _Title;
        
        public const string fn_Title = "Title";
        
        private int _Type;
        
        public const string fn_Type = "Type";
        
        // <summary>
        //实例化一个
        //</summary>QUESTION
        public QUESTION() {
        }
        
        /// <summary>
        ///实例化一个QUESTION，并填写所有字段的值
        ///(7个)
        ///</summary>
        public QUESTION(string param_answer, string param_Category, string param_content, int param_level, string param_reference, string param_Title, int param_Type) {
            this.answer = param_answer;
            this.Category = param_Category;
            this.content = param_content;
            this.level = param_level;
            this.reference = param_reference;
            this.Title = param_Title;
            this.Type = param_Type;
        }
        
        /// <summary>
        ///实例化一个QUESTION，并填写所有必填字段个的值
        ///(共2)
        ///</summary>
        public QUESTION(string param_Title, int param_Type) {
            this.Title = param_Title;
            this.Type = param_Type;
        }
        
        [Keel.ORM.DataFieldAttribute("answer", "StringFixedLength")]
        public string answer {
            get {
                return this._answer;
            }
            set {
                this._answer = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Category", "StringFixedLength")]
        public string Category {
            get {
                return this._Category;
            }
            set {
                this._Category = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("content", "StringFixedLength")]
        public string content {
            get {
                return this._content;
            }
            set {
                this._content = value;
            }
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
        
        [Keel.ORM.DataFieldAttribute("level", "Int32")]
        public int level {
            get {
                return this._level;
            }
            set {
                this._level = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("reference", "StringFixedLength")]
        public string reference {
            get {
                return this._reference;
            }
            set {
                this._reference = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Title", "StringFixedLength")]
        public string Title {
            get {
                return this._Title;
            }
            set {
                this._Title = value;
            }
        }
        
        [Keel.ORM.DataFieldAttribute("Type", "Int32")]
        public int Type {
            get {
                return this._Type;
            }
            set {
                this._Type = value;
            }
        }
    }
}
