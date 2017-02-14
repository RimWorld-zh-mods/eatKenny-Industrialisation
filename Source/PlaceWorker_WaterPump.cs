using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;


namespace Industrialisation
{
    public class PlaceWorker_WaterPump : PlaceWorker
    {
        public const int minDistanceBetweenTwoWaterPumps = 25;

        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Thing thingToIgnore = null)
        {
            List<Thing> WaterPumpList = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef);
            List<Thing> WaterPumpBlueprintList = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef.blueprintDef);
            List<Thing> WaterPumpFrameList = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef.frameDef);

            if (WaterPumpList != null)
            {
                IEnumerable<Thing> WaterPumpInTheArea = WaterPumpList.Where(building => loc.InHorDistOf(building.Position, minDistanceBetweenTwoWaterPumps));
                if (WaterPumpInTheArea.Count() > 0)
                {
                    return new AcceptanceReport("An other water pump is too close.");
                }
            }
            if (WaterPumpBlueprintList != null)
            {
                IEnumerable<Thing> WaterPumpBlueprintInTheArea = WaterPumpBlueprintList.Where(building => loc.InHorDistOf(building.Position, minDistanceBetweenTwoWaterPumps));
                if (WaterPumpBlueprintInTheArea.Count() > 0)
                {
                    return new AcceptanceReport("An other water pump blueprint is too close.");
                }
            }
            if (WaterPumpFrameList != null)
            {
                IEnumerable<Thing> WaterPumpFrameInTheArea = WaterPumpFrameList.Where(building => loc.InHorDistOf(building.Position, minDistanceBetweenTwoWaterPumps));
                if (WaterPumpFrameInTheArea.Count() > 0)
                {
                    return new AcceptanceReport("An other water pump frame is too close.");
                }
            }

            return true;
        }
    }
}