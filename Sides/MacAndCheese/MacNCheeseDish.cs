using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace ModdedKitchen.Dishes
{
    public class MacNCheeseDish : ModDish
    {
        public override string UniqueNameID => "Mac and Cheese Dish";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.MacNCheeseServing,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };     
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Pot,
            Main.Water,
            Main.Cheese,
            Main.Butter,
            Main.Milk,
            Main.Macaroni
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop,
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Put pasta and water in a pot then cook. Add grated cheese, a slice of butter, and milk then cook again. Makes 10 portions" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Mac and Cheese", "Adds Mac and Cheese as a Starter", "Seconds Please?") }
        };
    }
}