using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.PostPlanteraWeapons
{
	public class ShroomiteSplattershot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Splattershot");
			Tooltip.SetDefault("Fires an even spread of 7 bullets");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.knockBack = 5.5f;
			Item.crit += 3;

			Item.width = 52;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item38;

			Item.value = Item.sellPrice(0, 6, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ShroomiteBar, 16)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//Fires an even spread of 7 bullets in 21 degrees
			float numberProjectiles = 7;
			float rotation = MathHelper.ToRadians(21);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
    }
}