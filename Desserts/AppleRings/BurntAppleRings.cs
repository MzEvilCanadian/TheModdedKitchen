using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Desserts.AppleRings
{
    class BurntAppleRings : CustomItem
    {
        public override string UniqueNameID => "Burnt Apple Rings";
        public override GameObject Prefab => Main.Cheese.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        /*
                public override void OnRegister(GameDataObject gameDataObject)
                {
                    var materials = new Material[]
                    {
                        MaterialUtils.GetExistingMaterial("Bread - Inside Cooked"),
                     };
                    MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
                    materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
                    MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
                    materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
                    MaterialUtils.ApplyMaterial(Prefab, "GameObject (2)", materials);
                    materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Dark Green");
                    MaterialUtils.ApplyMaterial(Prefab, "GameObject (3)", materials);

                    // MaterialUtils.ApplyMaterial([object], [name], [material list]
                }
        */
    }
}
