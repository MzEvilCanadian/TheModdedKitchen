using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Sides.Bacon
{
    class CookedBaconSide : CustomItem
    {
        public override string UniqueNameID => "Cooked Bacon Side";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedBaconSide");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override int SplitCount => 6;
        public override Item SplitSubItem => Main.BaconSide;
        public override List<Item> SplitDepletedItems => new() {  };
        public override bool PreventExplicitSplit => false;
         public override void OnRegister(GameDataObject gameDataObject)
         {
             var materials = new Material[]
             {
                 MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon\""),
                 MaterialUtils.GetExistingMaterial("IngredientLib - \"Bacon Fat\"")
             };
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon", materials);
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon 2", materials);
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon 3", materials);
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon 4", materials);
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon 5", materials);
                 MaterialUtils.ApplyMaterial(Prefab, "Bacon 6", materials);

            if (!Prefab.HasComponent<BaconSideItemView>())
            {
                var view = Prefab.AddComponent<BaconSideItemView>();
                view.Setup(Prefab);
            }
        }
    }
    public class BaconSideItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("Bacon"),
                prefab.GetChild("Bacon 2"),
                prefab.GetChild("Bacon 3"),
                prefab.GetChild("Bacon 4"),
                prefab.GetChild("Bacon 5"),
                prefab.GetChild("Bacon 6")
            });
        }
    }
}
