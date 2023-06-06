using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Back, EquipType.Front)]
    public class ChampionsCloak : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Champion's Cloak");
			Tooltip.SetDefault("10% increased damage\nCauses stars to fall after taking damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
           	Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.starCloakItem = this.Item;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AvengerEmblem, 1)
                .AddIngredient(ItemID.StarCloak, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}