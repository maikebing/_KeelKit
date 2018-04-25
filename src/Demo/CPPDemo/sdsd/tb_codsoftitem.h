#pragma once

#using <mscorlib.dll>

using namespace System::Security::Permissions;
[assembly:SecurityPermissionAttribute(SecurityAction::RequestMinimum, SkipVerification=false)];
// 生成日期:20090629121440
namespace sdsd {
    using namespace System;
    using namespace System::Collections::Generic;
    using namespace System::ComponentModel;
    using namespace System::Data;
    using namespace System::Text;
    using namespace Keel::ORM;
    using namespace System;
    public __gc class tb_codsoftitem;
    
    
    [Keel::ORM::DataTableAttribute(S"tb_codsoftitem")]
    public __gc class tb_codsoftitem {
        
        private: System::String*  _CodFileMd5;
        
        private: System::String*  _FullName;
        
        private: System::String*  _SoftName;
        
        private: System::String*  _Version;
        
        private: System::Int32 _Size;
        
        private: System::DateTime _Created;
        
        private: System::Int32 _Score_Good;
        
        private: System::Int32 _Score_Bad;
        
        private: System::Int32 _Money;
        
        private: System::DateTime _UploadDateTime;
        
        private: System::String*  _PhoneTypes;
        
        private: System::String*  _PhoneOS;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"CodFileMd5", S"String")]
         __property System::String*  get_CodFileMd5();
        public: [property: Keel::ORM::DataFieldAttribute(S"CodFileMd5", S"String")]
         __property  void set_CodFileMd5(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"FullName", S"String")]
         __property System::String*  get_FullName();
        public: [property: Keel::ORM::DataFieldAttribute(S"FullName", S"String")]
         __property  void set_FullName(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"SoftName", S"String")]
         __property System::String*  get_SoftName();
        public: [property: Keel::ORM::DataFieldAttribute(S"SoftName", S"String")]
         __property  void set_SoftName(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Version", S"String")]
         __property System::String*  get_Version();
        public: [property: Keel::ORM::DataFieldAttribute(S"Version", S"String")]
         __property  void set_Version(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Size", S"Int32")]
         __property System::Int32 get_Size();
        public: [property: Keel::ORM::DataFieldAttribute(S"Size", S"Int32")]
         __property  void set_Size(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Created", S"DateTime")]
         __property System::DateTime get_Created();
        public: [property: Keel::ORM::DataFieldAttribute(S"Created", S"DateTime")]
         __property  void set_Created(System::DateTime value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Score_Good", S"Int32")]
         __property System::Int32 get_Score_Good();
        public: [property: Keel::ORM::DataFieldAttribute(S"Score_Good", S"Int32")]
         __property  void set_Score_Good(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Score_Bad", S"Int32")]
         __property System::Int32 get_Score_Bad();
        public: [property: Keel::ORM::DataFieldAttribute(S"Score_Bad", S"Int32")]
         __property  void set_Score_Bad(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"Money", S"Int32")]
         __property System::Int32 get_Money();
        public: [property: Keel::ORM::DataFieldAttribute(S"Money", S"Int32")]
         __property  void set_Money(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"UploadDateTime", S"DateTime")]
         __property System::DateTime get_UploadDateTime();
        public: [property: Keel::ORM::DataFieldAttribute(S"UploadDateTime", S"DateTime")]
         __property  void set_UploadDateTime(System::DateTime value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"PhoneTypes", S"String")]
         __property System::String*  get_PhoneTypes();
        public: [property: Keel::ORM::DataFieldAttribute(S"PhoneTypes", S"String")]
         __property  void set_PhoneTypes(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"PhoneOS", S"String")]
         __property System::String*  get_PhoneOS();
        public: [property: Keel::ORM::DataFieldAttribute(S"PhoneOS", S"String")]
         __property  void set_PhoneOS(System::String*  value)
        ;
    };
}
namespace sdsd {
    
    
    inline System::String*  tb_codsoftitem::get_CodFileMd5() {
        return this->_CodFileMd5;
    }
    inline void tb_codsoftitem::set_CodFileMd5(System::String*  value) {
        this->_CodFileMd5 = value;
    }
    
    inline System::String*  tb_codsoftitem::get_FullName() {
        return this->_FullName;
    }
    inline void tb_codsoftitem::set_FullName(System::String*  value) {
        this->_FullName = value;
    }
    
    inline System::String*  tb_codsoftitem::get_SoftName() {
        return this->_SoftName;
    }
    inline void tb_codsoftitem::set_SoftName(System::String*  value) {
        this->_SoftName = value;
    }
    
    inline System::String*  tb_codsoftitem::get_Version() {
        return this->_Version;
    }
    inline void tb_codsoftitem::set_Version(System::String*  value) {
        this->_Version = value;
    }
    
    inline System::Int32 tb_codsoftitem::get_Size() {
        return this->_Size;
    }
    inline void tb_codsoftitem::set_Size(System::Int32 value) {
        this->_Size = value;
    }
    
    inline System::DateTime tb_codsoftitem::get_Created() {
        return this->_Created;
    }
    inline void tb_codsoftitem::set_Created(System::DateTime value) {
        this->_Created = value;
    }
    
    inline System::Int32 tb_codsoftitem::get_Score_Good() {
        return this->_Score_Good;
    }
    inline void tb_codsoftitem::set_Score_Good(System::Int32 value) {
        this->_Score_Good = value;
    }
    
    inline System::Int32 tb_codsoftitem::get_Score_Bad() {
        return this->_Score_Bad;
    }
    inline void tb_codsoftitem::set_Score_Bad(System::Int32 value) {
        this->_Score_Bad = value;
    }
    
    inline System::Int32 tb_codsoftitem::get_Money() {
        return this->_Money;
    }
    inline void tb_codsoftitem::set_Money(System::Int32 value) {
        this->_Money = value;
    }
    
    inline System::DateTime tb_codsoftitem::get_UploadDateTime() {
        return this->_UploadDateTime;
    }
    inline void tb_codsoftitem::set_UploadDateTime(System::DateTime value) {
        this->_UploadDateTime = value;
    }
    
    inline System::String*  tb_codsoftitem::get_PhoneTypes() {
        return this->_PhoneTypes;
    }
    inline void tb_codsoftitem::set_PhoneTypes(System::String*  value) {
        this->_PhoneTypes = value;
    }
    
    inline System::String*  tb_codsoftitem::get_PhoneOS() {
        return this->_PhoneOS;
    }
    inline void tb_codsoftitem::set_PhoneOS(System::String*  value) {
        this->_PhoneOS = value;
    }
}
