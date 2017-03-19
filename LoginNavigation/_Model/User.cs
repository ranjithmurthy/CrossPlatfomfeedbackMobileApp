using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LoginNavigation
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
    }

    public class UserFeedbackViewModel
    {
        public int UserFeedbackId;
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public string UserFeedbackText { get; set; }

        [DefaultValue("DateTime.MinValue")]
        public DateTime StartDate { get; set; }

        [DefaultValue("DateTime.MinValue")]
        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }
        public List<UserAnswerViewModel> UserAnswerCollection { get; set; }
    }


    public class DataViewModel
    {
        public int UserFeedbackId;
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public string UserFeedbackText { get; set; }
        
    }



    public class UserAnswerViewModel
    {
        public string UserAnswerid { get; set; }
        public string AnswerText { get; set; }
        public string QuestionId { get; set; }
        public string Question { get; set; }
    }

    public class QAModel
    {
        public string UserAnswerid { get; set; }
        public string Question { get; set; }
        public string questionId { get; set; }
        public string AnswerText { get; set; }

        //var QuestionDropDownlist = Request.Form.ToDictionary()
        //      .Where(x => x.Key.Contains("QuestionDropDownlist"))
        //      .Select(each => new
        //      {
        //          key = each.Key,
        //          AnswerText = each.Value,
        //          questionId = each.Key.Split(':').LastOrDefault()
        //      }); ;
    }
}