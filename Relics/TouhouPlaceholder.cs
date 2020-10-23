using System;
using System.Collections.Generic;
using System.Text;

using Trainworks.Builders;
using System.Collections.Generic;
using static Trainworks.Constants.VanillaRelicPoolIDs;

namespace RetrospectiveUnknownVoyage.Relics
{
    class TouhouPlaceholder
    {
        public static string ID = "TouhouPlaceholder";

        public static void Make()
        {
            var relic = new CollectableRelicDataBuilder
            {
                IconPath = "influka/Relic/debug.png",
                RelicPoolIDs = new List<string> { MegaRelicPool },
                EffectBuilders = new List<RelicEffectDataBuilder>
                {
                }
            };
            AssetAdder.AddRelic(relic, ID);

            var r = relic.BuildAndRegister();
            r.GetNameEnglish();
        }
    }
}
