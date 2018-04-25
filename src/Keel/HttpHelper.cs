using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
namespace Keel
{
    public class HttpHelper
    {
        static HttpHelper hhutf8 = new HttpHelper(Encoding.UTF8 );
        /// <summary>
        /// 获取一个utf8的url助手
        /// </summary>
        public static HttpHelper UTF8
        {
            get
            {
                return hhutf8;
            }
        }
        static HttpHelper hhgb2312 = new HttpHelper(Encoding.GetEncoding ("gb2312"));
        /// <summary>
        /// 获取一个gb2132的http助手
        /// </summary>
        public static HttpHelper GB2312
        {
            get
            {
                return hhgb2312;
            }
        }
        /// <summary>
        /// 新建一个http助手
        /// </summary>
        public HttpHelper()
        {
        }
        /// <summary>
        /// 用指定的ur新建一个http助手，所有url可以是相对这个url的。 
        /// </summary>
        /// <param name="url">url 例如 http://www.keelkit.com </param>
        public HttpHelper(string url )
        {
            URL = new Uri(url);
        }
        public HttpHelper(string url,Encoding encoding)
        {
            URL = new Uri(url);
            Encoding = encoding;
        }
        public HttpHelper(  Encoding encoding)
        {
         
            Encoding = encoding;
        }
        /// <summary>
        /// 用指定的URI新建一个http助手，所有url可以是相对这个URI的。 
        /// </summary>
        /// <param name="uri"></param>
        public HttpHelper(Uri  uri)
        {
            URL = uri ;
        }


        #region 变量定义
        private CookieContainer cc = new CookieContainer();
        private string contentType = "application/x-www-form-urlencoded";
        private string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
        private Encoding encoding = Encoding.GetEncoding("utf-8");
        private int delay = 50;
        private int maxTry = 2;
        private int currentTry = 0;
        #endregion
        #region 变量赋值
        /// <summary> 
        /// Cookie
        /// </summary> 
        public CookieContainer CookieContainer
        {
            get
            {
                return cc;
            }
        }
        /// <summary>
        /// 基础URL地址
        /// </summary>
        public Uri URL { get; set; }

        /// <summary> 
        /// 语言
        /// </summary> 
        /// <value></value> 
        public Encoding Encoding
        {
            get
            {
                return encoding;
            }
            set
            {
                encoding = value;
            }
        }

        public int NetworkDelay
        {
            get
            {
                Random r = new Random();
                return (r.Next(delay, delay * 2));
            }
            set
            {
                delay = value;
            }
        }

        public int MaxTry
        {
            get
            {
                return maxTry;
            }
            set
            {
                maxTry = value;
            }
        }
        #endregion
        /// <summary>
        /// 如果服务器返回 417错误， 则设置此处为 flasu
        /// </summary>

        public bool Expect100Continue { get; set; }
        #region 获取HTML
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postData">post 提交的字符串</param>
        /// <param name="isPost">是否是post</param>
        /// <param name="cookieContainer">CookieContainer</param>
        /// <returns>html </returns>
        public string GetHtml(string url, string postData, bool isPost, CookieContainer cookieContainer)
        {
            url = SetURL(url);
            if (string.IsNullOrEmpty(postData))
            {
                return GetHtml(url, cookieContainer);
            }

            Thread.Sleep(NetworkDelay);//等待

            currentTry++;

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                byte[] byteRequest = Encoding.GetBytes(postData);

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.ServicePoint.Expect100Continue = Expect100Continue;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = isPost ? "POST" : "GET";
                httpWebRequest.ContentLength = byteRequest.Length;

                //httpWebRequest.

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(byteRequest, 0, byteRequest.Length);
                stream.Close();

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                currentTry = 0;

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, postData, isPost, cookieContainer);
                }
                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookieContainer">CookieContainer</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url, CookieContainer cookieContainer)
        {
            url = SetURL(url);
            Thread.Sleep(NetworkDelay);

            currentTry++;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                currentTry--;

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url)
        {
            return GetHtml(url, cc);
        }
   
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>HTML</returns>
        public string GetHtml()
        {
            return GetHtml(URL.ToString (), cc);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postData">提交的字符串</param>
        /// <param name="isPost">是否是POST</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url, string postData, bool isPost)
        {
            return GetHtml(url, postData, isPost, cc);
        }


        /// <summary>
        /// 获取字符流
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookieContainer">cookieContainer</param>
        /// <returns>Stream</returns>
        public Stream GetStream(string url, CookieContainer cookieContainer)
        {
            return GetStream(url, cookieContainer, false);
        }
        /// <summary>
        /// 获取字符流
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookieContainer">cookieContainer</param>
        /// <returns>Stream</returns>
        public Stream GetStream(string url, CookieContainer cookieContainer, bool once)
        {
            //Thread.Sleep(delay); 
            url = SetURL(url);
            currentTry++;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;

            try
            {

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                currentTry--;

                //httpWebRequest.Abort(); 
                //httpWebResponse.Close(); 

                return responseStream;
            }
            catch (Exception e)
            {
                if (!once)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                    Console.ForegroundColor = ConsoleColor.White;

                    if (currentTry <= maxTry)
                    {
                        GetHtml(url, cookieContainer);
                    }

                    currentTry--;
                }
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }

                return null;
            }
        }

        private string SetURL(string url)
        {
            if (!url.Contains("http://"))
            {
                url = URL.AbsoluteUri + ((URL.AbsoluteUri.EndsWith("/") || url.StartsWith("/")) ? "" : "/") + url;
            }
            return url;
        }
        #endregion


    }
}
