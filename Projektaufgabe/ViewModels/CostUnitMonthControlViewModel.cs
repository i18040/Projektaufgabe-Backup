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
    class CostUnitMonthControlViewModel : ViewModelBase
    {
        public ObservableCollection<MonthlyBusinessUnitCost> CostOfBusinessUnits { get; set; } = new ObservableCollection<MonthlyBusinessUnitCost>();
    }
}
