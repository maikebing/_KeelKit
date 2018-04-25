# 生成日期:20090422015421
class Model: # namespace
    import System
    import System.Collections.Generic
    import System.ComponentModel
    import System.Data
    import System.Text
    import Keel.ORM
    from clr import *
    
    class tb_codsoftitem(object):
        """type(__CodFileMd5) == System.String, type(__FullName) == System.String, type(__SoftName) == System.String, type(__Version) == System.String, type(__Size) == System.Int32, type(__Created) == System.DateTime, type(__Score_Good) == System.Int32, type(__Score_Bad) == System.Int32, type(__Money) == System.Int32, type(__UploadDateTime) == System.DateTime, type(__PhoneTypes) == System.String, type(__PhoneOS) == System.String"""
        __slots__ = ['__CodFileMd5', '__FullName', '__SoftName', '__Version', '__Size', '__Created', '__Score_Good', '__Score_Bad', '__Money', '__UploadDateTime', '__PhoneTypes', '__PhoneOS']
        @accepts(Self())
        @returns(System.String)
        def get_CodFileMd5(self):
            return self.__CodFileMd5
        
        @accepts(Self(), System.String)
        def set_CodFileMd5(self, value):
            self.__CodFileMd5 = value
        
        CodFileMd5 = property(fget=get_CodFileMd5,fset=set_CodFileMd5)
        @accepts(Self())
        @returns(System.String)
        def get_FullName(self):
            return self.__FullName
        
        @accepts(Self(), System.String)
        def set_FullName(self, value):
            self.__FullName = value
        
        FullName = property(fget=get_FullName,fset=set_FullName)
        @accepts(Self())
        @returns(System.String)
        def get_SoftName(self):
            return self.__SoftName
        
        @accepts(Self(), System.String)
        def set_SoftName(self, value):
            self.__SoftName = value
        
        SoftName = property(fget=get_SoftName,fset=set_SoftName)
        @accepts(Self())
        @returns(System.String)
        def get_Version(self):
            return self.__Version
        
        @accepts(Self(), System.String)
        def set_Version(self, value):
            self.__Version = value
        
        Version = property(fget=get_Version,fset=set_Version)
        @accepts(Self())
        @returns(System.Int32)
        def get_Size(self):
            return self.__Size
        
        @accepts(Self(), System.Int32)
        def set_Size(self, value):
            self.__Size = value
        
        Size = property(fget=get_Size,fset=set_Size)
        @accepts(Self())
        @returns(System.DateTime)
        def get_Created(self):
            return self.__Created
        
        @accepts(Self(), System.DateTime)
        def set_Created(self, value):
            self.__Created = value
        
        Created = property(fget=get_Created,fset=set_Created)
        @accepts(Self())
        @returns(System.Int32)
        def get_Score_Good(self):
            return self.__Score_Good
        
        @accepts(Self(), System.Int32)
        def set_Score_Good(self, value):
            self.__Score_Good = value
        
        Score_Good = property(fget=get_Score_Good,fset=set_Score_Good)
        @accepts(Self())
        @returns(System.Int32)
        def get_Score_Bad(self):
            return self.__Score_Bad
        
        @accepts(Self(), System.Int32)
        def set_Score_Bad(self, value):
            self.__Score_Bad = value
        
        Score_Bad = property(fget=get_Score_Bad,fset=set_Score_Bad)
        @accepts(Self())
        @returns(System.Int32)
        def get_Money(self):
            return self.__Money
        
        @accepts(Self(), System.Int32)
        def set_Money(self, value):
            self.__Money = value
        
        Money = property(fget=get_Money,fset=set_Money)
        @accepts(Self())
        @returns(System.DateTime)
        def get_UploadDateTime(self):
            return self.__UploadDateTime
        
        @accepts(Self(), System.DateTime)
        def set_UploadDateTime(self, value):
            self.__UploadDateTime = value
        
        UploadDateTime = property(fget=get_UploadDateTime,fset=set_UploadDateTime)
        @accepts(Self())
        @returns(System.String)
        def get_PhoneTypes(self):
            return self.__PhoneTypes
        
        @accepts(Self(), System.String)
        def set_PhoneTypes(self, value):
            self.__PhoneTypes = value
        
        PhoneTypes = property(fget=get_PhoneTypes,fset=set_PhoneTypes)
        @accepts(Self())
        @returns(System.String)
        def get_PhoneOS(self):
            return self.__PhoneOS
        
        @accepts(Self(), System.String)
        def set_PhoneOS(self, value):
            self.__PhoneOS = value
        
        PhoneOS = property(fget=get_PhoneOS,fset=set_PhoneOS)
    

