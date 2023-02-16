using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class ChiliBeans : ModDish
    {
        public override string UniqueNameID => "Chili Beans";
        public override DishType Type => DishType.Extra;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
    //    public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.ChiliDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new Dish.IngredientUnlock
            {
                MenuItem = Main.UncookedChiliPot,
                Ingredient = Main.Beans
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Beans
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Adds Beans into your chili recipe" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chili - Bean", "Making chili now requires beans", "You know you like it.") }
        };
    }
}
