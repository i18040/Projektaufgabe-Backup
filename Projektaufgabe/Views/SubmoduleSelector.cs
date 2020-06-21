using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Projektaufgabe.ViewModels;

namespace Projektaufgabe.Views
{
    public class SubmoduleSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var contentControl = container as FrameworkElement;
            if (item is StartControlViewModel)
                return contentControl.FindResource("startViewTemplate") as DataTemplate;
            if (item is CostUnitMonthControlViewModel)
                return contentControl.FindResource("costMonthViewTemplate") as DataTemplate;
            if (item is CostMonthControlViewModel)
                return contentControl.FindResource("costUnitMonthViewTemplate") as DataTemplate;
            if (item is VehiclesControlViewModel)
                return contentControl.FindResource("vehiclesViewTemplate") as DataTemplate;
            if (item is UnitsControlViewModel)
                return contentControl.FindResource("unitsViewTemplate") as DataTemplate;
            if (item is EmployeesControlViewModel)
                return contentControl.FindResource("employeesViewTemplate") as DataTemplate;
            if (item is UsersControlViewModel)
                return contentControl.FindResource("usersViewTemplate") as DataTemplate;
            return null;
        }
    }
}
