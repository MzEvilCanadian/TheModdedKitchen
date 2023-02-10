using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.BananaBread
{
    class BananaBreadSlice : CustomItem
    {
        public override string UniqueNameID => "Banana Bread Slice";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BananaBreadSlice");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override string ColourBlindTag => "BB";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
                   MaterialUtils.GetExistingMaterial("Bread - Cooked")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bread", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Chocolate");
            materials[1] = MaterialUtils.GetExistingMaterial("Chocolate");
            MaterialUtils.ApplyMaterial(Prefab, "Chocolate", materials);
        }
    }
}
