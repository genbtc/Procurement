using System.Windows;
using System.Windows.Controls;
using POEApi.Model;
using Procurement.ViewModel;

namespace Procurement.Controls
{
    /// <summary>
    /// Interaction logic for RecipeResults.xaml
    /// </summary>
    public partial class RecipeResults : UserControl
    {
        public RecipeResults()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RecipeResultViewModel vm = this.DataContext as RecipeResultViewModel;
            RadioButton button = sender as RadioButton;
            Item item = button.Tag as Item;
            vm.RadioButtonSelected(item);
        }
    }
}
