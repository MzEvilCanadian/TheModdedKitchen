using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras
{
    class CookedCornBread : CustomItem
    {
        public override string UniqueNameID => "Cooked Cornbread";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedCornBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override int SplitCount => 7;
        public override Item SplitSubItem => Main.CornBreadPortion;
        public override List<Item> SplitDepletedItems => new() { Main.CornBreadPortion };
        public override bool PreventExplicitSplit => false;

        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurntCornBread
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Bread - Inside"),
                   MaterialUtils.GetExistingMaterial("Bread")
        };
            MaterialUtils.ApplyMaterial(Prefab, "Slice 1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 4", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 5", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 6", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 7", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Slice 8", materials);

            if (!Prefab.HasComponent<CookedCornbreadItemView>())
            {
                var view = Prefab.AddComponent<CookedCornbreadItemView>();
                view.Setup(Prefab);
            }
        }
    }
    public class CookedCornbreadItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                GameObjectUtils.GetChildObject(prefab, "Slice 1"),
                GameObjectUtils.GetChildObject(prefab, "Slice 2"),
                GameObjectUtils.GetChildObject(prefab, "Slice 3"),
                GameObjectUtils.GetChildObject(prefab, "Slice 4"),
                GameObjectUtils.GetChildObject(prefab, "Slice 5"),
                GameObjectUtils.GetChildObject(prefab, "Slice 6"),
                GameObjectUtils.GetChildObject(prefab, "Slice 7"),
                GameObjectUtils.GetChildObject(prefab, "Slice 8")
            });
        }
    }
}