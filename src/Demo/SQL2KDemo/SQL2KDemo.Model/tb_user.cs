﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 生成日期:20090508100414
namespace SQL2KDemo.Model {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("tb_user")]
    public class tb_user {
        
        /// <summary>
        /// 用户名
        /// </summary>
        private string _username;
        
        /// <summary>
        /// 密码
        /// </summary>
        private string _password;
        
        /// <summary>
        /// 手机类型
        /// </summary>
        private string _phonetype;
        
        /// <summary>
        /// 电邮
        /// </summary>
        private string _email;
        
        /// <summary>
        /// 用户名
        /// </summary>
        [Keel.ORM.DataFieldAttribute("username", "String")]
        public string username {
            get {
                return this._username;
            }
            set {
                this._username = value;
            }
        }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Keel.ORM.DataFieldAttribute("password", "String")]
        public string password {
            get {
                return this._password;
            }
            set {
                this._password = value;
            }
        }
        
        /// <summary>
        /// 手机类型
        /// </summary>
        [Keel.ORM.DataFieldAttribute("phonetype", "String")]
        public string phonetype {
            get {
                return this._phonetype;
            }
            set {
                this._phonetype = value;
            }
        }
        
        /// <summary>
        /// 电邮
        /// </summary>
        [Keel.ORM.DataFieldAttribute("email", "String")]
        public string email {
            get {
                return this._email;
            }
            set {
                this._email = value;
            }
        }
    }
}
