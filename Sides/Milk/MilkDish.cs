﻿using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace ModdedKitchen.Dishes
{
    class MilkDish : ModDish
    {
        
        public override string UniqueNameID => "Milk Glass Dish";
        public override DishType Type => DishType.Side;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.MilkGlass,
                Phase = MenuPhase.Side,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Milk,
            Main.Cup
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine a cup and a portion of milk and serve." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Milk", "Adds Milk Side", "Jay's Milk") }
        };
        
    }
}
