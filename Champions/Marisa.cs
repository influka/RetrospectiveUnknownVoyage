using BepInEx.Logging;
using System.Collections.Generic;
using static Trainworks.Constants.VanillaCardPoolIDs;
using RetrospectiveUnknownVoyage.Cards;
using RetrospectiveUnknownVoyage.Upgrades.Reimu;
using RetrospectiveUnknownVoyage.Upgrades.Marisa;
using Trainworks.Builders;
using Trainworks.Managers;

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
                StarterCardData = CustomCardManager.GetCardDataByID(AliceGift.ID),
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
            return championCardDataBuilder.BuildAndRegister(1);
        }
        public static CardUpgradeTreeDataBuilder GetUpgradeTreeDataBuilder()
        {
            CardUpgradeTreeDataBuilder cardUpgradeTreeDataBuilder = new CardUpgradeTreeDataBuilder
            {
                UpgradeTrees = new List<List<CardUpgradeDataBuilder>>
                {
                    //new List<CardUpgradeDataBuilder>
                    //{
                    //    // SpellCaster:
                    //    // Incant: Gain 1 Spell Power
                    //    // +20 (40) (60) Health
                        
                    //},
                    //new List<CardUpgradeDataBuilder>
                    //{
                    //    // Charge-Up
                    //    // Multistrike 1 (2) (3)
                    //    // Strike: Double Marisa's attack
                    //},
                    //new List<CardUpgradeDataBuilder>
                    //{
                    //    // Thief
                    //    // + 20 (45) (95) Attack
                    //    // + 10 Health + 20 + 30 Health
                    //    // Extinguish : Gain a random Artifact.
                    //}

                    new List<CardUpgradeDataBuilder>
                    {
                        BorderlineNormal.Builder(),
                        BorderlineHard.Builder(),
                        BorderlineLunatic.Builder(),

                        // Borderline
                    
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Fantasy-Sealer
                        BorderlineNormal.Builder(),
                        BorderlineHard.Builder(),
                        BorderlineLunatic.Builder(),
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Youkai Hunter
                        BorderlineNormal.Builder(),
                        BorderlineHard.Builder(),
                        BorderlineLunatic.Builder(),
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

                RoomModifierBuilders = new List<RoomModifierDataBuilder>
                {
                    new RoomModifierDataBuilder
                    {
                        roomStateModifierClassType = typeof(RoomStateMagicalPowerModifier),
                        ParamInt = 0
                    }
                }

            };

            AssetAdder.AddUnitImg(characterDataBuilder, ID);

            // TODO: Magic Power this floor only
            return characterDataBuilder;
        }
    }
}
