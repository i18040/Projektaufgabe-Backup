using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;

namespace Projektaufgabe.Controllers
{
    class LoginController
    {
        private LoginViewModel mViewModel;
        private ServiceClient serviceClient;
        private LoginWindow mView;
        public User CurrentUser { get; set; }
        public void ExecuteLoginCommand(object obj)
        {
            CurrentUser = serviceClient.LoginUser(mViewModel.Username, mViewModel.Password);
            if (CurrentUser != null)
            {
                mView.CurrentUser = CurrentUser;
                mView.DialogResult = true;
                mView.Close();
            }
            else
            {
                mViewModel.Error = "Der Benutzername oder das eingegebene Passwort sind nicht korrekt!";
            }
        }

        public bool Initialize()
        {
            serviceClient = new ServiceClient();
            Console.WriteLine("amina");
            mViewModel = new LoginViewModel()
            {
                LoginCommand = new RelayCommand(ExecuteLoginCommand)
            };
            mView = new LoginWindow { DataContext = mViewModel };
            var result = mView.ShowDialog();
            if (result == true) return true;
            return false;
        }
    }
}
