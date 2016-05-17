﻿using System;
using System.Linq;
using POEApi.Model;

namespace Procurement.ViewModel.Filters.ForumExport
{
    class SixBlueSockets : IFilter
    {
        public bool CanFormCategory
        {
            get { throw new NotImplementedException(); }
        }

        public string Keyword
        {
            get { return "6 Blue Sockets"; }
        }

        public string Help
        {
            get { return "Gear with 6 blue sockets"; }
        }

        public FilterGroup Group
        {
            get { return FilterGroup.Default; }
        }

        public bool Applicable(Item item)
        {
            var gear = item as Gear;

            if (gear == null)
                return false;

            return gear.Sockets.Where(s => s.Attribute.Equals("I", StringComparison.OrdinalIgnoreCase)).Count() == 6;
        }
    }
}
