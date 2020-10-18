using HarmonyLib;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using System.Collections.Generic;
using UnityEngine;
using static MonsterTrainModdingAPI.Constants.VanillaCardPoolIDs;

namespace RetrospectiveUnknownVoyage
{
    class TouhouClan
    {
        public static string ID = "Touhou";

        public static ClassData Make()
        {
            ClassDataBuilder clan = new ClassDataBuilder
            {
                ClassID = ID,
                DraftIconPath = "influka/Clan/Icon_CardBack_Touhou.png",

                IconAssetPaths = new List<string>
                {
                    "influka/Clan/ClanLogo_92.png", // Clan Choice Icon
                    "influka/Clan/ClanLogo_92.png", // Also compendium...? 56x56
                    "influka/Clan/ClanLogo_92.png", // Large Coloured Icon
                    "influka/Clan/ClanLogo_Silhouette.png", // Compendium Silhouette 56x56
                },

                CardFrameUnitPath = "influka/Clan/unit-cardframe-touhou.png",
                CardFrameSpellPath = "influka/Clan/spell-cardframe-touhou.png",

                UiColor = new Color(0.964f, 0.729f, 0.015f, 1f),
                UiColorDark = new Color(0.12f, 0.375f, 0.5f, 1f),
            };

            return clan.BuildAndRegister();
        }

        public static void RegisterBanner()
        {
            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);

            foreach (var card in CustomCardManager.CustomCardData)
            {
                if (card.Value.GetLinkedClassID() == RetrospectiveUnknownVoyage.getClan().GetID() && card.Value.GetSpawnCharacterData() != null && !card.Value.GetSpawnCharacterData().IsChampion())
                {
                        cardDataList.Add(card.Value);
                }

                new RewardNodeDataBuilder()
                {
                    RewardNodeID = "Touhou_UnitBanner",
                    MapNodePoolIDs = new List<string> { "RandomChosenMainClassUnit", "RandomChosenSubClassUnit" },
                    Name = "RewardNodeData_Touhou_UnitBanner_TooltipBodyKey",
                    Description = "RewardNodeData_Touhou_UnitBanner_TooltipTitleKey",
                    RequiredClass = RetrospectiveUnknownVoyage.getClan(),
                    FrozenSpritePath = "influka/Clan/POI_Map_Clan_Touhou_Frozen.png",
                    EnabledSpritePath = "influka/Clan/POI_Map_Clan_Touhou_Enabled.png",
                    EnabledVisitedSpritePath = "influka/Clan/POI_Map_Clan_Touhou_Enabled.png",
                    DisabledSpritePath = "influka/Clan/POI_Map_Clan_Touhou_Disabled.png",
                    DisabledVisitedSpritePath = "influka/Clan/POI_Map_Clan_Touhou_VisitedDisabled.png",
                    GlowSpritePath = "influka/Clan/MSK_Map_Clan_Touhou_01.png",
                    MapIconPath = "influka/Clan/POI_Map_Clan_Touhou_Enabled.png",
                    MinimapIconPath = "influka/Clan/Icon_MiniMap_ClanBanner.png",
                    SkipCheckInBattleMode = true,
                    OverrideTooltipTitleBody = false,
                    NodeSelectedSfxCue = "Node_Banner",
                    RewardBuilders = new List<IRewardDataBuilder>
                    {
                        new DraftRewardDataBuilder()
                        {
                            DraftRewardID = "Touhou_UnitsDraft",
                            _RewardSpritePath = "influka/Clan/POI_Map_Clan_Touhou_Enabled.png",
                            _RewardTitleKey = "TouhouReward_Title",
                            _RewardDescriptionKey = "TouhouReward_Desc",
                            Costs = new int[] { 100 },
                            _IsServiceMerchantReward = false,
                            DraftPool = cardPool,
                            ClassType = (RunState.ClassType)7,
                            DraftOptionsCount = 2,
                            RarityFloorOverride = CollectableRarity.Uncommon
                        }
                    }
                }.BuildAndRegister();
            }
        }

    }
}

