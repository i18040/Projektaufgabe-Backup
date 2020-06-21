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
            if (mViewModel.SelectedIndex == 0 && mViewModel.SelectedVehicle != null)
            {
                var vehicle = vehicleGeneralControlController.Save(mViewModel.SelectedVehicle);
                mViewModel.SelectedVehicle = vehicle;
            }
        }

        public void New()
        {
            if (mViewModel.SelectedIndex == 0)
            {
                var vehicle = vehicleGeneralControlController.New();
                mViewModel.Vehicles.Add(vehicle);
            }
        }

        public void Delete()
        {
            if (mViewModel.SelectedIndex == 0 && mViewModel.SelectedVehicle != null)
            {
                vehicleGeneralControlController.Delete(mViewModel.SelectedVehicle);
                mViewModel.Vehicles.Remove(mViewModel.SelectedVehicle);
            }
        }

        public override ViewModelBase Initialize()
        {
            mViewModel = new VehiclesControlViewModel()
            {
                Vehicles = new ObservableCollection<Vehicle>(MainWindowController.serviceClient.GetVehicles())
            };
            return mViewModel;
        }
    }
}
