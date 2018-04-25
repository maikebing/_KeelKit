using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Keel.Tools
{
    /// <summary>
    /// XML读写器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XMLRW<T>
    {
        /// <summary>
        /// 从xml中反序列化一个对象
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Read(byte[] xml)
        {
            T ke = default(T);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            if (xml != null)
            {
                XmlReader xr = XmlReader.Create(new MemoryStream(xml));
                if (xs.CanDeserialize(xr))
                {
                    ke = (T)xs.Deserialize(xr);
                }
            }
            return ke;
        }

        
        /// <summary>
        /// 将一个对象序列化为二进制xml 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] Write(T t)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, t);
            return ms.ToArray();
        }
    }
}
