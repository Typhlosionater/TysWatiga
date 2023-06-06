using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessHellfireQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Hellfire Quiver");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(0, 20, 0, 0);

			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ProjectileID.HellfireArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 6.5f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HellfireArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}