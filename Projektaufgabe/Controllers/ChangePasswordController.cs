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
    class ChangePasswordController
    {
        private ChangePasswordWindow mView;
        private ChangePasswordViewModel mViewModel;

        public void ExecuteConfirmCommand(object obj)
        {
            if (mViewModel.NewPassword != mViewModel.Password)
            {
                if (mViewModel.NewPassword == mViewModel.NewPasswordCheck)
                {
                    mView.DialogResult = true;
                    mView.Close();
                }
                else
                    mViewModel.Error = "Die eingegebenen Passwörter stimmen nicht überein!";
            }
            else
            {
                mViewModel.Error = "Das neue Password, darf nicht das gleiche wie das alte sein!";
            }
            
        }

        public bool ConfirmChangePassword(User currentUser)
        {
            mViewModel = new ChangePasswordViewModel()
            {
                ConfirmCommand = new RelayCommand(ExecuteConfirmCommand)
            };
            mView = new ChangePasswordWindow { DataContext = mViewModel };
            var result = mView.ShowDialog();
            if (result == true)
            {
                MainWindowController.serviceClient.ChangePassword(currentUser.Username, mViewModel.Password,
                    mViewModel.NewPassword);
                return true;
            }
            return false;
        }
    }
}
