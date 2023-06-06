using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessVenomQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Venom Quiver");
			Tooltip.SetDefault("Inflicts target with Acid Venom");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 4.2f;
			Item.value = Item.sellPrice(0, 18, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.VenomArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4.3f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.VenomArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}