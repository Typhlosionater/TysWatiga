using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TysWatiga.Items.Ammo.Custom
{
	public class SpectreArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Arrow");
			Tooltip.SetDefault("Seeks out enemies");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 34;

			Item.maxStack = 999;
			Item.consumable = true;             
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 0, 0, 25);

			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.CustomAmmo.SpectreArrowProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Item.alpha, 255 - Item.alpha, 255 - Item.alpha, 255 - Item.alpha);
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient(ItemID.SpectreBar, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}