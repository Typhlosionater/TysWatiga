using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessLuminitePouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Luminite Pouch");
			Tooltip.SetDefault("'Line 'em up and knock 'em down...'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 2, 0, 0);

			Item.rare = ItemRarityID.Red;
			Item.shoot = ProjectileID.MoonlordBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 2f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MoonlordBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}