using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras
{
    class UncookedCornBread : CustomItemGroup <MyItemGroupView>
    {
        
        public override string UniqueNameID => "Uncooked Cornbread";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("UncookedCornBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 4,
                Min = 4,
                Items = new List<Item>()
                {
                    Main.HuskedCorn,
                    Main.Sugar,
                    Main.EggCracked,
                    Main.Flour
                }
            }
        };
        
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                Result = Main.CookedCornBread
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Egg - White"),
                   MaterialUtils.GetExistingMaterial("Egg - Yolk")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Egg", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn");
            materials[1] = MaterialUtils.GetExistingMaterial("Sweetcorn");
            MaterialUtils.ApplyMaterial(Prefab, "Corn", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sugar");
            materials[1] = MaterialUtils.GetExistingMaterial("S");
            MaterialUtils.ApplyMaterial(Prefab, "Sugar", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            materials[1] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Flour");
            materials[1] = MaterialUtils.GetExistingMaterial("Flour");
            MaterialUtils.ApplyMaterial(Prefab, "Flour", materials);


            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);
            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
        
    }

    
    // Invisible models when used
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Corn"),
                    Item = Main.HuskedCorn,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Egg"),
                    Item = Main.EggCracked,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sugar"),
                    Item = Main.Sugar,
                },
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Flour"),
                        GameObjectUtils.GetChildObject(prefab, "Bowl")
                    },
                    Item = Main.Flour,
                    DrawAll = true
                },
            };
        }
    }
    
}

