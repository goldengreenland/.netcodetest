using Estore.Core.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service.Proxy
{
    public class HttpClient<Req, Res>
    {
        private Req requestObject;
        private Res responseObject = default(Res);

        public HttpClient(Req value)
        {
            requestObject = value;
        }

        public async Task<Res> Get(string requestMessage, CredentialsInfo credentialsInfo)
        {
            string responseData = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                HttpWebRequest request = WebRequest.Create(credentialsInfo.Url + requestMessage) as HttpWebRequest;

                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Bearer " + credentialsInfo.AccessToken);

                using (HttpWebResponse output = await request.GetResponseAsync() as HttpWebResponse)
                {
                    if (output.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        responseData = new StreamReader(output.GetResponseStream()).ReadToEnd();
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.GatewayTimeout))
                    {
                        responseData = "Time-out.";
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.InternalServerError))
                    {
                        responseData = "Internal server error.";
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        responseData = "Method not found.";
                    }
                    else
                    {
                        responseData = "System error.";
                    }
                }
            }
            catch (Exception e)
            {
                responseData = e.Message;
            }

            var responseObject = JsonConvert.DeserializeObject<Res>(responseData);

            return responseObject;
        }

        public async Task<Res> Post(string requestMessage, CredentialsInfo credentialsInfo)
        {
            string responseData = string.Empty;
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                HttpWebRequest request = WebRequest.Create(credentialsInfo.Url + requestMessage) as HttpWebRequest;

                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Bearer " + credentialsInfo.AccessToken);

                using (HttpWebResponse output = await request.GetResponseAsync() as HttpWebResponse)
                {
                    if (output.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        responseData = new StreamReader(output.GetResponseStream()).ReadToEnd();
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.GatewayTimeout))
                    {
                        responseData = "Time-out.";
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.InternalServerError))
                    {
                        responseData = "Internal server error.";
                    }
                    else if (output.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        responseData = "Method not found.";
                    }
                    else
                    {
                        responseData = "System error.";
                    }
                }
            }
            catch (Exception e)
            {
                responseData = e.Message;
            }

            var responseObject = JsonConvert.DeserializeObject<Res>(responseData);
            return responseObject;
        }

        public async Task<Res> Post(Req requestObject, CredentialsInfo credentialsInfo)
        {
            try
            {
                var postBody = JsonConvert.SerializeObject(requestObject);
                var client = new RestClient(credentialsInfo?.Url);
                var request = new RestRequest(Method.POST);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                request.AddHeader("cache-control", "no-cache");
                if (!string.IsNullOrEmpty(credentialsInfo?.AccessToken))
                {
                    request.AddHeader("Authorization", "Bearer " + credentialsInfo?.AccessToken);
                }
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", postBody, ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteAsync(request);

                var responseObject = JsonConvert.DeserializeObject<Res>(response?.Content);
                return responseObject;
            }
            catch (Exception)
            {
                return default(Res);
            }
        }
    }
}
