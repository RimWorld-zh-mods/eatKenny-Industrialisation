using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace Industrialisation
{
	public class PlaceWorker_HandWaterPump : PlaceWorker
	{
		public const int minDistanceBetweenTwoWaterPump = 15;

		public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot)
		{
			TerrainDef terrainDef = Find.TerrainGrid.TerrainAt(loc);
			if (terrainDef != TerrainDef.Named("WaterShallow") && terrainDef != TerrainDef.Named("WaterDeep") && terrainDef != TerrainDef.Named("Marsh"))
			{
				return new AcceptanceReport("Water pump must be placed on a Water.");
			}
			List<Thing> list = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef);
			List<Thing> list2 = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef.blueprintDef);
			List<Thing> list3 = Find.ListerThings.ThingsOfDef(Util_Industrialisation.WaterPumpDef.frameDef);
			if (list != null && (from building in list
			where loc.InHorDistOf(building.Position, 15f)
			select building).Count<Thing>() > 0)
			{
				return new AcceptanceReport("An other water pump is too close.");
			}
			if (list2 != null && (from building in list2
			where loc.InHorDistOf(building.Position, 15f)
			select building).Count<Thing>() > 0)
			{
				return new AcceptanceReport("An other water pump blueprint is too close.");
			}
			if (list3 != null && (from building in list3
			where loc.InHorDistOf(building.Position, 15f)
			select building).Count<Thing>() > 0)
			{
				return new AcceptanceReport("An other water pump frame is too close.");
			}
			return true;
		}
	}
}