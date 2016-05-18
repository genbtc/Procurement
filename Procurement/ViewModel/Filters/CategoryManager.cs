using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Procurement.ViewModel.Filters.ForumExport;

namespace Procurement.ViewModel.Filters
{
    public static class CategoryManager
    {
        private static Dictionary<string, IEnumerable<IFilter>> categories;
        private static List<IFilter> availableFilters;

        static CategoryManager()
        {
            categories = new Dictionary<string, IEnumerable<IFilter>>();
            availableFilters = getAvailableFilters();

            initializeBaseCategories();
            initializeUserCategories();
        }

        public static List<AdvancedSearchCategory> GetAvailableCategories()
        {
            return categories.Select(category => new AdvancedSearchCategory(category.Key, string.Join(Environment.NewLine, category.Value.Select(filter => filter.Help)))).ToList();
        }

        public static IEnumerable<IFilter> GetCategory(string category)
        {
            return categories[category];
        }

        private static void initializeUserCategories()
        {
            categories.Add("Craftable Whites", new List<IFilter>() { new NormalRarity(), new OrFilter(new FourLink(), new FiveLink()) });
            addDynamicLevelReqCategoryFilter(0, 999);   //LEVEL REQUIREMENT CODE
        }

        public static List<IFilter> GetAvailableFilters()
        {
            availableFilters = availableFilters ?? getAvailableFilters();
            return availableFilters;
        }
        private static List<IFilter> getAvailableFilters()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                                                  .Where(t => !(t.IsAbstract || t.IsInterface) && typeof(IFilter).IsAssignableFrom(t) && t.Name != typeof(OrFilter).Name)
                                                  .Where(t => t.GetConstructor(new Type[] { }) != null)
                                                  .OrderBy(t => t.Name)
                                                  .Select(t => Activator.CreateInstance(t) as IFilter)
                                                  .OrderBy(i => i.Group)
                                                  .ThenBy(i => i.Keyword)
                                                  .ToList();
        }

        private static void initializeBaseCategories()
        {
            availableFilters.ForEach(f => categories.Add(f.Keyword, new List<IFilter>() { f }));
        }

        public static void addDynamicLevelReqCategoryFilter(int minlvl,int maxlvl)
        {
            //LEVEL REQUIREMENT CODE
            if (categories.ContainsKey("Level Requirement"))
                categories.Remove("Level Requirement");
            categories.Add("Level Requirement", new List<IFilter>() {new LevelFilter(minlvl, maxlvl)});
        }
    }
}
