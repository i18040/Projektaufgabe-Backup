using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;

namespace Projektaufgabe.ViewModels
{
    class UsersControlViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        private User selectedUser;
        private string userInfo;
        private string firstname;
        private string lastname;
        private string username;
        private bool isadmin;

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                if (selectedUser == value) return;
                selectedUser = value;
                UserInfo = selectedUser.Username + " (" + selectedUser.Firstname + " " + selectedUser.Lastname + ") ";
                NotifyPropertyChanged();
            }
        }

        public string UserInfo
        {
            get => userInfo;
            set
            {
                if (userInfo == value) return;
                userInfo = value;
                NotifyPropertyChanged();
            }
        }

        public string Firstname
        {
            get => firstname;
            set
            {
                if (firstname == value) return;
                firstname = value;
                NotifyPropertyChanged();
            }
        }

        public string Lastname
        {
            get => lastname;
            set
            {
                if (lastname == value) return;
                lastname = value;
                NotifyPropertyChanged();
            }
        }

        public string Username
        {
            get => username;
            set
            {
                if (username == value) return;
                username = value;
                NotifyPropertyChanged();
            }
        }

        public bool isAdmin
        {
            get => isadmin;
            set
            {
                if (isadmin == value) return;
                isadmin = value;
                NotifyPropertyChanged();
            }
        }
    }
}
