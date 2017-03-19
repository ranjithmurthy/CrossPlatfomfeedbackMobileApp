using LoginNavigation._View;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LoginNavigation
{
    public class App : Application
    {
        public App()
        {
            if (!IsUserLoggedIn)
            {
//               

                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new MainPage();
            }

            // MainPage = new MainPage();
        }

        public static bool IsUserLoggedIn { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}