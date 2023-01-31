using GrilledCheese.AppleCrisp;
using GrilledCheese.ApplePiewIceCream;
using GrilledCheese.GrilledCheeseProcess;
using GrilledCheese.MonteCristoProcess;
using GrilledCheese.Registry;
using GrilledCheese.Dishes;
using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using ItemReference = KitchenLib.References.ItemReferences;
using MacNCheese.Customs.MacNCheeseProcess;
using MacNCheese.Dishes;
using Bruschetta;
using Bruschetta.Dishes;
using GarlicBreadMod;
using GarlicBreadMod.Dishes;
using ChocolatePuddingPie;
using ChocolatePuddingPie.Dishes;

namespace GrilledCheese
{
    class Main : BaseMod
    {
        internal const string MOD_ID = "MzEvil'sKitchen";
        internal const string MOD_NAME = "MzEvil's Kitchen";
        internal const string MOD_VERSION = "0.0.6";
        internal const string MOD_AUTHOR = "MzEvilCanadian";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        public static AssetBundle bundle;

        // Filler prefabs
        internal static Item CookedDumplings => GetExistingGDO<Item>(ItemReference.CookedDumplings);

        // Vanilla Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);
        internal static Process Oven => GetExistingGDO<Process>(ProcessReferences.RequireOven);


        // Vanilla Ingredients

        internal static Item Flour => GetExistingGDO<Item>(ItemReference.Flour);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReference.Cheese);
        internal static Item GratedCheese => GetExistingGDO<Item>(ItemReference.CheeseGrated);
        internal static Item BreadSlice => GetExistingGDO<Item>(ItemReference.BreadSlice);
        internal static Item Tomato => GetExistingGDO<Item>(ItemReference.Tomato);
        internal static Item TomatoSlice => GetExistingGDO<Item>(ItemReference.TomatoChopped);
        internal static Item Egg => GetExistingGDO<Item>(ItemReference.Egg);
        internal static Item EggCracked => GetExistingGDO<Item>(ItemReference.EggCracked);
        internal static Item Apple => GetExistingGDO<Item>(ItemReference.Apple);
        internal static Item AppleSlices => GetExistingGDO<Item>(ItemReference.AppleSlices);
        internal static Item Sugar => GetExistingGDO<Item>(ItemReference.Sugar);
        internal static Item BreadCrumbs => GetExistingGDO<Item>(ItemReference.BreadBaked);
        internal static Item VanillaIceCream => GetExistingGDO<Item>(ItemReference.IceCreamVanilla);
        internal static Item ApplePie => GetExistingGDO<Item>(ItemReference.PieAppleCooked);
        internal static Item Oil => GetExistingGDO<Item>(ItemReference.Oil);
        internal static Item OilIngredient => GetExistingGDO<Item>(ItemReference.OilIngredient);
        internal static Item Onion => GetExistingGDO<Item>(ItemReference.Onion);
        internal static Item OnionChopped => GetExistingGDO<Item>(ItemReference.OnionChopped);
        internal static Item PieCrust => GetExistingGDO<Item>(ItemReference.PieCrustCooked);

        // Vanilla Items
        internal static Item Plate => GetExistingGDO<Item>(ItemReference.Plate);
        internal static Item DirtyPlate => GetExistingGDO<Item>(ItemReference.PlateDirty);
        internal static Item Ketchup => GetExistingGDO<Item>(ItemReference.CondimentKetchup);
        internal static Item Mustard => GetExistingGDO <Item>(ItemReference.CondimentMustard);
        internal static Item Pot => GetExistingGDO<Item>(ItemReference.Pot);
        internal static Item Water => GetExistingGDO <Item> (ItemReference.Water);
        internal static Item ServingBoard => GetExistingGDO<Item>(ItemReference.ServingBoard);

        // Ingredients Lib Ingredients

        public static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("butter"));
        public static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("butter"));
        public static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("bacon"));
        public static Item Pork => Find<Item>(IngredientLib.References.GetIngredient("pork"));
        public static Item Ham => Find<Item>(IngredientLib.References.GetIngredient("porkchop"));
        public static Item Milk => Find<Item>(IngredientLib.References.GetIngredient("milk"));
        public static Item MilkIngredient => Find<Item>(IngredientLib.References.GetSplitIngredient("milk"));
        public static Item CookedMacaroni => Find<Item>(IngredientLib.References.GetIngredient("cooked potted macaroni"));
        public static Item Macaroni => Find<Item>(IngredientLib.References.GetIngredient("macaroni"));
        public static Item Garlic => Find<Item>(IngredientLib.References.GetIngredient("garlic"));
        public static Item MincedGarlic => Find<Item>(IngredientLib.References.GetIngredient("minced garlic"));
        public static Item Chocolate => Find<Item>(IngredientLib.References.GetIngredient("chocolate"));
        public static Item ChocolateFilling => Find<Item>(IngredientLib.References.GetIngredient("chocolate sauce"));

        // Grilled Cheese
        internal static Item BurnedGrilledCheese => GetModdedGDO<Item, BurnedGrilledCheese>();
        internal static Item CookedGrilledCheese => GetModdedGDO<Item, CookedGrilledCheese>();
        internal static ItemGroup PlatedGrilledCheese => GetModdedGDO<ItemGroup, PlatedGrilledCheese>();
        internal static ItemGroup UncookedGrilledCheese => GetModdedGDO<ItemGroup, UncookedGrilledCheese>();

        // Monte Cristo
        internal static Item BurnedMonteCristo => GetModdedGDO<Item, BurntMonteCristo>();
        internal static Item CookedMonteCristo => GetModdedGDO<Item, CookedMonteCristo>();
        internal static ItemGroup PlatedMonteCristo => GetModdedGDO<ItemGroup, PlatedMonteCristo>();
        internal static ItemGroup UncookedMonteCristo => GetModdedGDO<ItemGroup, UncookedMonteCristo>();

        internal static Dish GrilledCheeseDish => GetModdedGDO<Dish, GrilledCheeseDish>();
        internal static ItemGroup GrilledCheeseAdditionalToppings => GetModdedGDO<ItemGroup, GrilledCheeseAdditionalToppings>();

        // Desserts
        internal static ItemGroup ApplePiewIceCream => GetModdedGDO<ItemGroup, ApplePieWithIceCream>();
        internal static Item CookedAppleCrisp => GetModdedGDO<Item, CookedAppleCrisp>();
        internal static Item BurntAppleCrisp => GetModdedGDO<Item, BurntAppleCrisp>();

        // Mac n Cheese
        internal static Item CookedMacNCheesePot => GetModdedGDO<Item, CookedMacNCheesePot>();
        internal static Item CookedMacNCheeseHalfPot => GetModdedGDO<Item, CookedMacNCheeseHalfPot>();
        internal static Item MacNCheeseServing => GetModdedGDO<Item, MacNCheeseServing>();
        internal static Dish MacNCheeseDish => GetModdedGDO<Dish, MacNCheeseDish>();

        // Bruschetta
        internal static Item BurntBruschetta => GetModdedGDO<Item, BurntBruschetta>();
        internal static Item CookedBread => GetModdedGDO<Item, CookedBread>();
        internal static ItemGroup UncookedBruschetta => GetModdedGDO<ItemGroup, UncookedBruschetta>();
        internal static ItemGroup AssembledBruschetta => GetModdedGDO<ItemGroup, AssembledBruschetta>();
        internal static ItemGroup PlatedBruschetta => GetModdedGDO<ItemGroup, PlatedBruschetta>();
        internal static Dish BruschettaDish => GetModdedGDO<Dish, BruschettaDish>();

        // Garlic Bread
        internal static Item BurntGarlicBread => GetModdedGDO<Item, BurntGarlicBread>();
        internal static ItemGroup UncookedGarlicBread => GetModdedGDO<ItemGroup, UncookedGarlicBread>();
        internal static ItemGroup PlatedGarlicBread => GetModdedGDO<ItemGroup, PlatedGarlicBread>();
        internal static Item CookedGarlicBread => GetModdedGDO<Item, CookedGarlicBread>();
        internal static Dish GarlicBreadDish => GetModdedGDO<Dish, GarlicBreadDish>();

        // Chocolate Pudding Pie
        internal static ItemGroup ChocolatePuddingPieA => GetModdedGDO<ItemGroup, ChocolatePuddingPieA>();
        internal static Item ChocolatePuddingPieServing => GetModdedGDO<Item, ChocolatePuddingPieServing>();



        internal static bool debug = true;
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogError(object _log) { LogError(_log.ToString()); }

        public Main() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, $"{MOD_GAMEVERSION}", Assembly.GetExecutingAssembly())
        {
            string bundlePath = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "Mods", ModID });

            Debug.Log($"{MOD_NAME} {MOD_VERSION} {MOD_AUTHOR}: Loaded");
            Debug.Log($"Assets Loaded From {bundlePath}");
        }


        public override void PostActivate(KitchenMods.Mod mod)
        {
            base.PostActivate(mod);
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            // Dishes
            AddGameDataObject<GrilledCheeseDish>();
            AddGameDataObject<MonteCristoDish>();
            AddGameDataObject<KetchupDish>();
            AddGameDataObject<MustardDish>();
            AddGameDataObject<AdditionalToppings>();
          //  AddGameDataObject<MacNCheeseDish>();
            AddGameDataObject<BruschettaDish>();
            AddGameDataObject<GarlicBreadDish>();
            AddGameDataObject<ChocolatePuddingPieDish>();

            // Grilled cheese
            AddGameDataObject<BurnedGrilledCheese>();
            AddGameDataObject<CookedGrilledCheese>();
            AddGameDataObject<UncookedGrilledCheese>();
            AddGameDataObject<PlatedGrilledCheese>();

            // Monte Cristo
            AddGameDataObject<BurntMonteCristo>();
            AddGameDataObject<CookedMonteCristo>();
            AddGameDataObject<UncookedMonteCristo>();
            AddGameDataObject<PlatedMonteCristo>();

            // Cards
            AddGameDataObject<GrilledCheeseAdditionalToppings>();

            // Mac n Cheese
            AddGameDataObject<UncookedPot>();
            AddGameDataObject<MacNCheeseServing>();
            AddGameDataObject<CookedMacNCheesePot>();
            AddGameDataObject<CookedMacNCheeseHalfPot>();

            // Bruschetta
            AddGameDataObject<BurntBruschetta>();
            AddGameDataObject<CookedBread>();
            AddGameDataObject<UncookedBruschetta>();
            AddGameDataObject<AssembledBruschetta>();
            AddGameDataObject<PlatedBruschetta>();

            // Garlic Bread
            AddGameDataObject<BurntGarlicBread>();
            AddGameDataObject<CookedGarlicBread>();
            AddGameDataObject<UncookedGarlicBread>();
            AddGameDataObject<PlatedGarlicBread>();

            // Chocolate PuddingPie

            AddGameDataObject<ChocolatePuddingPieServing>();
            AddGameDataObject<ChocolatePuddingPieA>();


            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                ModRegistry.HandleBuildGameDataEvent(args);
            };
        }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }
    }
}
