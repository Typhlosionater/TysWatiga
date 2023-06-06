using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.FragmentWeapons
{
	public class Constellation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Constellation");
			Tooltip.SetDefault("25 summon tag damage\nYour summons will focus struck enemies\nStriking enemies produces damaging stardust\n'They will suffer your divine justice!'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 200;
			Item.DamageType = DamageClass.Summon;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.knockBack = 4.5f;

			Item.width = 48;
			Item.height = 44;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item152;
			Item.noUseGraphic = true;

			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.FragmentWeapons.ConstellationProjectile>();
			Item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentStardust, 18)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
    }
}