using KitchenData;
using KitchenLib.Customs;
using KitchenLib.UI;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModdedKitchen.Desserts.RicePudding
{
    class RicePudding : CustomItem
    {
        public override string UniqueNameID => "RicePudding";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Rice Pudding");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override string ColourBlindTag => "RiPu";



        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            materials[0] = CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cinnamon\""];
            MaterialUtils.ApplyMaterial(Prefab, "Cinnamon", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(Prefab, "Milk", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(Prefab, "Rice", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);
        }
    }
}
