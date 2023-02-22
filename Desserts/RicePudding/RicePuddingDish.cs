using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using ModdedKitchen.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModdedKitchen.Desserts.RicePudding
{
    class RicePuddingDish : ModDish
    {
        public override string UniqueNameID => "Rice Pudding Dish";
        public override DishType Type => DishType.Dessert;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.RicePudding,
                Phase = MenuPhase.Dessert,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Rice,
            Main.Pot,
            Main.Milk,
            Main.Cinnamon
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add milk, rice, and cinnamon to a pot. Cook to make rice pudding. Portion and serve" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Rice Pudding", "Adds rice pudding as a dessert", null) )
        };
    }
}
