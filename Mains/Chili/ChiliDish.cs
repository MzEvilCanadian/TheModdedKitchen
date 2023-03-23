using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Dishes
{
    class ChiliDish : ModDish
    {
        public override string UniqueNameID => "Chili Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Main.bundle.LoadAsset<GameObject>("ChiliPrefab");
        public override GameObject IconPrefab => Main.bundle.LoadAsset<GameObject>("ChiliPrefab");
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;

        public override List<string> StartingNameSet => new()
        {
            "Dr. Chili Pepper",
            "A Taste of Heaven",
            "Beans are Us",
            "Ginger's Bean Chili",
            "The Ultimate Chili",
            "Mean Mama Chili",
            "Bubble and Simmer"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new Dish.MenuItem
            {
                Item = Main.ChiliPlated,
                Phase = MenuPhase.Main,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            Main.Tomato,
            Main.Onion,
            Main.Peppers,
            Main.Plate,
            Main.Pot
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            Main.Chop,
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Combine tomato sauce, chopped tomato, chopped onion, and chopped peppers into a pot and cook. Makes several servings" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chili", "Adds Chili as a Main", "Do you put beans in it?") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Metal"),
         };
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Pot", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Tomatoes", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(IconPrefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Onion", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(IconPrefab, "Pepper", materials);
        }
    }
}
