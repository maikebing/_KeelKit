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
    public __gc class Table_1;
    
    
    [Keel::ORM::DataTableAttribute(S"Table_1")]
    public __gc class Table_1 {
        
        private: System::Int32 _id;
        
        private: System::DateTime _sdf;
        
        private: System::Boolean _b;
        
        private: System::Int32 _sd;
        
        private: System::String*  _dsf;
        
        private: System::String*  _sfd;
        
        public: [property: Keel::ORM::KeyFieldAttribute(S"id", S"Int32")]
         __property System::Int32 get_id();
        public: [property: Keel::ORM::KeyFieldAttribute(S"id", S"Int32")]
         __property  void set_id(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"sdf", S"DateTime")]
         __property System::DateTime get_sdf();
        public: [property: Keel::ORM::DataFieldAttribute(S"sdf", S"DateTime")]
         __property  void set_sdf(System::DateTime value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"b", S"Boolean")]
         __property System::Boolean get_b();
        public: [property: Keel::ORM::DataFieldAttribute(S"b", S"Boolean")]
         __property  void set_b(System::Boolean value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"sd", S"Int32")]
         __property System::Int32 get_sd();
        public: [property: Keel::ORM::DataFieldAttribute(S"sd", S"Int32")]
         __property  void set_sd(System::Int32 value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"dsf", S"AnsiString")]
         __property System::String*  get_dsf();
        public: [property: Keel::ORM::DataFieldAttribute(S"dsf", S"AnsiString")]
         __property  void set_dsf(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"sfd", S"String")]
         __property System::String*  get_sfd();
        public: [property: Keel::ORM::DataFieldAttribute(S"sfd", S"String")]
         __property  void set_sfd(System::String*  value)
        ;
    };
}
namespace sdsd {
    
    
    inline System::Int32 Table_1::get_id() {
        return this->_id;
    }
    inline void Table_1::set_id(System::Int32 value) {
        this->_id = value;
    }
    
    inline System::DateTime Table_1::get_sdf() {
        return this->_sdf;
    }
    inline void Table_1::set_sdf(System::DateTime value) {
        this->_sdf = value;
    }
    
    inline System::Boolean Table_1::get_b() {
        return this->_b;
    }
    inline void Table_1::set_b(System::Boolean value) {
        this->_b = value;
    }
    
    inline System::Int32 Table_1::get_sd() {
        return this->_sd;
    }
    inline void Table_1::set_sd(System::Int32 value) {
        this->_sd = value;
    }
    
    inline System::String*  Table_1::get_dsf() {
        return this->_dsf;
    }
    inline void Table_1::set_dsf(System::String*  value) {
        this->_dsf = value;
    }
    
    inline System::String*  Table_1::get_sfd() {
        return this->_sfd;
    }
    inline void Table_1::set_sfd(System::String*  value) {
        this->_sfd = value;
    }
}
