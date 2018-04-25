using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Keel.ORM;
namespace Keel.Json
{
    public class Json<T> : JsonObject// : IComparable, IConvertible, IComparable<bool>, IEquatable<bool>
    {

     
       public static implicit operator Json<T>(string s)
       {
           return  new JsonObject(s ) as Json<T>   ;
        }

       public static explicit operator string (Json<T> ret)
       {
           return ret.ToString();
       }
        public void FromModel(T model)
        {
            foreach (var itemt in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = DBHelper<string>.GetDataFieldAttrib(itemt);
                if (dfa == null) continue;
                if (!this.ContainsKey(dfa.ColumnName))
                {
                    object obj = itemt.GetValue(model, null);
                    this.Add(dfa.ColumnName, obj.ToString());
                }
            }
        }
        public T ToModel()
        {
           
                 T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = DBHelper<string>.GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (this.ContainsKey (colname ) )
                        {
                            string  obj= this.GetValue(colname);
                             if (item.PropertyType == typeof(string ))
                             {
                            item.SetValue(t, this.GetValue (colname )  , null);
                             }
                             else if (item.PropertyType == typeof(int))
                             {
 
                                 item.SetValue(t, int.Parse (obj  ) , null);
                             }
                             else if (item.PropertyType == typeof(byte ))
                             {

                                 item.SetValue(t, byte.Parse(obj), null);
                             }
                             else if (item.PropertyType == typeof(double ))
                             {

                                 item.SetValue(t, double.Parse(obj), null);
                             }
                             else if (item.PropertyType == typeof(float ))
                             {

                                 item.SetValue(t, float.Parse(obj), null);
                             }
                             
                        }
                    }
                }
                return t;
       

         
        }
 
    }
}
