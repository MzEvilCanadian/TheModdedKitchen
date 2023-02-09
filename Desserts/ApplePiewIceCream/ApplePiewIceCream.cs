using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.ApplePiewIcecream
{
    class ApplePieWithIceCream : CustomItemGroup
    {
        public override string UniqueNameID => "Apple Pie with Ice Cream";
        public override GameObject Prefab => Main.TomatoSlice.Prefab; //Filler line until Models are made
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "APV";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.ApplePie,
                    Main.VanillaIceCream
                }
            },

            /*
              public override void OnRegister(GameDataObject gameDataObject)
            {

                // setup materials on prefab

                Prefab.GetComponent<MyItemGroupView>()?.Setup();
             }
            */
        };

    }
}

