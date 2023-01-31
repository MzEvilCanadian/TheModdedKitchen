using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.MonteCristoProcess
{
    class BurntMonteCristo : CustomItem
    {
        public override string UniqueNameID => "Burned Monte Cristo";
        public override GameObject Prefab => Main.Cheese.Prefab; // Temp item until models are made
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "BMC";


        /*
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Handles", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Piano White");
            MaterialUtils.ApplyMaterial(Prefab, "Milk", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Egg Dough\"");
            MaterialUtils.ApplyMaterial(Prefab, "Mac", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Butter\"");
            MaterialUtils.ApplyMaterial(Prefab, "Butter", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Cheese - Default");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese/Shaving0", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cheese/Shaving1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cheese/Shaving2", materials);
        }
        */
    }
}
