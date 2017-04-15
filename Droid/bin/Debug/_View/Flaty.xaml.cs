using System;
using LoginNavigation.Model;
using LoginNavigation.ViewModels;
using Plugin.RestClient;
using ServiceLibrary;
using Xamarin.Forms;

namespace LoginNavigation
{
    
    public partial class Flaty : ContentPage
    {
        public Flaty()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var t = ex.Message; 
            }           
        }
    }
}
