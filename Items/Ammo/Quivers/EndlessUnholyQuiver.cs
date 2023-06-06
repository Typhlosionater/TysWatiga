using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessUnholyQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Unholy Quiver");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 8, 0, 0);

			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileID.UnholyArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3.4f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.UnholyArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}