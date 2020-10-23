using Trainworks.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static Trainworks.Constants.VanillaStatusEffectIDs;
using RetrospectiveUnknownVoyage.Statuses;
namespace RetrospectiveUnknownVoyage.Upgrades.Marisa
{
    class SpellcasterNormal
    {
        public static string IDName = "SpellcasterNormal";

        public static CardUpgradeDataBuilder Builder()
        {

            CardUpgradeDataBuilder cardUpgradeDataBuilder = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                //BonusDamage = 4,

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
                                ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { count=1, statusId=StatusEffectMarisaMagic.ID } }
                            }
                        },

                    },
                },
            };
            return cardUpgradeDataBuilder;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }
    }
}
