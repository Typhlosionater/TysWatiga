using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class ShrunkenHead : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shrunken Head");
            Tooltip.SetDefault("Increases your max number of minions by 1\nEnemies are less likely to target you");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 32;
           	Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 1;
            player.aggro -= 400;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PygmyNecklace, 1)
                .AddIngredient(ItemID.PutridScent, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}