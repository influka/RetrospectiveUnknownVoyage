using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetrospectiveUnknownVoyage.Patches
{
    class CompendiumLogPatch
    {
        [HarmonyPatch(typeof(CompendiumRelicCollection), "Set")]
        public class LogPatch
        {
            [HarmonyPrefix]
            static void DoLog(ref CompendiumRelicCollection.Data data)
            {
                RetrospectiveUnknownVoyage.Log.Log(LogLevel.Debug, "helo");
            }
        }
    }
}
