using MonsterTrainModdingAPI.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static MonsterTrainModdingAPI.Constants.VanillaStatusEffectIDs;

namespace RetrospectiveUnknownVoyage.Upgrades.Reimu
{
    class BorderlineHard
    {
        public static string IDName = "BorderlineHard";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder cardUpgradeDataBuilder = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                //BonusDamage = 5,

                //traitDataUpgradeBuilders = new List<CardTraitDataBuilder> { },
                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.CardSpellPlayed,
                        DescriptionKey = IDName + "_Desc",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = "CardEffectAddStatusEffect",
                                TargetMode = TargetMode.Self,
                                ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { count=2, statusId=DamageShield } }
                            }
                        }
                    },
                },
            };
            return cardUpgradeDataBuilder;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }
    }
}
