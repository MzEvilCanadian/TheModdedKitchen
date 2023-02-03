using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.GrilledCheeseProcess
{
    class BurnedGrilledCheese : CustomItem
    {
        public override string UniqueNameID => "Burned Grilled Cheese";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BurntGrilledCheese");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "BGC";
       
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Burned - Light"),
                MaterialUtils.GetExistingMaterial("Burned")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
        }        
    }
}
