using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;


namespace ModdedKitchen.Mains.Chili.Extras.Ingredients
{
    class DeluxeChiliPot : CustomItem
    {
        public override string UniqueNameID => "Deluxe Chili Pot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("DeluxeChiliPot");
        public override Item DisposesTo => Main.Pot;
        public override int SplitCount => 8;
        public override Item SplitSubItem => Main.DeluxeChiliPortion;
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
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomatoes", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Pepper", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            MaterialUtils.ApplyMaterial(Prefab, "Meat", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Bean - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Beans", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Corn", materials);
        }
    }
}
