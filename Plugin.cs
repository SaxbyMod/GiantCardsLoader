using BepInEx;
using BepInEx.Configuration;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;

namespace ExampleMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        Harmony harmony = new Harmony(PluginGuid);

        // These are variables that exist everywhere in the entire class.
        private const string PluginGuid = "creator.inscryption.bosscardsloader";
        private const string PluginName = "BossCardsLoader";
        private const string PluginVersion = "1.0.0";
        private const string PluginPrefix = "BossCardsLoader";
        private static ConfigEntry<string> ReplaceMoon;
        private static ConfigEntry<string> ReplaceLemoncello;

        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // This is where you would run all of your other methods.
        public void Awake()
        {
            ReplaceMoon = Config.Bind<string>("BossCardsLoader.ReplaceCards",
                        "Moon Replacement",
                        "",
                        "What card should replace the Moon?");
            ReplaceLemoncello = Config.Bind<string>("BossCardsLoader.ReplaceCards",
                        "Lemoncello Replacement",
                        "",
                        "What card should replace the Lemoncello?");
            AddMEGALADON();
            AddSUM();
            // Apply our harmony patches.
            harmony.PatchAll(typeof(Plugin));
            int i = 0;
            static void AddMEGALADON()
            {
                if (ReplaceLemoncello.BoxedValue.Equals("BossCardsLoader_MEGALADON") && ReplaceMoon.BoxedValue.Equals("BossCardsLoader_MEGALADON"))
                {
                    CardInfo Megaladon = CardManager.BaseGameCards.CardByName("!GIANTCARD_MOON")
                    .SetBasic(displayedName: "MEGALADON", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                    .SetCost(0, 0, 0, null)
                    .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                    .AddTraits(Trait.Giant)
                    .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    Megaladon.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));
                    CardInfo MegaladonShip = CardManager.BaseGameCards.CardByName("!GIANTCARD_SHIP")
                    .SetBasic(displayedName: "MEGALADON", attack: 1, health: 200, description: "Megaladon Bites Hard especially on Squirrels.")
                    .SetCost(0, 0, 0, null)
                    .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                    .AddTraits(Trait.Giant)
                    .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    MegaladonShip.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));
                }
                else if (ReplaceMoon.BoxedValue.Equals("BossCardsLoader_MEGALADON"))
                {
                    CardInfo Megaladon = CardManager.BaseGameCards.CardByName("!GIANTCARD_MOON")
                        .SetBasic(displayedName: "MEGALADON", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    Megaladon.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));
                }
                else if (ReplaceLemoncello.BoxedValue.Equals("BossCardsLoader_MEGALADON"))
                {
                    CardInfo Megaladon = CardManager.BaseGameCards.CardByName("!GIANTCARD_SHIP")
                         .SetBasic(displayedName: "MEGALADON", attack: 1, health: 200, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    Megaladon.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));
                }
                else
                {
                    CardInfo Megaladon = CardManager.New(modPrefix: "BossCardsLoader","!GIANTCARD_MEGALADON","MEGALADON",1,200,description: "Megaladon Bites Hard especially on Squirrels.")
                    .SetCost(0, 0, 0, null)
                    .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.RandomAbility, Ability.Reach)
                    .AddTraits(Trait.Giant)
                    .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                CardManager.Add("BossCardsLoader", Megaladon);
                Megaladon.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));
                }
            }
            i++;
            static void AddSUM()
            {
                if (ReplaceMoon.BoxedValue.Equals("BossCardsLoader_SUM") && ReplaceLemoncello.BoxedValue.Equals("BossCardsLoader_SUM"))
                {
                    CardInfo SUM = CardManager.BaseGameCards.CardByName("!GIANTCARD_MOON")
                        .SetBasic(displayedName: "Сумеречная", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    SUM.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("SUM.png"));
                    CardInfo SUMShip = CardManager.BaseGameCards.CardByName("!GIANTCARD_SHIP")
                        .SetBasic(displayedName: "Сумеречная", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    SUMShip.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("SUM.png"));
                }
                else if (ReplaceMoon.BoxedValue.Equals("BossCardsLoader_SUM"))
                {
                    CardInfo SUM = CardManager.BaseGameCards.CardByName("!GIANTCARD_MOON")
                        .SetBasic(displayedName: "Сумеречная", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    SUM.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("SUM.png"));
                }
                else if (ReplaceLemoncello.BoxedValue.Equals("BossCardsLoader_SUM"))
                {
                    CardInfo SUM = CardManager.BaseGameCards.CardByName("!GIANTCARD_SHIP")
                        .SetBasic(displayedName: "Сумеречная", attack: 2, health: 40, description: "Megaladon Bites Hard especially on Squirrels.")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    SUM.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("SUM.png"));
                }
                else
                {
                    CardInfo SUM = CardManager.New(modPrefix: "BossCardsLoader","!GIANTCARD_SUM","Сумеречная",2,40,description: "Megaladon Bites Hard especially on Squirrels")
                        .SetCost(0, 0, 0, null)
                        .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.MadeOfStone, Ability.Reach)
                        .AddTraits(Trait.Giant)
                        .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                        .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait);
                    CardManager.Add("BossCardsLoader", SUM);
                    SUM.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("SUM.png"));
                }
            }
            i++;
            Logger.LogInfo($"Loaded {i} Boss Cards!");
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
