# 生成日期:20090517024747
class IronPython.DAL: # namespace
    import System
    import System.Collections.Generic
    import System.ComponentModel
    import System.Data
    import System.Text
    import Keel.ORM
    from clr import *
    
    class SP(object):
        __slots__ = []
        @staticmethod
        @accepts()
        @returns(System.Int32)
        def coop_tb_codfiles_GetAll():
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            return dbi.ExcStoredProcedure('coop_tb_codfiles_GetAll', Keel.SPExcMethod.ExecuteNonQuery)
        
        @staticmethod
        @accepts()
        @returns(System.Int32)
        def coop_tb_codsoftitem_GetAll():
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            return dbi.ExcStoredProcedure('coop_tb_codsoftitem_GetAll', Keel.SPExcMethod.ExecuteNonQuery)
        
        @staticmethod
        @accepts()
        @returns(System.Int32)
        def coop_tb_user_GetAll():
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            return dbi.ExcStoredProcedure('coop_tb_user_GetAll', Keel.SPExcMethod.ExecuteNonQuery)
        
        @staticmethod
        @accepts(System.String, System.String)
        @returns(System.Int32)
        def coop_tb_codfiles_Insert(filemd5, filepath):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('filemd5', 'filepath', ))
            values = System.Array[System.Object]((filemd5, filepath, ))
            return dbi.ExcStoredProcedure('coop_tb_codfiles_Insert', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String)
        @returns(System.Int32)
        def coop_tb_codfiles_GetOne(filemd5):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('filemd5', ))
            values = System.Array[System.Object]((filemd5, ))
            return dbi.ExcStoredProcedure('coop_tb_codfiles_GetOne', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String)
        @returns(System.Int32)
        def coop_tb_codfiles_Delete(filemd5):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('filemd5', ))
            values = System.Array[System.Object]((filemd5, ))
            return dbi.ExcStoredProcedure('coop_tb_codfiles_Delete', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String, System.String, System.String)
        @returns(System.Int32)
        def coop_tb_codfiles_Update(filemd5, filepath, PK_filemd5):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('filemd5', 'filepath', 'PK_filemd5', ))
            values = System.Array[System.Object]((filemd5, filepath, PK_filemd5, ))
            return dbi.ExcStoredProcedure('coop_tb_codfiles_Update', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String, System.String)
        @returns(System.Int32)
        def SP_Codfiles_Insert(Filemd5, Filepath):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('Filemd5', 'Filepath', ))
            values = System.Array[System.Object]((Filemd5, Filepath, ))
            return dbi.ExcStoredProcedure('SP_Codfiles_Insert', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String, System.String)
        @returns(System.Int32)
        def SP_Codfiles_Update(Filemd5, Filepath):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('Filemd5', 'Filepath', ))
            values = System.Array[System.Object]((Filemd5, Filepath, ))
            return dbi.ExcStoredProcedure('SP_Codfiles_Update', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String)
        @returns(System.Int32)
        def SP_Codfiles_DeleteByPK(Filemd5):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('Filemd5', ))
            values = System.Array[System.Object]((Filemd5, ))
            return dbi.ExcStoredProcedure('SP_Codfiles_DeleteByPK', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts()
        @returns(System.Int32)
        def SP_Codfiles_SelectAll():
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            return dbi.ExcStoredProcedure('SP_Codfiles_SelectAll', Keel.SPExcMethod.ExecuteNonQuery)
        
        @staticmethod
        @accepts(System.String)
        @returns(System.Int32)
        def SP_Codfiles_SelectByPK(Filemd5):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('Filemd5', ))
            values = System.Array[System.Object]((Filemd5, ))
            return dbi.ExcStoredProcedure('SP_Codfiles_SelectByPK', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String)
        @returns(System.Int32)
        def SP_Codfiles_QuickSearch(searchKey):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('searchKey', ))
            values = System.Array[System.Object]((searchKey, ))
            return dbi.ExcStoredProcedure('SP_Codfiles_QuickSearch', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String, System.String, System.String, System.String, System.Int32, System.DateTime, System.Int32, System.Int32, System.Int32, System.DateTime, System.String, System.String)
        @returns(System.Int32)
        def SP_Codsoftitem_Insert(CodFileMd5, FullName, SoftName, Version, Size, Created, Score_Good, Score_Bad, Money, UploadDateTime, PhoneTypes, PhoneOS):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('CodFileMd5', 'FullName', 'SoftName', 'Version', 'Size', 'Created', 'Score_Good', 'Score_Bad', 'Money', 'UploadDateTime', 'PhoneTypes', 'PhoneOS', ))
            values = System.Array[System.Object]((CodFileMd5, FullName, SoftName, Version, Size, Created, Score_Good, Score_Bad, Money, UploadDateTime, PhoneTypes, PhoneOS, ))
            return dbi.ExcStoredProcedure('SP_Codsoftitem_Insert', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts(System.String, System.String, System.String, System.String)
        @returns(System.Int32)
        def SP_User_Insert(Username, Password, Phonetype, Email):
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            names = System.Array[System.String](('Username', 'Password', 'Phonetype', 'Email', ))
            values = System.Array[System.Object]((Username, Password, Phonetype, Email, ))
            return dbi.ExcStoredProcedure('SP_User_Insert', Keel.SPExcMethod.ExecuteNonQuery, names, values)
        
        @staticmethod
        @accepts()
        @returns(System.Int32)
        def test1():
            dbi = Keel.SPHelper[System.Int32, System.Object][System.Int32, System.Object]()
            return dbi.ExcStoredProcedure('test1', Keel.SPExcMethod.ExecuteNonQuery)
        
    

