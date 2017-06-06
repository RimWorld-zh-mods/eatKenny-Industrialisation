using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.Sound;

namespace Industrialisation
{
    class Building_SkydrillerCallmaker_Drilling : Building
    {
        private int plasmaTick = 4;
        private int explosionTick = 4;
        public Skydriller_PlasmaBeam skydrillerEffect;
        private static readonly SoundDef PlasmaDrill = SoundDef.Named("Ind_PlasmaDrill");
        private static readonly SoundDef PlasmaDrillFire = SoundDef.Named("Ind_PlasmaDrillFire");

        //public override void SpawnSetup(Map map, bool respawningAfterLoad)
        //{
        //    base.SpawnSetup(map, respawningAfterLoad);
        //    this.skydrillerEffect = new Skydriller_PlasmaBeam(base.Map, this.Position);
        //}

        public override void Tick()
        {
            base.Tick();
            this.plasmaTick--;
            this.explosionTick--;

            if (this.plasmaTick == 0)
            {
                base.Map.weatherManager.eventHandler.AddEvent(new Skydriller_PlasmaBeam(base.Map, this.Position));
                this.explosionTick = 4;
            }

            if (this.explosionTick == 0)
            {
                MoteMaker.MakeStaticMote(base.Position, base.Map, ThingDefOf.Mote_ShotFlash, 9f);
                GenExplosion.DoExplosion(base.Position, base.Map, 1.5f, DamageDefOf.Flame, (Thing)null, PlasmaDrill, (ThingDef)null);
                this.plasmaTick = 4;
            }
        }

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            var position = this.Position;
            var map = base.Map;
            base.Destroy(mode);
            SoundStarter.PlayOneShot(PlasmaDrillFire, new TargetInfo(position, map, false));
            GenSpawn.Spawn(ThingDef.Named("Ind_MiningHole"), position, map);
            Messages.Message("Ind_SkyDriller_Completed".Translate(), MessageSound.Standard);
        }
    }
}
