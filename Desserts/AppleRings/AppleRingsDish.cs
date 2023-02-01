using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GrilledCheese.Dishes
{
    class AppleRingsDish : ModDish
    {
        public override string UniqueNameID => "Apple Rings Dish";
        public override DishType Type => DishType.Dessert;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override float SelectionBias => 1;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.CookedAppleRings,
                Phase = MenuPhase.Dessert,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Apple,
            Main.Sugar,
            Main.Cinnamon,
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine a chopped Apple with Sugar and Cinnamon and cook." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Apple Rings", "Adds Apple Rings as a Dessert", "Mmmmm Tasty") }
        };
    }
}
