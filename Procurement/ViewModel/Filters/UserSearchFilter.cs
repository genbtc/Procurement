using System.Linq;
using POEApi.Model;

namespace Procurement.ViewModel.Filters
{
    public class UserSearchFilter : IFilter
    {
        public FilterGroup Group
        {
            get { return FilterGroup.Default; }
        }

        private string filter;
        private int minLevelReq;
        private int maxLevelReq;
        public UserSearchFilter(string filter,int minLevelReq=-1, int maxLevelReq=999)
        {
            this.filter = filter;
            this.minLevelReq = minLevelReq;
            this.maxLevelReq = maxLevelReq;
        }
        public bool CanFormCategory
        {
            get { return false; }
        }

        public string Keyword
        {
            get { return "User search"; }
        }

        public string Help
        {
            get { return "Matches user search on name/typeline and geartype"; }
        }

        public bool Applicable(Item item)
        {
            if (string.IsNullOrEmpty(filter))
                return false;

            var gear = item as Gear;

            //Check for min/max level requirements.
            bool useminlvl = (minLevelReq != 0 || maxLevelReq != 999);
            if (gear != null && gear.Requirements.Count > 0 && gear.Requirements[0].Name == "Level")
            {
                int lvl = System.Convert.ToInt16(gear.Requirements[0].Value);
                if (useminlvl && (lvl < minLevelReq || lvl > maxLevelReq))
                    return false;
            }
            if (item.TypeLine.ToLower().Contains(filter.ToLower()) || item.Name.ToLower().Contains(filter.ToLower()) || containsMatchedCosmeticMod(item) || isMatchedGear(item))
                return true;


            if (gear != null && gear.SocketedItems.Any(x => Applicable(x)))
                return true;

            return false;
        }

        private bool containsMatchedCosmeticMod(Item item)
        {
            return item.Microtransactions.Any(x => x.ToLower().Contains(filter.ToLower()));
        }

        private bool isMatchedGear(Item item)
        {
            Gear gear = item as Gear;

            if (gear == null)
                return false;

            return gear.GearType.ToString().ToLower().Contains(filter.ToLower());
        }
    }
}
