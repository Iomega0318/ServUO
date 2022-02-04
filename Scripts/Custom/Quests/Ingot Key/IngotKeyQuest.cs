//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/8/2021 9:47:31 PM
//=================================================

using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class IngotKeyQuest : BaseQuest
    {
        //The player will have a delay before they can redo quest again
        public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(60); } }

        //This is the Quest Title the player sees at the top of the Gump
        public override object Title { get { return "Smiths Competetion"; } }
        //This tells the story of the quest
        public override object Description { get { return "‘Ail! Ya look like ya’ve traveled around quite a bit, eh? ‘Ave ya ‘eard about the King’s blacksmithing competition?<br>" +
                    "Aye, smiths from all ‘round Britainia are competin’ for who can make the best sword and I just gotta win you see.<br><br>" +
                    "Me ol’ pa ‘ad some strange metal, ‘e called it uranium or something like dat, it glows green all by itself. ‘E ‘ad an ingot of it and kept it with ‘im at all times, I’ve seen it meself, we buried ‘im with it. If I only ‘ad a few ingots of of dat, I could win for sure.<br><br>" +
                    "Before 'e passed he spoke of a mine deep in the lands of Tokuno where a rare elemental lives.<br><br>" +
                    "Ya think ya could find it fer me? ‘E said elementals worship the stuff and ya need a fancy pickaxe to mine it, so be careful."; } }
        //This decides how the npc reacts in text the player refusing the quest
        public override object Refuse { get { return "I'll bury you!"; } }
        //This is what the npc says when the player returns without completing the objective(s)
        public override object Uncomplete { get { return "Have you found the ingots yet?"; } }
        //This is what the Quest Giver says when the player completes the quest.
        public override object Complete { get { return "I'll win this competetion for sure!"; } }

        public IngotKeyQuest() : base()
        {
            AddObjective(new ObtainObjective(typeof(UraniumIngot), "Uranium Ingot", 4));
            AddReward(new BaseReward(typeof(IngotKey), "Ingot Key"));
        }
    }
}
