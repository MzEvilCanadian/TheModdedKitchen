using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class ExtraMilkCard : ModDish
    {
        public override string UniqueNameID => "Extra Milk";
        public override DishType Type => DishType.Extra;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.MilkDish
        };
        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>()
        {
            new Dish.IngredientUnlock
            {
                MenuItem = Main.MilkGlass,
                Ingredient = Main.MilkGlass
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Milk,
            Main.Cup
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Customers can request more Milk while eating. They will leave it on the table after they are done" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Extra Milk", "Customers can request more milk while eating.", "For when you can't get enough of Jay's Milk") }
        };
    }
}
