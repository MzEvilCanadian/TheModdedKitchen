using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Starters.Bruschetta
{
    internal class AssembledBruschetta : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Bruschetta Stage 2";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("BruschettaStage2");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.CookedBread,
                    Main.TomatoSlice,
                    Main.OnionChopped
                }
            },
        };
        
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Olive Oil Bottle");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (3)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato"),
                    Item = Main.TomatoSlice
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion"),
                    Item = Main.OnionChopped
                },
            };
        }
    }
}
