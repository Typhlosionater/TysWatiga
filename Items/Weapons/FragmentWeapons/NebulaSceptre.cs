using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.FragmentWeapons
{
	public class NebulaSceptre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Sceptre");
			Tooltip.SetDefault("Rapidly fires erratic bolts of primordial magic");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 137;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 7;
			Item.useAnimation = 21;
			Item.reuseDelay = 14;
			Item.knockBack = 3f;
			Item.mana = 16;
			Item.crit += 10;

			Item.width = 48;
			Item.height = 48;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item60;

			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.CrystalPulse;
			Item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentNebula, 18)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			//Inaccuracy
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6 + Main.rand.Next(1, 6)));
		}
	}
}