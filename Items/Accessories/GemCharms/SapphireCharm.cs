using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.GemCharms
{
    [AutoloadEquip(EquipType.Neck)]
    public class SapphireCharm : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sapphire Charm");
			Tooltip.SetDefault("5% increased magic damage");

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
            player.GetDamage(DamageClass.Magic) += 0.05f;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sapphire, 5)
                .AddIngredient(ItemID.Chain, 2)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                .Register();
        }
    }
}