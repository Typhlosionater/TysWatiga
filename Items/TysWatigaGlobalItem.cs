using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using Terraria.Audio;
using Terraria.GameContent.Creative;

namespace TysWatiga.Items
{
    public class TysWatigaGlobalItem : GlobalItem
    {
        //New Loot Bag Items
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            //Boss Bag Items
            if (context == "bossBag")
            {
                //Sharkron Tooth Necklace drops from Duke Fishron's Treasure bag at 33%
                if (arg == 3330 && Main.rand.Next(3) == 0)
                {
                    player.QuickSpawnItem(player.GetItemSource_OpenItem(arg), ModContent.ItemType<Accessories.HardmodeMisc.SharkronToothNecklace>());
                }

                //Wyvern's Heart drops from Betsy's Treasure bag (New Expert Item)
                if (arg == 3860)
                {
                    player.QuickSpawnItem(player.GetItemSource_OpenItem(arg), ModContent.ItemType<Accessories.NewExpertAccessories.WyvernsHeart>());
                }
            }
        }
    }
}