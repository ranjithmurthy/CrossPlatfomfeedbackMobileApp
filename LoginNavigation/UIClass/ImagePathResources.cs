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
        public static readonly string BackgroundImagePath =Device.OnPlatform("rainBus.jpg", "rainBus.jpg", "rainBus.jpg"); 
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
