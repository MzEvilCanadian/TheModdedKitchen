using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Lasagna
{
    class CookedLasagna : CustomItem
    {
        public override string UniqueNameID => "Cooked Lasagna";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("CookedLasagna");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override int SplitCount => 6;
        public override Item SplitSubItem => Main.LasagnaPortion;
        public override List<Item> SplitDepletedItems => new() { Main.Pot };
        public override bool PreventExplicitSplit => false;

        /*
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess
            {
                Duration = 15,
                Process = Main.Cook,
                IsBad = true,
                Result = Main.BurntLasagna
            }
        };
        */
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Cheese - Pizza"),     // Medium Cheese
                   MaterialUtils.GetExistingMaterial("Cheese - Default"), // Cheese
                   MaterialUtils.GetExistingMaterial("Raw Pastry"),     // Pasta
                   MaterialUtils.GetExistingMaterial("Tomato Flesh"),         // Sauce
                   MaterialUtils.GetExistingMaterial("Wood - Dark")     // Dark Cheese
            };
            MaterialUtils.ApplyMaterial(Prefab, "Piece 1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Piece 2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Piece 5", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Piece 6", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cheese - Default");
            materials[1] = MaterialUtils.GetExistingMaterial("Raw Pastry");
            materials[2] = MaterialUtils.GetExistingMaterial("Tomato");
            materials[3] = MaterialUtils.GetExistingMaterial("Cheese - Pizza");
            materials[4] = MaterialUtils.GetExistingMaterial("Wood - Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Piece 3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Piece 4", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            materials[1] = MaterialUtils.GetExistingMaterial("Metal Dark");
            materials[2] = MaterialUtils.GetExistingMaterial("Metal Dark");
            materials[3] = MaterialUtils.GetExistingMaterial("Metal Dark");
            materials[4] = MaterialUtils.GetExistingMaterial("Metal Dark");

            MaterialUtils.ApplyMaterial(Prefab, "Pan/Base", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Pan/Handles", materials);

            if (!Prefab.HasComponent<LasagnaItemView>())
            {
                var view = Prefab.AddComponent<LasagnaItemView>();
                view.Setup(Prefab);
            }
        }
    }

    public class LasagnaItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("Piece 1"),
                prefab.GetChild("Piece 2"),
                prefab.GetChild("Piece 3"),
                prefab.GetChild("Piece 4"),
                prefab.GetChild("Piece 5"),
                prefab.GetChild("Piece 6"),
            });
        }
    }
}
