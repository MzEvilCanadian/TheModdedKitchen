using ApplianceLib.Api.References;
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
using KitchenLib.Customs;
using ModdedKitchen.Mains.GrilledCheese;
using ModdedKitchen.Mains.GrilledCheese.MonteCristo;
using ModdedKitchen.Dishes;
using ModdedKitchen.GrilledCheeseXToppings;
using ModdedKitchen.Desserts.ApplePiewIcecream;
using ModdedKitchen.AppleCrisp;
using ModdedKitchen.Sides.MacNCheese;
using ModdedKitchen.Starters.Bruschetta;
using ModdedKitchen.Starters.GarlicBread;
using ModdedKitchen.Desserts.ChocolatePuddingPie;
using ModdedKitchen.Starters.MozzaSticks;
using ModdedKitchen.Desserts.AppleRings;
using ModdedKitchen.Registry;
using ModdedKitchen.Desserts.BananaBread;
using ModdedKitchen.Sides.Milk;
using ModdedKitchen.Mains.Chili.Extras;
using ModdedKitchen.Mains.Chili;
using ModdedKitchen.Mains.Chili.Extras.Toppings;
using ModdedKitchen.Mains.Chili.Extras.Ingredients;
using ModdedKitchen.Mains.Chili.Extras.Deluxe;
using ModdedKitchen.Mains.Chili.Extras.ChiliDog;
using ModdedKitchen.Desserts.RicePudding;
using ModdedKitchen.Starters.SoupoftheDay;
using ModdedKitchen.Sides.Bacon;
using ModdedKitchen.Mains.Lasagna;

namespace ModdedKitchen
{
    class Main : BaseMod
    {
        internal const string MOD_ID = "The Modded Kitchen";
        internal const string MOD_NAME = "The Modded Kitchen";
        internal const string MOD_VERSION = "1.4.0";
        internal const string MOD_AUTHOR = "MzEvilCanadian";
        public const string MOD_GAMEVERSION = ">=1.1.3";


        public static AssetBundle bundle;

        // Vanilla Dishes
        internal static Dish HotdogDish => GetExistingGDO<Dish>(DishReferences.HotdogBase);

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
        internal static Item TomatoSauce => GetExistingGDO<Item>(ItemReference.TomatoSauce);
        internal static Item Egg => GetExistingGDO<Item>(ItemReference.Egg);
        internal static Item EggCracked => GetExistingGDO<Item>(ItemReference.EggCracked);
        internal static Item Apple => GetExistingGDO<Item>(ItemReference.Apple);
        internal static Item AppleSlices => GetExistingGDO<Item>(ItemReference.AppleSlices);
        internal static Item Sugar => GetExistingGDO<Item>(ItemReference.Sugar);
        internal static Item BreadCrumbs => GetExistingGDO<Item>(ItemReference.Breadcrumbs);
        internal static Item VanillaIceCream => GetExistingGDO<Item>(ItemReference.IceCreamVanilla);
        internal static Item ApplePie => GetExistingGDO<Item>(ItemReference.PieAppleCooked);
        internal static Item Oil => GetExistingGDO<Item>(ItemReference.Oil);
        internal static Item OilIngredient => GetExistingGDO<Item>(ItemReference.OilIngredient);
        internal static Item Onion => GetExistingGDO<Item>(ItemReference.Onion);
        internal static Item OnionChopped => GetExistingGDO<Item>(ItemReference.OnionChopped);
        internal static Item PieCrust => GetExistingGDO<Item>(ItemReference.PieCrustCooked);
        internal static Item BurntBread => GetExistingGDO<Item>(ItemReference.BurnedBread);
        internal static Item Dough => GetExistingGDO<Item>(ItemReference.Dough);
        internal static Item SteakWellDone => GetExistingGDO<Item>(ItemReference.SteakWelldone);
        internal static Item Meat => GetExistingGDO<Item>(ItemReference.Meat);
        internal static Item Corn => GetExistingGDO<Item>(ItemReference.CornRaw);
        internal static Item HuskedCorn => GetExistingGDO<Item>(ItemReference.CornHusked);
        internal static Item ChoppedMeat => GetExistingGDO<Item>(ItemReference.MeatChopped);
        internal static Item Rice => GetExistingGDO<Item>(ItemReference.Rice);
        internal static Item RiceCooked => GetExistingGDO<Item>(ItemReference.RiceContainerCooked);
        internal static Item Beans => GetExistingGDO<Item>(ItemReference.BeansIngredient);
        internal static Item DogBun => GetExistingGDO<Item>(ItemReference.HotdogBun);
        internal static Item CookedHotDog => GetExistingGDO<Item>(ItemReference.HotdogCooked);
        internal static Item HotDog => GetExistingGDO<Item>(ItemReference.HotdogRaw);
        internal static Item DepletedSoup => GetExistingGDO<Item>(ItemReference.SoupDepleted);
        internal static Item Broth => GetExistingGDO<Item>(ItemReference.BrothCookedOnion);
        internal static Item Pumpkin => GetExistingGDO<Item>(ItemReference.Pumpkin);
        internal static Item PumpkinHallow => GetExistingGDO<Item>(ItemReference.PumpkinHollow);
        internal static Item Broccoli => GetExistingGDO<Item>(ItemReference.BroccoliRaw);
        internal static Item Carrot => GetExistingGDO<Item>(ItemReference.Carrot);
        internal static Item Lettuce => GetExistingGDO<Item>(ItemReference.Lettuce);
        internal static Item Mushroom => GetExistingGDO<Item>(ItemReference.Mushroom);
        internal static Item Potato => GetExistingGDO<Item>(ItemReference.Potato);

        // Vanilla Items
        internal static Item Plate => GetExistingGDO<Item>(ItemReference.Plate);
        internal static Item DirtyPlate => GetExistingGDO<Item>(ItemReference.PlateDirty);
        internal static Item Ketchup => GetExistingGDO<Item>(ItemReference.CondimentKetchup);
        internal static Item Mustard => GetExistingGDO<Item>(ItemReference.CondimentMustard);
        internal static Item Pot => GetExistingGDO<Item>(ItemReference.Pot);
        internal static Item Water => GetExistingGDO<Item>(ItemReference.Water);
        internal static Item ServingBoard => GetExistingGDO<Item>(ItemReference.ServingBoard);

        // Ingredients Lib Ingredients

        public static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("butter"));
        public static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("butter"));
        public static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("bacon"));
        public static Item UncookedBacon => Find<Item>(IngredientLib.References.GetIngredient("chopped pork"));
        public static Item Pork => Find<Item>(IngredientLib.References.GetIngredient("pork"));
        public static Item Ham => Find<Item>(IngredientLib.References.GetIngredient("porkchop"));
        public static Item Milk => Find<Item>(IngredientLib.References.GetIngredient("milk"));
        public static Item MilkIngredient => Find<Item>(IngredientLib.References.GetSplitIngredient("milk"));
        public static Item CookedMacaroni => Find<Item>(IngredientLib.References.GetIngredient("cooked potted macaroni"));
        public static Item Macaroni => Find<Item>(IngredientLib.References.GetIngredient("macaroni"));
        public static Item Garlic => Find<Item>(IngredientLib.References.GetIngredient("garlic"));
        public static Item MincedGarlic => Find<Item>(IngredientLib.References.GetIngredient("minced garlic"));
        public static Item Chocolate => Find<Item>(IngredientLib.References.GetIngredient("chocolate"));
        public static Item ChoppedChocolate => Find<Item>(IngredientLib.References.GetIngredient("chopped chocolate"));
        public static Item ChocolateFilling => Find<Item>(IngredientLib.References.GetIngredient("chocolate sauce"));
        public static Item Cinnamon => Find<Item>(IngredientLib.References.GetIngredient("cinnamon"));
        public static Item Banana => Find<Item>(IngredientLib.References.GetIngredient("banana"));
        public static Item PeeledBanana => Find<Item>(IngredientLib.References.GetIngredient("peeled banana"));
        public static Item Oats => Find<Item>(IngredientLib.References.GetIngredient("oats"));
        public static Item Peppers => Find<Item>(IngredientLib.References.GetIngredient("peppers"));
        public static Item ChoppedPeppers => Find<Item>(IngredientLib.References.GetIngredient("chopped peppers"));
        public static Item WhippingCream => Find<Item>(IngredientLib.References.GetIngredient("whipping cream"));
        public static Item WhippedCream => Find<Item>(IngredientLib.References.GetIngredient("whipped cream"));
        public static Item Tortilla => Find<Item>(IngredientLib.References.GetIngredient("tortilla"));
        public static Item Noodles => Find<Item>(IngredientLib.References.GetIngredient("box pasta"));
        public static Item CookedNoodles => Find<Item>(IngredientLib.References.GetIngredient("cooked potted pasta"));


        // Appliance Lib
        public static Item Cup => ApplianceLibGDOs.Refs.Cup;


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
        internal static ItemGroup GrilledCheeseBT => GetModdedGDO<ItemGroup, GrilledCheeseBT>();

        // Apple Crisp & Apple Pie w Ice Cream
        internal static ItemGroup ApplePiewIceCream => GetModdedGDO<ItemGroup, ApplePieWithIceCream>();
        internal static Item CookedAppleCrisp => GetModdedGDO<Item, CookedAppleCrisp>();
        internal static Item BurntAppleCrisp => GetModdedGDO<Item, BurntAppleCrisp>();

        // Mac n Cheese
        internal static Item CookedMacNCheesePot => GetModdedGDO<Item, CookedMacNCheesePot>();
        internal static Item MacNCheeseServing => GetModdedGDO<Item, MacNCheeseServing>();

        // Bruschetta
        internal static Item BurntBruschetta => GetModdedGDO<Item, BurntBruschetta>();
        internal static Item CookedBread => GetModdedGDO<Item, CookedBread>();
        internal static ItemGroup AssembledBruschetta => GetModdedGDO<ItemGroup, AssembledBruschetta>();
        internal static ItemGroup PlatedBruschetta => GetModdedGDO<ItemGroup, PlatedBruschetta>();

        // Garlic Bread
        internal static Item BurntGarlicBread => GetModdedGDO<Item, BurntGarlicBread>();
        internal static ItemGroup PlatedGarlicBread => GetModdedGDO<ItemGroup, PlatedGarlicBread>();
        internal static Item CookedGarlicBread => GetModdedGDO<Item, CookedGarlicBread>();

        // Chocolate Pudding Pie
        internal static Item ChocolatePuddingPieServing => GetModdedGDO<Item, ChocolatePuddingPieServing>();

        // Mozza Sticks
        internal static Item BurntMozzaSticks => GetModdedGDO<Item, BurntMozzaSticks>();
        internal static ItemGroup CombinedMozzaSticks => GetModdedGDO<ItemGroup, CombinedMozzaSticks>();
        internal static Item CookedMozzaSticks => GetModdedGDO<Item, CookedMozzaSticks>();
        internal static ItemGroup MaranaraSauce => GetModdedGDO<ItemGroup, MaranaraSauce>();

        // Apple Rings
        internal static Item BurntAppleRings => GetModdedGDO<Item, BurntAppleRings>();
        internal static Item CookedAppleRings => GetModdedGDO<Item, CookedAppleRings>();

        // Banana Bread
        internal static Item BananaBreadLoaf => GetModdedGDO<Item, BananaBreadLoaf>();
        internal static Item BananaBreadSlice => GetModdedGDO<Item, BananaBreadSlice>();

        // Cornbread
        internal static Item CornBreadPortion => GetModdedGDO<Item, CornBreadPortion>();
        internal static Item CookedCornBread => GetModdedGDO<Item, CookedCornBread>();
        internal static Item BurntCornBread => GetModdedGDO<Item, BurntCornBread>();

        // Milk
        internal static ItemGroup MilkGlass => GetModdedGDO<ItemGroup, MilkGlass>();
        internal static Dish MilkDish => GetModdedGDO<Dish, MilkDish>();

        // Chili
        internal static ItemGroup ChiliPlated => GetModdedGDO<ItemGroup, ChiliPlated>();
        internal static Item ChiliPot => GetModdedGDO<Item, ChiliPot>();
        internal static Item ChiliPortion => GetModdedGDO<Item, ChiliPortion>();
        internal static Dish ChiliDish => GetModdedGDO<Dish, ChiliDish>();
        internal static ItemGroup UncookedChiliPot => GetModdedGDO<ItemGroup, UncookedChiliPot>();
        internal static ItemGroup ChiliXT => GetModdedGDO<ItemGroup, ChiliXT>();

        // Chili Dog
        internal static ItemGroup ChiliDogPlated => GetModdedGDO<ItemGroup, ChiliDogPlated>();
        internal static Dish ChilidogDish => GetModdedGDO<Dish, ChiliDogDish>();
        internal static Item ChiliDogCombinedStage2 => GetModdedGDO<Item, ChiliDogCombinedStage2>();
        internal static Item ChiliDogCombined => GetModdedGDO<Item, ChiliDogCombined>();

        // Deluxe Chili
        internal static Item DeluxeChiliPortion => GetModdedGDO<Item, DeluxeChiliPortion>();
        internal static Item DeluxeChiliPot => GetModdedGDO<Item, DeluxeChiliPot>();
        internal static ItemGroup DeluxeChiliPlated => GetModdedGDO<ItemGroup, DeluxeChiliPlated>();

        // Rice Pudding
        internal static Item RicePuddingPotCooked => GetModdedGDO<Item, RicePuddingPotCooked>();
        internal static Item RicePudding => GetModdedGDO<Item, RicePudding>();

        // Soup of the Day
        internal static Item SOTDServing => GetModdedGDO<Item, SOTDServing>();
        internal static Item SOTDPot => GetModdedGDO<Item, SOTDPot>();

        // Bacon Side
        internal static Item BaconSide => GetModdedGDO<Item, BaconSide>();
        internal static Item CookedBaconSide => GetModdedGDO<Item, CookedBaconSide>();
        internal static Dish BaconDish => GetModdedGDO<Dish, BaconDish>();

        // Lasagna

        internal static Item LasagnaPortion => GetModdedGDO<Item, LasagnaPortion>();
        internal static Item CookedLasagna => GetModdedGDO<Item, CookedLasagna>();
        internal static ItemGroup PlatedLasagna => GetModdedGDO<ItemGroup, PlatedLasagna>();


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
        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];


            // Dishes
            // Starters
            AddGameDataObject<BruschettaDish>();
            AddGameDataObject<GarlicBreadDish>();
            AddGameDataObject<MozzaSticksDish>();
            AddGameDataObject<SOTDDish>();


            // Mains
            AddGameDataObject<GrilledCheeseDish>();
            AddGameDataObject<MonteCristoDish>();

            AddGameDataObject<ChiliDish>();
            AddGameDataObject<DeluxeChiliDish>();
            AddGameDataObject<ChiliDogDish>();
            AddGameDataObject<HotdogChilidog>();

            AddGameDataObject<LasagnaDish>();

            // Extras
            AddGameDataObject<KetchupDish>();
            AddGameDataObject<MustardDish>();
            AddGameDataObject<AdditionalToppings>();

            AddGameDataObject<ChiliXTDish>();
            AddGameDataObject<ChiliDogKetchupDish>();


            // Sides
            AddGameDataObject<MacNCheeseDish>();
            AddGameDataObject<MilkDish>();
            AddGameDataObject<CornBreadDish>();
            AddGameDataObject<BaconDish>();

            // Desserts
            AddGameDataObject<ChocolatePuddingPieDish>();
            AddGameDataObject<AppleRingsDish>();
            AddGameDataObject<AppleCrispDish>();
            AddGameDataObject<BananaBreadDish>();
            AddGameDataObject<RicePuddingDish>();

            // Cards
            AddGameDataObject<ExtraMilkCard>();

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
            AddGameDataObject<GrilledCheeseBT>();

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

            // Chocolate Pudding Pie

            AddGameDataObject<ChocolatePuddingPieServing>();
            AddGameDataObject<ChocolatePuddingPieA>();

            // Mozza Sticks
            AddGameDataObject<BurntMozzaSticks>();
            AddGameDataObject<CombinedMozzaSticks>();
            AddGameDataObject<CookedMozzaSticks>();
            AddGameDataObject<MaranaraSauce>();
            AddGameDataObject<UncookedMozzaSticks>();

            // Apple Rings
            AddGameDataObject<BurntAppleRings>();
            AddGameDataObject<CookedAppleRings>();
            AddGameDataObject<UncookedAppleRings>();

            // Apple Crisp
            AddGameDataObject<BurntAppleCrisp>();
            AddGameDataObject<CookedAppleCrisp>();
            AddGameDataObject<UncookedAppleCrisp>();

            // Banana Bread
            AddGameDataObject<BananaBreadLoaf>();
            AddGameDataObject<BananaBreadSlice>();
            AddGameDataObject<UncookedBananaBread>();

            // Cornbread
            AddGameDataObject<UncookedCornBread>();
            AddGameDataObject<CornBreadPortion>();
            AddGameDataObject<CookedCornBread>();
            AddGameDataObject<BurntCornBread>();

            // Milk
            AddGameDataObject<MilkGlass>();

            // Chili
            AddGameDataObject<ChiliPlated>();
            AddGameDataObject<ChiliPortion>();
            AddGameDataObject<ChiliPot>();
            AddGameDataObject<UncookedChiliPot>();

            // Deluxe Chili
            AddGameDataObject<DeluxeChiliPlated>();
            AddGameDataObject<DeluxeChiliPortion>();
            AddGameDataObject<DeluxeChiliPot>();
            AddGameDataObject<UncookedDeluxeChili>();

            AddGameDataObject<ChiliXT>();
            AddGameDataObject<ChiliDogPlated>();
            AddGameDataObject<ChiliDogCombined>();
            AddGameDataObject<ChiliDogCombinedStage2>();

            // Rice Pudding 
            AddGameDataObject<RicePudding>();
            AddGameDataObject<RicePuddingPot>();
            AddGameDataObject<RicePuddingPotCooked>();

            // Soup of the Day
            AddGameDataObject<SOTDUncookedPot>();
            AddGameDataObject<SOTDPot>();
            AddGameDataObject<SOTDServing>();

            // Bacon Side
            AddGameDataObject<BaconSide>();
            AddGameDataObject<UncookedBaconSide>();
            AddGameDataObject<CookedBaconSide>();

            // Lasagna
            AddGameDataObject<LasagnaPortion>();
            AddGameDataObject<CookedLasagna>();
            AddGameDataObject<UncookedLasagna>();
            AddGameDataObject<PlatedLasagna>();

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

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }
        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }
    }
}
