using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessCursedPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Cursed Pouch");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 6, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.CursedBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CursedBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}