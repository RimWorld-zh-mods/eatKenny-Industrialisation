using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace Industrialisation
{
    class CompUseEffect_ActiveSkyDrillerCallMaker : CompUseEffect
    {
        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            GenSpawn.Spawn(ThingDef.Named("Ind_SkydrillerCallmaker_Calling"), this.parent.Position, this.parent.Map);
            Messages.Message("Ind_SkyDriller_Calling".Translate(), MessageSound.Standard);
        }
    }
}
