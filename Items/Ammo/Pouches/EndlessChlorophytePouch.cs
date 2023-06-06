using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessChlorophytePouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Chlorophyte Pouch");
			Tooltip.SetDefault("Chases after your enemy");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 10, 0, 0);

			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ProjectileID.ChlorophyteBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ChlorophyteBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}