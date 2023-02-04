using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.AppleCrisp
{
    class BurntAppleCrisp : CustomItem
    {
        public override string UniqueNameID => "Burnt Apple Crisp";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BurntAppleCrisp");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "BAC";   
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Plate"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Burned");
            MaterialUtils.ApplyMaterial(Prefab, "AppleSlices", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "BreadCrumbs", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Burned");
            MaterialUtils.ApplyMaterial(Prefab, "Sugar", materials);
        }
    }
}
