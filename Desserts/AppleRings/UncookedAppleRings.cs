using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.AppleRings
{
    class UncookedAppleRings : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "UncookedAppleRings";
        public override GameObject Prefab => Main.Cheese.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Main.Apple,
                    Main.Sugar,
                    Main.Cinnamon
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 6,
                Process = Main.Cook,
                Result = Main.CookedAppleRings
            }
        };

       
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("AppleRed"),
                MaterialUtils.GetExistingMaterial("Apple Flesh")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Apples", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Cinnamon", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Sugar", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cinnamon"),
                    Item = Main.Cinnamon
                }
            };
    }
}
