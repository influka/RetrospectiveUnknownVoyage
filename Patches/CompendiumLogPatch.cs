using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetrospectiveUnknownVoyage.Patches
{
    [HarmonyPatch(typeof(CompendiumRelicCollection), "Set")]
    public class CompendiumLogPatch
    {
        [HarmonyPrefix]
        static void DoLog(ref CompendiumRelicCollection.Data data)
        {
            RetrospectiveUnknownVoyage.Log.Log(LogLevel.Debug, "hi");
        }
    }
}
