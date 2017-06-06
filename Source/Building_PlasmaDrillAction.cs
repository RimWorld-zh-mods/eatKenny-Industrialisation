using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;   // Always needed    // Material/Graphics handling functions are found here
using RimWorld;      // RimWorld specific functions are found here
using Verse;         // RimWorld universal objects are here
//using Verse.AI;    // Needed when you do something with the AI
using Verse.Sound;   // Needed when you do something with the Sound

namespace Industrialisation
{
    public class Building_PlasmaDrillAction : Building
    {
        private int Burnticks = 4;
        private int Burnticks2 = 4;
        public int drillticksRemaining = 0;
        public int drilltickAmountToGen = 0;
        public Skydriller_PlasmaBeam skydrillerEffect;
        private static readonly SoundDef PlasmaDrill = SoundDef.Named("Ind_PlasmaDrill");
        private static readonly SoundDef PlasmaDrillFire = SoundDef.Named("Ind_PlasmaDrillFire");

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            this.drilltickAmountToGen = this.randomDrillticks();
            this.drillticksRemaining = this.drilltickAmountToGen;
        }

        public int randomDrillticks()
        {
            return Rand.Range(6000, 12000);
        }

        public override void Tick()
        {
            base.Tick();
            Burnticks--;
            Burnticks2--;
            --this.drillticksRemaining;
           
            if (Burnticks == 0)
            {
                skydrillerEffect = new Skydriller_PlasmaBeam(base.Map, this.Position);
                base.Map.weatherManager.eventHandler.AddEvent(skydrillerEffect);
                Burnticks = 4;
            }

            if (Burnticks2 == 0)
            {
                MoteMaker.MakeStaticMote(base.Position, base.Map, ThingDefOf.Mote_ShotFlash, 9f);
                GenExplosion.DoExplosion(base.Position, base.Map, 1, DamageDefOf.Flame, (Thing)null, PlasmaDrill, (ThingDef)null);
                Burnticks2 = 4;
            }

            if (drillticksRemaining == 0)
            {
                Messages.Message("Ind_PlasmaDrillingComplete".Translate(), MessageSound.Standard);
                GenSpawn.Spawn(ThingDef.Named("Ind_MiningHole"), this.Position, base.Map);
                SoundStarter.PlayOneShot(Building_PlasmaDrillAction.PlasmaDrillFire, new TargetInfo(base.Position, base.Map, false));
                ((Thing)this).Destroy((DestroyMode)0);
            }
        }
    }
}