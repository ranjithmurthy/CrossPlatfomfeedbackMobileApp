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
    }
}