namespace Procurement.ViewModel.Filters
{
    public class VaalFragmentFilter : TypeLineFilter
    {
        public VaalFragmentFilter()
            : base("Sacrifice at Dusk", "Sacrifice at Midnight", "Sacrifice at Noon", "Sacrifice at Dawn")
        { }
        public override bool CanFormCategory
        {
            get { return true; }
        }

        public override string Keyword
        {
            get { return "Vaal Fragments"; }
        }

        public override string Help
        {
            get { return "Vaal Fragments"; }
        }

        public override FilterGroup Group
        {
            get { return FilterGroup.VaalFragments; }
        }
    }
}
