using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.PrehardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class SharkToothCollar : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shark Tooth Collar");
			Tooltip.SetDefault("Increases armor penetration by 5");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
           	Item.value = Item.sellPrice(0, 1, 10, 0);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.defense = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 5;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Shackle, 1)
                .AddIngredient(ItemID.SharkToothNecklace, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}