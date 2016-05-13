using System;
using System.Windows.Data;
using POEApi.Model;
using Procurement.Controls;
using Procurement.ViewModel;

namespace Procurement.View
{
    public class ItemDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Item item = value as Item;
            return new ItemDisplay() { DataContext = new ItemDisplayViewModel(item) };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
