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
    class EmployeesControlController : SubmoduleController
    {
        private EmployeesControlViewModel mViewModel;

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
            mViewModel = new EmployeesControlViewModel()
            {
                Employees = new ObservableCollection<Employee>(MainWindowController.serviceClient.GetEmployees()),
                BusinessUnits = new ObservableCollection<BusinessUnit>(MainWindowController.serviceClient.GetBusinessUnits())
            };
            return mViewModel;
        }
    }
}
