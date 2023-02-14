using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;
using KitchenLib.References;

namespace ModdedKitchen.Dishes
{
    class MonteCristoDish : ModDish
    {
        public override string UniqueNameID => "Monte Cristo Dish";
        public override DishType Type => DishType.Main;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.GrilledCheeseDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.PlatedMonteCristo,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Cheese,
            Main.Flour,
            Main.Butter,
            Main.Pork,
            Main.Egg
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Oven,
            Main.Chop,
            Main.Knead,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Knead flour into dough and cook. Combine two bread slices with grated cheese, a cracked egg, and cooked ham, then cook. It assists with revenge." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Monte Cristo - Grilled Cheese", "Adds Monte Cristo sandwich as a Main", "Ham and cheese between french toast. Yummm.") }
        };
    }
}
