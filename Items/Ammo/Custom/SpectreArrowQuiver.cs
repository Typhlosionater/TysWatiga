using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TysWatiga.Items.Ammo.Custom
{
	public class SpectreArrowQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Spectre Quiver");
			Tooltip.SetDefault("Seeks out enemies");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 25, 0, 0);

			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.CustomAmmo.SpectreArrowProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("TysWatiga/Items/Ammo/Custom/SpectreArrowQuiver_Glowmask").Value;
			Main.spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<SpectreArrow>(), 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}