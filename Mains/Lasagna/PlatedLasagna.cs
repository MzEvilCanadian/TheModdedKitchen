using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Lasagna
{
    class PlatedLasagna : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Lasagna";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("PlatedLasagna");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "Las";
        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.LasagnaPortion,
                    Main.Plate
                }
            },
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Cheese - Default"), // Cheese
                MaterialUtils.GetExistingMaterial("Raw Pastry"),     // Pasta
                MaterialUtils.GetExistingMaterial("Tomato"),         // Sauce
                MaterialUtils.GetExistingMaterial("Cheese - Pizza"),     // Medium Cheese
                MaterialUtils.GetExistingMaterial("Wood - Dark")     // Dark Cheese
            };
            MaterialUtils.ApplyMaterial(Prefab, "Portion", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            materials[2] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            materials[3] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            materials[4] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);
        }
    }
}
