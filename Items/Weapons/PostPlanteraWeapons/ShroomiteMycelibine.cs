using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.PostPlanteraWeapons
{
	public class ShroomiteMycelibine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Mycelibine");
			Tooltip.SetDefault("Fires in 4 round bursts\nOnly the first shot consumes ammo");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 3;
			Item.useAnimation = 12;
			Item.reuseDelay = 12;
			Item.knockBack = 1.5f;
			Item.crit += 3;

			Item.width = 74;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item31;

			Item.value = Item.sellPrice(0, 6, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 14f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ShroomiteBar, 16)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override bool CanConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < Item.useAnimation - 2);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			//bullet height
			Vector2 BaseAngle2 = Vector2.Normalize(velocity);
			Vector2 PerpendicularAngle2 = new Vector2(BaseAngle2.Y, -BaseAngle2.X);
			if (PerpendicularAngle2.Y < 0)
			{
				PerpendicularAngle2 = new Vector2(-BaseAngle2.Y, BaseAngle2.X);
			}
			PerpendicularAngle2 *= -6;
			position.X += PerpendicularAngle2.X;
			position.Y += PerpendicularAngle2.Y;
		}
	}
}