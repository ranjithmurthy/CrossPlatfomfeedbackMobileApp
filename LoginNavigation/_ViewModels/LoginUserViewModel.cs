using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginNavigation.ViewModels
{
    class LoginUserViewModel:INotifyPropertyChanged
    {
        private string _UserName;
        private string _Password;
        private string _DisplayMessage;
        public string UserName
        {
            get {
                return _UserName;
            }

            set {

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

       // public Command LoginCommand { get; }
        //public Command SignUpCommand { get; }
        public LoginUserViewModel()
        {
           // LoginCommand= new Command()
           //     SignUpCommand
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
