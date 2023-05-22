using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;


namespace ModdedKitchen.Dishes
{
    class BaconDish : ModDish
    {
        public override string UniqueNameID => "Bacon Side Dish";
        public override DishType Type => DishType.Side;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.BaconSide,
                Phase = MenuPhase.Side,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            Main.Pork,
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            Main.Chop,
            Main.Cook
        };
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Chop two portions of pork and combine then cook. Portion out a serving and add to the plate. Makes 6 portions." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Bacon", "Adds Bacon Side", "sweet, smoky, and salty pork slices") }
        };
    }
}
