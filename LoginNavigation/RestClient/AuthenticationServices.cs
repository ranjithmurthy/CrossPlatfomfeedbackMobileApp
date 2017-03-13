using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExternalProviderAuthentication
{
    public class AuthenticationServices
    {
        public AuthenticationServices(string baseUri)
        {
            BaseUri = baseUri;
        }

        public string BaseUri { get; }

        public string AccessToken { get; set; }

        public async Task<IEnumerable<ExternalLoginViewModel>> GetExternalLoginProviders()
        {
            var uri = string.Format("{0}/api/Account/ExternalLogins?returnUrl=%2F&generateState=true", BaseUri);

            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "GET";

            try
            {
                WebResponse response = await request.GetResponseAsync();
                var httpResponse = (HttpWebResponse) response;
                string result;

                using (var responseStream = httpResponse.GetResponseStream())
                {
                    result = new StreamReader(responseStream).ReadToEnd();
                }

                var models = JsonConvert.DeserializeObject<List<ExternalLoginViewModel>>(result);
                return models;
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to get login providers", ex);
            }
        }

        public async Task RegisterExternal(string username)
        {
            var uri = string.Format("{0}/api/Account/RegisterExternal", BaseUri);

            var model = new RegisterExternalBindingModel
            {
                UserName = username
            };

            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            // request.Headers.Add("Authorization", String.Format("Bearer {0}", AccessToken));
            request.Method = "POST";

            var postJson = JsonConvert.SerializeObject(model);
            var bytes = Encoding.UTF8.GetBytes(postJson);
            using (var requestStream = await request.GetRequestStreamAsync())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                WebResponse response = await request.GetResponseAsync();
                var httpResponse = (HttpWebResponse) response;
                string result;

                using (var responseStream = httpResponse.GetResponseStream())
                {
                    result = new StreamReader(responseStream).ReadToEnd();
                }
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to register user", ex);
            }
        }
    }
}