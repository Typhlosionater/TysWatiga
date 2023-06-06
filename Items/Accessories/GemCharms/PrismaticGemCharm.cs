using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.GemCharms
{
    [AutoloadEquip(EquipType.Neck)]
    public class PrismaticGemCharm : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Prismatic Gem Charm");
			Tooltip.SetDefault("5% increased damage\n5% increased critical strike chance\n5% increased movement speed\n'Finally, I have them all...'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 34;
           	Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.moveSpeed += 0.05f;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RubyCharm>(), 1)
                .AddIngredient(ModContent.ItemType<EmeraldCharm>(), 1)
                .AddIngredient(ModContent.ItemType<SapphireCharm>(), 1)
                .AddIngredient(ModContent.ItemType<AmethystCharm>(), 1)
                .AddIngredient(ModContent.ItemType<DiamondCharm>(), 1)
                .AddIngredient(ModContent.ItemType<TopazCharm>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}