using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessMeteorPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Meteor Pouch");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(0, 1, 0, 0);

			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileID.MeteorShot;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MeteorShot, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}