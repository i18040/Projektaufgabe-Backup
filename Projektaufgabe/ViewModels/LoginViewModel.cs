using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projektaufgabe.Framework;

namespace Projektaufgabe.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string error;

        public ICommand LoginCommand { get; set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get => error;
            set
            {
                error = value;
                NotifyPropertyChanged();
            }
        }
    }
}
