# 生成日期:20090422015421
class Model: # namespace
    import System
    import System.Collections.Generic
    import System.ComponentModel
    import System.Data
    import System.Text
    import Keel.ORM
    from clr import *
    
    class tb_codfiles(object):
        """type(__filemd5) == System.String, type(__filepath) == System.String"""
        __slots__ = ['__filemd5', '__filepath']
        @accepts(Self())
        @returns(System.String)
        def get_filemd5(self):
            return self.__filemd5
        
        @accepts(Self(), System.String)
        def set_filemd5(self, value):
            self.__filemd5 = value
        
        filemd5 = property(fget=get_filemd5,fset=set_filemd5)
        @accepts(Self())
        @returns(System.String)
        def get_filepath(self):
            return self.__filepath
        
        @accepts(Self(), System.String)
        def set_filepath(self, value):
            self.__filepath = value
        
        filepath = property(fget=get_filepath,fset=set_filepath)
    

