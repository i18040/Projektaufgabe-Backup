using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;

namespace Projektaufgabe.Controllers
{
    class ConfirmRemovalController
    {
        private Window1 mView;

        public void ExecuteOkCommand(object obj)
        {
            mView.DialogResult = true;
            mView.Close();
        }

        public void ExecuteCancelCommand(object obj)
        {
            mView.DialogResult = false;
            mView.Close();
        }

        public bool ConfirmDelete()
        {
            var mViewModel = new ConfirmRemovalViewModel()
            {
                OkCommand = new RelayCommand(ExecuteOkCommand),
                CancelCommand = new RelayCommand(ExecuteCancelCommand)
            };
            mView = new Window1 { DataContext = mViewModel };
            var result = mView.ShowDialog();
            if (result == true) return true;
            return false;
        }
    }
}
