﻿using System.Collections.Generic;
using System.Text;
using POEApi.Model;

namespace Procurement.ViewModel
{
    public class ItemHoverViewModel
    {
        public Item Item { get; private set; }
        public string TypeLine { get; private set; }
        public ItemType ItemType { get; private set; }
        public List<Property> Properties { get; private set; }
        public List<Requirement> Requirements { get; private set; }
        public bool HasRequirements { get; private set; }

        public string Name { get; private set; }
        public bool HasName { get; private set; }
        public List<string> ExplicitMods { get; private set; }
        public bool HasExplicitMods { get; private set; }
        public List<string> ImplicitMods { get; private set; }
        public bool HasImplicitMods { get; private set; }
        public string DescriptionText { get; private set; }
        public string SecondaryDescriptionText { get; private set; }
        public bool IsCorrupted { get; private set; }
        public List<string> Microtransactions { get; private set; }
        public bool HasMicrotransactions { get; private set; }

        public List<string> CraftedMods { get; set; }

        public bool HasCraftedMods { get; private set; }


        public ItemHoverViewModel(Item item)
        {
            this.Item = item;
            this.Name = item.Name;
            this.TypeLine = item.TypeLine;
            this.HasName = !string.IsNullOrEmpty(item.Name);
            this.ItemType = item.ItemType;
            this.Properties = item.Properties;

            this.Requirements = new List<Requirement>();
            this.ExplicitMods = item.Explicitmods;

            this.ImplicitMods = new List<string>();

            this.DescriptionText = item.DescrText;

            this.IsCorrupted = item.Corrupted;

            this.Microtransactions = item.Microtransactions;
            this.HasMicrotransactions = item.Microtransactions.Count > 0;

            this.CraftedMods = item.CraftedMods;

            SecondaryDescriptionText = item.SecDescrText;
            setTypeSpecificProperties(item);

            this.HasExplicitMods = ExplicitMods != null && ExplicitMods.Count > 0;
            this.HasImplicitMods = ImplicitMods != null && ImplicitMods.Count > 0; 
            this.HasCraftedMods = CraftedMods != null && CraftedMods.Count > 0;
            this.HasRequirements = Requirements != null && Requirements.Count > 0;
        }

        private void setTypeSpecificProperties(Item item)
        {
            var gear = item as Gear;

            if (gear != null)
                setGearProperties(item, gear);

            var gem = item as Gem;

            if (gem != null)
                this.Requirements = gem.Requirements;
        }

        private void setGearProperties(Item item, Gear gear)
        {
            this.Requirements = gear.Requirements;
            this.ImplicitMods = gear.Implicitmods;

            if (gear.FlavourText != null && gear.FlavourText.Count > 0)
            {
                var builder = new StringBuilder();

                foreach (var text in ((Gear)(item)).FlavourText)
                    builder.Append(text);

                DescriptionText = builder.ToString();
            }
        }
    }
}
