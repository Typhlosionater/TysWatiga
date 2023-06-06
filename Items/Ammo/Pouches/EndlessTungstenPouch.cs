using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessTungstenPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Tungsten Pouch");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 3, 0, 0);

			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.Bullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4.5f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.TungstenBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}