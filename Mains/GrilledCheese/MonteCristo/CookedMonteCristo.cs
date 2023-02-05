using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.MonteCristoProcess
{
    class CookedMonteCristo : CustomItem
    {
        public override string UniqueNameID => "Cooked Monte Cristo";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedMonteCristo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override string ColourBlindTag => "CMC";
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurnedMonteCristo
            }
        };    
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("IngredientLib - \"Egg Dough\""),
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\"");
            MaterialUtils.ApplyMaterial(Prefab, "Pork", materials);
        }      
    }
}
