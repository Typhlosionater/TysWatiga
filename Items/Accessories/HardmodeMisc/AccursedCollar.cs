using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class AccursedCollar : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Accursed Collar");
            Tooltip.SetDefault("Increases armour penetration by 16");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 18;
           	Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 16;
        }
    }
}