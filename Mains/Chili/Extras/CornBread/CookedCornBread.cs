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

            if (!Prefab.HasComponent<CookedCornBreadItemView>())
            {
                var view = Prefab.AddComponent<CookedCornBreadItemView>();
                view.Setup(Prefab);
            }
        }
    }
    public class CookedCornBreadItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                // Invisible models
                GameObjectUtils.GetChildObject(prefab, "Slice 1"),
                GameObjectUtils.GetChildObject(prefab, "Slice 2"),
                GameObjectUtils.GetChildObject(prefab, "Slice 3"),
                GameObjectUtils.GetChildObject(prefab, "Slice 4"),
                GameObjectUtils.GetChildObject(prefab, "Slice 5"),
                GameObjectUtils.GetChildObject(prefab, "Slice 6"),
                GameObjectUtils.GetChildObject(prefab, "Slice 7"),
                GameObjectUtils.GetChildObject(prefab, "Slice 8"),
                

                // This doesnt let me launch the game
                /*
                prefab.GetChild("Slice 1"),
                prefab.GetChild("Slice 2"),
                prefab.GetChild("Slice 3"),
                prefab.GetChild("Slice 4"),
                prefab.GetChild("Slice 5"),
                prefab.GetChild("Slice 6"),
                prefab.GetChild("Slice 7"),
                prefab.GetChild("Slice 8")
                */
            });
        }
    }
}