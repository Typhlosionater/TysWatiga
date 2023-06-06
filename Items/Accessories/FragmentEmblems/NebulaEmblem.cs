using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.FragmentEmblems
{
    public class NebulaEmblem : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nebula Emblem");
			Tooltip.SetDefault("25% increased magic damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
           	Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Red;       
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.25f;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AvengerEmblem, 1)
                .AddIngredient(ItemID.FragmentNebula, 12)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}