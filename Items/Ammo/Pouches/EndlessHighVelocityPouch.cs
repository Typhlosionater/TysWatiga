using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessHighVelocityPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless High Velocity Pouch");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 8, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.BulletHighVelocity;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HighVelocityBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}