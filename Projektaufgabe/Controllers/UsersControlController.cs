using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;
using Projektaufgabe.ServiceReference1;

namespace Projektaufgabe.Controllers
{
    class UsersControlController : SubmoduleController
    {
        private UsersControlViewModel mViewModel;

        public void Save()
        {
            if (mViewModel.SelectedUser != null)
            {
                MainWindowController.serviceClient.UpdateUser(mViewModel.SelectedUser.Username, mViewModel.Username,
                    mViewModel.Firstname, mViewModel.Lastname, mViewModel.isAdmin);
                mViewModel.SelectedUser.Username = mViewModel.Username;
                mViewModel.SelectedUser.Firstname = mViewModel.Firstname;
                mViewModel.SelectedUser.Lastname = mViewModel.Lastname;
                mViewModel.SelectedUser.isAdmin = mViewModel.isAdmin;
            }
        }

        public void New()
        {
            var unit = MainWindowController.serviceClient.NewUser(mViewModel.Username, mViewModel.Firstname, mViewModel.Lastname, mViewModel.isAdmin);
            if (unit != null)
                mViewModel.Users.Add(unit);
        }

        public void Delete()
        {
            if (mViewModel.SelectedUser != null)
            {
                MainWindowController.serviceClient.DeleteUser(mViewModel.SelectedUser.Username);
                mViewModel.Users.Remove(mViewModel.SelectedUser);
            }
        }
        public override ViewModelBase Initialize()
        {
            mViewModel = new UsersControlViewModel()
            {
                Users = new ObservableCollection<User>(MainWindowController.serviceClient.GetUsers())
            };
            return mViewModel;
        }
    }
}
