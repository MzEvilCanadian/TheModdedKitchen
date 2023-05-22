using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Dishes
{
    class LasagnaDish : ModDish
    {
        public override string UniqueNameID => "Lasagna Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Main.bundle.LoadAsset<GameObject>("LasagnaPortion");
        public override GameObject IconPrefab => Main.bundle.LoadAsset<GameObject>("LasagnaPortion");
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;

        public override List<string> StartingNameSet => new()
        {
            "Hasta Lasagna!",
            "Noodle Cake Factory",
            "Multi-layered Cheese",
            "Tasty Layers",
            "Garfields",
            "Layers upon Layers"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new Dish.MenuItem
            {
                Item = Main.PlatedLasagna,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            Main.Tomato,
            Main.Cheese,
            Main.Noodles,
            Main.Meat,
            Main.Plate,     // Ingredient Lib Boxed Pasta
            Main.Pot
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            Main.Chop,
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Combine tomato sauce, chopped cheese, chopped meat, and boxed noodles in a pot then cook. Serves 6" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Lasagna", "Adds Lasagna as a Main", "Like cheese cake with noodles") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Cheese - Default"),
                  MaterialUtils.GetExistingMaterial("Raw Pastry"),
                  MaterialUtils.GetExistingMaterial("Tomato Flesh"),
                  MaterialUtils.GetExistingMaterial("Cheese - Pizza"),
                  MaterialUtils.GetExistingMaterial("Wood - Dark"),
         };
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Portion", materials);
        }
    }
}

