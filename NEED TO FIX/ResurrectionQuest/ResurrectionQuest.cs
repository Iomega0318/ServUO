using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{ 
    public class TheGroveResurrectionQuest : BaseQuest
    { 
        public TheGroveResurrectionQuest()
            : base()
        { 
            this.AddObjective(new SlayObjective(typeof(KeeperOfSouls), "The Keeper of Souls", 1));
            this.AddObjective(new SlayObjective(typeof(KeeperMinion), "The Keeper's Minion", 1));
			
            this.AddReward(new BaseReward(typeof(ResurrectionSword), 1072584));
        }

        /* The Grove Resurrection */
        public override object Title
        {
            get
            {
                return 1074739;
            }
        }
        /* Why hello there lone warrior! Have you the time to help out an old fart like me?
        You see, I've been trying to defeat this beast for years but i've come too old to get the job done.
        He took over a sacred place, years ago when it was first built and now it is unused and ridden of people
        because he either scares them away, or just eats them as his own personal lunch. He's monstrous i tell you.
        If you could be so kind and rid this area of the god forsaken beast, i will reward you greatly! Ah i almost
        forgot! Poke around the shrine in destard, kill the Keeper's Minion, stand on shrine and say 'I challenge thee' */
        public override object Description
        {
            get
            {
                return 1074740;
            }
        }
        /* You just don't understand the gravity of the situation.  If you did, you'd agree to my task. */
        public override object Refuse
        {
            get
            {
                return 1074745;
            }
        }
        /* Perhaps you are confused as to where this beast resides, look around the shrine within Destard. */
        public override object Uncomplete
        {
            get
            {
                return 1074746;
            }
        }
        /* Ah! Is it done?! Has the beast been slain?! Hooray! You have done very well for me and for The Grove as a whole! */
        public override object Complete
        {
            get
            {
                return 1074747;
            }
        }
        public override bool CanOffer()
        {
            return MondainsLegacy.TwistedWeald;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Gemini : MondainQuester
    {
        [Constructable]
        public Gemini()
            : base("Gemini", "The Lost Traveler")
        { 
        }

        public Gemini(Serial serial)
            : base(serial)
        {
        }

        public override Type[] Quests
        {
            get
            {
                return new Type[] 
                {
                    typeof(TheGroveResurrectionQuest),
                };
            }
        }
        public override void InitBody()
        {
            this.InitStats(100, 100, 25);
			
            this.Female = false;
            this.Race = Race.Human;
			
            this.Hue = 0x841D;
        }

        public override void InitOutfit()
        {
            this.AddItem(new Backpack());
            this.AddItem(new Sandals(1920));
            this.AddItem(new Skirt(1910));
            this.AddItem(new HalfApron(1920));
            this.AddItem(new WizardsHat(1920));
            this.AddItem(new Doublet(1910));
            this.AddItem(new FancyShirt(1920));
            this.AddItem(new QuiverOfInfinity(1920));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}