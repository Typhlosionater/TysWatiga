using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TysWatiga.Items.Ammo.Quivers
{
	public class EndlessFrostburnQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Frostburn Quiver");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;

			Item.consumable = false;             
			Item.knockBack = 2.2f;
			Item.value = Item.sellPrice(0, 3, 0, 0);

			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.FrostburnArrow;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3.75f;
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
			//Produces Light in world like the frostburn arrow
			if (!Item.wet)
			{
				Lighting.AddLight((int)((Item.position.X + (float)Item.width) / 16f), (int)((Item.position.Y + (float)(Item.height / 2)) / 16f), 0.35f, 0.65f, 1f);
			}
			return base.PreDrawInWorld(spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FrostburnArrow, 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}