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
    ref class tb_codsoftitem;
    
    
    [Keel::ORM::DataTableAttribute(L"tb_codsoftitem")]
    public ref class tb_codsoftitem {
        
        private: System::String^  _CodFileMd5;
        
        /// <summary>
        /// 这是cod软件项
        /// </summary>
        public: literal System::String^  fn_CodFileMd5 = L"CodFileMd5";
        
        private: System::String^  _FullName;
        
        public: literal System::String^  fn_FullName = L"FullName";
        
        private: System::String^  _SoftName;
        
        public: literal System::String^  fn_SoftName = L"SoftName";
        
        private: System::String^  _Version;
        
        public: literal System::String^  fn_Version = L"Version";
        
        private: System::Int32 _Size;
        
        public: literal System::String^  fn_Size = L"Size";
        
        private: System::DateTime _Created;
        
        public: literal System::String^  fn_Created = L"Created";
        
        private: System::Int32 _Score_Good;
        
        public: literal System::String^  fn_Score_Good = L"Score_Good";
        
        private: System::Int32 _Score_Bad;
        
        public: literal System::String^  fn_Score_Bad = L"Score_Bad";
        
        private: System::Int32 _Money;
        
        public: literal System::String^  fn_Money = L"Money";
        
        private: System::DateTime _UploadDateTime;
        
        public: literal System::String^  fn_UploadDateTime = L"UploadDateTime";
        
        private: System::String^  _PhoneTypes;
        
        public: literal System::String^  fn_PhoneTypes = L"PhoneTypes";
        
        private: System::String^  _PhoneOS;
        
        public: literal System::String^  fn_PhoneOS = L"PhoneOS";
        
        public: tb_codsoftitem(
                    System::String^  param_CodFileMd5, 
                    System::String^  param_FullName, 
                    System::String^  param_SoftName, 
                    System::String^  param_Version, 
                    System::Int32 param_Size, 
                    System::DateTime param_Created, 
                    System::Int32 param_Score_Good, 
                    System::Int32 param_Score_Bad, 
                    System::Int32 param_Money, 
                    System::DateTime param_UploadDateTime, 
                    System::String^  param_PhoneTypes, 
                    System::String^  param_PhoneOS);
        public: [Keel::ORM::DataFieldAttribute(L"CodFileMd5", L"String")]
        property System::String^  CodFileMd5 {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"FullName", L"String")]
        property System::String^  FullName {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"SoftName", L"String")]
        property System::String^  SoftName {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Version", L"String")]
        property System::String^  Version {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Size", L"Int32")]
        property System::Int32 Size {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Created", L"DateTime")]
        property System::DateTime Created {
            System::DateTime get();
            System::Void set(System::DateTime value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Score_Good", L"Int32")]
        property System::Int32 Score_Good {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Score_Bad", L"Int32")]
        property System::Int32 Score_Bad {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"Money", L"Int32")]
        property System::Int32 Money {
            System::Int32 get();
            System::Void set(System::Int32 value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"UploadDateTime", L"DateTime")]
        property System::DateTime UploadDateTime {
            System::DateTime get();
            System::Void set(System::DateTime value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"PhoneTypes", L"String")]
        property System::String^  PhoneTypes {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"PhoneOS", L"String")]
        property System::String^  PhoneOS {
            System::String^  get();
            System::Void set(System::String^  value);
        }
    };
}
namespace Model {
    
    
    inline tb_codsoftitem::tb_codsoftitem(
                System::String^  param_CodFileMd5, 
                System::String^  param_FullName, 
                System::String^  param_SoftName, 
                System::String^  param_Version, 
                System::Int32 param_Size, 
                System::DateTime param_Created, 
                System::Int32 param_Score_Good, 
                System::Int32 param_Score_Bad, 
                System::Int32 param_Money, 
                System::DateTime param_UploadDateTime, 
                System::String^  param_PhoneTypes, 
                System::String^  param_PhoneOS) {
        this->CodFileMd5 = param_CodFileMd5;
        this->FullName = param_FullName;
        this->SoftName = param_SoftName;
        this->Version = param_Version;
        this->Size = param_Size;
        this->Created = param_Created;
        this->Score_Good = param_Score_Good;
        this->Score_Bad = param_Score_Bad;
        this->Money = param_Money;
        this->UploadDateTime = param_UploadDateTime;
        this->PhoneTypes = param_PhoneTypes;
        this->PhoneOS = param_PhoneOS;
    }
    
    inline System::String^  tb_codsoftitem::CodFileMd5::get() {
        return this->_CodFileMd5;
    }
    inline System::Void tb_codsoftitem::CodFileMd5::set(System::String^  value) {
        this->_CodFileMd5 = value;
    }
    
    inline System::String^  tb_codsoftitem::FullName::get() {
        return this->_FullName;
    }
    inline System::Void tb_codsoftitem::FullName::set(System::String^  value) {
        this->_FullName = value;
    }
    
    inline System::String^  tb_codsoftitem::SoftName::get() {
        return this->_SoftName;
    }
    inline System::Void tb_codsoftitem::SoftName::set(System::String^  value) {
        this->_SoftName = value;
    }
    
    inline System::String^  tb_codsoftitem::Version::get() {
        return this->_Version;
    }
    inline System::Void tb_codsoftitem::Version::set(System::String^  value) {
        this->_Version = value;
    }
    
    inline System::Int32 tb_codsoftitem::Size::get() {
        return this->_Size;
    }
    inline System::Void tb_codsoftitem::Size::set(System::Int32 value) {
        this->_Size = value;
    }
    
    inline System::DateTime tb_codsoftitem::Created::get() {
        return this->_Created;
    }
    inline System::Void tb_codsoftitem::Created::set(System::DateTime value) {
        this->_Created = value;
    }
    
    inline System::Int32 tb_codsoftitem::Score_Good::get() {
        return this->_Score_Good;
    }
    inline System::Void tb_codsoftitem::Score_Good::set(System::Int32 value) {
        this->_Score_Good = value;
    }
    
    inline System::Int32 tb_codsoftitem::Score_Bad::get() {
        return this->_Score_Bad;
    }
    inline System::Void tb_codsoftitem::Score_Bad::set(System::Int32 value) {
        this->_Score_Bad = value;
    }
    
    inline System::Int32 tb_codsoftitem::Money::get() {
        return this->_Money;
    }
    inline System::Void tb_codsoftitem::Money::set(System::Int32 value) {
        this->_Money = value;
    }
    
    inline System::DateTime tb_codsoftitem::UploadDateTime::get() {
        return this->_UploadDateTime;
    }
    inline System::Void tb_codsoftitem::UploadDateTime::set(System::DateTime value) {
        this->_UploadDateTime = value;
    }
    
    inline System::String^  tb_codsoftitem::PhoneTypes::get() {
        return this->_PhoneTypes;
    }
    inline System::Void tb_codsoftitem::PhoneTypes::set(System::String^  value) {
        this->_PhoneTypes = value;
    }
    
    inline System::String^  tb_codsoftitem::PhoneOS::get() {
        return this->_PhoneOS;
    }
    inline System::Void tb_codsoftitem::PhoneOS::set(System::String^  value) {
        this->_PhoneOS = value;
    }
}
