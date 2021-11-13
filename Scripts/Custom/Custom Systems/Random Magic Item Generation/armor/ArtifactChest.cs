// Scripted by Thor86
using System;
using Server;

namespace Server.Items
{
    public class ArtifactChest : LeatherChest
	{
        //public override int ArtifactRarity{ get{ return 6; } }
        public override int ArtifactRarity { get { return Utility.RandomMinMax(1, 10); } }

        public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } } 
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

        public override bool AllowMaleWearer { get { return true; } }
	 	public override int InitMinHits{ get{ return 255; } }
	 	public override int InitMaxHits{ get{ return 255; } }

        private static string[] m_Names = new string[]
		{
                  // names based off past expanions
			"Chest from the Order armory",
	    	"Chest from the Chaos armory",
            "Chest crafted during the The Second Age",
            "Chest crafted during the Renaissance ",
            "Chest crafted during the Third Dawn",
	    	"Chest crafted during the Age of Shadows",

                // names based off past npc's
            "Chest crafted by Lord British",
            "Chest crafted by Lord Blackthorn",
            "Chest crafted by Lady Dawn",// She was a great warrior and great follower of Virtue, and her career eventually led to her being crowned Queen,
            "Chest crafted by Sir Dupre",//Dupre is usually portrayed in official fiction as leading the True Britannians Faction in Felucca,
            "Chest crafted by Minax",//Minax is an important NPC villain in the history of Ultima. Also called the Dark Mistress, Minax first appeared in the single player game, Ultima II: Revenge of the Enchantress,
            "Chest crafted by Mondain",//Mondain was an evil sorcerer who heralded the First Age of Darkness in Sosaria. 
            "Chest crafted by The Avatar", // Avatar from the single player games
            "Chest crafted by Exodus",//Exodus was the prodigy of Mondain and Minax,
            "Chest crafted by King Casca", // Yew prosecutor turned King before killed by dawn on easports shards

             // names based on monsters
           "Chest crafted by a Goblin",
           "Chest crafted by a Meer",
           "Chest crafted by a Troll",
           "Chest crafted by a Ogre",
           "Chest crafted by a Daemon",
           "Chest crafted by a Orc",
           "Chest crafted by a Juka",
           "Chest crafted by a Liche",
           "Chest crafted by a Lizardman",
           "Chest crafted by a Ophidian",
           "Chest crafted by a Ratman",
           "Chest crafted by a Terathan",

                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
            "Chest from the Ancient Samurai Empire"
		};

	 	[Constructable]
	 	public ArtifactChest()
	 	{
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomMinMax(5, 3000);
            // Name = "Artifact Chest";

            // random chance to get diffent resist %
            PhysicalBonus = Utility.RandomMinMax(4, 13);
            FireBonus = Utility.RandomMinMax( 4, 13);
            ColdBonus = Utility.RandomMinMax(4, 13);
            PoisonBonus = Utility.RandomMinMax(4, 13);
            EnergyBonus = Utility.RandomMinMax(4, 13);

            // id it shows item as
            switch (Utility.Random(5))
            {
                case 0: ItemID = 5199; break;//bone
                case 1: ItemID = 5100; break;//ring
                case 2: ItemID = 5055; break;//chain
                case 3: ItemID = 5068; break;//leather
                case 4: ItemID = 5141; break;//plate
            }
            // random chance to get these stats added to item ,chance of one stat per switch
            switch (Utility.Random(5))
            {
                case 0: Attributes.RegenHits = Utility.RandomMinMax(1, 4); break;
                case 1: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 2: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 3: Attributes.DefendChance = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.AttackChance = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(6))
            {
                case 0: Attributes.BonusStr = Utility.RandomMinMax(1, 5); break;
                case 1: Attributes.BonusDex = Utility.RandomMinMax(1, 5); break;
                case 2: Attributes.BonusInt = Utility.RandomMinMax(1, 5); break;
                case 3: Attributes.BonusHits = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.BonusStam = Utility.RandomMinMax(10, 20); break;
                case 5: Attributes.BonusMana = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(8))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }
            switch (Utility.Random(6))
            {
                case 0: Attributes.LowerManaCost = Utility.RandomMinMax(5, 10); break;
                case 1: Attributes.LowerRegCost = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.ReflectPhysical = Utility.RandomMinMax(5, 20); break;
                case 3: Attributes.EnhancePotions = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.Luck = Utility.RandomMinMax(100, 200); break;
                case 5: Attributes.NightSight = 1; break;
            }
            switch (Utility.Random(8))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }
 //Disadvantages
            // can be brittle 
            switch (Utility.Random(2))
            {
                case 0: Attributes.Brittle = 1; break;
            }
            // can be cursed 
            switch (Utility.Random(2)) { case 0: LootType = LootType.Cursed; break; }

            // can be unlucky
            switch (Utility.Random(2))
            {
                case 0: Attributes.Luck = -100; break;
            }
        }

        public ArtifactChest(Serial serial)
            : base(serial)
	 	{
	 	}
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
