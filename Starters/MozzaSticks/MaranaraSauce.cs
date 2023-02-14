using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Starters.MozzaSticks
{
    class MaranaraSauce : CustomItemGroup
    {
        public override string UniqueNameID => "Maranara Sauce";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("MaranaraSauce");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.OilIngredient,
                    Main.TomatoSauce
                }
            }
        };

        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plate"),
                MaterialUtils.GetExistingMaterial("Tomato")
             };
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);
        }  
    }
}
