using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.FragmentWeapons
{
	public class AlphaCentauri : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha-Centauri");
			Tooltip.SetDefault("'Who needs binary when you can have trinary?'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 160;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 6.5f;

			Item.width = 30;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item1;
			Item.channel = true;
			Item.noUseGraphic = true;

			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.FragmentWeapons.AlphaCentauriProjectile>();
			Item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentSolar, 18)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
    }
}