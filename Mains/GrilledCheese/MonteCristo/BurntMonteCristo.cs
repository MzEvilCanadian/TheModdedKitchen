using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.GrilledCheese.MonteCristo
{
    class BurntMonteCristo : CustomItem
    {
        public override string UniqueNameID => "Burned Monte Cristo";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BurntMonteCristo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Burned"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned");
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "Pork", materials);
        }
        
    }
}
