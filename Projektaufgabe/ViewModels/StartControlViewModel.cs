using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;

namespace Projektaufgabe.ViewModels
{
    class StartControlViewModel : ViewModelBase
    {
        public ICommand ChangePasswordCommand { get; set; }
    }
}
