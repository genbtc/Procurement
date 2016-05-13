using System.Windows.Controls;
using Procurement.ViewModel;

namespace Procurement.View
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : UserControl, IView
    {
        public RecipeView()
        {
            InitializeComponent();
            this.DataContext = new RecipeResultViewModel();
        }

        public new Grid Content
        {
            get { return this.ViewContent; }
        }
    }
}
