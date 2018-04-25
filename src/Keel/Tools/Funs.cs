﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace Keel.Tools
{
   public static   class Funs
    {
       public static void OpenFileInExplorer(string filename)
       {
           try
           {
               System.Diagnostics.Process p = new System.Diagnostics.Process();
               p.StartInfo = new System.Diagnostics.ProcessStartInfo("Explorer", "/select, " + filename);
               p.Start();
           }
           catch (Exception)
           {


           }
       }

        static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        public static string MD5Sum(byte []  bary)
        {
            string t2 = BitConverter.ToString(md5.ComputeHash(bary ));
            t2 = t2.Replace("-", "");
            return t2;
        }
        public static string MD5Sum(string bary)
        {
            string t2 = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(bary)));
            t2 = t2.Replace("-", "");
            return t2;
        }
        public static string MD5File(string filename)
        {
            string t2 = BitConverter.ToString(md5.ComputeHash(System.IO.File.ReadAllBytes (filename )));
            t2 = t2.Replace("-", "");
            return t2;
        }
        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="_context">要压缩的内容</param>
        /// <returns>使用base64的方式输出压缩后的内容</returns>
        public static string Compress(string _context)
        {
            return Convert.ToBase64String(Compress(Encoding.UTF8.GetBytes(_context)));
        }
        /// <summary>
        /// 压缩二进制
        /// </summary>
        /// <param name="_context">要压缩的内容</param>
        /// <returns>输出压缩后的内容</returns>
        public static byte[] Compress(byte[] _context)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream gzs = new GZipStream(ms, CompressionMode.Compress, true);
            gzs.Write(_context, 0, _context.Length);
            gzs.Close();
            return ms.ToArray();
        }
        /// <summary>
        /// 解压一个base64格式的字符串
        /// </summary>
        /// <param name="_context">内容</param>
        /// <returns>返回解压后的内容</returns>
        public static string Decompress(string _context)
        {
            return Encoding.UTF8.GetString(Decompress(Convert.FromBase64String(_context)));
        }
        /// <summary>
        /// 解压二进制
        /// </summary>
        /// <param name="_context">内容</param>
        /// <returns>返回解压后的内容</returns>
        public static byte[] Decompress(byte[] _context)
        {
            byte[] result = null;
            if (_context != null)
            {
                byte[] bytes = new byte[1024];
                MemoryStream ms = new MemoryStream();
                GZipStream gzs = new GZipStream(new MemoryStream(_context), CompressionMode.Decompress, true);
                int i;
                while ((i = gzs.Read(bytes, 0, bytes.Length)) != 0)
                {
                    ms.Write(bytes, 0, i);

                }
                result = ms.ToArray();
                gzs.Close();
                ms.Close();
                ms.Dispose();
                gzs.Dispose();
            }
            return result;
        }
    }
}
