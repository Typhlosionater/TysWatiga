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
	public class AlphaCentauriFlaresProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha-Centauri Flares");
		}

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;

            Projectile.penetrate = -1;
			Projectile.alpha = 255;

			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.scale = 1f;
		}

		public override void AI()
		{
			//Set parent
			Projectile parent = Main.projectile[(int)Projectile.ai[1]];

			//Movement
			Projectile.Center = parent.Center;
			if (!parent.active)
			{
				Projectile.Kill();
			}
            else
            {
				Projectile.timeLeft = 2;
            }

			//Rotate projectile
			Projectile.rotation += 0.18f;

			//Fade in and grow
			if (Projectile.ai[0] == 0)
            {
				Projectile.scale = 0.05f;
			}
			if (Projectile.ai[0] < 17)
            {
				Projectile.scale += 0.05f;
				Projectile.alpha -= 15;

				Projectile.ai[0]++;
			}

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 200 - Projectile.alpha);
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
	}
}