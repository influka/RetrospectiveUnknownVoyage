using BepInEx;
using HarmonyLib;
using MonsterTrainModdingAPI;
using MonsterTrainModdingAPI.Interfaces;
using MonsterTrainModdingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using RetrospectiveUnknownVoyage.Champions;
using RetrospectiveUnknownVoyage.Characters;
using RetrospectiveUnknownVoyage.Cards;
using RetrospectiveUnknownVoyage.Relics;
using BepInEx.Logging;

namespace RetrospectiveUnknownVoyage
{
    [BepInPlugin(MODGUID, MODNAME, VERSION)]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class RetrospectiveUnknownVoyage : BaseUnityPlugin, IInitializable
    {
        public const string MODGUID = "com.influka.RetrospectiveUnknownVoyage";
        public const string MODNAME = "Retrospective Unknown Voyage";
        public const string VERSION = "0.0";
        private static ClassData clanRef;
        public static readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource(MODNAME);
        void Awake()
        {
            var harmony = new Harmony(MODGUID);
            harmony.PatchAll();
        }

        public void Initialize()
        {
            CustomLocalizationManager.ImportCSV("influka/Touhou.csv", ';');
            clanRef = TouhouClan.Make();

            AliceGift.Make();
            Alice.Make();

            Marisa.Make();
            Reimu.Make();

            TouhouClan.RegisterBanner();
            TouhouPlaceholder.Make();
        }
        public static ClassData getClan() { return clanRef; }
    }
}
