﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 生成日期:20090418185334
namespace SQL2KDemo.Model {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text;
    using Keel.ORM;
    
    
    [Keel.ORM.DataTableAttribute("EmployeeTerritories")]
    public class EmployeeTerritories {
        
        private int _EmployeeID;
        
        private string _TerritoryID;
        
        [Keel.ORM.KeyFieldAttribute("EmployeeID", "Int32", false)]
        public int EmployeeID {
            get {
                return this._EmployeeID;
            }
            set {
                this._EmployeeID = value;
            }
        }
        
        [Keel.ORM.KeyFieldAttribute("TerritoryID", "String", false)]
        public string TerritoryID {
            get {
                return this._TerritoryID;
            }
            set {
                this._TerritoryID = value;
            }
        }
    }
}
