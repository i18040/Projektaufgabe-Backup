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
    class VehiclesControlController : SubmoduleController
    {
        private VehicleEmployeeControlController vehicleEmployeeControlController;
        private VehicleEmployeeControlViewModel vehicleEmployeeControlViewModel;
        private VehicleGeneralControlController vehicleGeneralControlController;
        private VehicleGeneralControlViewModel vehicleGeneralControlViewModel;
        private VehiclesControlViewModel mViewModel;

        public void Save()
        {
            
        }

        public void New()
        {

        }

        public void Delete()
        {

        }

        public void ExecuteSelectionChanged(object obj)
        {
            if (mViewModel.SelectedIndex == 0)
            {
                vehicleGeneralControlController = new VehicleGeneralControlController();
                mViewModel.ActiveViewModel = vehicleGeneralControlController.Initialize();
                vehicleGeneralControlViewModel = (VehicleGeneralControlViewModel) mViewModel.ActiveViewModel;
            }
            else
            {
                vehicleEmployeeControlController = new VehicleEmployeeControlController()
                {
                    LicensePlate = mViewModel.SelectedVehicle.LicensePlate
                };
                mViewModel.ActiveViewModel = vehicleEmployeeControlController.Initialize();
                vehicleEmployeeControlViewModel = (VehicleEmployeeControlViewModel) mViewModel.ActiveViewModel;
            }
        }

        public override ViewModelBase Initialize()
        {
            mViewModel = new VehiclesControlViewModel()
            {
                BusinessUnits = new ObservableCollection<Vehicle>(MainWindowController.serviceClient.GetVehicles())
            };
            return mViewModel;
        }
    }
}
