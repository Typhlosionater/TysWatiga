using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Pouches
{
	public class EndlessPartyPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Party Pouch");
			Tooltip.SetDefault("Explodes into confetti on impact");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 34;

			Item.consumable = false;             
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 2, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.PartyBullet;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5.1f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PartyBullet, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}