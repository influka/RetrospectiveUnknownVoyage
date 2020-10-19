using System;
using System.Collections.Generic;
using System.Text;
using MonsterTrainModdingAPI.Builders;
using System.Collections.Generic;
using static MonsterTrainModdingAPI.Constants.VanillaStatusEffectIDs;

namespace RetrospectiveUnknownVoyage.Upgrades.Reimu
{
    class BorderlineLunatic
    {
        public static string IDName = "BorderlineLunatic";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder cardUpgradeDataBuilder = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                //BonusDamage = 6,

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
                                ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { count=3, statusId=DamageShield } }
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

