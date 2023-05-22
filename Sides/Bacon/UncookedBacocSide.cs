using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.Bacon
{
    class UncookedBaconSide : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Bacon Side";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BaconSide");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => Main.Pot;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.UncookedBacon,
                    Main.UncookedBacon
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5,
                Process = Main.Cook,
                Result = Main.CookedBaconSide
            }
        };
         public override void OnRegister(GameDataObject gameDataObject)
         {
             var materials = new Material[]
             {
                 MaterialUtils.GetExistingMaterial("Pork"),
                 MaterialUtils.GetExistingMaterial("Pork Fat")
             };
             MaterialUtils.ApplyMaterial(Prefab, "Bacon", materials);
             MaterialUtils.ApplyMaterial(Prefab, "Bacon 2", materials);
             MaterialUtils.ApplyMaterial(Prefab, "Bacon 3", materials);
             MaterialUtils.ApplyMaterial(Prefab, "Bacon 4", materials);
             MaterialUtils.ApplyMaterial(Prefab, "Bacon 5", materials);
             MaterialUtils.ApplyMaterial(Prefab, "Bacon 6", materials);
         }
        
    }
}
