using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Custom
{
	public class ShadeRound : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shade Round");
			Tooltip.SetDefault("Critical strikes deal additional damage");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.height = 14;

			Item.maxStack = 999;
			Item.consumable = true;             
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(0, 0, 0, 1);

			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.CustomAmmo.ShadeRoundProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(70)
				.AddIngredient(ItemID.MusketBall, 70)
				.AddIngredient(ItemID.ShadowScale, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}