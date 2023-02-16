using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras
{
    class BurntCornBread : CustomItem
    {
        public override string UniqueNameID => "Burned Cornbread";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BurntCornBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Burned")
        };
            MaterialUtils.ApplyMaterial(Prefab, "CornBread", materials);
        }
    }
}

