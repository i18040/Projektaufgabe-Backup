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
    class EmployeesControlViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public ObservableCollection<BusinessUnit> BusinessUnits { get; set; } = new ObservableCollection<BusinessUnit>();
        private Employee selectedEmployee;
        private BusinessUnit selectedUnit;
        private string employeeInfo;
        private string firstname;
        private string lastname;
        private string title;
        private string employeeNumber;
        private string salutation;

        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee = value;
                employeeInfo = value.Firstname + " " + value.Lastname + " (" + value.EmployeeNumber + ")";
                NotifyPropertyChanged();
            }
        }

        public BusinessUnit SelectedUnit
        {
            get => selectedUnit;
            set
            {
                if (selectedUnit == value) return;
                selectedUnit = value;

                NotifyPropertyChanged();
            }
        }

        public string EmployeeInfo
        {
            get => employeeInfo;
            set
            {
                if (employeeInfo == value) return;
                employeeInfo = value;
                NotifyPropertyChanged();
            }
        }

        public string Firstname
        {
            get => firstname;
            set
            {
                if (firstname == value) return;
                firstname = value;
                NotifyPropertyChanged();
            }
        }

        public string Lastname
        {
            get => lastname;
            set
            {
                if (lastname == value) return;
                lastname = value;
                NotifyPropertyChanged();
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (title == value) return;
                title = value;
                NotifyPropertyChanged();
            }
        }

        public string EmployeeNumber
        {
            get => employeeNumber;
            set
            {
                if (employeeNumber == value) return;
                employeeNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string Salutation
        {
            get => salutation;
            set
            {
                if (salutation == value) return;
                salutation = value;
                NotifyPropertyChanged();
            }
        }
    }
}
