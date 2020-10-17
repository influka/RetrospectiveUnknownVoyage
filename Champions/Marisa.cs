using BepInEx.Logging;
using MonsterTrainModdingAPI;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using System.Collections.Generic;
using static MonsterTrainModdingAPI.Constants.VanillaCardPoolIDs;

namespace RetrospectiveUnknownVoyage.Champions
{
    class Marisa
    {
        public const string ID = "Marisa";
        public static CardData Make()
        {
            ChampionCardDataBuilder championCardDataBuilder = new ChampionCardDataBuilder
            {
                Cost = 0,
                Champion = BuildUnit(),
                ChampionIconPath = "influka/Clan/Icon_ClassSelect_Marisa.png",
                ChampionSelectedCue = "",
                //StarterCardData
                CardID = ID,
                NameKey = ID + "_Name",
                OverrideDescriptionKey = ID + "_Desc",
                LinkedClass = RetrospectiveUnknownVoyage.getClan(),
                ClanID = TouhouClan.ID,
                CardPoolIDs = new List<string> { TouhouClan.ID, UnitsAllBanner },
                CardType = CardType.Monster,
                TargetsRoom = true,
                AssetPath = AssetAdder.rootPath + AssetAdder.ucardPath,
                UpgradeTree = GetUpgradeTreeDataBuilder(),
            };
            AssetAdder.AddImg(championCardDataBuilder, ID);
            return championCardDataBuilder.BuildAndRegister();
        }
        public static CardUpgradeTreeDataBuilder GetUpgradeTreeDataBuilder()
        {
            CardUpgradeTreeDataBuilder cardUpgradeTreeDataBuilder = new CardUpgradeTreeDataBuilder
            {
                UpgradeTrees = new List<List<CardUpgradeDataBuilder>>
                {
                    new List<CardUpgradeDataBuilder>
                    {
                        // SpellCaster:
                        // Resolve: Add "Master Spark" to your hand.
                        // +20 (40) (60) Health
                        
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Charge-Up
                        // Multistrike 1 (2) (3)
                        // Strike: Double Marisa's attack
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Thief
                        // + 20 (45) (95) Attack
                        // + 10 Health + 20 + 30 Health
                        // Extinguish : Gain a random Artifact.
                    }
                }
            };
            return cardUpgradeTreeDataBuilder;
        }
        public static CharacterDataBuilder BuildUnit()
        {
            // Monster card, so we build an attached unit
            CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder
            {
                CharacterID = ID,
                NameKey = ID + "_Name",

                Size = 2,
                Health = 10,
                AttackDamage = 5,
            };

            AssetAdder.AddUnitImg(characterDataBuilder, ID);

            // TODO: Magic Power this floor only
            return characterDataBuilder;
        }
    }
}
