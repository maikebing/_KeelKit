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
    ref class tb_codfiles;
    
    
    [Keel::ORM::DataTableAttribute(L"tb_codfiles")]
    public ref class tb_codfiles {
        
        private: System::String^  _filemd5;
        
        /// <summary>
        /// Cod文件
        /// </summary>
        public: literal System::String^  fn_filemd5 = L"filemd5";
        
        private: System::String^  _filepath;
        
        public: literal System::String^  fn_filepath = L"filepath";
        
        public: tb_codfiles(System::String^  param_filemd5, System::String^  param_filepath);
        public: [Keel::ORM::KeyFieldAttribute(L"filemd5", L"String", false)]
        property System::String^  filemd5 {
            System::String^  get();
            System::Void set(System::String^  value);
        }
        
        public: [Keel::ORM::DataFieldAttribute(L"filepath", L"String")]
        property System::String^  filepath {
            System::String^  get();
            System::Void set(System::String^  value);
        }
    };
}
namespace Model {
    
    
    inline tb_codfiles::tb_codfiles(System::String^  param_filemd5, System::String^  param_filepath) {
        this->filemd5 = param_filemd5;
        this->filepath = param_filepath;
    }
    
    inline System::String^  tb_codfiles::filemd5::get() {
        return this->_filemd5;
    }
    inline System::Void tb_codfiles::filemd5::set(System::String^  value) {
        this->_filemd5 = value;
    }
    
    inline System::String^  tb_codfiles::filepath::get() {
        return this->_filepath;
    }
    inline System::Void tb_codfiles::filepath::set(System::String^  value) {
        this->_filepath = value;
    }
}
