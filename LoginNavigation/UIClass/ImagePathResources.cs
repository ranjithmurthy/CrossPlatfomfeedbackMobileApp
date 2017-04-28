using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsUI.Classes
{
    public static class ImagePathResources
    {
        //public static readonly string BackgroundImagePath =Device.OnPlatform("rainBus.jpg", "rainBus.jpg", "rainBus.jpg");

        public static readonly string BackgroundImagePath = Device.OnPlatform("rainBus.png", "rainBus.png",
            "ms-appx:///Images/rainBus.png");
        public static readonly string FeedbackBackgroundImagePath= Device.OnPlatform("Foody9.png", "Foody9.png",
           "ms-appx:///Images/Foody9.png");

        public static readonly string  colourBgCode = Device.OnPlatform("Foody9.png", "Foody9.png", "ms-appx:///Images/Foody9.png");



        public static readonly string UserNamePng = Device.OnPlatform("iconUsername.png", "iconUsername.png", "ms-appx:///Images/iconUsername.png");

        public static readonly string PasswordPng = Device.OnPlatform("iconPassword.png", "iconPassword.png", "ms-appx:///Images/iconPassword.png");


        public static readonly string FacebookPng = Device.OnPlatform("fblogin.png", "fblogin.png", "ms-appx:///Images/fblogin.png");

        //ImageURL	"ms-appx:///Images/Foody12.png"	string


    }



    public class XOnPlatform<T> : OnPlatform<T>
    {
        public T Windows { get; set; }

        public static implicit operator T(XOnPlatform<T> onPlatform)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                return onPlatform.WinPhone;
            }

            return (OnPlatform<T>)onPlatform;
        }
    }
}
