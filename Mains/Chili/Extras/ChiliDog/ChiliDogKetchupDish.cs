using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;


namespace ModdedKitchen.Dishes
{
    class ChiliDogKetchupDish : ModDish
    {
        public override string UniqueNameID => "Chili dogs Ketchup";
        public override DishType Type => DishType.Extra;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.ChilidogDish
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
            Main.Ketchup,
            Main.Tomato,
            Main.Onion,
            Main.Peppers,
            Main.Plate,
            Main.Pot,
            Main.HotDog,
            Main.DogBun,
            Main.Cheese
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Customers can request Ketchup while eating chili dogs" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chili Dog Ketchup", "Customers can request Ketchup while eating chili dogs", "Because it wasnt sloppy enough before") }
        };
    }
}
