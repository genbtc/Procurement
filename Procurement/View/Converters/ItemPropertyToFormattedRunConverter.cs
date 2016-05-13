using System;
using System.Windows.Data;
using System.Windows.Documents;
using POEApi.Model;
using Procurement.ViewModel;

namespace Procurement.View
{
    public class ItemPropertyToFormattedRunConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Property property = value as Property;
            return new FlowDocument(DisplayModeFactory.Create(property).Get());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
