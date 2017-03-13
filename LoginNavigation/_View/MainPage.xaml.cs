using System;
using System.Collections.Generic;
using LoginNavigation._ViewModels;
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
            var serviceWrapper = new ServiceWrapper();
            var surveryDatalist = await serviceWrapper.GetJsonData<List<SurveryData>>();

            listView.ItemsSource = surveryDatalist;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            // Them cast the object SENDER to your Datasource Object, my case House

            try
            {
                var mySelected = sender as ListView;

                var mySelectedSurvey = (SurveryData) mySelected.SelectedItem;

                var serviceWrapper = new ServiceWrapper();

                var surveryDatalist =
                    await serviceWrapper.GetJsonSurveyData<UserFeedbackViewModel>(mySelectedSurvey.SurveyId);
            }
            catch (Exception exception)
            {
            }
        }
    }
}