#pragma once

#using <mscorlib.dll>

using namespace System::Security::Permissions;
[assembly:SecurityPermissionAttribute(SecurityAction::RequestMinimum, SkipVerification=false)];
// 生成日期:20090629123819
namespace DAL {
    using namespace System;
    using namespace System::Collections::Generic;
    using namespace System::ComponentModel;
    using namespace System::Data;
    using namespace System::Text;
    using namespace Keel::ORM;
    using namespace System;
    public __gc class SP;
    
    
    public __gc class SP {
        
        public: static System::Data::DataTable*  coop_tb_codfiles_GetAll();
        
        public: static System::Int32 coop_tb_codfiles_Insert(System::String*  filemd5, System::String*  filepath);
        
        public: static tb_codfiles*  coop_tb_codfiles_GetOne(System::String*  filemd5);
    };
}
namespace DAL {
    
    
    inline System::Data::DataTable*  SP::coop_tb_codfiles_GetAll() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_GetAll", Keel::SPExcMethod::Fill);
    }
    
    inline System::Int32 SP::coop_tb_codfiles_Insert(System::String*  filemd5, System::String*  filepath) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[2];
                __mcTemp__1[0] = S"filemd5";
                __mcTemp__1[1] = S"filepath";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[2];
                __mcTemp__2[0] = filemd5;
                __mcTemp__2[1] = filepath;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_Insert", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline tb_codfiles*  SP::coop_tb_codfiles_GetOne(System::String*  filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_GetOne", Keel::SPExcMethod::Model, names, values);
    }
}
