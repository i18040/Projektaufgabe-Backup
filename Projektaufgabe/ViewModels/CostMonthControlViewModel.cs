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
    class CostMonthControlViewModel : ViewModelBase
    {
        public ObservableCollection<MonthlyCost> CostPerMonth { get; set; } = new ObservableCollection<MonthlyCost>();
    }
}
