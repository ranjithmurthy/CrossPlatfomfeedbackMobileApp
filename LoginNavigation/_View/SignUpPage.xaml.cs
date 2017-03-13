using System;
using LoginNavigation.Model;
using LoginNavigation._ViewModels;
using ServiceLibrary;
using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class SignUpPage : ContentPage
    {
        private readonly RegisterUserviewModel _SignUpPage;

        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = _SignUpPage = new RegisterUserviewModel();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var userDetails = new RegisterModel
            {
                FirstName = _SignUpPage.FirstName,
                LastName = _SignUpPage.LastName,
                Email = _SignUpPage.UserName,
                Password = _SignUpPage.Password,
                ConfirmPassword = _SignUpPage.ConfirmPassword
            };

            if (!userDetails.IsValid())
            {
                _SignUpPage.DisplayMessage = "please fill in your details";
                //lblRegisterFormFeedback.TextColor = UIColor.Red;
                return;
            }

            if (userDetails.ConfirmPassword == userDetails.Password)
            {
                var model = new LoginViewModel
                {
                    Email = userDetails.Email,
                    Password = userDetails.Password,
                    Username = userDetails.FirstName
                };

                var serviceWrapper = new ServiceWrapper();

                var authenticationResult = await serviceWrapper.RegisterUser(model);

                _SignUpPage.DisplayMessage = authenticationResult;
            }
            else
            {
                _SignUpPage.DisplayMessage = "CheckData";
            }
        }

        //        using (UserClientRestService UserRest = new UserClientRestService())
        //{
        //    bool AreDetailsValid(RegisterModel userDetails)
        //        {
        //            var status = UserRest.SignUpForUser(userDetails);

        //            return status.Result;
        //        }

        //    }
    }
}