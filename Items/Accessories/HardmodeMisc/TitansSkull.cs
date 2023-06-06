using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Neck)]
    public class TitansSkull : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Titan's Skull");
            Tooltip.SetDefault("12% increased summon damage\nIncreases your max number of minions by 1\nYour minion's attacks may confuse enemies");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
           	Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.12f;
            player.maxMinions += 1;
            player.GetModPlayer<TysWatigaPlayer>().SeersStone = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SeersSkull>(), 1)
                .AddIngredient(ItemID.AvengerEmblem, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}