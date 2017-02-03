using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;   // Always needed     // Material/Graphics handling functions are found here
using RimWorld;      // RimWorld specific functions are found here
using Verse;         // RimWorld universal objects are here
//using Verse.AI;    // Needed when you do something with the AI
using Verse.Sound;   // Needed when you do something with the Sound

namespace Industrialisation
{
    [StaticConstructorOnStartup]
    public class Skydriller_PlasmaBeam : WeatherEvent
    {
        private IntVec3 strikeLoc = IntVec3.Invalid;
        private Mesh boltMesh;
        private static readonly Material PBMat = MaterialPool.MatFrom("PlasmaBeam");
        private int age;
        private int duration;

        public override bool Expired
        {
            get
            {
                return this.age > this.duration;
            }
        }

        public override void WeatherEventTick()
        {
            ++this.age;
        }
         
        public Skydriller_PlasmaBeam()
        {
            this.duration = 14;
        }

        public Skydriller_PlasmaBeam(IntVec3 forcedStrikeLoc) : this()
        {
            this.strikeLoc = forcedStrikeLoc;
        }
        public override void FireEvent()
        {
            if (!this.strikeLoc.IsValid)
            {
                this.strikeLoc = CellFinderLoose.RandomCellWith((IntVec3 sq) => sq.Standable() && !Find.RoofGrid.Roofed(sq));
            }
            this.boltMesh = Skydriller_PLasmaBeam_MeshMaker.NewBoltMesh();
        }

        protected float PBBrightness
        {
            get
            {
                if (this.age <= 2)
                    return (float)this.age / 2f;
                else
                    return (float)(1.0 - (double)this.age / (double)this.duration);
            }
        }

        public override void WeatherEventDraw()
        {
            Graphics.DrawMesh(this.boltMesh, this.strikeLoc.ToVector3ShiftedWithAltitude(AltitudeLayer.WorldDataOverlay), Quaternion.identity, FadedMaterialPool.FadedVersionOf(Skydriller_PlasmaBeam.PBMat, this.PBBrightness), 0);
        }
    }
}
