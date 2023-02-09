using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;
using KitchenLib.References;

namespace ModdedKitchen.Dishes
{
    class GrilledCheeseDish : ModDish
    {
        public override string UniqueNameID => "Grilled Cheese Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Main.bundle.LoadAsset<GameObject>("Grilled_Cheese_Icon");
        public override GameObject IconPrefab => Main.bundle.LoadAsset<GameObject>("Grilled_Cheese_Icon");
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
            "90s Melts",
            "The Mega Melt",
            "Yes, Cheese!",
            "The Cheese Knees",
            "Sink Cheese",
            "Toasty Squares",
            "The Soaking Sink"
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
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Grilled Cheese", "Adds Grilled Cheese as a Main", "Perfect for when you RoughiT.") }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside Cooked"),
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
         };
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Bread Top", materials);
            MaterialUtils.ApplyMaterial(IconPrefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(IconPrefab, "Bread Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Cheese", materials);
            MaterialUtils.ApplyMaterial(IconPrefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Plate", materials);
            MaterialUtils.ApplyMaterial(IconPrefab, "Plate", materials);
        }
    }
}
