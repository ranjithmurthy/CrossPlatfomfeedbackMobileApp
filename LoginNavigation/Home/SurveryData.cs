using System;

namespace LoginNavigation._ViewModels
{
    public class SurveryData
    {
        public int SurveyId { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }
    }
}