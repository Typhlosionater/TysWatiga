using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    public class SeersStone : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Seer's Stone");
            Tooltip.SetDefault("Your minion's attacks may confuse enemies");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
           	Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TysWatigaPlayer>().SeersStone = true;
        }
    }
}