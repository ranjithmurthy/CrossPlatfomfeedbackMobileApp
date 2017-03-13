using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoginNavigation._ViewModels
{
    internal class RegisterUserviewModel : INotifyPropertyChanged
    {
        private string _ConfirmPassword;
        private string _DisplayMessage;
        private string _Password;
        private string _UserName;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }

            set
            {
                _ConfirmPassword = value;

                OnPropertyChanged(nameof(Password));
                if (Password != _ConfirmPassword)
                    _DisplayMessage = "Password not Match";
                else
                    _DisplayMessage = "";
            }
        }

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