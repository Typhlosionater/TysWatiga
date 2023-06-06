using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.GemCharms
{
    [AutoloadEquip(EquipType.Neck)]
    public class DiamondCharm : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Diamond Charm");
			Tooltip.SetDefault("5% increased critical strike chance");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 34;
           	Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += 5;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Diamond, 5)
                .AddIngredient(ItemID.Chain, 2)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                .Register();
        }
    }
}