using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.GrilledCheese.MonteCristo
{
    class UncookedMonteCristo : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Monte Cristo";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Uncooked Monte Cristo");
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
                    Main.BreadSlice,
                    Main.GratedCheese
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Main.BreadSlice,
                    Main.EggCracked,
                    Main.Ham
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 4,
                Process = Main.Cook,
                Result = Main.CookedMonteCristo
            }
        };

        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\"");
            MaterialUtils.ApplyMaterial(Prefab, "Pork", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Egg - White");
            materials[1] = MaterialUtils.GetExistingMaterial("Egg - White");
            MaterialUtils.ApplyMaterial(Prefab, "Eggwite", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Eggyolk", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
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
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Bread Bottom"),
                        GameObjectUtils.GetChildObject(prefab, "Bread Top")
                    },
                    Item = Main.BreadSlice
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese"),
                    Item = Main.GratedCheese
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pork"),
                    Item = Main.Ham
                },
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Eggyolk"),
                        GameObjectUtils.GetChildObject(prefab, "Eggwite")
                    },
                    Item = Main.EggCracked,
                    DrawAll = true
                },
            };
        }
    }
}
