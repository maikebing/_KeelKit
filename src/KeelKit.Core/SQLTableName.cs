﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 生成日期:20081226191548
namespace KeelKit.Generators
{
    using System.Data;
    using Keel.ORM;


    [Keel.ORM.DataViewAttribute("SQLTableName", "c2VsZWN0ICBuYW1lICBmcm9tIFNZU09CSkVDVFMgd2hlcmUgICBYVFlQRT0nVScgQU5EICBOQU1FPD4nR" +
        "FRQUk9QRVJUSUVTJw==")]
    [DataView("ViewInfo", "IHNlbGVjdCBUQUJMRV9OQU1FIGFzIG5hbWUgICBmcm9tIElORk9STUFUSU9OX1NDSEVNQS5WSUVXUw==")]
    [DataView("SPInfo", "c2VsZWN0IG5hbWUgIGZyb20gIHN5cy5hbGxfb2JqZWN0cyBhcyBPQkpTICB3aGVyZSAoT0JKUy50eXBlID0gJ1AnIE9SIE9CSlMudHlwZSA9ICdYJyBPUiBPQkpTLnR5cGUgPSAnUEMnKSBhbmQgT0JKUy5pc19tc19zaGlwcGVkID0gMCA=")]
    public class SQLTableName
    {

        private string _name;

        [Keel.ORM.DataFieldAttribute("name")]
        public virtual string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
    }
}