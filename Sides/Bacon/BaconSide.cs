using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.Bacon
{
    class BaconSide : CustomItem
    {
        public override string UniqueNameID => "Bacon Side";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BaconSlice");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsMergeableSide => true;
        public override string ColourBlindTag => "Bac";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\""),
                MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon Fat\"")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bacon", materials);
        }
       
    }
}
