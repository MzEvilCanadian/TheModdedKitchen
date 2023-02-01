using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.Starters.MozzaSticks
{
    class CombinedMozzaSticks : CustomItemGroup
    {
        public override string UniqueNameID => "Combined Mozza Sticks";
        public override GameObject Prefab => Main.Cheese.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "MS";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.CookedMozzaSticks
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.MaranaraSauce
                }
            }
        };
        /*
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Olive Oil Bottle");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (2)", materials);

            // MaterialUtils.ApplyMaterial([object], [name], [material list]
        }
        */
    }
}
