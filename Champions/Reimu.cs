﻿using BepInEx.Logging;
using MonsterTrainModdingAPI;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using System.Collections.Generic;
using static MonsterTrainModdingAPI.Constants.VanillaCardPoolIDs;

namespace RetrospectiveUnknownVoyage.Champions
{
    class Reimu
    {
        public const string ID = "Reimu";
        public static CardData Make()
        {
            ChampionCardDataBuilder championCardDataBuilder = new ChampionCardDataBuilder
            {
                Cost = 0,
                Champion = BuildUnit(),
                ChampionIconPath = "influka/Clan/Icon_ClassSelect_Reimu.png",
                ChampionSelectedCue = "",
                //StarterCardData
                CardID = ID,
                NameKey = ID + "_Name",
                OverrideDescriptionKey = ID + "_Desc",
                LinkedClass = RetrospectiveUnknownVoyage.getClan(),
                ClanID = TouhouClan.ID,
                CardPoolIDs = new List<string> {TouhouClan.ID, UnitsAllBanner},
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

                //Borderline 1:
	                // + 5 Attack
                    // + Incant: Gain Damage Shield 1

                //Borderline 2:
	               // + 15 Attack
                   // + Incant: Gain Damage Shield 2

                //Borderline 3:
	               // + 30 Attack
                   // + Incant: Gain Damage Shield 3

                //Fantasy_Sealer 1:
	               // +10 Health
	               // + Action: If an enemy has 40 HP or less, kill it

                //Fantasy - Sealer 2:
	               // + 20 Health
	               // + Action: If an enemy has 60 HP or less, kill it

                //Fantasy - Sealer 3:
	               // + 35 Health
                   // + Action: If an enemy has 100 HP or less, kill it

                //Youkai Hunter 1:
	               // + 20 Attack
                   //  + 10 Health
                   // + Extinguish: Gain 3 Gold

                //Youkai Hunter 2:
	               // + 45 Attack
                   // + 20 Health
                   // + Extinguish : Gain 4 Gold

                //Youkai Hunter 3:
	               // + 95 Attack
                   // + 30 Health
                   // + Extinguish : Gain 5 Gold

               UpgradeTrees = new List<List<CardUpgradeDataBuilder>>
                {

                    new List<CardUpgradeDataBuilder>
                    {
                        // Borderline
                    
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Fantasy-Sealer
                    },
                    new List<CardUpgradeDataBuilder>
                    {
                        // Youkai Hunter
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
            return characterDataBuilder;
        }
    }
}
