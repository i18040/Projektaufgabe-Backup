using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Projektaufgabe.Framework;

namespace Projektaufgabe.ViewModels
{
    class ChangePasswordViewModel : ViewModelBase
    {
        private string password;
        private string newPassword;
        private string newPasswordCheck;
        private string error = "";

        public ICommand ConfirmCommand { get; set; }

        public string Password
        {
            get => password;
            set
            {
                if(password == value) return;
                password = value;
                NotifyPropertyChanged();
            }
        }

        public string NewPassword
        {
            get => newPassword;
            set
            {
                if (newPassword == value) return;
                newPassword = value;
                NotifyPropertyChanged();
            }
        }

        public string NewPasswordCheck
        {
            get => newPasswordCheck;
            set
            {
                if (newPasswordCheck == value) return;
                newPasswordCheck = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get => error;
            set
            {
                if (error == value) return;
                error = value;
                NotifyPropertyChanged();
            }
        }
    }
}
