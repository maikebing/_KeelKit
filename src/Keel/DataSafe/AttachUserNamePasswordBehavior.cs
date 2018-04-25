using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Keel.DataSafe
{
    /// <summary>
    /// http://www.cnblogs.com/jillzhang/archive/2010/04/11/1709397.html
    /// </summary>
    public class KeelMessageInspector : IClientMessageInspector, IDispatchMessageInspector, IEndpointBehavior
    {
        //
        private static string UserName = System.Configuration.ConfigurationManager .AppSettings["username"];

        private static string Password = System.Configuration.ConfigurationManager.AppSettings["pwd"];



        public KeelMessageInspector()
        {

        }





        #region IClientMessageInspector 成员



        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {



        }



        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {

            MessageHeader userNameHeader = MessageHeader.CreateHeader("OperationUserName", "http://tempuri.org", UserName, false, "");

            MessageHeader pwdNameHeader = MessageHeader.CreateHeader("OperationPwd", "http://tempuri.org", Password, false, "");

            request.Headers.Add(userNameHeader);

            request.Headers.Add(pwdNameHeader);

            Console.WriteLine(request);

            return null;

        }



        #endregion



        #region IDispatchMessageInspector 成员



        string GetHeaderValue(string key)
        {

            int index = OperationContext.Current.IncomingMessageHeaders.FindHeader(key, "http://tempuri.org");

            if (index >= 0)
            {

                return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(index).ToString();

            }

            return null;

        }



        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {

            Console.WriteLine(request);

            string username = GetHeaderValue("OperationUserName");

            string pwd = GetHeaderValue("OperationPwd");

            if (username == "robinzhang" && pwd == "111111")
            {

            }

            else
            {

                throw new Exception("操作中的用户名，密码不正确！");

            }

            return null;

        }



        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {



        }



        #endregion



        #region IEndpointBehavior 成员



        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {



        }



        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {

            clientRuntime.MessageInspectors.Add(new KeelMessageInspector());

        }



        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new KeelMessageInspector());

        }



        public void Validate(ServiceEndpoint endpoint)
        {



        }



        #endregion

    } 

}
