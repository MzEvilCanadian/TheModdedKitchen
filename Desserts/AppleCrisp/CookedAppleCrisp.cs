using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.AppleCrisp
{
    class CookedAppleCrisp : CustomItem
    {
        public override string UniqueNameID => "Cooked Apple Crisp";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedAppleCrisp");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "CAC";

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurntAppleCrisp
            }
        };
        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Plate"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Apple Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "AppleSlices", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "BreadCrumbs", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Baked Apple");
            MaterialUtils.ApplyMaterial(Prefab, "Sugar", materials);
        }
        
    }
}
