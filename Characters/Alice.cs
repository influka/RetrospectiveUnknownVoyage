using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using RetrospectiveUnknownVoyage.Cards;

namespace RetrospectiveUnknownVoyage.Characters
{
    class Alice
    {
        public const string ID = "Alice";
        public static CardData Make()
        {

            CardDataBuilder cardDataBuilder = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common
            };

            AssetAdder.AddUnit(cardDataBuilder, ID, BuildUnit());
            AssetAdder.AddImg(cardDataBuilder, ID);

            return cardDataBuilder.BuildAndRegister();
        }

        public static CharacterData BuildUnit()
        {
            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();

            CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder
            {
                characterID = ID,
                NameKey = ID + "_Name",
                Size = 1,
                Health = 10,
                AttackDamage = 3,


                TriggerBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.PostCombat,
                        AdditionalTextOnTrigger = "",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddBattleCard),
                                ParamCardPool = cardPool,
                                ParamInt = 1
                            }
                        }
                    }
                }
            };
            AssetAdder.AddUnitImg(characterDataBuilder, ID);

            CardData forPool = CustomCardManager.GetCardDataByID(AliceGift.ID);

            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);
            cardDataList.Add(forPool);

            return characterDataBuilder.BuildAndRegister();
        }
    }
}
