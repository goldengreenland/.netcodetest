using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities
{
    public class CredentialsInfo
    {
        public string AccessToken { get; set; }
        public int? TimeOut { get; set; }
        public string Url { get; set; }
    }
}
