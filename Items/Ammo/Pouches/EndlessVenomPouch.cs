using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessVenomPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Venom Pouch");
			Tooltip.SetDefault("Inflicts target with Acid Venom");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 4.1f;
			Item.value = Item.sellPrice(0, 8, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.VenomBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5.3f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.VenomBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}