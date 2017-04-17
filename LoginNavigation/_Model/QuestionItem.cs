using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LoginNavigation._View
{
    public class QuestionItemHolder
    {
        public string Question { get; set; }

        public string QuestionID { get; set; }

        public string AnswerText { get; set; }

        public override string ToString()
        {
            return Question;
        }

        public string ImageURL
        {
            get
            {
                Random rnd = new Random();
                int index = rnd.Next(1, 10);
                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    return "Images/" + _listofimages[index];
                }
                else
                {
                    return _listofimages[index];
                }
            }

        }

        private List<string> _listofimages = new List<string>()
        {
         "Foody1.png",
         "Foody2.png",
         "Foody3.png",
         "Foody4.png",
         "Foody5.png",
         "Foody6.png",
         "Foody7.png",
         "Foody8.png",
         "Foody9.png",
         "Foody10.png",
         "Foody11.png",
         "Foody12.png",
         "Foody13.png"
        };
    }
}