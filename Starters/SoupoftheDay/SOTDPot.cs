using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Starters.SoupoftheDay
{
    public class SOTDItemView : PositionSplittableView
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

    class SOTDPot : CustomItem
    {
        public override string UniqueNameID => "SOTD Pot";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedSoupOfTheDay");
        public override Item DisposesTo => Main.Pot;
        public override int SplitCount => 3;
        public override float SplitSpeed => 2f;
        public override Item SplitSubItem => Main.SOTDServing;
        public override string ColourBlindTag => "SOTD";
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Main.DepletedSoup
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
            MaterialUtils.ApplyMaterial(Prefab, "Handles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Liquid", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Pumpkin");
            MaterialUtils.ApplyMaterial(Prefab, "Objects/Items", materials);

            if (!Prefab.HasComponent<SOTDItemView>())
            {
                var view = Prefab.AddComponent<SOTDItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
