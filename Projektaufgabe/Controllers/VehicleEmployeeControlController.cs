using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;

namespace Projektaufgabe.Controllers
{
    class VehicleEmployeeControlController : SubmoduleController
    {
        private VehicleEmployeeControlViewModel mViewModel;
        public string LicensePlate { get; set; }
        public void ExecuteAddEmployeeCommand(object obj)
        {
            var mAddEmployeeWindow = new AddEmployeeToVehicleController();
            var result = mAddEmployeeWindow.AddEmployee(mViewModel.LicensePlate);
            if (result != null)
            {
                mViewModel.EmployeesOfVehicle.Add(result);
            }
        }
        public void ExecuteRemoveEmployeeCommand(object obj)
        {
            var mRemEmployeeWindow = new ConfirmRemovalController();
            var result = mRemEmployeeWindow.ConfirmDelete();
            if (result)
            {
                MainWindowController.serviceClient.DeleteVehicle2EmployeeRelation(mViewModel.LicensePlate,
                    mViewModel.SelectedEmployee.EmployeeId);
            }
        }
        public bool CanExecuteRemoveEmployeeCommand(object obj)
        {
            return mViewModel.SelectedEmployee != null;
        }

        public override ViewModelBase Initialize()
        {
            mViewModel = new VehicleEmployeeControlViewModel()
            {
                EmployeesOfVehicle = new ObservableCollection<VehicleToEmployeeRelation>(MainWindowController.serviceClient.GetEmployeesForVehicleTab(LicensePlate)),
                AddEmployeeCommand = new RelayCommand(ExecuteAddEmployeeCommand),
                RemoveEmployeeCommand = new RelayCommand(ExecuteRemoveEmployeeCommand, CanExecuteRemoveEmployeeCommand)
            };
            return mViewModel;
        }
    }
}
