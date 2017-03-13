using System;
using System.Collections.Generic;

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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }
        public List<UserAnswerViewModel> UserAnswerCollection { get; set; }

        public string UserFeedbackText { get; set; }

        public void addQuestionsAnswer()
        {
            // UserAnswerCollection.Add();
        }
    }

    public class UserAnswerViewModel
    {
        public string UserAnswerid { get; set; }
        public string Question { get; set; }

        public string QuestionId { get; set; }
        public string AnswerText { get; set; }
        //    Answer = _answer;
        //    UserAnswerid = _question;
        //{
        //public UserAnswerViewModel( string _question, string _answer)
        //}
    }

    public class QAModel
    {
        public string UserAnswerid { get; set; }
        public string Question { get; set; }
        public string questionId { get; set; }
        public string AnswerText { get; set; }
        //      {
        //      .Select(each => new
        //      .Where(x => x.Key.Contains("QuestionDropDownlist"))

        //var QuestionDropDownlist = Request.Form.ToDictionary()
        //          key = each.Key,
        //          AnswerText = each.Value,
        //          questionId = each.Key.Split(':').LastOrDefault()
        //      }); ;
    }
}