using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace ModdedKitchen.Dishes
{
    class SOTDDish : ModDish
    {
        public override string UniqueNameID => "Soup of the Day Dish";
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
                Item = Main.SOTDServing,
                Phase = MenuPhase.Starter,
                Weight = 1,
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Pot,
            Main.Water,
            Main.Corn,
            Main.Onion,
            Main.Pumpkin
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Put water in a pot with an onion and cook. Add 3 of the following and cook: Broccoli, Carrot, Husked Corn, Lettuce, Mushroom, Onion, Pepper, Potato, Hollow Pumpkin, Tomato" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Soup of the Day", "Adds Soup of the Day as a Starter", "Use whatever we got in the kitchen") }
        };
    }
}
