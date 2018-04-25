# 生成日期:20090422015421
class Model: # namespace
    import System
    import System.Collections.Generic
    import System.ComponentModel
    import System.Data
    import System.Text
    import Keel.ORM
    from clr import *
    
    class tb_user(object):
        """type(__username) == System.String, type(__password) == System.String, type(__phonetype) == System.String, type(__email) == System.String"""
        __slots__ = ['__username', '__password', '__phonetype', '__email']
        # <summary>
        # 用户名
        # </summary>
        # <summary>
        # 密码
        # </summary>
        # <summary>
        # 手机类型
        # </summary>
        # <summary>
        # 电邮
        # </summary>
        # <summary>
        # 用户名
        # </summary>
        @accepts(Self())
        @returns(System.String)
        def get_username(self):
            return self.__username
        
        @accepts(Self(), System.String)
        def set_username(self, value):
            self.__username = value
        
        username = property(fget=get_username,fset=set_username,fdoc="""<summary>
        用户名
        </summary>
        """)
        # <summary>
        # 密码
        # </summary>
        @accepts(Self())
        @returns(System.String)
        def get_password(self):
            return self.__password
        
        @accepts(Self(), System.String)
        def set_password(self, value):
            self.__password = value
        
        password = property(fget=get_password,fset=set_password,fdoc="""<summary>
        密码
        </summary>
        """)
        # <summary>
        # 手机类型
        # </summary>
        @accepts(Self())
        @returns(System.String)
        def get_phonetype(self):
            return self.__phonetype
        
        @accepts(Self(), System.String)
        def set_phonetype(self, value):
            self.__phonetype = value
        
        phonetype = property(fget=get_phonetype,fset=set_phonetype,fdoc="""<summary>
        手机类型
        </summary>
        """)
        # <summary>
        # 电邮
        # </summary>
        @accepts(Self())
        @returns(System.String)
        def get_email(self):
            return self.__email
        
        @accepts(Self(), System.String)
        def set_email(self, value):
            self.__email = value
        
        email = property(fget=get_email,fset=set_email,fdoc="""<summary>
        电邮
        </summary>
        """)
    

