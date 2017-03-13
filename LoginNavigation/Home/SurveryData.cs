using System;

namespace LoginNavigation.Home
{
    public  class SurveryData
    {
        

        public int SurveyId { get; set; }
        public string Description { get; set; }

        public DateTime StartDate
        {
            get;
            set;
        }
       public DateTime EndDate { get; set; }

        public Boolean IsOpen { get; set; }
    }
}