using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.GrilledCheeseProcess
{
    class CookedGrilledCheese : CustomItem
    {
        public override string UniqueNameID => "Cooked Grilled Cheese";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedGrilledCheese");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurnedGrilledCheese
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
        }       
    }
}
