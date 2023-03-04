using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Starters.SoupoftheDay
{
    class SOTDServing : CustomItem
    {
        public override string UniqueNameID => "Soup of the Day Portion";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("SoupOfTheDayPortion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "SOTD";

        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup");    // Yellowish Brown
            MaterialUtils.ApplyMaterial(Prefab, "Liquid", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Pumpkin");     // Orange
            MaterialUtils.ApplyMaterial(Prefab, "Items", materials);

        }
    }
}
