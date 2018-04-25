#pragma once

#using <mscorlib.dll>

using namespace System::Security::Permissions;
[assembly:SecurityPermissionAttribute(SecurityAction::RequestMinimum, SkipVerification=false)];
// ----------------------------------------------------------------------------
//    此文件由KeelKit自动生成
//    生成器版本:1.0.3700.25643
//    运行时版本:2.0.50727.3053
//
//    对此文件的更改可能会导致不正确的行为，并且如果
//    重新生成代码，这些更改将会丢失。
//    生成日期:20090712004037
//----------------------------------------------------------------------------
//
namespace Model {
    using namespace System;
    using namespace System::Collections::Generic;
    using namespace System::ComponentModel;
    using namespace System::Data;
    using namespace System::Text;
    using namespace Keel::ORM;
    using namespace System;
    ref class Table_1;
    
    
    [Keel::ORM::DataTableAttribute(L"Table_1")]
    public ref class Table_1 {
        
        private: System::Int32 _id;
        
        public: literal System::String^  fn_id = L"id";
        
        private: System::DateTime _sdf;
        
        public: literal System::String^  fn_sdf = L"sdf";
        
        private: System::Boolean _b;
        
        public: literal System::String^  fn_b = L"b";
        
        private: System::Int32 _sd;
        
        public: literal System::String^  fn_sd = L"sd";
        
        private: System::String^  _dsf;
        
        public: literal System::String^  fn_dsf = L"dsf";
        
        private: System::String^  _sfd;
        
        public: literal System::String^  fn_sfd = L"sfd";
        
        public: Table_1(System::DateTime param_sdf, System::Boolean param_b, System::Int32 param_sd, System::String^  param_dsf, 
                    System::String^  param_sfd);
        public: [Keel::ORM::KeyFieldAttribute(L"id", L"Int32")]
        property System::Int32 id {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"sdf", L"DateTime")]
        property System::DateTime sdf {
            System::DateTime get();
            System::Void set(System::DateTime value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"b", L"Boolean")]
        property System::Boolean b {
            System::Boolean get();
            System::Void set(System::Boolean value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"sd", L"Int32")]
        property System::Int32 sd {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"dsf", L"AnsiString")]
        property System::String^  dsf {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"sfd", L"String")]
        property System::String^  sfd {
            System::String^  get();
            System::Void set(System::String^  value);
        }
    };
}
namespace Model {
    
    
    inline Table_1::Table_1(System::DateTime param_sdf, System::Boolean param_b, System::Int32 param_sd, System::String^  param_dsf, 
                System::String^  param_sfd) {
        this->sdf = param_sdf;
        this->b = param_b;
        this->sd = param_sd;
        this->dsf = param_dsf;
        this->sfd = param_sfd;
    }
    
    inline System::Int32 Table_1::id::get() {
        return this->_id;
    }
    inline System::Void Table_1::id::set(System::Int32 value) {
        this->_id = value;
    }
    
    inline System::DateTime Table_1::sdf::get() {
        return this->_sdf;
    }
    inline System::Void Table_1::sdf::set(System::DateTime value) {
        this->_sdf = value;
    }
    
    inline System::Boolean Table_1::b::get() {
        return this->_b;
    }
    inline System::Void Table_1::b::set(System::Boolean value) {
        this->_b = value;
    }
    
    inline System::Int32 Table_1::sd::get() {
        return this->_sd;
    }
    inline System::Void Table_1::sd::set(System::Int32 value) {
        this->_sd = value;
    }
    
    inline System::String^  Table_1::dsf::get() {
        return this->_dsf;
    }
    inline System::Void Table_1::dsf::set(System::String^  value) {
        this->_dsf = value;
    }
    
    inline System::String^  Table_1::sfd::get() {
        return this->_sfd;
    }
    inline System::Void Table_1::sfd::set(System::String^  value) {
        this->_sfd = value;
    }
}
