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
            GenSpawn.Spawn(ThingDef.Named("Ind_PlasmaDrillDeployed"), this.Position, Find.VisibleMap);
        }

    }
}
