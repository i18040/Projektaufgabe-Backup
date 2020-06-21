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
    class VehiclesControlViewModel : ViewModelBase
    {
        public ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();
        private Vehicle selectedVehicle;
        private ViewModelBase mActiveViewModel;
        private int selectedIndex;
        private string licensePlate;
        private string brand;
        private string model;
        private bool buttonsEnabled;

        public bool ButtonsEnabled
        {
            get => buttonsEnabled;
            set
            {
                buttonsEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                if (selectedVehicle == value) return;
                selectedVehicle = value;
                NotifyPropertyChanged();
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (selectedIndex == value) return;
                selectedIndex = value;
                ButtonsEnabled = value == 0;
                NotifyPropertyChanged();
            }
        }

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

        public string LicensePlate
        {
            get => licensePlate;
            set
            {
                if (licensePlate == value) return;
                licensePlate = value;
                NotifyPropertyChanged();
            }
        }

        public string Brand
        {
            get => brand;
            set
            {
                if (brand == value) return;
                brand = value;
                NotifyPropertyChanged();
            }
        }

        public string Model
        {
            get => model;
            set
            {
                if (model == value) return;
                model = value;
                NotifyPropertyChanged();
            }
        }
    }
}
