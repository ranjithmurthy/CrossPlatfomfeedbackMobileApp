using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GroupingSampleListView;
using LoginNavigation.Home;
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

      
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void onShowSurveyButtonClicked(object sender, EventArgs e)
        {
            var serviceWrapper = new ServiceWrapper();
            var surveryDatalist = await serviceWrapper.GetJsonData<List<SurveryData>>();



            listView.ItemsSource = surveryDatalist;
        }
    }
}
