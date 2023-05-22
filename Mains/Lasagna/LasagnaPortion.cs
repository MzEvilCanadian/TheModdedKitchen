using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;


namespace ModdedKitchen.Mains.Lasagna
{
    class LasagnaPortion : CustomItem
    {
        public override string UniqueNameID => "Lasagna Portion";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("LasagnaPortion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Cheese - Default"),
                  MaterialUtils.GetExistingMaterial("Raw Pastry"),
                  MaterialUtils.GetExistingMaterial("Tomato Flesh"),
                  MaterialUtils.GetExistingMaterial("Cheese - Pizza"),
                  MaterialUtils.GetExistingMaterial("Wood - Dark"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Portion", materials);
        }
    }
}
