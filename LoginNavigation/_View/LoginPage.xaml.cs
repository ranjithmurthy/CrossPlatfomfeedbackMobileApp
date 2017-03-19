using System;
using LoginNavigation.Model;
using LoginNavigation.ViewModels;
using Plugin.RestClient;
using ServiceLibrary;
using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginUserViewModel _loginPage;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _loginPage = new LoginUserViewModel();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            using (var userClient = new RestClient<RegisterModel>())
            {
                var model = new LoginViewModel
                {
                    Username = _loginPage.UserName,
                    Email = _loginPage.UserName,
                    Password = _loginPage.Password
                };

                if (!model.IsValid())
                    return;

                var serviceWrapper = new ServiceWrapper();

                var authenticationResult = await serviceWrapper.ValidateUser(model);

                if (authenticationResult)
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

        private async void OnLoginGuestButtonClicked(object sender, EventArgs e)
        {


            using (var userClient = new RestClient<RegisterModel>())
            {
                var model = new LoginViewModel
                {
                    Username = "Guest@Feedback.com",
                    Email = "Guest@Feedback.com",
                    Password = "$Guest007"
                };

                if (!model.IsValid())
                    return;

                var serviceWrapper = new ServiceWrapper();

                var authenticationResult = await serviceWrapper.ValidateUser(model);

                if (authenticationResult)
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