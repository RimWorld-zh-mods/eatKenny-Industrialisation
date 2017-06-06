using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace Industrialisation
{
    class Building_SkydrillerCallmaker_Calling : Building
    {
        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            var position = this.Position;
            var map = base.Map;
            base.Destroy(mode);
            GenSpawn.Spawn(ThingDef.Named("Ind_SkydrillerCallmaker_Drilling"), position, map);
            Messages.Message("Ind_SkyDriller_StartDrilling".Translate(), MessageSound.SeriousAlert);
        }
    }
}
