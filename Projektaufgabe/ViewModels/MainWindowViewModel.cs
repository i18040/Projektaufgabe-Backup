using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Projektaufgabe.Framework;

namespace Projektaufgabe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand NewItemCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand CostMonthCommand { get; set; }
        public ICommand CostUnitCommand { get; set; }
        public ICommand VehiclesCommand { get; set; }
        public ICommand EmployeesCommand { get; set; }
        public ICommand UnitsCommand { get; set; }
        public ICommand UsersCommand { get; set; }

        private ViewModelBase mActiveViewModel;

        private Brush startCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush startCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
        private Brush costMonthCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush costMonthCurrentBackColor = new SolidColorBrush(Colors.White);
        private Brush costBusinessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush costBusinessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
        private Brush vehiclesCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush vehiclesCurrentBackColor = new SolidColorBrush(Colors.White);
        private Brush employeeCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush employeeCurrentBackColor = new SolidColorBrush(Colors.White);
        private Brush businessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush businessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
        private Brush userCurrentForeColor = new SolidColorBrush(Colors.Black);
        private Brush userCurrentBackColor = new SolidColorBrush(Colors.White);
        private Visibility visibility;
        private bool buttonsEnabled;

        public ViewModelBase ActiveViewModel
        {
            get => mActiveViewModel;
            set
            {
                if (mActiveViewModel == value) return;
                mActiveViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public Brush StartCurrentForeColor
        {
            get => startCurrentForeColor;
            set
            {
                startCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush StartCurrentBackColor
        {
            get => startCurrentBackColor;
            set
            {
                startCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush CostMonthCurrentForeColor
        {
            get => costMonthCurrentForeColor;
            set
            {
                costMonthCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush CostMonthCurrentBackColor
        {
            get => costMonthCurrentBackColor;
            set
            {
                costMonthCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush CostBusinessUnitCurrentForeColor
        {
            get => costBusinessUnitCurrentForeColor;
            set
            {
                costBusinessUnitCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush CostBusinessUnitCurrentBackColor
        {
            get => costBusinessUnitCurrentBackColor;
            set
            {
                costBusinessUnitCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush VehiclesCurrentForeColor
        {
            get => vehiclesCurrentForeColor;
            set
            {
                vehiclesCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush VehiclesCurrentBackColor
        {
            get => vehiclesCurrentBackColor;
            set
            {
                vehiclesCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush EmployeeCurrentForeColor
        {
            get => employeeCurrentForeColor;
            set
            {
                employeeCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush EmployeeCurrentBackColor
        {
            get => employeeCurrentBackColor;
            set
            {
                employeeCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush BusinessUnitCurrentForeColor
        {
            get => businessUnitCurrentForeColor;
            set
            {
                businessUnitCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush BusinessUnitCurrentBackColor
        {
            get => businessUnitCurrentBackColor;
            set
            {
                businessUnitCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush UserCurrentForeColor
        {
            get => userCurrentForeColor;
            set
            {
                userCurrentForeColor = value;
                NotifyPropertyChanged();
            }
        }
        public Brush UserCurrentBackColor
        {
            get => userCurrentBackColor;
            set
            {
                userCurrentBackColor = value;
                NotifyPropertyChanged();
            }
        }
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                NotifyPropertyChanged();
            }
        }

        public bool ButtonsEnabled
        {
            get => buttonsEnabled;
            set
            {
                buttonsEnabled = value;
                NotifyPropertyChanged();
            }
        }
    }
}
