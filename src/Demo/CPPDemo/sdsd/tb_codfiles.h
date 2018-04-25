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
    public __gc class tb_codfiles;
    
    
    [Keel::ORM::DataTableAttribute(S"tb_codfiles")]
    public __gc class tb_codfiles {
        
        private: System::String*  _filemd5;
        
        private: System::String*  _filepath;
        
        public: [property: Keel::ORM::KeyFieldAttribute(S"filemd5", S"String", false)]
         __property System::String*  get_filemd5();
        public: [property: Keel::ORM::KeyFieldAttribute(S"filemd5", S"String", false)]
         __property  void set_filemd5(System::String*  value)
        ;
        
        public: [property: Keel::ORM::DataFieldAttribute(S"filepath", S"String")]
         __property System::String*  get_filepath();
        public: [property: Keel::ORM::DataFieldAttribute(S"filepath", S"String")]
         __property  void set_filepath(System::String*  value)
        ;
    };
}
namespace sdsd {
    
    
    inline System::String*  tb_codfiles::get_filemd5() {
        return this->_filemd5;
    }
    inline void tb_codfiles::set_filemd5(System::String*  value) {
        this->_filemd5 = value;
    }
    
    inline System::String*  tb_codfiles::get_filepath() {
        return this->_filepath;
    }
    inline void tb_codfiles::set_filepath(System::String*  value) {
        this->_filepath = value;
    }
}
