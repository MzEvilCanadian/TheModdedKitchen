using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using static KitchenData.ItemGroup;
using UnityEngine;

namespace ModdedKitchen.Desserts.RicePudding
{
    class RicePuddingPot : CustomItemGroup<RicePuddingPotItemGroupView>
    {
        public override string UniqueNameID => "Rice Pudding Pot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("RicePuddingPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Main.Pot;

        public override List<ItemSet> Sets => new()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.Pot
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.Rice
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.MilkIngredient
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.Cinnamon
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 20f,
                Process = Main.Cook,
                Result = Main.RicePuddingPotCooked
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            var pot = Prefab.GetChild("Pot/Pot.001");

            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(pot, "Cylinder", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(pot, "Cylinder.003", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Coffee Cup");
            MaterialUtils.ApplyMaterial(Prefab, "Milk/Milk.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(Prefab, "Rice/Cube", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(Prefab, "Rice/Cylinder.002", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Cinnamon\"");
            MaterialUtils.ApplyMaterial(Prefab, "Cinnamon/Cinnamon.001/Cylinder.001", materials);


            Prefab.GetComponent<RicePuddingPotItemGroupView>()?.Setup(Prefab);


            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }
    public class RicePuddingPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Rice"),
                    Item = Main.Rice
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pot"),
                    Item = Main.Pot
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Milk"),
                    Item = Main.MilkIngredient
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cinnamon"),
                    Item = Main.Cinnamon
                }
            };

            ComponentLabels = new()
            {
                new()
                {
                    Text = "Ri",
                    Item = Main.Rice
                },
                new()
                {
                    Text = "Mi",
                    Item = Main.MilkIngredient
                },
                new()
                {
                    Text = "Ci",
                    Item = Main.Cinnamon
                }
            };
        }
    }
}