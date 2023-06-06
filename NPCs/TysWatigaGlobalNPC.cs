using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TysWatiga.NPCs
{
	public class TysWatigaGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		//Vanilla NPCs Selling Items
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			//Seer's Stone sold by Wizard
			if (type == NPCID.Wizard)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.HardmodeMisc.SeersStone>());
				nextSlot++;
			}
		}

		//Items dropped by vanilla NPCs
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			//Possessed Armor drops Accursed Collar at 2%
			if (npc.type == NPCID.PossessedArmor)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.HardmodeMisc.AccursedCollar>(), 50));
			}

			//On not on expert+ Duke Fishron drops Sharkron Tooth Necklace at 25%
			if (npc.type == NPCID.DukeFishron)
			{
				IItemDropRule NotExpert = new LeadingConditionRule(new Conditions.NotExpert());
				NotExpert.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.HardmodeMisc.SharkronToothNecklace>(), 4));
				npcLoot.Add(NotExpert);
			}
		}
	}
}