using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class KetchupDish : ModDish
    {
        public override string UniqueNameID => "Grilled Cheese Ketchup";
        public override DishType Type => DishType.Extra;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.GrilledCheeseDish
        };

        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>()
        {
            new Dish.IngredientUnlock
            {
                MenuItem = Main.PlatedGrilledCheese,
                Ingredient = Main.Ketchup
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Ketchup
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Customers can request Ketchup while eating grilled cheese" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Grilled Cheese - Ketchup", "Customers can request Ketchup while eating grilled cheese", "") }
        };
    }
}
