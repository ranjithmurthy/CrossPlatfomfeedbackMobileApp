using LoginNavigation.RestClientForApp;
using System;
using System.Linq;
using Xamarin.Forms;
using LoginNavigation.Model;
using LoginNavigation._ViewModels;

namespace LoginNavigation
{
    public partial class SignUpPage : ContentPage
    {
        RegisterUserviewModel _SignUpPage;



        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = _SignUpPage = new RegisterUserviewModel();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            RegisterModel userDetails = new RegisterModel()
            {
                FirstName = _SignUpPage.FirstName,
                LastName = _SignUpPage.LastName,
                Email = _SignUpPage.UserName,
                Password = _SignUpPage.Password,
                ConfirmPassword = _SignUpPage.ConfirmPassword,

            };

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(userDetails);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                _SignUpPage.DisplayMessage = "Sign up failed";
            }
        }

        bool AreDetailsValid(RegisterModel userDetails)
        {

            using (UserClientRestService UserRest = new UserClientRestService())
            {

                var status = UserRest.SignUpForUser(userDetails);

                return status.Result;
            }

        }
    }
}
