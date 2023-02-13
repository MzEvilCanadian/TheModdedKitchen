using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace ModdedKitchen.Dishes
{
    class BananaBreadDish : ModDish
    {
        public override string UniqueNameID => "Banana Bread Dish";
        public override DishType Type => DishType.Dessert;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.BananaBreadSlice,
                Phase = MenuPhase.Dessert,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Flour,
            Main.Chocolate,
            Main.Banana
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Oven,
            Main.Chop,
            Main.Knead,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Knead flour into dough and combine with chopped chocolate and a peeled banana and cook. Makes 10 portions" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Banana Bread", "Banana Bread as a Dessert", "Mom's recipe") }
        };
    }
}
