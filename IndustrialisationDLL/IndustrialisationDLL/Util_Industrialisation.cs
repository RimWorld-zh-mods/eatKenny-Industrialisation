using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;   // Always needed
//using VerseBase;   // Material/Graphics handling functions are found here
using RimWorld;      // RimWorld specific functions are found here
using Verse;         // RimWorld universal objects are here
//using Verse.AI;    // Needed when you do something with the AI
//using Verse.Sound; // Needed when you do something with the Sound

namespace Industrialisation
{
    public static class Util_Industrialisation
    {
        public static ThingDef HandWaterPumpDef
        {
            get
            {
                return (ThingDef.Named("WaterPump"));
            }
        }

        public static ThingDef WaterPumpDef
        {
            get
            {
                return (ThingDef.Named("WaterPump"));
            }
        }
    }
}
