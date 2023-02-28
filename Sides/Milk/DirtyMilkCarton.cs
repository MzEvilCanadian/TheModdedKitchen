using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace ModdedKitchen.Sides.Milk
{
    public class DirtyMilkCarton : CustomItem
    {
        public override string UniqueNameID => "Cup - Milk - Dirty";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("DirtyMilkCarton");

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plastic - White"),
                MaterialUtils.GetExistingMaterial("Plastic - Blue")
            };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
        }
    }
}