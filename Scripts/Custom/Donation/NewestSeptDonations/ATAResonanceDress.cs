using System;
using Server;

namespace Server.Items
{
	public class ATAResonanceDress : Robe
	{
		public override int LabelNumber{ get{ return 1094926; } } // Good Samaritan of Britannia [Replica]

		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }


		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public ATAResonanceDress()
		{
			
         Name = "ATA Resonance Dress";
         Layer = Layer.OuterTorso;
         ItemID = 21590;
      

	

            Attributes.SpellDamage = 2;
            Attributes.CastSpeed = 2;
            Attributes.CastRecovery = 2;
            Attributes.LowerManaCost = 2;
            Attributes.LowerRegCost = 15;
            Attributes.RegenMana = 5;
            Attributes.BonusMana = 5;

		
		Attributes.ReflectPhysical = 10;
		Attributes.Luck = 10;
		Attributes.SpellChanneling = 2;

		Attributes.DefendChance = 10;
		Attributes.AttackChance = 10;

		}

		public ATAResonanceDress( Serial serial ) : base( serial )
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