using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Keel.DataSafe
{
    public class KeelDataSafeBinding : CustomBinding
    {
        private static ICollection<BindingElement> GetBindingElement(int MaxBufferSize, int MaxReceivedMessageSize, int ReaderQuotasMaxArrayLength, string key, string iv)
        {
            ICollection<BindingElement> bindingElements = new List<BindingElement>();
            HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
            //string key = "JggkieIw7JM=";
            //string iv = "XdTkT85fZ0U=";
            CryptEncodingBindingElement textBindingElement = new CryptEncodingBindingElement(new BinaryMessageEncodingBindingElement(), key, iv);
            httpBindingElement.MaxBufferSize = MaxBufferSize;
            httpBindingElement.MaxReceivedMessageSize = MaxReceivedMessageSize;
            textBindingElement.readerQuotas.MaxArrayLength = ReaderQuotasMaxArrayLength;
            textBindingElement.readerQuotas.MaxStringContentLength = MaxBufferSize;
            textBindingElement.readerQuotas.MaxNameTableCharCount = MaxBufferSize;
            textBindingElement.readerQuotas.MaxDepth = MaxBufferSize;
            bindingElements.Add(textBindingElement);
            bindingElements.Add(httpBindingElement);
            return bindingElements;
        }
        /// <summary>
        /// 创建默认的Binding
        /// </summary>
        public KeelDataSafeBinding( )
            : base(GetBindingElement(20971520, 20971520, 20971520, "JggkieIw7JM=", "XdTkT85fZ0U="))
        {

        }
        /// <summary>
        /// 指定加密密钥
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public KeelDataSafeBinding( string key, string iv)
            : base(GetBindingElement(20971520, 20971520, 20971520, key, iv))
        {

        }
        public KeelDataSafeBinding(int MaxBufferSize, int MaxReceivedMessageSize, int ReaderQuotasMaxArrayLength )
            : base(GetBindingElement(MaxBufferSize, MaxReceivedMessageSize, ReaderQuotasMaxArrayLength, "JggkieIw7JM=", "XdTkT85fZ0U="))
        {

        }
        public KeelDataSafeBinding(int MaxBufferSize, int MaxReceivedMessageSize, int ReaderQuotasMaxArrayLength, string key, string iv)
            : base(GetBindingElement(MaxBufferSize, MaxReceivedMessageSize, ReaderQuotasMaxArrayLength, key, iv))
        {

        }

    }
}
