using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace TysWatiga.Projectiles.CustomAmmo
{
	public class PhantomBulletProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Bullet");

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true; 
            Projectile.hostile = false;

            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
			Projectile.alpha = 255;

			Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
			Projectile.extraUpdates = 2;
			Projectile.scale = 1.2f;

			AIType = ProjectileID.Bullet;
		}

        public override void AI()
        {
			//Produces Dust in Flight
			if (Projectile.alpha < 190)
			{
				for (int DustLoop = 0; DustLoop < 5; DustLoop++)
				{
					Vector2 DustPosition = Projectile.Center - (Projectile.velocity * (0.2f * DustLoop));
					int TrailDust = Dust.NewDust(Projectile.Center, 0, 0, DustID.DungeonSpirit);
					Main.dust[TrailDust].position = DustPosition;
					Main.dust[TrailDust].alpha = Projectile.alpha;
					Main.dust[TrailDust].velocity *= 0f;
					Main.dust[TrailDust].scale *= 0.75f;
					Main.dust[TrailDust].rotation = Main.rand.NextFloat(0, 4);
					Main.dust[TrailDust].noGravity = true;
				}
			}
		}

        public override void Kill(int timeLeft)
		{
			//Spawns dust + plays sound on death
			for (int i = 0; i < 3; i++)
			{
				int ImpactDust = Dust.NewDust(Projectile.Center, 0, 0, DustID.DungeonSpirit);
				Main.dust[ImpactDust].velocity *= 1f;
				Main.dust[ImpactDust].scale *= 1.25f;
				Main.dust[ImpactDust].rotation = Main.rand.NextFloat(0, 4);
				Main.dust[ImpactDust].noGravity = true;
			}
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			//Code from Examplebullet to make bullet not affected by lightning
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

			// Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}
			return true;
		}
	}
}