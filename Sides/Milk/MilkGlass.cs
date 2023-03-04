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
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("MilkGlass");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsMergeableSide => true;
        public override string ColourBlindTag => "M";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.MilkIngredient,
                    Main.Cup
                }
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plastic - White"),
                MaterialUtils.GetExistingMaterial("Plastic - Blue")
            };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
        }
    }
}


