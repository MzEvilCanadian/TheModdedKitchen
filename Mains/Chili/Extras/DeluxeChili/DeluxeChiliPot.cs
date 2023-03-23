using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;


namespace ModdedKitchen.Mains.Chili.Extras.Ingredients
{
    public class DeluxeChiliItemView : PositionSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fFullPosition = ReflectionUtils.GetField<PositionSplittableView>("FullPosition");
            fFullPosition.SetValue(this, new Vector3(0, 0.267f, 0));

            var fEmptyPosition = ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition");
            fEmptyPosition.SetValue(this, new Vector3(0, 0, 0));

            var fObjects = ReflectionUtils.GetField<PositionSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("Objects")
            });
        }
    }
    class DeluxeChiliPot : CustomItem
    {
        public override string UniqueNameID => "Deluxe Chili Pot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("DeluxeChiliPot");
        public override Item DisposesTo => Main.Pot;
        public override int SplitCount => 8;
        public override float SplitSpeed => 2f;
        public override Item SplitSubItem => Main.DeluxeChiliPortion;
        public override string ColourBlindTag => "DCh";
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Main.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "PotHandles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Sauce", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Tomatoes", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Tomato Flesh 3");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Pepper", materials);
            MaterialUtils.ApplyMaterial(Prefab, "PepperPot", materials);
            MaterialUtils.ApplyMaterial(Prefab, "PepperPot2", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Onion", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Meat", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Bean - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Beans", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sweetcorn - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Corn", materials);
            MaterialUtils.ApplyMaterial(Prefab, "CornPot", materials);
            MaterialUtils.ApplyMaterial(Prefab, "CornPot2", materials);

            if (!Prefab.HasComponent<DeluxeChiliItemView>())
            {
                var view = Prefab.AddComponent<DeluxeChiliItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
