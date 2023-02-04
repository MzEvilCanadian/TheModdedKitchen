using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.MonteCristoProcess
{
    class PlatedMonteCristo : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Monte Cristo";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Monte Cristo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "PMC";
        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.CookedMonteCristo

                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Plate
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 0,
                IsMandatory = false,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    Main.Bacon,
                    Main.TomatoSlice
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
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\"");
            MaterialUtils.ApplyMaterial(Prefab, "Pork", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[0] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);


        }
    }
}
