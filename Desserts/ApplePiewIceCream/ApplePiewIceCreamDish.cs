using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;
using KitchenLib.References;

namespace ModdedKitchen.Dishes
{
    class ApplePiewIceCreamDish : ModDish
    {
        public override string UniqueNameID => "Apple Pie with Ice Cream Dish";
        public override DishType Type => DishType.Dessert;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.ApplePiewIceCream,
                Phase = MenuPhase.Dessert,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Apple,
            Main.VanillaIceCream
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Oven,
            Main.Chop,
            Main.Knead,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine a chopped apple, sugar, and bread crumbs and cook." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Apple Crisp - Grilled Cheese", "Adds Apple Crisp as a Dessert", "Moooooove over Jay!") }
        };
    }
}
