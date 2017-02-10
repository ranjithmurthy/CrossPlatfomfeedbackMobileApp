using LoginNavigation.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using LoginNavigation.RestClientForApp;
using Plugin.RestClient;
using LoginNavigation.Model;

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
            using (RestClient<RegisterModel> userClient = new RestClient<RegisterModel>())
            {
                var user = new User
                {
                    Username = _loginPage.UserName,
                    Password = _loginPage.Password
                };

                var isValid = await userClient.GetCheckUserIsCorrectOrNot(user);
                if (isValid.IsSuccessStatusCode)
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

       
    }
}
