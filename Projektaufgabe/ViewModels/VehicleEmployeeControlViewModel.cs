using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;

namespace Projektaufgabe.ViewModels
{
    class VehicleEmployeeControlViewModel : ViewModelBase
    {
        public ObservableCollection<VehicleToEmployeeRelation> EmployeesOfVehicle { get; set; } =
            new ObservableCollection<VehicleToEmployeeRelation>();

        private VehicleToEmployeeRelation selectedEmployee;
        public string LicensePlate { get; set; }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }

        public VehicleToEmployeeRelation SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee = value;
                NotifyPropertyChanged();
            }
        }
    }
}
