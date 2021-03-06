﻿
using System.Collections.Generic;
using Trainworks.Builders;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace RetrospectiveUnknownVoyage
{
    class AssetAdder
    {
        public static string rootPath = "influka/";
        public static string ucardPath = "Cards/UnitCardArt/";
        public static string scardPath = "Cards/SpellCardArt/";
        public static string unitPath = "Units/";
        public static string relicPath = "Relic/";

        public static void AddSpell(CardDataBuilder r, string IDName)
        {
            r.CardID = IDName;
            r.NameKey = IDName + "_Name";
            r.OverrideDescriptionKey = IDName + "_Desc";
            r.LinkedClass = RetrospectiveUnknownVoyage.getClan();
            r.ClanID = TouhouClan.ID;
            r.CardPoolIDs = new List<string> { TouhouClan.ID, MegaPool };

            r.AssetPath = rootPath + scardPath;


            //API.Log(BepInEx.Logging.LogLevel.All, string.Join("\t", new string[] { "Spell", r.NameKey.Localize(), r.Rarity.ToString(), r.Cost.ToString(), r.OverrideDescriptionKey.Localize() }));
        }

        public static void AddRelic(CollectableRelicDataBuilder r, string ID)
        {
            r.CollectableRelicID = ID;
            r.NameKey = ID + "_Name";
            r.DescriptionKey = ID + "_Desc";
            r.RelicActivatedKey = ID + "_Active";
            r.RelicLoreTooltipKeys = new List<string> { ID + "_Lore" };
            r.ClanID = TouhouClan.ID;
            r.Rarity = CollectableRarity.Common;
            r.IsBossGivenRelic = false;

        }

        public static void AddUnit(CardDataBuilder r, string IDName, CharacterData character)
        {
            r.CardID = IDName;
            r.NameKey = IDName + "_Name";
            r.OverrideDescriptionKey = IDName + "_Desc";
            r.LinkedClass = RetrospectiveUnknownVoyage.getClan();
            r.ClanID = TouhouClan.ID;
            r.CardPoolIDs = new List<string> { TouhouClan.ID, UnitsAllBanner };
            r.CardType = CardType.Monster;
            r.TargetsRoom = true;

            r.AssetPath = rootPath + ucardPath;
            r.EffectBuilders.Add(
                new CardEffectDataBuilder
                {
                    EffectStateName = "CardEffectSpawnMonster",
                    TargetMode = TargetMode.DropTargetCharacter,
                    ParamCharacterData = character,
                });

            //API.Log(BepInEx.Logging.LogLevel.All, string.Join("\t", new string[] { "Unit", r.NameKey.Localize(), r.Rarity.ToString(), r.Cost.ToString(), character.GetSize().ToString(), character.GetHealth().ToString(), character.GetAttackDamage().ToString(), character.GetLocalizedSubtype(), r.OverrideDescriptionKey.Localize() }));
        }

        public static void AddImg(CardDataBuilder r, string imgName)
        {
            r.AssetPath = r.AssetPath + imgName + ".png";
        }

        public static void AddUnitImg(CharacterDataBuilder r, string imgName)
        {
            r.AssetPath = rootPath + unitPath + imgName + ".png";
        }

        //public static void AddUnitAnim(CharacterDataBuilder r, string imgName)
        //{
        //    r.BundleLoadingInfo = new BundleAssetLoadingInfo
        //    {
        //        FilePath = "influka/gensokyo_units",
        //        SpriteName = "assets/" + imgName + ".png",
        //        ObjectName = "assets/" + imgName + ".prefab",
        //        AssetType = AssetRefBuilder.AssetTypeEnum.Character
        //    };
        //}

        //public static void AddCardPortrait(CardDataBuilder r, string imgName)
        //{
        //    r.BundleLoadingInfo = new BundleAssetLoadingInfo
        //    {
        //        FilePath = "influka/gensokyo_units",
        //        SpriteName = "assets/cardart/" + imgName.ToLower() + ".png",
        //        AssetType = AssetRefBuilder.AssetTypeEnum.CardArt
        //    };
        //}
    }
}