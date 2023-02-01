using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.Starters.MozzaSticks
{
    class UncookedMozzaSticks : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Grilled Cheese";
        public override GameObject Prefab => Main.Cheese.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.GratedCheese
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
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
