using System;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;
namespace Industrialisation
{
    public class Projectile_PlasmaDrillBullet : Projectile
    {

        protected override void Impact(Thing hitThing)
            {
            base.Impact(hitThing);
            if (hitThing != null)
            {
                GenSpawn.Spawn(ThingDef.Named("PlasmaDrillDeployed"), this.Position);
            }
            else
            {
                GenSpawn.Spawn(ThingDef.Named("PlasmaDrillDeployed"), this.Position);
            }
        }

    }
}
