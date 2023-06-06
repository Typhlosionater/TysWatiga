using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessGoldenPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Golden Pouch");
			Tooltip.SetDefault("Enemies killed will drop more money");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 36;

			Item.consumable = false;             
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 8, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.GoldenBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4.6f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GoldenBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}