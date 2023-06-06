using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class SharkronToothNecklace : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sharkron Tooth Necklace");
            Tooltip.SetDefault("Increases armour penetration by 25");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
           	Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 25;
        }
    }
}