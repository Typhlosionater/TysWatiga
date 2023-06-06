using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.FragmentWeapons
{
	public class GaussCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gauss Cannon");
			Tooltip.SetDefault("Fires ludicrously fast plasma rockets that deal double damage to enemies they hit\n50% chance to not consume ammo");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 125;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 8f;

			Item.width = 68;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item92;

			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = true;
			Item.shoot = 134;
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.Rocket;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentVortex, 18)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 3);
		}

		public override bool CanConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .5f;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			switch (type)
			{
				case ProjectileID.RocketI:
					break;
				case ProjectileID.RocketII:
					break;
				case ProjectileID.RocketIII:
					break;
				case ProjectileID.RocketIV:
					break;
				case ProjectileID.ClusterRocketI:
					break;
				case ProjectileID.ClusterRocketII:
					break;
				case ProjectileID.WetRocket:
					break;
				case ProjectileID.LavaRocket:
					break;
				case ProjectileID.HoneyRocket:
					break;
				case ProjectileID.MiniNukeRocketI:
					break;
				case ProjectileID.MiniNukeRocketII:
					break;
				case ProjectileID.DryRocket:
					break;

			}
		}

        /*public override void PickAmmo(Item sItem, ref int projToShoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, out int usedAmmoItemId, bool dontConsume = false)
		{
			if (sItem.type == 1946)
			{
				projToShoot = 338 + item.type - 771;
			}
		}*/

        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			switch (type)
			{
				case ProjectileID.RocketI:
					break;
				case ProjectileID.RocketII:
					break;
				case ProjectileID.RocketIII:
					break;
				case ProjectileID.RocketIV:
					break;
				case ProjectileID.ClusterRocketI:
					break;
				case ProjectileID.ClusterRocketII:
					break;
				case ProjectileID.WetRocket:
					break;
				case ProjectileID.LavaRocket:
					break;
				case ProjectileID.HoneyRocket:
					break;
				case ProjectileID.MiniNukeRocketI:
					break;
				case ProjectileID.MiniNukeRocketII:
					break;
				case ProjectileID.DryRocket:
					break;
			}

			//Superfast Rocket Test
			int SuperfastRocket = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			Main.projectile[SuperfastRocket].extraUpdates = 4;

			return false;
        }*/
    }
}