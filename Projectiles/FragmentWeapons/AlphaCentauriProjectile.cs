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
	public class AlphaCentauriProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha-Centauri");

			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 384f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17f;
		}

		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.aiStyle = 99;
			Projectile.friendly = true; 
            Projectile.hostile = false;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;

			Projectile.extraUpdates = 0;
			Projectile.scale = 1f;
		}

		public bool AlphaCentauriFlaresProjectileActive;

		public override void AI()
		{
			//Alpha-Centauri Flares effect
			if (!AlphaCentauriFlaresProjectileActive)
			{
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AlphaCentauriFlaresProjectile>(), 0, 0, Projectile.owner, 0f, Projectile.whoAmI);
				AlphaCentauriFlaresProjectileActive = true;
			}

			//Produce Light
			Lighting.AddLight(Projectile.Center, 0.6f, 0.3f, 0.075f);

			//Produce Dust
			if (Projectile.velocity.Length() > 1f)
            {
				if (Main.rand.Next(2) == 0)
				{
					int SolarEruptionDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * -0.8f, Projectile.velocity.X * -0.8f, 100, Color.Transparent, 3f * Main.rand.NextFloat());
					Main.dust[SolarEruptionDust].noGravity = true;
					Main.dust[SolarEruptionDust].velocity.RotatedByRandom(MathHelper.ToRadians(45f));
					Main.dust[SolarEruptionDust].fadeIn = 1.25f;
				}
				if (Main.rand.Next(8) == 0)
				{
					int SolarEruptionFallingDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * -0.5f, Projectile.velocity.X * -0.5f, 100, Color.Transparent, Main.rand.NextFloat());
					Main.dust[SolarEruptionFallingDust].velocity.RotatedByRandom(MathHelper.ToRadians(45f));
					Main.dust[SolarEruptionFallingDust].fadeIn = 1.25f;
				}
			}
            else
            {
				if (Main.rand.Next(5) == 0)
				{
					int SolarEruptionDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * -0.8f, Projectile.velocity.X * -0.8f, 100, Color.Transparent, 3f * Main.rand.NextFloat());
					Main.dust[SolarEruptionDust].noGravity = true;
					Main.dust[SolarEruptionDust].velocity.RotatedByRandom(MathHelper.ToRadians(45f));
					Main.dust[SolarEruptionDust].fadeIn = 1.25f;
				}
				if (Main.rand.Next(15) == 0)
				{
					int SolarEruptionFallingDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * -0.5f, Projectile.velocity.X * -0.5f, 100, Color.Transparent, Main.rand.NextFloat());
					Main.dust[SolarEruptionFallingDust].velocity.RotatedByRandom(MathHelper.ToRadians(45f));
					Main.dust[SolarEruptionFallingDust].fadeIn = 1.25f;
				}
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 200);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			//Code from Examplebullet to make bullet not affected by coloured lightning
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//Apply Daybreak
			target.AddBuff(189, 300);

			//Solar Flare Explosion
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, 953, damage, 10f, Projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);

		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			//Solar Flare Explosion
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, 953, damage, 10f, Projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
		}
	}
}