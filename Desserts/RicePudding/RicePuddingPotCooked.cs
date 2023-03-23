using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Desserts.RicePudding
{
    public class RicePuddingPotCookedItemView : PositionSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fFullPosition = ReflectionUtils.GetField<PositionSplittableView>("FullPosition");
            fFullPosition.SetValue(this, new Vector3(0, 0.273f, 0));

            var fEmptyPosition = ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition");
            fEmptyPosition.SetValue(this, new Vector3(0, 0.028f, 0));

            var fObjects = ReflectionUtils.GetField<PositionSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("Rice Pudding")
            });
        }
        
    }

    public class RicePuddingPotCooked : CustomItem
    {
        public override string UniqueNameID => "Rice Pudding Pot Cooked";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("RicePuddingPotCooked");
        public override float SplitSpeed => 2f;
        public override int SplitCount => 10;
        public override Item SplitSubItem => Main.RicePudding;
        public override List<Item> SplitDepletedItems => new() { Main.Pot };
        public override Item DisposesTo => Main.Pot;
       public override string ColourBlindTag => "RiPu";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            var ricePudding = Prefab.GetChild("Rice Pudding");

            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Pot.001/Cylinder", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Pot/Pot.001/Cylinder.003", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Cinnamon\"");
            MaterialUtils.ApplyMaterial(ricePudding, "Cinnamon/Cinnamon.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(ricePudding, "Milk/Milk.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Rice");
            MaterialUtils.ApplyMaterial(ricePudding, "Rice/Cube", materials);

            
            if (!Prefab.HasComponent<RicePuddingPotCookedItemView>())
            {
                var view = Prefab.AddComponent<RicePuddingPotCookedItemView>();
                view.Setup(Prefab);
            }
            
            
        }

    }
}