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
        public override int SplitCount => 7;
        public override Item SplitSubItem => Main.CornBreadPortion;
        public override List<Item> SplitDepletedItems => new()
        {
            Main.CornBreadPortion
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

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
                   MaterialUtils.GetExistingMaterial("Bread"),
                   MaterialUtils.GetExistingMaterial("Plastic - Yellow")
            };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 4", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 5", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 6", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 7", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GameObject/Slice 8", materials);

            Prefab.GetComponent<MyItemGroupView>()?.Setup(Prefab);

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

                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 8"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 7"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 6"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 5"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 4"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 3"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 2"),
                GameObjectUtils.GetChildObject(prefab, "GameObject/Slice 1"),

            });
        }
    }
}