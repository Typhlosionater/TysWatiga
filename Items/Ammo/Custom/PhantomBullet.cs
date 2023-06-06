using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TysWatiga.Items.Ammo.Custom
{
	public class PhantomBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Bullet");
			Tooltip.SetDefault("Passes through walls unhindered");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 12;

			Item.maxStack = 999;
			Item.consumable = true;             
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 0, 0, 10);

			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.CustomAmmo.PhantomBulletProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5f;
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Item.alpha, 255 - Item.alpha, 255 - Item.alpha, 255 - Item.alpha);
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(ItemID.MusketBall, 100)
				.AddIngredient(ItemID.Ectoplasm, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}