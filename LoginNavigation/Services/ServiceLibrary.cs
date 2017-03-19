using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LoginNavigation;
using Newtonsoft.Json;

namespace ServiceLibrary
{
    public class ServiceWrapper : IServiceWrapper
    {
        //http://192.168.0.8:56431/api/users

        //private const string WebServiceUrl = "http://192.168.0.15:56431/api/";

          private const string WebServiceUrl = "http://192.168.178.29:56431/api/";
        // 192.168.178.29
        // private const string WebServiceUrl = "http://192.168.0.8:56431/api/";
        public async Task<bool> ValidateUser(LoginViewModel loginModel)
        {
            if (!loginModel.IsValid())
                return false;

            using (var client = new HttpClient())
            {
                var uri = new Uri(WebServiceUrl + "Users/validate");

                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var postResponse = await client.PostAsync(uri, content);

                if (postResponse.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }

        public async Task<string> RegisterUser(LoginViewModel loginModel)
        {
            if (!loginModel.IsValid())
                return "invalid_model";

            using (var client = new HttpClient())
            {
                var uri = new Uri(WebServiceUrl + "Login/CreateUser");
                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postResponse = await client.PostAsync(uri, content);

                if (postResponse.IsSuccessStatusCode)
                    return "RegisterUser Successfully";

                return "Not Successfully!";
            }
        }

      

        public async Task<bool> SubmitUserFeedback(UserFeedbackViewModel userFeedback)
        {

            //api/RestUserFeedBack/SubmitFeedback
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(WebServiceUrl + "RestUserFeedBack/SubmitFeedback");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));




                string json = JsonConvert.SerializeObject(userFeedback);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postResponse = await client.PostAsync(uri, content);

                if (postResponse.IsSuccessStatusCode)
                    return true;
                else 
                     return false;
            }



            //Submit one userfeedbackviewmodel
            return true;
        }




        public async Task<T> GetJsonData<T>() where T : new()
        {
            var uri = new Uri(WebServiceUrl + "/RestUserFeedBack");

            using (var httpClient = new HttpClient())
            {
                var json_data = string.Empty;
                try
                {
                    // Now parse with JSON.Net

                    // attempt to download JSON data as a string
                    json_data = await httpClient.GetStringAsync(uri);

                    // json_data = w.DownloadString(url);

                    return JsonConvert.DeserializeObject<T>(json_data);
                }
                catch (Exception)
                {
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }



        public async Task<T> GetJsonSurveyData<T>(int id) where T : new()
        {
            var uri = new Uri(WebServiceUrl + "/RestUserFeedBack" + "/" + id);

            using (var httpClient = new HttpClient())
            {
                var json_data = string.Empty;
                try
                {
                    // Now parse with JSON.Net

                    // attempt to download JSON data as a string
                    json_data = await httpClient.GetStringAsync(uri);

                    // json_data = w.DownloadString(url);

                    return JsonConvert.DeserializeObject<T>(json_data);
                }
                catch (Exception)
                {
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}