#pragma once

#using <mscorlib.dll>

using namespace System::Security::Permissions;
[assembly:SecurityPermissionAttribute(SecurityAction::RequestMinimum, SkipVerification=false)];
// 生成日期:20090629120556
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
        
        public: static System::Int32 coop_tb_codfiles_GetAll();
        
        public: static System::Int32 coop_tb_codsoftitem_GetAll();
        
        public: static System::Int32 coop_tb_user_GetAll();
        
        public: static System::Int32 coop_tb_codfiles_Insert(System::String*  filemd5, System::String*  filepath);
        
        public: static System::Int32 coop_tb_codfiles_GetOne(System::String*  filemd5);
        
        public: static System::Int32 coop_tb_codfiles_Delete(System::String*  filemd5);
        
        public: static System::Int32 coop_tb_codfiles_Update(System::String*  filemd5, System::String*  filepath, System::String*  PK_filemd5);
        
        public: static System::Int32 SP_Codfiles_Insert(System::String*  Filemd5, System::String*  Filepath);
        
        public: static System::Int32 SP_Codfiles_Update(System::String*  Filemd5, System::String*  Filepath);
        
        public: static System::Int32 SP_Codfiles_DeleteByPK(System::String*  Filemd5);
        
        public: static System::Int32 SP_Codfiles_SelectAll();
        
        public: static System::Int32 SP_Codfiles_SelectByPK(System::String*  Filemd5);
        
        public: static System::Int32 SP_Codfiles_QuickSearch(System::String*  searchKey);
        
        public: static System::Int32 SP_Codsoftitem_Insert(
                    System::String*  CodFileMd5, 
                    System::String*  FullName, 
                    System::String*  SoftName, 
                    System::String*  Version, 
                    System::Int32 Size, 
                    System::DateTime Created, 
                    System::Int32 Score_Good, 
                    System::Int32 Score_Bad, 
                    System::Int32 Money, 
                    System::DateTime UploadDateTime, 
                    System::String*  PhoneTypes, 
                    System::String*  PhoneOS);
        
        public: static System::Int32 SP_User_Insert(System::String*  Username, System::String*  Password, System::String*  Phonetype, 
                    System::String*  Email);
        
        public: static System::Int32 test1();
    };
}
namespace DAL {
    
    
    inline System::Int32 SP::coop_tb_codfiles_GetAll() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_GetAll", Keel::SPExcMethod::ExecuteNonQuery);
    }
    
    inline System::Int32 SP::coop_tb_codsoftitem_GetAll() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"coop_tb_codsoftitem_GetAll", Keel::SPExcMethod::ExecuteNonQuery);
    }
    
    inline System::Int32 SP::coop_tb_user_GetAll() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"coop_tb_user_GetAll", Keel::SPExcMethod::ExecuteNonQuery);
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
    
    inline System::Int32 SP::coop_tb_codfiles_GetOne(System::String*  filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_GetOne", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::coop_tb_codfiles_Delete(System::String*  filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_Delete", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::coop_tb_codfiles_Update(System::String*  filemd5, System::String*  filepath, System::String*  PK_filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[3];
                __mcTemp__1[0] = S"filemd5";
                __mcTemp__1[1] = S"filepath";
                __mcTemp__1[2] = S"PK_filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[3];
                __mcTemp__2[0] = filemd5;
                __mcTemp__2[1] = filepath;
                __mcTemp__2[2] = PK_filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"coop_tb_codfiles_Update", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codfiles_Insert(System::String*  Filemd5, System::String*  Filepath) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[2];
                __mcTemp__1[0] = S"Filemd5";
                __mcTemp__1[1] = S"Filepath";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[2];
                __mcTemp__2[0] = Filemd5;
                __mcTemp__2[1] = Filepath;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codfiles_Insert", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codfiles_Update(System::String*  Filemd5, System::String*  Filepath) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[2];
                __mcTemp__1[0] = S"Filemd5";
                __mcTemp__1[1] = S"Filepath";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[2];
                __mcTemp__2[0] = Filemd5;
                __mcTemp__2[1] = Filepath;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codfiles_Update", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codfiles_DeleteByPK(System::String*  Filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"Filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = Filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codfiles_DeleteByPK", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codfiles_SelectAll() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"SP_Codfiles_SelectAll", Keel::SPExcMethod::ExecuteNonQuery);
    }
    
    inline System::Int32 SP::SP_Codfiles_SelectByPK(System::String*  Filemd5) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"Filemd5";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = Filemd5;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codfiles_SelectByPK", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codfiles_QuickSearch(System::String*  searchKey) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[1];
                __mcTemp__1[0] = S"searchKey";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[1];
                __mcTemp__2[0] = searchKey;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codfiles_QuickSearch", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_Codsoftitem_Insert(
                System::String*  CodFileMd5, 
                System::String*  FullName, 
                System::String*  SoftName, 
                System::String*  Version, 
                System::Int32 Size, 
                System::DateTime Created, 
                System::Int32 Score_Good, 
                System::Int32 Score_Bad, 
                System::Int32 Money, 
                System::DateTime UploadDateTime, 
                System::String*  PhoneTypes, 
                System::String*  PhoneOS) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[12];
                __mcTemp__1[0] = S"CodFileMd5";
                __mcTemp__1[1] = S"FullName";
                __mcTemp__1[2] = S"SoftName";
                __mcTemp__1[3] = S"Version";
                __mcTemp__1[4] = S"Size";
                __mcTemp__1[5] = S"Created";
                __mcTemp__1[6] = S"Score_Good";
                __mcTemp__1[7] = S"Score_Bad";
                __mcTemp__1[8] = S"Money";
                __mcTemp__1[9] = S"UploadDateTime";
                __mcTemp__1[10] = S"PhoneTypes";
                __mcTemp__1[11] = S"PhoneOS";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[12];
                __mcTemp__2[0] = CodFileMd5;
                __mcTemp__2[1] = FullName;
                __mcTemp__2[2] = SoftName;
                __mcTemp__2[3] = Version;
                __mcTemp__2[4] = __box(Size);
                __mcTemp__2[5] = __box(Created);
                __mcTemp__2[6] = __box(Score_Good);
                __mcTemp__2[7] = __box(Score_Bad);
                __mcTemp__2[8] = __box(Money);
                __mcTemp__2[9] = __box(UploadDateTime);
                __mcTemp__2[10] = PhoneTypes;
                __mcTemp__2[11] = PhoneOS;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_Codsoftitem_Insert", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::SP_User_Insert(System::String*  Username, System::String*  Password, System::String*  Phonetype, 
                System::String*  Email) {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        System::String* __mcTemp__1[] = new System::String*[4];
                __mcTemp__1[0] = S"Username";
                __mcTemp__1[1] = S"Password";
                __mcTemp__1[2] = S"Phonetype";
                __mcTemp__1[3] = S"Email";
        System::String*  names[] = __mcTemp__1;
        System::Object* __mcTemp__2[] = new System::Object*[4];
                __mcTemp__2[0] = Username;
                __mcTemp__2[1] = Password;
                __mcTemp__2[2] = Phonetype;
                __mcTemp__2[3] = Email;
        System::Object*  values[] = __mcTemp__2;
        return dbi->ExcStoredProcedure(S"SP_User_Insert", Keel::SPExcMethod::ExecuteNonQuery, names, values);
    }
    
    inline System::Int32 SP::test1() {
        Keel::SPHelper`2*  dbi = (new Keel::SPHelper`2());
        return dbi->ExcStoredProcedure(S"test1", Keel::SPExcMethod::ExecuteNonQuery);
    }
}
