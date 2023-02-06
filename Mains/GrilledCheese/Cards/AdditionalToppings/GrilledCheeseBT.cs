using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.GrilledCheeseXToppings
{
    class GrilledCheeseBT : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Plated Grilled Cheese with toppings";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("GrilledCheeseXToppings");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Main.Plate;
        public override Item DirtiesTo => Main.DirtyPlate;
        public override bool CanContainSide => true;
        

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.PlatedGrilledCheese
                }
            },
             new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.Bacon,
                    Main.TomatoSlice
                }
            }
        };

        private bool GameDataBuilt = false;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            if (GameDataBuilt)
            {
                return;
            }

            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside Cooked"),
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
             };
            MaterialUtils.ApplyMaterial(Prefab, "Bread Bottom", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bread Top", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate - Ring");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\"");
            materials[1] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon Fat\"");
            MaterialUtils.ApplyMaterial(Prefab, "Bacon/Bacon Strip (0)", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Bacon/Bacon Strip (1)", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced/Liquid", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced (1)/Liquid", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 2");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced/Inner", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced (1)/Inner", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced/Skin", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Tomato/Tomato Sliced (1)/Skin", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }

            GameDataBuilt = true;
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
                    Item = Main.TomatoSlice,
                    
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon"),
                    Item = Main.Bacon
                },

            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = Main.PlatedGrilledCheese,
                    Text = "PGC"
                },
                new()
                {
                    Item = Main.TomatoSlice,
                    Text = "T"
                },
                new()
                {
                    Item = Main.Bacon,
                    Text = "B"
                }
            };
        }
    }
}
