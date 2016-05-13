namespace Procurement.ViewModel.Filters
{
    public class ItemQuantityFilter : StatFilter
    {
        public override FilterGroup Group
        {
            get { return FilterGroup.MagicFind; }
        }

        public ItemQuantityFilter()
            : base("Item Quantity", "Item with the Item Quantity stat", "INCREASED QUANTITY")
        { }
    }
}
