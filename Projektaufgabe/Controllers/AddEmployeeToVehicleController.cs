using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektaufgabe.Framework;
using Projektaufgabe.Views;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;

namespace Projektaufgabe.Controllers
{
    class AddEmployeeToVehicleController
    {
        private AddEmployeeToVehicleWindow mView;
        private AddEmployeeToVehicleViewModel mViewModel;
        public void ExecuteOkCommand(object obj)
        {
            if(mViewModel.SelectedEmployee != null)
            {
                mView.DialogResult = true;
                mView.Close();
            }
        }

        public void ExecuteCancelCommand(object obj)
        {
            mView.DialogResult = false;
            mView.Close();
        }

        public VehicleToEmployeeRelation AddEmployee(string LicensePlate)
        {
            mViewModel = new AddEmployeeToVehicleViewModel()
            {
                OkCommand = new RelayCommand(ExecuteOkCommand),
                CancelCommand = new RelayCommand(ExecuteCancelCommand)
            };
            mView = new AddEmployeeToVehicleWindow();
            mViewModel.AvailableEmployees = new ObservableCollection<Employee>(MainWindowController.serviceClient.GetEmployeesForNewVehicleRelation(LicensePlate));
            mView.DataContext = mViewModel;
            var result = mView.ShowDialog();
            if (result == true)
            {
                return MainWindowController.serviceClient.NewVehicle2EmployeeRelation(mViewModel.StartDate, mViewModel.EndDate,
                    LicensePlate, mViewModel.SelectedEmployee.EmployeeNumber);
            }
            return null;
        }
    }
}
