using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.AppleRings
{
    class CookedAppleRings : CustomItem
    {
        public override string UniqueNameID => "Cooked Apple Rings";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedAppleRings");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
 //       public override string ColourBlindTag => "AR";

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                Result = Main.BurntAppleRings,
                IsBad = true
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Cooked"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Apples", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);
        }
    }
}
