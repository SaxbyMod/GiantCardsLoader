using BepInEx;
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

        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // This is where you would run all of your other methods.
        private void Awake()
        {
            AddTest();
            // Apply our harmony patches.
            harmony.PatchAll(typeof(Plugin));
            int i = 0;
            static void AddTest()
            {
                CardInfo Megaladon = CardManager.New(

                    // Card ID Prefix
                    modPrefix: "BossCardsLoader",

                    // Card internal name.
                    "!GIANTCARD_MEGALADON",
                    // Card display name.
                    "MEGALADON",
                    // Attack.
                    1,
                    // Health.
                    200,
                    // Descryption.
                    description: "Megaladon Bites Hard especially on Squirrels"
                )
                .SetCost(0, 0, 0, null)
                .AddAbilities(Ability.AllStrike, Ability.SquirrelOrbit, Ability.RandomAbility, Ability.Reach)
                .AddTraits(Trait.Giant)
                .AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
                .AddAppearances(CardAppearanceBehaviour.Appearance.GiantAnimatedPortrait)
                ;
                CardManager.Add("BossCardsLoader", Megaladon);


                Megaladon.animatedPortrait = GiantCardManager.Plugin.CreateGiantCard(TextureHelper.GetImageAsTexture("MEGALADON.png"));

            }
            i++;
            Logger.LogInfo($"Loaded {i} Boss Cards!");
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
