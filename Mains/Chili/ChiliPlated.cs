using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili
{
    class ChiliPlated : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Chili";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("PlatedChili");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "Ch";
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
                    Main.ChiliPortion,
                    Main.Plate
                }
            },
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
                  MaterialUtils.GetExistingMaterial("Plate - Ring")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato 2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion 2", materials);
        }
    }
}
