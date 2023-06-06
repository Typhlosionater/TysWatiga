using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TysWatiga.Items.Weapons.LunaticCultistLoot
{
	public class TomeOfFulmination : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tome of Fulmination");
			Tooltip.SetDefault("Channels bolts of otherworldly lightning");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 160;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 4;
			Item.useAnimation = 24;
			Item.knockBack = 2f;
			Item.mana = 8;

			Item.width = 28;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item93;

			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.CultistBossLightningOrbArc;
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//Inaccuracy
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));

			//Actually fire with overrides
			int projfire = Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(10)), type, damage, knockback, player.whoAmI, velocity.ToRotation(), Main.rand.Next(100));
			Main.projectile[projfire].DamageType = DamageClass.Magic;
			Main.projectile[projfire].friendly = true;
			Main.projectile[projfire].hostile = false;
			Main.projectile[projfire].penetrate = -1;
			Main.projectile[projfire].usesIDStaticNPCImmunity = true;
			Main.projectile[projfire].idStaticNPCHitCooldown = 6;
			Main.projectile[projfire].tileCollide = false;
			Main.projectile[projfire].timeLeft = 60;
			return false;
		}
	}
}