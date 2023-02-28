using ApplianceLib.Customs.GDO;
using Kitchen;
using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace ModdedKitchen.Sides.Milk
{
    public class ThrowOutMilkCartonsCard : ModUnlockCard
    {
        public const RestaurantStatus RestaurantStatus = (RestaurantStatus)(-628800);

        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override string UniqueNameID => "ThrowOutMilkCard";
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override List<UnlockEffect> Effects => new()
        {
            new StatusEffect
            {
                Status = RestaurantStatus
            }
        };

        public override List<Unlock> HardcodedRequirements => new()
        {
            Main.MilkDish
        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Dirty Cartons", "Customers leave behind their dirty milk cartons which must be thrown out", "You got a bin right?"))
        };
    }

    [UpdateAfter(typeof(GroupReceiveItem))]
    public class ThrowOutCupsSystem : GameSystemBase
    {
        private EntityQuery AllOrderedItems;

        protected override void Initialise()
        {
            AllOrderedItems = GetEntityQuery(new QueryHelper()
                .All(typeof(CWaitingForItem.Marker))
            );
        }

        protected override void OnUpdate()
        {
            if (!HasStatus(ThrowOutMilkCartonsCard.RestaurantStatus))
            {
                return;
            }

            using var orderedItems = AllOrderedItems.ToEntityArray(Allocator.Temp);
            foreach (var entity in orderedItems)
            {
                var buffer = EntityManager.GetBuffer<CWaitingForItem>(entity);
                for (int i = 0; i < buffer.Length; i++)
                {
                    var orderedItem = buffer[i];

                    if (orderedItem.ItemID == Main.MilkGlass.ID)
                    {
                        orderedItem.DirtItem = Main.DirtyMilkCarton.ID;
                    }

                    buffer[i] = orderedItem;
                }
            }
        }
    }
}