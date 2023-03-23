﻿using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class HotdogChilidog : ModDish
    {
        public override string UniqueNameID => "Hotdog Chili Dog Dish";
        public override DishType Type => DishType.Main;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.HotdogDish
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
               Item = Main.ChiliDogPlated,
               Phase = MenuPhase.Main,
               Weight = 1
            }
        };
        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>()
        {
            new Dish.IngredientUnlock
            {
                MenuItem = Main.ChiliDogPlated,
                Ingredient = Main.Ketchup
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Tomato,
            Main.Onion,
            Main.Peppers,
            Main.Plate,
            Main.Pot,
            Main.HotDog,
            Main.DogBun,
            Main.Cheese
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook a hotdog and place on a bun. Add chili then grated cheese then and plate. To make chili combine tomato sauce, chopped tomato, chopped onion, and chopped peppers into a pot and cook. Makes several servings" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Hotdog - Chili Dog", "Adds chili dogs to the menu - They can request ketchup", "Because you love your spicy weiner.") }
        };
    }
}