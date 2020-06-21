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
    class AddEmployeeToVehicleViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> AvailableEmployees { get; set; } = new ObservableCollection<Employee>();
        private Employee selectedEmployee;
        public DateTime CurrentDate { get; set; } = DateTime.Now;
        private DateTime startDate;
        private DateTime endDate;

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate == value) return;
                startDate = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate == value) return;
                endDate = value;
                NotifyPropertyChanged();
            }
        }
    }
}
