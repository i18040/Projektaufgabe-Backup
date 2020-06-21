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
    class VehicleGeneralControlController : SubmoduleController
    {
        private VehicleGeneralControlViewModel mViewModel;

        public Vehicle Save(Vehicle selectedVehicle)
        {
            if(mViewModel.LeasingFrom < mViewModel.LeasingTo)
            {
                var vehicle = MainWindowController.serviceClient.UpdateVehicle(selectedVehicle.LicensePlate, mViewModel.LicensePlate,
                    mViewModel.Brand, mViewModel.Model, mViewModel.Insurance, mViewModel.LeasingFrom,
                    mViewModel.LeasingTo,
                    mViewModel.LeasingRate);
                return vehicle;
            }
            return null;
        }

        public Vehicle New()
        {
            if (mViewModel.LeasingFrom < mViewModel.LeasingTo)
            {
                var vehicle = MainWindowController.serviceClient.NewVehicle(mViewModel.LicensePlate, mViewModel.Brand,
                    mViewModel.Model, mViewModel.Insurance,
                    mViewModel.LeasingFrom, mViewModel.LeasingTo,
                    mViewModel.LeasingRate);
                return vehicle;
            }

            return null;
        }

        public void Delete(Vehicle selectedVehicle)
        {
            MainWindowController.serviceClient.DeleteVehicle(selectedVehicle.LicensePlate);
        }

        public override ViewModelBase Initialize()
        {
            mViewModel = new VehicleGeneralControlViewModel();
            return mViewModel;
        }
    }
}
