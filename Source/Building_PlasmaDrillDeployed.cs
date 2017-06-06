using Verse;
using RimWorld;
using UnityEngine;

namespace Industrialisation
{
    public class Building_PlasmaDrillDeployed : Building
    {
        public int waitticksRemaining = 0;
        public int waittickAmountToGen = 0;

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            Messages.Message("Ind_PlasmaDrillingOrderSend".Translate(), MessageSound.Standard);
            this.waittickAmountToGen = this.randomWaitticks();
            this.waitticksRemaining = this.waittickAmountToGen;
        }

        public int randomWaitticks()
        {
                return Rand.Range(6000, 12000);
        }

        public override void Tick()
        {
            base.Tick();
            --this.waitticksRemaining;
            
            if (waitticksRemaining == 900)
            {
                Messages.Message("Ind_LowOrbitPlasmaDrillApproaching".Translate(), MessageSound.Standard);
            }
            if (waitticksRemaining == 180)
            {
                Messages.Message("Ind_InitiatingPlasmaDrilling".Translate(), MessageSound.SeriousAlert);
            }
            if (waitticksRemaining == 0)
            {
                GenSpawn.Spawn(ThingDef.Named("Ind_PlasmaDrillAction"), this.Position, base.Map);
                ((Thing)this).Destroy((DestroyMode)0);
            }
        }
    }
}