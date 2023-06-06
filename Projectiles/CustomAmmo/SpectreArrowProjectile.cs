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
	public class SpectreArrowProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Arrow");

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            Projectile.penetrate = 1;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.arrow = true;
			Projectile.extraUpdates = 1;

			AIType = ProjectileID.Bullet;
		}

        public override void AI()
        {
			//Homing Stats
			float maxDetectionRadius = 400f;
			float rotationAmount = MathHelper.ToRadians(1f);

			//homes in on enemies if friendly
			if (Projectile.friendly)
            {
				//Choose Target
				NPC closestNPC = null;
				float sqrMaxDetectDistance = maxDetectionRadius * maxDetectionRadius;
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC target = Main.npc[i];
					if (target.CanBeChasedBy() && Collision.CanHit(Projectile.Center, 1, 1, target.Center, 1, 1))
					{
						float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
						if (sqrDistanceToTarget < sqrMaxDetectDistance)
						{
							sqrMaxDetectDistance = sqrDistanceToTarget;
							closestNPC = target;
						}
					}
				}

				//Homes in on target if applicable
				if (closestNPC != null)
				{
					float rotTarget = (closestNPC.Center - Projectile.Center).ToRotation();
					float rotCurrent = Projectile.velocity.ToRotation();
					Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.WrapAngle(MathHelper.WrapAngle(Utils.AngleTowards(rotCurrent, rotTarget, rotationAmount)) - Projectile.velocity.ToRotation()));
				}
			}

            //homes in on owner if hostile
            if (Projectile.hostile)
            {
				//Choose Target
				bool ownerIsValidTarget = false;
				Player owner = Main.player[Projectile.owner];
				float sqrMaxDetectDistance = maxDetectionRadius * maxDetectionRadius;
				float sqrDistanceToTarget = Vector2.DistanceSquared(owner.Center, Projectile.Center);
				if (!owner.dead && (sqrDistanceToTarget < sqrMaxDetectDistance) && (Collision.CanHit(Projectile.Center, 1, 1, owner.Center, 1, 1)))
				{
					ownerIsValidTarget = true;
				}

				//Homes in on target if applicable
				if (ownerIsValidTarget)
				{
					float rotTarget = (owner.Center - Projectile.Center).ToRotation();
					float rotCurrent = Projectile.velocity.ToRotation();
					Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.WrapAngle(MathHelper.WrapAngle(Utils.AngleTowards(rotCurrent, rotTarget, rotationAmount)) - Projectile.velocity.ToRotation()));
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			//Spawns dust + plays sound on death
			for (int i = 0; i < 5; i++)
			{
				int ImpactDust = Dust.NewDust(Projectile.Center, 0, 0, DustID.DungeonSpirit);
				Main.dust[ImpactDust].velocity *= 1.5f;
				Main.dust[ImpactDust].scale *= 1.5f;
				Main.dust[ImpactDust].rotation = Main.rand.NextFloat(0, 4);
				Main.dust[ImpactDust].noGravity = true;
			}
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