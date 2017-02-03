using Verse;
using RimWorld;
using UnityEngine;

namespace Industrialisation
{
    public class Building_PlasmaDrillDeployed : Building
    {
        public int waitticksRemaining = 0;
        public int waittickAmountToGen = 0;

        public override void SpawnSetup()
        {
            base.SpawnSetup();
            Messages.Message(Translator.Translate("PlasmaDrillingOrderSend"), MessageSound.Standard);
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
                Messages.Message(Translator.Translate("LowOrbitPlasmaDrillApproaching"), MessageSound.Standard);
            }
            if (waitticksRemaining == 180)
            {
                Messages.Message(Translator.Translate("InitiatingPlasmaDrilling"), MessageSound.SeriousAlert);
            }
            if (waitticksRemaining == 0)
            {
                GenSpawn.Spawn(ThingDef.Named("PlasmaDrillAction"), this.Position);
                ((Thing)this).Destroy((DestroyMode)0);
            }
        }
    }
}