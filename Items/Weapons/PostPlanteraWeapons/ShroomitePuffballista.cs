using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.PostPlanteraWeapons
{
	public class ShroomitePuffballista : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Puffballista");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.knockBack = 2.5f;
			Item.crit += 3;

			Item.width = 58;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item5;

			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ShroomiteBar, 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//Implementation of shooting mechanism like Tsunami
			float numberProjectiles = 2;
			float pi = 3.14159265f;
			Vector2 vector1 = Vector2.Normalize(velocity);
			vector1 *= 40f;
			bool flag = Collision.CanHit(position, 0, 0, position + vector1, 0, 0);
			for (int i = 0; i < numberProjectiles; i++)
			{
				float num = (float)i - ((float)numberProjectiles - 1f) / 2f;
				Vector2 vector2 = vector1.RotatedBy((double)(pi * num / 10), default(Vector2));
				if (!flag)
				{
					vector2 -= vector1;
				}
				int projfire = Projectile.NewProjectile(source, position.X + vector2.X, position.Y + vector2.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
				Main.projectile[projfire].noDropItem = true;
			}
			return false;
		}
	}
}