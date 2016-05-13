using System.Windows.Documents;

namespace Procurement.ViewModel
{
    internal interface IDisplayModeStrategy
    {
        Block Get();
    }
}
