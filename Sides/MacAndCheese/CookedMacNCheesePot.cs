using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.MacNCheese
{
    class CookedMacNCheesePot : CustomItem
    {
        public override string UniqueNameID => "CookedMacNCheesePot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Cooked Mac Pot");
        public override Item DisposesTo => Main.Pot;
        public override int SplitCount => 10;
        public override Item SplitSubItem => Main.MacNCheeseServing;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Main.Pot
        };

        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Handles", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Milk", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Mac", materials);
        }
    }

}
