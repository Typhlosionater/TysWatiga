using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Ammo.Custom
{
	public class PoisonedArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poisoned Arrow");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 32;

			Item.maxStack = 999;
			Item.consumable = true;             
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 0, 0, 3);

			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<Projectiles.CustomAmmo.PoisonedArrowProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3.5f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(25)
				.AddIngredient(ItemID.WoodenArrow, 25)
				.AddIngredient(ItemID.ViciousPowder, 1)
				.Register();
			CreateRecipe(25)
				.AddIngredient(ItemID.WoodenArrow, 25)
				.AddIngredient(ItemID.VilePowder, 1)
				.Register();
		}
	}
}