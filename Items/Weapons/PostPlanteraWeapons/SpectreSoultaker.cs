using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.PostPlanteraWeapons
{
	public class SpectreSoultaker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Soultaker");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 110;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 5f;
			Item.mana = 8;

			Item.width = 62;
			Item.height = 60;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item43;

			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.PostPlanteraWeapons.SpectreSoultakerProjectile>();
			Item.shootSpeed = 4f;

			Item.alpha = 80;
			Item.color = new Color(255, 255, 255, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SpectreBar, 14)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}