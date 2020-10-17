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
        void Awake()
        {
            var harmony = new Harmony(MODGUID);
            harmony.PatchAll();
        }

        public void Initialize()
        {
            CustomLocalizationManager.ImportCSV("influka/Touhou.csv", ';');
            clanRef = TouhouClan.Make();

            Marisa.Make();
            Reimu.Make();

            AliceGift.Make();
            Alice.Make();
            //RegisterSubtypes();
            //MakeStatuses();
            //MakeEnhancers();

            //MakeCards();

            //foreach (var bundle in BundleManager.LoadedAssetBundles)
            //{
            //    API.Log(BepInEx.Logging.LogLevel.All, bundle.Value.GetAllAssetNames().Join());
            //}

            //SecondDisciple.Make();
            //Disciple.Make();
            //Clan.RegisterBanner();
            //MakeArtifacts();

            //PrintCardStats();
            //foreach (SubtypeData s in SubtypeManager.AllData)
            //{
            //    API.Log(BepInEx.Logging.LogLevel.All, "Subtype: " + s.LocalizedName + " - Key: " + s.Key);
            //}
        }
        public static ClassData getClan() { return clanRef; }
    }
}
