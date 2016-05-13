using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Procurement.View
{
    public class ItemExplicitModsToFormattedRunConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string mod = value as string;
            return new FlowDocument(new Paragraph(new Run(mod) { Foreground = new SolidColorBrush { Color = Color.FromArgb(0xFF, 0x88, 0x88, 0xFF)}, BaselineAlignment = BaselineAlignment.Center }));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

