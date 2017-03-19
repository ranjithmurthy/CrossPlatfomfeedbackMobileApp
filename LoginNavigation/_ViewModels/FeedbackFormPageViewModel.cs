using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginNavigation;
using Xamarin.Forms;
using XamarinFormsBindablePicker.Model;

namespace LoginNavigation._View
{
    partial class FeedbackFormPageViewModel : ObservableObject
    {
        //  public List<QuestionItemHolder> QuestionItems = new List<QuestionItemHolder>();

        public ObservableCollection<QuestionItemHolder> QuestionHolders { get; set; } =
       new ObservableCollection<QuestionItemHolder>();

        public int UserFeedbackId;
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public string UserFeedbackText { get; set; }

        private ObservableCollection<string> pickerItems;
        public ObservableCollection<string> PickerItems
        {
            get { return pickerItems; }
            set
            {
                pickerItems = value;
                RaisePropertyChanged();
            }
        }
        
        public FeedbackFormPageViewModel(UserFeedbackViewModel _surveryDatalist)
        {
            SurveyId = _surveryDatalist.SurveyId;

            PickerItems = new ObservableCollection<string>
            {
                "Excellent", "Good","Average","Poor","Fair"
            };

            this.Description = _surveryDatalist.Description;

            foreach (UserAnswerViewModel userAnswerViewModel in _surveryDatalist.UserAnswerCollection)
            {
                QuestionHolders.Add(new QuestionItemHolder()
                {
                    QuestionID = userAnswerViewModel.UserAnswerid,
                    Question = userAnswerViewModel.Question,
                    
                });
            }

        }
    }
}