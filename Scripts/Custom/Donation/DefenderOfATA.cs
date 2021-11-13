using System;
using Server;
namespace Server.Items
{
	public class DefenderOfATA : MetalShield
	{
		public override int ArtifactRarity{ get{ return 101; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public DefenderOfATA()
		{
			Weight = 5.0; 
            		Name = "Defender Of ATA"; 
            		Hue = 0;
					ItemID = 21535;

		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			
			Attributes.BonusDex = 10;
			Attributes.BonusStr = 15;
			Attributes.BonusHits = 25;
				 	 	
			Attributes.DefendChance = 20;
			Attributes.AttackChance = 15;
			Attributes.ReflectPhysical = 15;

			
			Attributes.LowerRegCost = 25;
			Attributes.ReflectPhysical = 15;
			
			Attributes.RegenHits = 4;
			Attributes.RegenStam = 10;

			Attributes.WeaponDamage = 15;
	 	 	Attributes.WeaponSpeed = 15;

			Attributes.SpellChanneling = 2;
			
            ArmorAttributes.SelfRepair = 50;

			ColdBonus = 25;
			StrRequirement = 10;

            

			

		}

		public DefenderOfATA( Serial serial ) : base( serial )
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