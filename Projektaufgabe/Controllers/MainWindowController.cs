using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Projektaufgabe.Framework;
using Projektaufgabe.ServiceReference1;
using Projektaufgabe.ViewModels;
using Projektaufgabe.Views;

namespace Projektaufgabe.Controllers
{
    public class MainWindowController
    {

        private StartControlController startControlController;
        private UnitsControlController unitsControlController;
        private UsersControlController usersControlController;
        private VehiclesControlController vehiclesControlController;
        private EmployeesControlController employeesControlController;

        private StartControlViewModel startControlViewModel;
        private UnitsControlViewModel unitsControlViewModel;
        private UsersControlViewModel usersControlViewModel;
        private VehiclesControlViewModel vehiclesControlViewModel;
        private EmployeesControlViewModel employeesControlViewModel;

        public static ServiceClient serviceClient = new ServiceClient();
        private MainWindowViewModel mViewModel;
        public MainWindow mView;
        public User CurrentUser { get; set; }

        public void ExecuteStartCommand(object obj)
        {
            startControlController = new StartControlController();
            mViewModel.ActiveViewModel = startControlController.Initialize();
            startControlViewModel = (StartControlViewModel) mViewModel.ActiveViewModel;
            mViewModel.StartCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
            mViewModel.StartCurrentForeColor = new SolidColorBrush(Colors.White);
            mViewModel.VehiclesCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.VehiclesCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.EmployeeCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.EmployeeCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.BusinessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.BusinessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.UserCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.UserCurrentForeColor = new SolidColorBrush(Colors.Black);
        }
        public void ExecuteCostMonthCommand(object obj)
        {

        }
        public void ExecuteCostUnitCommand(object obj)
        {

        }
        public void ExecuteVehiclesCommand(object obj)
        {
            vehiclesControlController = new VehiclesControlController();
            mViewModel.ActiveViewModel = vehiclesControlController.Initialize();
            vehiclesControlViewModel = (VehiclesControlViewModel)mViewModel.ActiveViewModel;
            mViewModel.VehiclesCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
            mViewModel.VehiclesCurrentForeColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.EmployeeCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.EmployeeCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.BusinessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.BusinessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.UserCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.UserCurrentForeColor = new SolidColorBrush(Colors.Black);
        }
        public void ExecuteEmployeesCommand(object obj)
        {
            employeesControlController = new EmployeesControlController();
            mViewModel.ActiveViewModel = employeesControlController.Initialize();
            employeesControlViewModel = (EmployeesControlViewModel)mViewModel.ActiveViewModel;
            mViewModel.EmployeeCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
            mViewModel.EmployeeCurrentForeColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.VehiclesCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.VehiclesCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.BusinessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.BusinessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.UserCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.UserCurrentForeColor = new SolidColorBrush(Colors.Black);
        }
        public void ExecuteUnitsCommand(object obj)
        {
            unitsControlController = new UnitsControlController();
            mViewModel.ActiveViewModel = unitsControlController.Initialize();
            unitsControlViewModel = (UnitsControlViewModel)mViewModel.ActiveViewModel;
            mViewModel.BusinessUnitCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
            mViewModel.BusinessUnitCurrentForeColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.VehiclesCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.VehiclesCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.EmployeeCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.EmployeeCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.UserCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.UserCurrentForeColor = new SolidColorBrush(Colors.Black);
        }
        public void ExecuteUsersCommand(object obj)
        {
            usersControlController = new UsersControlController();
            mViewModel.ActiveViewModel = usersControlController.Initialize();
            usersControlViewModel = (UsersControlViewModel)mViewModel.ActiveViewModel;
            mViewModel.UserCurrentBackColor = new SolidColorBrush(Colors.DodgerBlue);
            mViewModel.UserCurrentForeColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.StartCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.VehiclesCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.VehiclesCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.EmployeeCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.EmployeeCurrentForeColor = new SolidColorBrush(Colors.Black);
            mViewModel.BusinessUnitCurrentBackColor = new SolidColorBrush(Colors.White);
            mViewModel.BusinessUnitCurrentForeColor = new SolidColorBrush(Colors.Black);
        }
        public void ExecuteNewItemCommand(object obj)
        {
            if(mViewModel.ActiveViewModel is UnitsControlViewModel)
                unitsControlController.New();
            if (mViewModel.ActiveViewModel is UsersControlViewModel)
                usersControlController.New();
            if (mViewModel.ActiveViewModel is VehiclesControlViewModel)
                vehiclesControlController.New();
            if (mViewModel.ActiveViewModel is EmployeesControlViewModel)
                employeesControlController.New();
        }
        public void ExecuteSaveItemCommand(object obj)
        {
            if (mViewModel.ActiveViewModel is UnitsControlViewModel)
                unitsControlController.Save();
            if (mViewModel.ActiveViewModel is UsersControlViewModel)
                usersControlController.Save();
            if (mViewModel.ActiveViewModel is VehiclesControlViewModel)
                vehiclesControlController.Save();
            if (mViewModel.ActiveViewModel is EmployeesControlViewModel)
                employeesControlController.Save();
        }
        public void ExecuteDeleteItemCommand(object obj)
        {
            if (mViewModel.ActiveViewModel is UnitsControlViewModel)
                unitsControlController.Delete();
            if (mViewModel.ActiveViewModel is UsersControlViewModel)
                usersControlController.Delete();
            if (mViewModel.ActiveViewModel is VehiclesControlViewModel)
                vehiclesControlController.Delete();
            if (mViewModel.ActiveViewModel is EmployeesControlViewModel)
                employeesControlController.Delete();
        }

        public void Initialize()
        {
            var view = new MainWindow();
            mViewModel = new MainWindowViewModel()
            {
                StartCommand = new RelayCommand(ExecuteStartCommand),
                CostMonthCommand = new RelayCommand(ExecuteCostMonthCommand),
                CostUnitCommand = new RelayCommand(ExecuteCostUnitCommand),
                VehiclesCommand = new RelayCommand(ExecuteVehiclesCommand),
                EmployeesCommand = new RelayCommand(ExecuteEmployeesCommand),
                UnitsCommand = new RelayCommand(ExecuteUnitsCommand),
                UsersCommand = new RelayCommand(ExecuteUsersCommand),
                NewItemCommand = new RelayCommand(ExecuteNewItemCommand),
                SaveItemCommand = new RelayCommand(ExecuteSaveItemCommand),
                DeleteItemCommand = new RelayCommand(ExecuteDeleteItemCommand)
            };
            mViewModel.Visibility = Visibility.Hidden;
            if (CurrentUser.isAdmin)
                mViewModel.Visibility = Visibility.Visible;
            view.DataContext = mViewModel;
            startControlController = new StartControlController();
            mViewModel.ActiveViewModel = startControlController.Initialize();
            startControlViewModel = (StartControlViewModel)mViewModel.ActiveViewModel;
            view.Show();
        }
    }
}
