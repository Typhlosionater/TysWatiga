using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items.Accessories.HardmodeMisc
{
    [AutoloadEquip(EquipType.Back, EquipType.Front)]
    public class CloakOfTheSorcerer : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cloak of the Sorcerer");
			Tooltip.SetDefault("12% increased magic damage and reduced mana usage\nIncreases pickup range for mana stars\nAutomatically use mana potions when needed\nCauses stars, which restore mana when collected, to fall after taking damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		
		public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 32;
           	Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.12f;
            player.manaCost -= 0.12f;
            player.manaFlower = true;
            player.manaMagnet = true;
            player.starCloakItem = this.Item;
            player.starCloakItem_manaCloakOverrideItem = this.Item;
        }
 
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CelestialEmblem, 1)
                .AddIngredient(ItemID.ManaCloak, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ChampionsCloak>(), 1)
                .AddIngredient(ItemID.MagnetFlower, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}