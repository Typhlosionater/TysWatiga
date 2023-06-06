using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class SeersSkull : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Seer's Skull");
            Tooltip.SetDefault("Increases your max number of minions by 1\nYour minion's attacks may confuse enemies");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
           	Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 1;
            player.GetModPlayer<TysWatigaPlayer>().SeersStone = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PygmyNecklace, 1)
                .AddIngredient(ModContent.ItemType<SeersStone>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}