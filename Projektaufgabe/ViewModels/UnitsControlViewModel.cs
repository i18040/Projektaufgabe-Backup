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
    class UnitsControlViewModel : ViewModelBase
    {
        public ObservableCollection<BusinessUnit> BusinessUnits { get; set; } = new ObservableCollection<BusinessUnit>();
        private BusinessUnit selectedUnit;
        private string unitInfo;
        private string name;
        private string description;

        public BusinessUnit SelectedUnit
        {
            get => selectedUnit;
            set
            {
                if (selectedUnit == value) return;
                selectedUnit = value;
                UnitInfo = selectedUnit.Name;
                NotifyPropertyChanged();
            }
        }

        public string UnitInfo
        {
            get => unitInfo;
            set
            {
                if (unitInfo == value) return;
                unitInfo = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description == value) return;
                description = value;
                NotifyPropertyChanged();
            }
        }
    }
}
