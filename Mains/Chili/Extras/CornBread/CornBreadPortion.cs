using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras
{
    class CornBreadPortion : CustomItem
    {
        public override string UniqueNameID => "Cornbread Portion";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CornBreadPortion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool IsMergeableSide => true;
        public override string ColourBlindTag => "CB";

        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
                  MaterialUtils.GetExistingMaterial("Plastic - Yellow")
            };
            MaterialUtils.ApplyMaterial(Prefab, "CornBread", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);
        }
    }
}
