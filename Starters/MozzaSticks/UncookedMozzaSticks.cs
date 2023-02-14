using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Starters.MozzaSticks
{
    class UncookedMozzaSticks : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Mozza Sticks";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedMozzaSticks");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.GratedCheese,
                    Main.Flour
                }
            },
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3,
                Process = Main.Cook,
                Result = Main.CookedMozzaSticks
            }
        };  
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Flour"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "MozzaSticks", materials);
        } 
    }
}
