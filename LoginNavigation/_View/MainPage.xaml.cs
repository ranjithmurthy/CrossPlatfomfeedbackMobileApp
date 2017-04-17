using System;
using System.Collections.Generic;
using LoginNavigation._View;
using LoginNavigation._ViewModels;
using Newtonsoft.Json;
using ServiceLibrary;
using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        private async void OnShowSurveyButtonClicked(object sender, EventArgs e)
        {
           // LabelSurvey.Text = "List of Events";

            var serviceWrapper = new ServiceWrapper();

            List<SurveryData> surveryDatalist = await serviceWrapper.GetJsonData<List<SurveryData>>();

            listRecipies.ItemsSource = surveryDatalist;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            // Them cast the object SENDER to your Datasource Object, my case House

            try
            {
                var mySelected = sender as ListView;

                var mySelectedSurvey = (SurveryData) mySelected.SelectedItem;

                var serviceWrapper = new ServiceWrapper();

                var surveryDatalist =await serviceWrapper.GetJsonSurveyData<UserFeedbackViewModel>(mySelectedSurvey.SurveyId);

                // new NavigationPage(new LoginPage());

               // string json_data = Newtonsoft.Json.JsonConvert.SerializeObject(surveryDatalist);

                // json_data = w.DownloadString(url);

                //var surveryObject = JsonConvert.DeserializeObject<UserFeedbackViewModel>(json_data); 

                await Navigation.PushAsync(new FeedbackFormPage(surveryDatalist));
            }
            catch (Exception exception)
            {
            }
        }
    }
}