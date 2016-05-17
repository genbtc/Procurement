namespace Procurement.ViewModel.Filters.ForumExport
{
    class StrengthFilter : StatFilter
    {
        public override FilterGroup Group
        {
            get { return FilterGroup.CharacterAttributes; }
        }

        public StrengthFilter()
            : base("Strength", "Strength", "Strength")
        { }
    }


    class IntelligenceFilter : StatFilter
    {
        public override FilterGroup Group
        {
            get { return FilterGroup.CharacterAttributes; }
        }

        public IntelligenceFilter()
            : base("Intelligence", "Intelligence", "Intelligence")
        { }
    }

    class DexterityFilter : StatFilter
    {
        public override FilterGroup Group
        {
            get { return FilterGroup.CharacterAttributes; }
        }

        public DexterityFilter()
            : base("Dexterity", "Dexterity", "Dexterity")
        { }
    }

    class AllAttributesFilter : StatFilter
    {
        public override FilterGroup Group
        {
            get { return FilterGroup.CharacterAttributes; }
        }

        public AllAttributesFilter()
            : base("All Attributes", "All Attributes", "All Attributes")
        { }
    }
}
