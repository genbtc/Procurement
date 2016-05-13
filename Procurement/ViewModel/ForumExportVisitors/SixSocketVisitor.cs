using System.Collections.Generic;
using POEApi.Model;
using Procurement.ViewModel.Filters.ForumExport;

namespace Procurement.ViewModel.ForumExportVisitors
{
    internal class SixSocketVisitor : VisitorBase
    {
        private const string TOKEN = "{6Socket}";
        public override string Visit(IEnumerable<Item> items, string current)
        {
            return current.Replace(TOKEN, runFilter<SixSocketFilter>(items));
        }
    }
}
