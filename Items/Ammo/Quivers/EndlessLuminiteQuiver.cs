using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessLuminiteQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Luminite Quiver");
			Tooltip.SetDefault("'Shooting them down at the speed of sound!'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 3.5f;
			Item.value = Item.sellPrice(0, 2, 0, 0);

			Item.rare = ItemRarityID.Red;
			Item.shoot = ProjectileID.MoonlordArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MoonlordArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}