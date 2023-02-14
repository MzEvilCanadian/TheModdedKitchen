using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.BananaBread
{
    class UncookedBananaBread : CustomItemGroup  <MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Banana Bread";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedBananaBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Main.Dough,
                    Main.ChoppedChocolate,
                    Main.PeeledBanana
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Main.Cook,
                Result = Main.BananaBreadLoaf
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plastic - Light Yellow"),
                MaterialUtils.GetExistingMaterial("Plastic - Light Yellow")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Banana", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Chocolate");
            materials[1] = MaterialUtils.GetExistingMaterial("Chocolate");
            MaterialUtils.ApplyMaterial(Prefab, "Chocolate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Raw Pastry");
            materials[1] = MaterialUtils.GetExistingMaterial("Raw Pastry");
            MaterialUtils.ApplyMaterial(Prefab, "Dough", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Dough"),
                    Item = Main.Dough
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Chocolate"),
                    Item = Main.ChoppedChocolate,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Banana"),
                    Item = Main.PeeledBanana
                }
            };
    } 
}

