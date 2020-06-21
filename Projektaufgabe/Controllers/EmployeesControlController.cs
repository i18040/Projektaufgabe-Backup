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
            if(mViewModel.Firstname != null && mViewModel.Lastname != null && mViewModel.SelectedUnit != null)
            {
                MainWindowController.serviceClient.UpdateEmployee(mViewModel.Firstname, mViewModel.Lastname,
                    mViewModel.SelectedEmployee.EmployeeNumber, mViewModel.EmployeeNumber, mViewModel.Salutation,
                    mViewModel.Title, mViewModel.SelectedUnit.Id);
                mViewModel.SelectedEmployee.Firstname = mViewModel.Firstname;
                mViewModel.SelectedEmployee.Lastname = mViewModel.Lastname;
                mViewModel.SelectedEmployee.EmployeeNumber = mViewModel.EmployeeNumber;
                mViewModel.SelectedEmployee.Salutation = mViewModel.Salutation;
                mViewModel.SelectedEmployee.Title = mViewModel.Title;
                mViewModel.SelectedEmployee.BusinessUnitId = mViewModel.SelectedUnit.Id;
            }
        }

        public void New()
        {
            if (mViewModel.Firstname != null && mViewModel.Lastname != null && mViewModel.SelectedUnit != null)
            {
                var employee = MainWindowController.serviceClient.NewEmployee(mViewModel.Firstname, mViewModel.Lastname, mViewModel.EmployeeNumber, mViewModel.Salutation, mViewModel.Title, mViewModel.SelectedUnit.Id);
            mViewModel.Employees.Add(employee);
            }
        }

        public void Delete()
        {
            if (mViewModel.SelectedEmployee != null)
            {
                MainWindowController.serviceClient.DeleteEmployee(mViewModel.SelectedEmployee.EmployeeNumber);
            }
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
