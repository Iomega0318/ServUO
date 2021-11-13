using System;
using Server;

namespace Server.Items
{
	public class FemaleSoulBootsOfATA : Sandals
	{

		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }


		[Constructable]
		public FemaleSoulBootsOfATA()
		{
			Name = "Female Soul Boots Of ATA";
                       
                        ItemID = 21445;
                        Layer = Layer.Shoes;
                        
                        
                        Attributes.BonusDex = 10;
                        Attributes.Luck = 25;

			Attributes.BonusMana = 10;
			Attributes.CastRecovery = 5;
			Attributes.CastSpeed = 3;
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 10;
			Attributes.SpellDamage = 3;
		    Attributes.RegenMana = 5;
			

		Attributes.RegenHits = 5;
		Attributes.RegenStam = 5;
 
		Attributes.BonusInt = 10;
        Attributes.BonusStr = 10;



		

			  StrRequirement = 30;
		}

		public FemaleSoulBootsOfATA( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
