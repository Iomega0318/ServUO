using System;
using Server;

namespace Server.Items
{
	public class GlovesOfAtA : LeatherGloves
	{
		public override int LabelNumber{ get{ return 1061092; } } // Gauntlets of Nobility
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 17; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public GlovesOfAtA()
		{
            Hue = 1150;
            Name = "Gloves Of AtA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

            Attributes.BonusInt = 25;
            Attributes.BonusStr = 20;
			Attributes.BonusDex = 10;
			Attributes.RegenHits = 6;
			ArmorAttributes.SelfRepair = 50;
			Attributes.Luck = 25;
            Attributes.DefendChance = 20;
			Attributes.LowerRegCost = 10;
			ArmorAttributes.MageArmor = 2;
	        Attributes.ReflectPhysical = 10;

            Attributes.BonusMana = 25;
            Attributes.BonusHits = 25;
	 	 	Attributes.AttackChance = 15;


	 	 	Attributes.CastSpeed = 4;
	 	 	Attributes.CastRecovery = 5;
	 	 	Attributes.SpellDamage = 10;
	 	 
		}

		public GlovesOfAtA( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x562 )
					Hue = 1150;

				PhysicalBonus = 2;
				PoisonBonus = 17;
			}
		}
	}
}