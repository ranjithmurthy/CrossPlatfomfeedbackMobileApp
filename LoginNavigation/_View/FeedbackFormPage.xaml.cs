using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceLibrary;
using Xamarin.Forms;

namespace LoginNavigation._View
{



    public partial class FeedbackFormPage : ContentPage
    {
        private readonly FeedbackFormPageViewModel _FeedbackFormPage;
        public UserFeedbackViewModel surveryDatalist;

        public FeedbackFormPage(UserFeedbackViewModel surveryDatalist)
        {
            InitializeComponent();
            BindingContext = _FeedbackFormPage = new FeedbackFormPageViewModel(surveryDatalist);
        }

        public FeedbackFormPage()
        {
            UserFeedbackViewModel surveryDatalist= new UserFeedbackViewModel();
            InitializeComponent();
            BindingContext = _FeedbackFormPage = new FeedbackFormPageViewModel(surveryDatalist);
        }

        private async void OnSubmitButtonClickedAsync(object sender, EventArgs e)
        {
            var questionsAnswer = new List<UserAnswerViewModel>();

            foreach (var questionItemHolder in _FeedbackFormPage.QuestionHolders)
                questionsAnswer.Add(new UserAnswerViewModel
                {
                    Question = questionItemHolder.Question,
                    QuestionId = questionItemHolder.QuestionID,
                    AnswerText = questionItemHolder.AnswerText,
                    UserAnswerid = questionItemHolder.QuestionID
                });

            var serFeedbackModel = new UserFeedbackViewModel
            {
                SurveyId = _FeedbackFormPage.SurveyId,
                Description = _FeedbackFormPage.Description,
                UserAnswerCollection = questionsAnswer,
                EndDate = DateTime.Today,
                StartDate = DateTime.Today,
                IsOpen = true,
                UserFeedbackId = _FeedbackFormPage.UserFeedbackId,
                UserFeedbackText = _FeedbackFormPage.UserFeedbackText
            };

            var surveryObject = JsonConvert.SerializeObject(serFeedbackModel);


            var serviceWrapper = new ServiceWrapper();

            var feedBackSuccessStatus = await serviceWrapper.SubmitUserFeedback(serFeedbackModel);


            if (feedBackSuccessStatus)
            {

                Navigation.PushAsync(new ThanksContent()); 
            }
           
        }

       

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}