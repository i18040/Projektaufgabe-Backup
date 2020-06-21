using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;

namespace Projektaufgabe.Controllers
{
    class CostMonthControlController : SubmoduleController
    {
        private CostMonthControlViewModel mViewModel;

        public override ViewModelBase Initialize()
        {
            mViewModel = new CostMonthControlViewModel()
            {
                CostPerMonth = new ObservableCollection<MonthlyCost>(MainWindowController.serviceClient.GetMonthlyCosts())
            };
            return mViewModel;
        }
    }
}
