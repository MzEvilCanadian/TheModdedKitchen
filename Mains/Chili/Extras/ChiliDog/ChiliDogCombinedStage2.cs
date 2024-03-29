﻿using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ModdedKitchen.Mains.Chili.Extras.ChiliDog
{
    class ChiliDogCombinedStage2 : CustomItemGroup
    {
        public override string UniqueNameID => "Combined Chili Dog Stage 2";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Combined2");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "ChDogC";

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Main.ChiliDogCombined,
                    Main.GratedCheese,
                }
            },
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {

            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Bun"),
                MaterialUtils.GetExistingMaterial("Bread - Bun"),
                MaterialUtils.GetExistingMaterial("Bread - Bun")
            };          
            MaterialUtils.ApplyMaterial(Prefab, "Bun", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Well-done  Burger"); // Well-done  Burger has 2 spaces
            materials[1] = MaterialUtils.GetExistingMaterial("Well-done  Burger");
            materials[2] = MaterialUtils.GetExistingMaterial("Well-done  Burger");
            MaterialUtils.ApplyMaterial(Prefab, "Dog", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[1] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            materials[2] = MaterialUtils.GetExistingMaterial("Plastic - Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "Cheese", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Flesh");
            materials[1] = MaterialUtils.GetExistingMaterial("Tomato Flesh");
            materials[2] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "Chili", materials);
        }
    }
}
