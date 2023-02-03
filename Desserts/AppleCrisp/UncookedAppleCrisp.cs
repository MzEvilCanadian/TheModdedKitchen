using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.AppleCrisp
{
    class UncookedAppleCrisp : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Apple Crisp";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedAppleCrisp");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "UAC";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.AppleSlices
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.Sugar
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.BreadCrumbs
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 6,
                Process = Main.Cook,
                Result = Main.CookedAppleCrisp
            }
        };

        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Apple Flesh"),
                MaterialUtils.GetExistingMaterial("Apple Green"),
                MaterialUtils.GetExistingMaterial("Baked Apple"),
                MaterialUtils.GetExistingMaterial("Baked Apple"),
            };
            MaterialUtils.ApplyMaterial(Prefab, "Apple", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Sugar");
            MaterialUtils.ApplyMaterial(Prefab, "Sugar", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Inside Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "BreadCrumbs", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
        }
        
    }
    public class MyItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Apple"),
                    Item = Main.AppleSlices
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sugar"),
                    Item = Main.Sugar,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Breadcrumbs"),
                    Item = Main.BreadCrumbs
                }
            };
    }
}
