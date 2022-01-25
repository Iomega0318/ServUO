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
        public override object Title { get { return "Bed for the King"; } }
        //This tells the story of the quest
        public override object Description { get { return "Ugh! The king has requested that I make him a new bed. Something worthy of a king.<br>" +
                    "I’ve made a hundred of ‘em and they just don’t seem worthy to me. What I need is a special type of wood called “ravenwood” that comes from a grove of trees deep in the heart of the Yew forests.<br>" +
                    "If I had just one log of ravenwood, I think I could make something truly special.<br>" +
                    "Would you be willing to go find one for me? I could reward you handsomely for sure.<br><br>" +
                    "You’re going to need a ravenwood axe to chop those trees though, I’m sure you’ll find one on the way.<br>" +
                    "Oh, ravenwood trees produce a toxic sap that has a tendency to splash when you cut ‘em. Don’t say I didn’t warn you."; } }
        //This decides how the npc reacts in text the player refusing the quest
        public override object Refuse { get { return "The King will not be pleased!"; } }
        //This is what the npc says when the player returns without completing the objective(s)
        public override object Uncomplete { get { return "Have you found the wood yet?"; } }
        //This is what the Quest Giver says when the player completes the quest.
        public override object Complete { get { return "This will make an excellent bed for the King, he will be pleased, have this token of my appreciation as a reward."; } }

        public IngotKeyQuest() : base()
        {
            AddObjective(new ObtainObjective(typeof(RavenwoodLog), "Ravenwood Log", 1));
            AddReward(new BaseReward(typeof(WoodKey), "Wood Key"));
        }
    }
}
