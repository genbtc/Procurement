using System.Linq;
using POEApi.Model;

namespace Procurement.ViewModel.Filters.ForumExport
{
    public class LevelFilter : IFilter
    {
        public FilterGroup Group
        {
            get { return FilterGroup.Default; }
        }

        private int minLevelReq;
        private int maxLevelReq;
        public LevelFilter(int minLevelReq = 0, int maxLevelReq = 999)
        {
            this.minLevelReq = minLevelReq;
            this.maxLevelReq = maxLevelReq;
        }
        public bool CanFormCategory
        {
            get { return true; }
        }

        public string Keyword
        {
            get { return "Level Requirement"; }
        }

        public string Help
        {
            get { return "Matches gear with level requirements in-between Min. and Max. boxes above."; }
        }

        public bool Applicable(Item item)
        {
            var gear = item as Gear;

            //Check for min/max level requirements.
            if (gear == null) 
                return false;
            var requirement = gear.Requirements.SingleOrDefault(f => f.Name == "Level");
            if (requirement == null) 
                return false;
            int lvl = System.Convert.ToInt16(requirement.Value);
            return (lvl >= minLevelReq && lvl <= maxLevelReq);
        }
    }
}
