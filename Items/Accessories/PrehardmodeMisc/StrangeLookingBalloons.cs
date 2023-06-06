using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.PrehardmodeMisc
{
    [AutoloadEquip(EquipType.Balloon)]
    public class StrangeLookingBalloons : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Strange Looking Balloons");
			Tooltip.SetDefault("Allows the holder to triple jump\nIncreases jump height\nReleases bees and douses the user in honey when damaged");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 28;
           	Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.hasJumpOption_Sail = true;
            player.hasJumpOption_Fart = true;
            player.jumpBoost = true;
            player.honeyCombItem = this.Item;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SharkronBalloon, 1)
                .AddIngredient(ItemID.FartInABalloon, 1)
                .AddIngredient(ItemID.HoneyBalloon, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}