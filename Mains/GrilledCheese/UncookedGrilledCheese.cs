using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.GrilledCheeseProcess
{
    class UncookedGrilledCheese : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Grilled Cheese";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Uncooked Grilled Cheese");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "UGC";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.BreadSlice,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Main.BreadSlice,
                    Main.GratedCheese,
                    Main.ButterSlice
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3,
                Process = Main.Cook,
                Result = Main.CookedGrilledCheese
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
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Butter\"");
            MaterialUtils.ApplyMaterial(Prefab, "Butter", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Butter"),
                    Item = Main.ButterSlice
                },
            };
        }
    }
}
