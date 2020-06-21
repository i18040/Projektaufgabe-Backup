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
    class VehicleGeneralControlViewModel : ViewModelBase
    {
        private string licensePlate;
        private string brand;
        private string model;
        private decimal insurance;
        private DateTime currentDate;
        private DateTime leasingFrom;
        private DateTime leasingTo;
        private decimal leasingRate;


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

        public decimal Insurance
        {
            get => insurance;
            set
            {
                if (insurance == value) return;
                insurance = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (currentDate == value) return;
                currentDate = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime LeasingFrom
        {
            get => leasingFrom;
            set
            {
                if (leasingFrom == value) return;
                leasingFrom = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime LeasingTo
        {
            get => leasingTo;
            set
            {
                if (leasingTo == value) return;
                leasingTo = value;
                NotifyPropertyChanged();
            }
        }

        public decimal LeasingRate
        {
            get => leasingRate;
            set
            {
                if (leasingRate == value) return;
                leasingRate = value;
                NotifyPropertyChanged();
            }
        }
    }
}
