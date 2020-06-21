using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projektaufgabe.Framework;

namespace Projektaufgabe.ViewModels
{
    class ConfirmRemovalViewModel : ViewModelBase
    {
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
