﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras.Ingredients
{
    class DeluxeChiliPortion : CustomItem
    {
        public override string UniqueNameID => "Deluxe Chili Portion";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("DeluxeChiliPortion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            MaterialUtils.ApplyMaterial(Prefab, "Meat", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Corn", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Bean - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Beans", materials);
        }
    }
}
