using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.GrilledCheeseProcess
{
    class PlatedGrilledCheese : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Grilled Cheese";
        public override GameObject Prefab => Main.TomatoSlice.Prefab; //Filler line until Models are made
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override string ColourBlindTag => "GC";
        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.CookedGrilledCheese
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Plate
                }
            }

            /*
              public override void OnRegister(GameDataObject gameDataObject)
            {

                // setup materials on prefab

                Prefab.GetComponent<MyItemGroupView>()?.Setup();
             }
            */
        };

    }

    /*
    public class MyItemGroupView : ItemGroupView
    {
        internal void Setup()
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new List<ComponentGroup>()
            {
                new ComponentGroup()
                {
                    GameObject = Prefab.GetChildFromPath("MilkshakeCup/Cup"),
                    Item = Refs.Cup
                },
                new ComponentGroup()
                {
                    Objects = new List<GameObject>()
                    {
                        prefab.GetChildFromPath("MilkshakeCup/IceCream1"),
                        prefab.GetChildFromPath("MilkshakeCup/IceCream2"),
                        prefab.GetChildFromPath("MilkshakeCup/IceCream3")
                    },
                    DrawAll = true, // this makes it so that the entire list is handled at once (otherwise, if you have multiple instances of the same item in the itemgroup (i.e. icecream), it will enable one at a time)
                    Item = Refs.IceCream
                },
                new ComponentGroup()
                {
                    Objects = new List<GameObject>()
                    {
                        prefab.GetChildFromPath("MilkshakeCup/MyOptionalIngredient")
                    },
                    Item = Refs.MyOptionalIngredient
                }
            };

            // Colorblind labels; text is the label; item is the item to display it for (all present ingredients have their labels combined)
            ComponentLabels = new List<ColourBlindLabel>()
            {
                new ColourBlindLabel()
                {
                    Text = "A",
                    Item = Refs.IceCream
                },
                new ColourBlindLabel()
                {
                    Text = "B",
                    Item = Refs.MyOptionalIngredient
                },
            };
        }
    }
    */
}
