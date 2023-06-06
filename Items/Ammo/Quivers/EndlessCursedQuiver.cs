using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessCursedQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Cursed Quiver");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 8, 0, 0);

			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.CursedArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CursedArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}