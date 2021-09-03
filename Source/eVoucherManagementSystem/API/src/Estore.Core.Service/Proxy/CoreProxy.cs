using Estore.Core.Entities;
using Estore.Core.Entities.Const;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Estore.Core.Service.Proxy
{
    public class CoreProxy : ICoreProxy
    {
        public CredentialsInfo GetCredentialsInfo(string url, string token)
        {
            CredentialsInfo credentialsInfo = new CredentialsInfo
            {
                AccessToken = token,
                Url = url,
                TimeOut = Convert.ToInt32(ConfigurationConsts.TimeOut)
            };
            return credentialsInfo;
        }

        public string GetURL(string controller, string method)
        {
            string url = string.Empty;
            url = ConfigurationConsts.PcmsApiUrl + "/" + controller + "/" + method;
            return url;
        }

        public string GetQueryString(NameValueCollection nvc)
        {
            StringBuilder sb = new StringBuilder("?");

            bool first = true;

            foreach (string key in nvc.AllKeys)
            {
                foreach (string value in nvc.GetValues(key))
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }

                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));

                    first = false;
                }
            }

            return sb.ToString();
        }
    }
}
