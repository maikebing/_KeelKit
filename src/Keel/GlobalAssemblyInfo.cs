using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Keel;
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyCopyright("Copyright © KeelKit Studio 2011")]
[assembly: AssemblyDescription("KeelKit Keel(龙骨)的ORM开发包,详情访问我们的站点 www.keelkit.com ")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("KeelKit Studio")]
[assembly: AssemblyVersion( Ver.version )]

namespace Keel
{
    /// <summary>
    /// 版本
    /// </summary>
    internal   class Ver 
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public const string version = major + "." + minor + "." + build + "." + revision;
        /// <summary>
        /// 主版本号
        /// </summary>
        public    const string major = "3";
        /// <summary>
        /// 次版本号
        /// </summary>
        public    const string minor = "0";
        /// <summary>
        /// 内部版本号
        /// </summary>
        public    const  string build  ="7600";
        /// <summary>
        /// 修订版本号 ，本程序集中为版本库版本号 
        /// </summary>
        public const string revision = "638";
    }
}
