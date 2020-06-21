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
    class CostUnitMonthControlController : SubmoduleController
    {
        private CostUnitMonthControlViewModel mViewModel;

        public override ViewModelBase Initialize()
        {
            mViewModel = new CostUnitMonthControlViewModel()
            {
                CostOfBusinessUnits = new ObservableCollection<MonthlyBusinessUnitCost>(MainWindowController.serviceClient.GetMonthlyBusinessUnitCosts())
            };
            return mViewModel;
        }
    }
}
