using LoginNavigation.Model;
using LoginNavigation.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation.RestClientForApp
{
    internal class UserClientRestService : IDisposable
    {
        private HttpClient httpClient;

        public UserClientRestService()
        {
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
        }

        //http://192.168.178.29:56431/api/Users/ranjith.murthy@gmail.com/password
        private const string WebServiceUrl = " http://192.168.178.54:56431/api/Users/";

        //public bool CheckUserIsCorrectOrNot(User user)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // client.BaseAddress = new Uri("http://192.168.178.29:56431/api/Users/"+user.Email+"/");
        //        //http://192.168.178.29:56431/api/Users/ranjith.murthy@gmail.com/add
        //        //HTTP GET

        //        var simple = WebServiceUrl + user.Username + "/" + user.Password;

        //        //var data= client.
        //        var responseTask = client.GetAsync(simple);
        //        // responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else
        //            return false;

        //    }
        //}

        //public bool SignUpForUser(RegisterViewModel userDetails, int i)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64189/api/student");

        //        //HTTP POST
        //        var json = JsonConvert.SerializeObject(userDetails);
        //        var postTask = client.PostAsJsonAsync<RegisterViewModel>("student", userDetails);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return false;
        //        }
        //    }

        //    // ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    return true;
        //}

        public async Task<bool> SignUpForUser(RegisterModel userDetails)
        {
            var uri = new Uri(WebServiceUrl);
            var json = JsonConvert.SerializeObject(userDetails);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);

            // read response object properly
            //TODO: Ranjith Not returning from client properly
            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            else
            {
                return false;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserClientRestService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}