using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace TysWatiga.Projectiles.PostPlanteraWeapons
{
	public class SpectreSoultakerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Scythe");

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 54;
			Projectile.height = 54;
			Projectile.friendly = true; 
            Projectile.hostile = false;

            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.timeLeft = 100;

			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			//Fade in and out
			if(Projectile.timeLeft > 75)
            {
				Projectile.alpha -= 7;
            }
			else if(Projectile.timeLeft < 25)
            {
				Projectile.alpha += 7;
			}

			//light
			float AlphaLightningMultiplier = 1 - ((Projectile.alpha - 80) / 175);
			Lighting.AddLight(Projectile.Center, 0.2f * AlphaLightningMultiplier, 0.4f * AlphaLightningMultiplier, 0.4f * AlphaLightningMultiplier);

			//Speed up
			Projectile.velocity *= 1.02f;

			//Point forward
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);
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
			//Reduce damge by 5% on enemy hits
			Projectile.damage = (int)(Projectile.damage * 0.90);
		}

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
			//Reduce damge by 5% on player hits
			Projectile.damage = (int)(Projectile.damage * 0.90);
		}
    }
}