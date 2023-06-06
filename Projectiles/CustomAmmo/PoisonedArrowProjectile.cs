using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;


namespace TysWatiga.Projectiles.CustomAmmo
{
	public class PoisonedArrowProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poisoned Arrow"); 
        }

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = 1;
			Projectile.friendly = true; 
            Projectile.hostile = false;

            Projectile.timeLeft = 1200;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.arrow = true;

			AIType = ProjectileID.WoodenArrowFriendly;

			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}

        public override void Kill(int timeLeft)
		{
			//Plays a sound and produces dust on death
			SoundEngine.PlaySound(0, Projectile.position);
			for (int num421 = 0; num421 < 10; num421++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
            {
				target.AddBuff(BuffID.Poisoned, 10 * 60);
			}
		}

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.Poisoned, 10 * 60);
			}
		}
    }
}