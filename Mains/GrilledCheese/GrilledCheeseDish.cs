using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;
using KitchenLib.References;

namespace GrilledCheese.Dishes
{
    class GrilledCheeseDish : ModDish
    {
        public override string UniqueNameID => "Grilled Cheese Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Main.Cheese.Prefab;
        public override GameObject IconPrefab => Main.Cheese.Prefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override CardType CardType => CardType.Default;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => false;
        

        public override List<string> StartingNameSet => new List<string>
        {
            "It's Cheesy",
            "Lil’ Cheese Sandwiches",
            "Almost Grown Up Grilled Cheese",
            "90s Melts",
            "The Mega Melt",
            "Yes, Cheese!",
            "The Cheese Knees",
            "Sink Cheese",
            "Toasty Squares"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.PlatedGrilledCheese,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Cheese,
            Main.Flour,
            Main.Butter,
            Main.Plate
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Chop,
            Main.Knead,
            Main.Oven
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Knead flour into dough and cook. Combine two bread slices, cheese, and butter then cook. " }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Grilled Cheese", "Adds Grilled Cheese as a Main", "You know you want it.") }
        };
    }
}
