using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Class1
    {
        public static void  SP_Codsoftitem_Insert( string CodFileMd5   ,  string FullName ,
		string SoftName , 
		string Version   , 
		int Size  ,
		DateTime   Created , 
		int  Score_Good  , 
		int  Score_Bad  , 
		int  Money , 
		DateTime UploadDateTime    , 
		string  PhoneTypes  , 
		string  PhoneOS )
    {
        Keel.DBHelper<int> dbi = new Keel.DBHelper<int>();
            string[] names =new string[]{"CodFileMd5","FullName","SoftName","Version","Size","Created","Score_Good","Score_Bad","Money","UploadDateTime","PhoneTypes","PhoneOS"};
            object [] objs =new object[]{CodFileMd5,FullName,SoftName,Version,Size,Created,Score_Good,Score_Bad,Money,UploadDateTime,PhoneTypes,PhoneOS};
          int i =  dbi.ExcStoredProcedure("SP_Codsoftitem_Insert", Keel.SPExcMethod.ExecuteNonQuery, names, objs);
    }
    }
}
