using System.Collections.Generic;
using Procurement.ViewModel.Filters;

namespace Procurement.ViewModel.ForumExportVisitors
{
    internal class CorruptedGemVisitor : VisitorBase
    {
        private const string TOKEN = "{CorruptedGems}";

        public override string Visit(IEnumerable<POEApi.Model.Item> items, string current)
        {
            return current.Replace(TOKEN, runFilter<CorruptedGemFilter>(items));
        }
    }
}
