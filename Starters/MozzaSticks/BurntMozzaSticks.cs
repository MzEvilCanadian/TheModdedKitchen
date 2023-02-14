using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Starters.MozzaSticks
{
    class BurntMozzaSticks : CustomItem
    {
        public override string UniqueNameID => "Burnt Mozza Sticks";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BurntMozzaSticks");
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Burned"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Pot", materials);
        }    
    }
}
