using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace TysWatiga
{
    public class TysWatigaPlayer : ModPlayer
    {
        //Initialise Special triggers
        public bool SeersStone;

        //Reset Triggers
        public override void ResetEffects()
        {
            SeersStone = false;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            //Seer's Stone minions inflict confusion
            if (SeersStone && (proj.minion || ProjectileID.Sets.MinionShot[proj.type]))
            {
                if (Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Confused, (int)(2 * 60));
                }
            }
        }

        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
        {
            //Seer's Stone minions inflict confusion
            if (SeersStone && (proj.minion || ProjectileID.Sets.MinionShot[proj.type]))
            {
                if (Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Confused, (int)(2 * 60));
                }
            }
        }
    }
}
