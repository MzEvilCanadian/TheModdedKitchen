using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.MonteCristoProcess
{
    class UncookedMonteCristo : CustomItemGroup<MyItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Monte Cristo";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Uncooked Monte Cristo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "UMC";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    Main.BreadSlice,
                    Main.BreadSlice
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.GratedCheese
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.EggCracked
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.Ham
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 4,
                Process = Main.Cook,
                Result = Main.CookedMonteCristo
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
            materials[0] = MaterialUtils.GetExistingMaterial("Dark Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Pork", materials);

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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bread Bottom"),
                    Item = Main.BreadSlice
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bread Top"),
                    Item = Main.BreadSlice,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese"),
                    Item = Main.GratedCheese
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pork"),
                    Item = Main.Pork
                },
            };
    }
}
