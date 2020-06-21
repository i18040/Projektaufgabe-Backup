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
    class UnitsControlController : SubmoduleController
    {
        private UnitsControlViewModel mViewModel;

        public void Save()
        {
            if (mViewModel.SelectedUnit != null)
            {
                MainWindowController.serviceClient.UpdateBusinessUnit(mViewModel.SelectedUnit.Name, mViewModel.Name,
                    mViewModel.Description);
                mViewModel.SelectedUnit.Name = mViewModel.Name;
                mViewModel.SelectedUnit.Description = mViewModel.Description;
            }
        }

        public void New()
        {
            var unit = MainWindowController.serviceClient.NewBusinessUnit(mViewModel.Name, mViewModel.Description);
            if(unit != null)
                mViewModel.BusinessUnits.Add(unit);
        }

        public void Delete()
        {
            if (mViewModel.SelectedUnit != null)
            {
                MainWindowController.serviceClient.DeleteBusinessUnit(mViewModel.SelectedUnit.Name);
                mViewModel.BusinessUnits.Remove(mViewModel.SelectedUnit);
            }
        }
        public override ViewModelBase Initialize()
        {
            mViewModel = new UnitsControlViewModel()
            {
                BusinessUnits = new ObservableCollection<BusinessUnit>(MainWindowController.serviceClient.GetBusinessUnits())
            };
            return mViewModel;
        }
    }
}
