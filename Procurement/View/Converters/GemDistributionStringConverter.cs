using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Procurement.View
{
    public class GemDistributionStringConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var all = value as string;
            return new FlowDocument(new Paragraph(new Run(all) { Foreground = new SolidColorBrush { Color = Color.FromArgb(0xFF, 0xAB, 0x90, 0x66) }, FontWeight = FontWeights.Bold }));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
