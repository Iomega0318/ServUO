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
    public class GemKeyQuest : BaseQuest
    {
        //The player will have a delay before they can redo quest again
        public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(60); } }

        //This is the Quest Title the player sees at the top of the Gump
        public override object Title { get { return "Shiny Heart"; } }
        //This tells the story of the quest
        public override object Description
        {
            get
            {
                return "A'hoy there adventurer, I've been looking for someone just like you to help me.<br>" +
                    "I've been tying for years to win the heart of my true love and she has finally said yes, on one condition, she has asked me to gather a tremendous amount of gems!<br>" +
                    "If you can help me I have something precious I will trade you.";
            }
        }
        //This decides how the npc reacts in text the player refusing the quest
        public override object Refuse { get { return "I don't need you anyways!"; } }
        //This is what the npc says when the player returns without completing the objective(s)
        public override object Uncomplete { get { return "Get back to the mines!"; } }
        //This is what the Quest Giver says when the player completes the quest.
        public override object Complete { get { return "These will be sure to please her heart!"; } }

        public GemKeyQuest() : base()
        {
            AddObjective(new ObtainObjective(typeof(Amber), "Amber", 1000));
            AddObjective(new ObtainObjective(typeof(Amethyst), "Amethyst", 1000));
            AddObjective(new ObtainObjective(typeof(Citrine), "Citrine", 1000));
            AddObjective(new ObtainObjective(typeof(Diamond), "Diamond", 1000));
            AddObjective(new ObtainObjective(typeof(Emerald), "Emerald", 1000));
            AddObjective(new ObtainObjective(typeof(Ruby), "Ruby", 1000));
            AddObjective(new ObtainObjective(typeof(Sapphire), "Sapphire", 1000));
            AddObjective(new ObtainObjective(typeof(StarSapphire), "Star Sapphire", 1000));
            AddObjective(new ObtainObjective(typeof(Tourmaline), "Tourmaline", 1000));
            AddObjective(new ObtainObjective(typeof(BrilliantAmber), "Brilliant Amber", 1000));// Gold Panning
            AddObjective(new ObtainObjective(typeof(Turquoise), "Turquoise", 1000));
            AddObjective(new ObtainObjective(typeof(FireRuby), "Fire Ruby", 1000));
            AddObjective(new ObtainObjective(typeof(EcruCitrine), "EcruCitrine", 1000));
            AddObjective(new ObtainObjective(typeof(DarkSapphire), "Dark Sapphire", 1000));
            AddObjective(new ObtainObjective(typeof(PerfectEmerald), "Perfect Emerald", 1000));
            AddObjective(new ObtainObjective(typeof(BlueDiamond), "Blue Diamond", 1000));
            AddObjective(new ObtainObjective(typeof(SmallPieceofBlackrock), "Small Blackrock", 500));
            AddObjective(new ObtainObjective(typeof(CrystallineBlackrock), "Crystalline Blackrock", 500));
            AddReward(new BaseReward(typeof(GemKey), "Gem Key"));
        }
    }
}
