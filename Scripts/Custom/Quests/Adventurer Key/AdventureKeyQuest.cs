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
    public class AdventureKeyQuest : BaseQuest
    {
        //The player will have a delay before they can redo quest again
        public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(60); } }

        //This is the Quest Title the player sees at the top of the Gump
        public override object Title { get { return "Footless Joe"; } }
        //This tells the story of the quest
        public override object Description { get { return "Please slay the Chieftan and rescue me.<br><br>" +
                    "There was once a time when I could have done that myself. I used to be quite the adventurer. " +
                    "Magic weapons, magic armor, the whole shebang, but you make one wrong move and you find yourself the butt of some sick ironic joke like me.<br><br>" +
                    "You see, a few years back, I was hunting orcs in these caves as I often did back then, when I tripped over a damn rock and got caught by these brutes.<br>" +
                    "They stripped off my armor, took my weapons, and cut off my feet so I couldn't run away. " +
                    "Then they forced me to craft shoes day in and day out for the orcish horde.<br><br>" +
                    "The funny thing is, I had these boots that were probably worth more than all of my weapons and armor combined. " +
                    "After they cut them off they threw them in the ocean with my feet still in them.<br><br>" +
                    "Kill the Orc Chieftan for me then bring me his key and I might tell you where they are."; } }
        //This decides how the npc reacts in text the player refusing the quest
        public override object Refuse { get { return "Please help me!"; } }
        //This is what the npc says when the player returns without completing the objective(s)
        public override object Uncomplete { get { return "Please hurry!"; } }
        //This is what the Quest Giver says when the player completes the quest.
        public override object Complete { get { return "Hey! Since you rescued me and proved your worth, I think I could draw up a map to where they threw them.<br>" +
                    "If you know a good fisherman, I'm willing to bet you could fish them up. Don't worry about the algae and barnacles, you know how magic stuff tends to resist such things.<br><br>*Scribbles out a crudely drawn map*"; } }

        public AdventureKeyQuest() : base()
        {
            AddObjective(new ObtainObjective(typeof(AdventureKey), "Skull of the Orc Chieftan", 1));
        }

        public override void GiveRewards()
        {
            Item bonusitem;
            bonusitem = new SOS(Map.Trammel, 3, true);
            //Adding Bonus Item #1
            if (!Owner.AddToBackpack(bonusitem))
            {
                bonusitem.MoveToWorld(Owner.Location, Owner.Map);
            }

            base.GiveRewards();
        }
    }
}
