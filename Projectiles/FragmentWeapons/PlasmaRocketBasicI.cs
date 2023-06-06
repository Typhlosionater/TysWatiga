using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace TysWatiga.Projectiles.FragmentWeapons
{
	public class PlasmaRocketBasicI : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasma Rocket I");

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;

			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;

			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 4;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.tileCollide = false;
			Projectile.velocity *= 0f;
			Projectile.alpha = 255;
			Projectile.timeLeft = 3;

			return false;
		}
    }
}