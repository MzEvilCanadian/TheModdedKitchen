using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.GrilledCheese
{
    class PlatedGrilledCheese : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Grilled Cheese";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Grilled Cheese");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "GC";
        public override bool CanContainSide => false;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.CookedGrilledCheese,
                    Main.Plate
                }
            }
        };           
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside Cooked"),
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

        }
    }
}
