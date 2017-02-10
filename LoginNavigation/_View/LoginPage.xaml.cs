using LoginNavigation.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using LoginNavigation.RestClientForApp;

namespace LoginNavigation
{
	public partial class LoginPage : ContentPage
	{
        LoginUserViewModel _loginPage;
        public LoginPage ()
		{
			InitializeComponent();
            BindingContext = _loginPage= new LoginUserViewModel();
        }

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPage ());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
            using (UserClientRestService UserRest = new UserClientRestService())
            {
                var user = new User
                {
                    Username = _loginPage.UserName,
                    Password = _loginPage.Password
                };

                var isValid = UserRest.CheckUserIsCorrectOrNot(user);
                if (isValid)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    _loginPage.DisplayMessage = "Login failed";

                    _loginPage.Password = string.Empty;
                }
            }
        }

        async Task<bool> AreCredentialsCorrect(User user)
        {
            //  return user.Username == Constants.Username && user.Password == Constants.Password;

            //http://localhost:56431/api/Users/ranasdjith.murthy@gmail.com/password

            HttpClient client = new HttpClient();

           // http://localhost:56431/Account/Login?ReturnUrl=%2F

            var data = string.Format("http://localhost:56431/api/Users/" + user.Username + "/" + user.Password);

            var uri = new Uri(string.Format("http://localhost:56431/api/Users/" + user.Username + "/" + user.Password));
            HttpResponseMessage response; ;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return true;


            }
            else
            {
                return false;


            }
        }
    }
}
