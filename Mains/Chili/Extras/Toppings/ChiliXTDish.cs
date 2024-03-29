﻿using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class ChiliXTDish : ModDish
    {
        public override string UniqueNameID => "Chili Extra Toppings";
        public override DishType Type => DishType.Extra;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.ChiliDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
               Item = Main.ChiliXT,
               Phase = MenuPhase.Main,
               Weight = 1
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Main.GratedCheese,
                MenuItem = Main.DeluxeChiliPlated
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Main.WhippingCream,
                MenuItem = Main.DeluxeChiliPlated
            },
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Cheese,
            Main.Tomato,
            Main.Onion,
            Main.Peppers,
            Main.Plate,
            Main.Pot,
            Main.WhippedCream
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Chop,
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop cheese and add to plated chili. For sour cream take cream and knead then add to plated chili. Also can be added to deluxe chili." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chili - Toppings", "Customers can request cheese and sour cream with their chili", "It's how my mom likes it.") }
        };
    }
}
