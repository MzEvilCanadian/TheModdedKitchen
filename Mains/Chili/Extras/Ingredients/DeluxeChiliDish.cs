using KitchenLib.Utils;
using System.Collections.Generic;
using KitchenData;

namespace ModdedKitchen.Dishes
{
    class DeluxeChiliDish : ModDish
    {
        public override string UniqueNameID => "Deluxe Chili Dish";
        public override DishType Type => DishType.Main;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.ChiliDish
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
               Item = Main.DeluxeChiliPlated,
               Phase = MenuPhase.Main,
               Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Beans,
            Main.Tomato,
            Main.Onion,
            Main.Peppers,
            Main.Plate,
            Main.Pot,
            Main.Meat,
            Main.Corn
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add beans, husked corn, and chopped meat into a pot of chili and cook." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chili - Bean", "Adds a deluxe chili to the menu", "Much more filling?") }
        };
    }
}
