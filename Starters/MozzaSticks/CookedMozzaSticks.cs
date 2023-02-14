using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using KitchenLib.Utils;


namespace ModdedKitchen.Starters.MozzaSticks
{
    class CookedMozzaSticks : CustomItem
    {
        public override string UniqueNameID => "Cooked Mozza Sticks";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedMozzaSticks");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurntMozzaSticks
            }
        };
        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Bread"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "MozzaSticks", materials);
        }
    }
}
