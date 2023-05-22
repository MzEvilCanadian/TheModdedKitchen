using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Starters.SoupoftheDay
{
    class SOTDUncookedPot : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Soup of the Day";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedSoupOfTheDay");
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
                    Main.Broth
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Main.Broccoli,
                    Main.Carrot,
                    Main.HuskedCorn,
                    Main.Lettuce,
                    Main.Mushroom,
                    Main.Onion,
                    Main.Peppers,
                    Main.Potato,
                    Main.PumpkinHallow,
                    Main.Tomato
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                Result = Main.SOTDPot
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Handles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup");
            MaterialUtils.ApplyMaterial(Prefab, "Liquid", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Pepper", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Onion (1)", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Green");
            MaterialUtils.ApplyMaterial(Prefab, "Broccoli", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn");
            MaterialUtils.ApplyMaterial(Prefab, "Corn", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Lettuce");
            MaterialUtils.ApplyMaterial(Prefab, "Lettuce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Mushroom Light");
            MaterialUtils.ApplyMaterial(Prefab, "Mushroom/Stem", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Mushroom Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Mushroom/Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Raw Potato - Skin");
            MaterialUtils.ApplyMaterial(Prefab, "Potato", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Pumpkin");
            MaterialUtils.ApplyMaterial(Prefab, "Pumpkin", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato"),
                    Item = Main.Tomato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion"),
                    Item = Main.Onion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Carrot"),
                    Item = Main.Carrot
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Broccoli"),
                    Item = Main.Broccoli
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Corn"),
                    Item = Main.HuskedCorn
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Lettuce"),
                    Item = Main.Lettuce
                },
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Mushroom/Stem"),
                        GameObjectUtils.GetChildObject(prefab, "Mushroom/Top"),
                    },
                    Item = Main.Mushroom,
                    DrawAll = true
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pepper"),
                    Item = Main.Peppers
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Potato"),
                    Item = Main.Potato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pumpkin"),
                    Item = Main.PumpkinHallow
                },
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.Pot,
                    Text = ""
                },
                new()
                {
                    Item = Main.Broccoli,
                    Text = "B"
                },
                new()
                {
                    Item = Main.Carrot,
                    Text = "C"
                },
                new()
                {
                    Item = Main.HuskedCorn,
                    Text = "C"
                },
                new()
                {
                    Item = Main.Lettuce,
                    Text = "L"
                },
                new()
                {
                    Item = Main.Mushroom,
                    Text = "M"
                },
                new()
                {
                    Item = Main.Onion,
                    Text = "O"
                },
                new()
                {
                    Item = Main.Peppers,
                    Text = "P"
                },
                new()
                {
                    Item = Main.Potato,
                    Text = "P"
                },
                new()
                {
                    Item = Main.PumpkinHallow,
                    Text = "P"
                },
                new()
                {
                    Item = Main.Tomato,
                    Text = "T"
                },
            };
        }
    }
}
