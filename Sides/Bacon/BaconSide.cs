using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.Bacon
{
    class BaconSide : CustomItemGroup
    {
        public override string UniqueNameID => "Bacon Side";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BaconSide");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsMergeableSide => true;
        public override string ColourBlindTag => "Bac";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Bacon,
                    Main.Bacon
                }
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\""),
                MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon Fat\"")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bacon", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon 3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon 4", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon 5", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon 6", materials);
        }
    }
}
