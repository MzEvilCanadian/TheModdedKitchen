using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Sides.MacNCheese
{
    class MacNCheeseServing : CustomItem
    {
        public override string UniqueNameID => "MacNCheeseServing";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Mac and Cheese");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool IsMergeableSide =>  true;
        public override string ColourBlindTag => "M&C";

        public override void OnRegister(GameDataObject gameDataObject)
          {

              var materials = new Material[]
              {
                  MaterialUtils.GetExistingMaterial("Plate"),
              };
               MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);
              materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
              MaterialUtils.ApplyMaterial(Prefab, "Pile", materials);
              materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
              MaterialUtils.ApplyMaterial(Prefab, "Mac", materials);
          }
        
    }
}
