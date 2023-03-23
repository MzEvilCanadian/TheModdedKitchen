using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.BananaBread
{
    class BananaBreadLoaf : CustomItem
    {
        public override string UniqueNameID => "Banana Bread Loaf";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedBananaBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override int SplitCount => 9;
        public override Item SplitSubItem => Main.BananaBreadSlice;
        public override List<Item> SplitDepletedItems => new() { Main.BananaBreadSlice };
        public override bool PreventExplicitSplit => false;

        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurntBread
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Bread - Inside"),
                   MaterialUtils.GetExistingMaterial("Bread")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Slice - End/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 2/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 3/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 4/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 5/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 6/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 7/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 8/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 9/Bread", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice - Start/Bread", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Chocolate");
            materials[1] = MaterialUtils.GetExistingMaterial("Chocolate");
            MaterialUtils.ApplyMaterial(Prefab, "Slice - End/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice - Start/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 2/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 3/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 4/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 5/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 6/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 7/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 8/Chocolate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 9/Chocolate", materials);

            if (!Prefab.HasComponent<BananaBreadLoafItemView>())
            {
                var view = Prefab.AddComponent<BananaBreadLoafItemView>();
                view.Setup(Prefab);
            }
        }
    }

    public class BananaBreadLoafItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            { 
                prefab.GetChild("Slice - Start"),
                prefab.GetChild("Slice 2"),
                prefab.GetChild("Slice 3"),
                prefab.GetChild("Slice 4"),
                prefab.GetChild("Slice 5"),
                prefab.GetChild("Slice 6"),
                prefab.GetChild("Slice 7"),
                prefab.GetChild("Slice 8"),
                prefab.GetChild("Slice 9"),
                prefab.GetChild("Slice - End")
            });
        }
    }
}
