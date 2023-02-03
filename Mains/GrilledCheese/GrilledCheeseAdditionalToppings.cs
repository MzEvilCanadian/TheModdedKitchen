using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.GrilledCheeseProcess
{
    class GrilledCheeseAdditionalToppings : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Plated Grilled Cheese with toppings";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("GrilledCheeseXToppings");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "GCBT";
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
                    Main.PlatedGrilledCheese
                }
            },
             new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 1,
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
             };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Butter\"");
            MaterialUtils.ApplyMaterial(Prefab, "Butter", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
        }        
    }
}
