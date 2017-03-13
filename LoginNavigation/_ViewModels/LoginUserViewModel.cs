using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoginNavigation.ViewModels
{
    internal class LoginUserViewModel : INotifyPropertyChanged
    {
        private string _DisplayMessage;
        private string _Password;
        private string _UserName;

        // public Command LoginCommand { get; }
        //public Command SignUpCommand { get; }

        public string UserName
        {
            get { return _UserName; }

            set
            {
                _UserName = value;
                OnPropertyChanged(nameof(UserName));
                //OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Password
        {
            get { return _Password; }

            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string DisplayMessage
        {
            get { return _DisplayMessage; }
            set
            {
                _DisplayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
                //OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}