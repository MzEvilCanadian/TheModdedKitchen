using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Lasagna
{
    class UncookedLasagna : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Lasagna";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedLasagna");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => Main.Pot;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Pot
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 4,
                Min = 4,
                Items = new List<Item>()
                {
                    Main.GratedCheese,
                    Main.TomatoSauce,
                    Main.Noodles,
                    Main.ChoppedMeat
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 8,
                Process = Main.Cook,
                Result = Main.CookedLasagna
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
                   MaterialUtils.GetExistingMaterial("Metal Very Dark"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Pan/Base", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Pan/Handles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Sauce", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Sauce (1)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Sauce (2)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Sauce (3)", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cheese - Default");
            materials[1] = MaterialUtils.GetExistingMaterial("Cheese - Default");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cheese (1)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cheese (2)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cheese (3)", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Raw Pastry");
            materials[1] = MaterialUtils.GetExistingMaterial("Raw Pastry");
            MaterialUtils.ApplyMaterial(Prefab, "Noodles", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Noodles (1)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Noodles (2)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Noodles (3)", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Meat Piece Raw");
            materials[1] = MaterialUtils.GetExistingMaterial("Meat Piece Raw");
            MaterialUtils.ApplyMaterial(Prefab, "Meat", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Meat (1)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Meat (2)", materials);


            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }

    }
    public class MyItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Sauce"),
                        GameObjectUtils.GetChildObject(prefab, "Sauce (1)"),
                        GameObjectUtils.GetChildObject(prefab, "Sauce (2)"),
                        GameObjectUtils.GetChildObject(prefab, "Sauce (3)"),
                    },
                    Item = Main.TomatoSauce,
                    DrawAll= true
                },
                new()
                {
                    Objects = new()
                    {

                        GameObjectUtils.GetChildObject(prefab, "Cheese"),
                        GameObjectUtils.GetChildObject(prefab, "Cheese (1)"),
                        GameObjectUtils.GetChildObject(prefab, "Cheese (2)"),
                        GameObjectUtils.GetChildObject(prefab, "Cheese (3)"),
                    },
                    Item = Main.GratedCheese,
                    DrawAll = true
                },
                new()
                {
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Noodles"),
                        GameObjectUtils.GetChildObject(prefab, "Noodles (1)"),
                        GameObjectUtils.GetChildObject(prefab, "Noodles (2)"),
                        GameObjectUtils.GetChildObject(prefab, "Noodles (3)"),
                    },
                    Item = Main.Noodles,
                    DrawAll= true
                },
                new()
                {
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Meat"),
                        GameObjectUtils.GetChildObject(prefab, "Meat (1)"),
                        GameObjectUtils.GetChildObject(prefab, "Meat (2)"),
                    },
                    Item = Main.ChoppedMeat,
                    DrawAll = true
                },
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.Pot,
                    Text = "Las"
                },
                new()
                {
                    Item = Main.TomatoSauce,
                    Text = "Ts"
                },
                new()
                {
                    Item = Main.Noodles,
                    Text = "N"
                },
                new()
                {
                    Item = Main.GratedCheese,
                    Text = "C"
                },
                new()
                {
                    Item = Main.ChoppedMeat,
                    Text = "M"
                },
            };
        }
    }
}

