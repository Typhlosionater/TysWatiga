using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessBoneQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Bone Quiver");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 3, 0, 0);

			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.BoneArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3.5f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BoneArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}