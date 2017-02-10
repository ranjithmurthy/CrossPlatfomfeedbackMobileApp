using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation._ViewModels
{
    class RegisterUserviewModel : INotifyPropertyChanged
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }

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
        private string _UserName;
        private string _Password;
        private string _DisplayMessage;
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {

                _UserName = value;
                OnPropertyChanged(nameof(UserName));
                //OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

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

        public RegisterUserviewModel()
        {

        }




        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
