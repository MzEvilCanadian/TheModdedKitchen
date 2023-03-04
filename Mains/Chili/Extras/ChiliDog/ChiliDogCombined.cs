using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras.ChiliDog
{
    class ChiliDogCombined : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Combined Chili Dog";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("ChiliDog");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.CookedHotDog,
                    Main.DogBun
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    Main.ChiliPortion,
                    Main.GratedCheese
                }
            },
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                  MaterialUtils.GetExistingMaterial("Plate"),
                  MaterialUtils.GetExistingMaterial("Plate - Ring"),
                  MaterialUtils.GetExistingMaterial("Plate - Ring")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Bun");
            materials[1] = MaterialUtils.GetExistingMaterial("Bread - Bun");
            materials[2] = MaterialUtils.GetExistingMaterial("Bread - Bun");
            MaterialUtils.ApplyMaterial(Prefab, "Bun", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Well-done  Burger"); // Well-done  Burger has 2 spaces
            materials[1] = MaterialUtils.GetExistingMaterial("Well-done  Burger");
            materials[2] = MaterialUtils.GetExistingMaterial("Well-done  Burger");
            MaterialUtils.ApplyMaterial(Prefab, "Dog", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[2] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            materials[2] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Chili", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bun"),
                    Item = Main.DogBun
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Dog"),
                    Item = Main.CookedHotDog
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese"),
                    Item = Main.GratedCheese
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = Main.Plate
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Chili"),
                    Item = Main.ChiliPortion
                },
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.ChiliPortion,
                    Text = "Ch"
                },
                new()
                {
                    Item = Main.CookedHotDog,
                    Text = "Dog"
                },
            };
        }

    }
}
