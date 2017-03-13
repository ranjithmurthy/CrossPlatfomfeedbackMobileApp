using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoginNavigation;
using Xamarin.Forms;

namespace ServiceLibrary
{
    public class ServiceLibrary : IServiceWrapper
    {
        public async Task<bool> ValidateUser(UserLoginModel loginModel)
        {
            if (!loginModel.IsValid())
            {
                return false;
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);
                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/ValidateUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return response.Equals("true");
            }
        }

        public async Task<string> RegisterUser(UserLoginModel loginModel)
        {
            if (!loginModel.IsValid())
            {
                return "invalid_model";
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                //  client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);

                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/createUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                return await postResponse.Content.ReadAsStringAsync();
            }
        }
    }
}