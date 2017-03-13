using LoginNavigation.RestClientForApp;
using System;
using System.Linq;
using Xamarin.Forms;
using LoginNavigation.Model;
using LoginNavigation._ViewModels;
using Plugin.RestClient;
using ServiceLibrary;

namespace LoginNavigation
{
    public partial class SignUpPage : ContentPage
    {
        private RegisterUserviewModel _SignUpPage;

        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = _SignUpPage = new RegisterUserviewModel();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            RegisterModel userDetails = new RegisterModel()
            {
                FirstName = _SignUpPage.FirstName,
                LastName = _SignUpPage.LastName,
                Email = _SignUpPage.UserName,
                Password = _SignUpPage.Password,
                ConfirmPassword = _SignUpPage.ConfirmPassword,
            };

            if (!userDetails.IsValid())
            {
                _SignUpPage.DisplayMessage = "please fill in your details";
                //lblRegisterFormFeedback.TextColor = UIColor.Red;
                return;
            }

            if (userDetails.ConfirmPassword == userDetails.Password)
            {
                LoginViewModel model = new LoginViewModel()
                {
                    Email = userDetails.Email,
                    Password = userDetails.Password,
                    Username = userDetails.FirstName,
                };

                ServiceWrapper serviceWrapper = new ServiceWrapper();

                string authenticationResult = await serviceWrapper.RegisterUser(model);

                _SignUpPage.DisplayMessage = authenticationResult;

               
            }
            else
            {
                _SignUpPage.DisplayMessage = "CheckData";
            }
        }

        //    bool AreDetailsValid(RegisterModel userDetails)
        //{
        //        using (UserClientRestService UserRest = new UserClientRestService())
        //        {
        //            var status = UserRest.SignUpForUser(userDetails);

        //            return status.Result;
        //        }

        //    }
    }
}