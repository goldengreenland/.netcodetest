using Estore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Estore.Core.Service.Proxy
{
    public interface ICoreProxy
    {
        CredentialsInfo GetCredentialsInfo(string Url, string token);
        string GetURL(string controller, string method);
        string GetQueryString(NameValueCollection nvc);
    }
}
