using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;

namespace Projektaufgabe.Controllers
{
    class StartControlController : SubmoduleController
    {
        private StartControlViewModel mViewModel;
        public User CurrentUser { get; set; }

        public void ExecuteChangePasswordCommand(object obj)
        {
            var mChangePasswordWindow = new ChangePasswordController();
            var result = mChangePasswordWindow.ConfirmChangePassword(CurrentUser);
        }

        public override ViewModelBase Initialize()
        {
            mViewModel = new StartControlViewModel()
            {
                ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand)
            };
            return mViewModel;
        }
    }
}
