using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.Milk
{
    class MilkGlass : CustomItemGroup
    {
        public override string UniqueNameID => "Milk Glass";
        public override GameObject Prefab => Main.MilkIngredient.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool IsMergeableSide => true;
        public override string ColourBlindTag => "Mi";
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.MilkIngredient
                }
            }
        };
    }
}

