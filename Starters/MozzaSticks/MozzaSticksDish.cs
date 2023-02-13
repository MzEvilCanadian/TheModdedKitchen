using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace ModdedKitchen.Dishes
{
    class MozzaSticksDish : ModDish
    {
        public override string UniqueNameID => "Mozza Sticks Dish";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.CombinedMozzaSticks,
                Phase = MenuPhase.Starter,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Cheese,
            Main.Flour,
            Main.Tomato,
            Main.Oil
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine grated cheese with flour and cook. Make maranara sauce by combining tomato sauce with oil. Combine both and serve." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Mozza Sticks", "Adds Mozza Stick as a Starter", "Best. Food. Ever.") }
        };

    }
}
