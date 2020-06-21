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

        }

        public void New()
        {

        }

        public void Delete()
        {

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
