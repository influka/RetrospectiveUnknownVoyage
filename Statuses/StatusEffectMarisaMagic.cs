using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;

namespace RetrospectiveUnknownVoyage.Statuses
{
    class StatusEffectMarisaMagic : StatusEffectState
    {
        public const string ID = "marisaMagic";

        public override void OnStacksAdded(CharacterState character, int numStacksAdded)
        {
            bool found = false;
            var myModifiers = character.GetRoomStateModifiers();
            foreach(var modifier in myModifiers)
            {
                if (modifier is RoomStateMagicalPowerModifier magicalPowerModifier)
                {
                    var paramInt = AccessTools.Field(typeof(RoomStateModifierBase), "paramInt");
                    paramInt.SetValue(magicalPowerModifier, (int) paramInt.GetValue(magicalPowerModifier) + numStacksAdded);
                    found = true;
                }
            }
            if (!found)
            {
                myModifiers.Add(new RoomStateMagicalPowerModifier());
            }
        }

        public static void Make()
        {
            new StatusEffectDataBuilder
            {
                StatusEffectStateName = typeof(StatusEffectMarisaMagic).AssemblyQualifiedName,
                StatusId = ID,
                DisplayCategory = StatusEffectData.DisplayCategory.Positive,
                TriggerStage = StatusEffectData.TriggerStage.None,
                IsStackable = false,
                IconPath = "influka/Status/spellcaster.png",
            }.Build();
        }
    }
}
