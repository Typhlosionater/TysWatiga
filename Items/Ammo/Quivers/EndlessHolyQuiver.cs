using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessHolyQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Holy Quiver");
			Tooltip.SetDefault("Summons falling stars on impact");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 16, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.HolyArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3.5f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HolyArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}