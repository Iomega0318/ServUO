using System;
using Server;
namespace Server.Items
{
	public class AtlantisShieldOfTheWhaleBelly : OrderShield
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public AtlantisShieldOfTheWhaleBelly()
		{
			Weight = 3.0; 
            		Name = "Atlantis Shield Of The Whale Belly"; 
            		Hue = 1153;

			
			
			Attributes.BonusStr = 10;
			Attributes.DefendChance = 15;
			Attributes.LowerRegCost = 15;
			Attributes.ReflectPhysical = 15;
			Attributes.RegenHits = 4;
			Attributes.SpellChanneling = 1;
			Attributes.NightSight = 25;
			ArmorAttributes.SelfRepair = 30;
            Attributes.WeaponDamage = 3;
			
            

			EnergyBonus = 25;
			StrRequirement = 20;

			

		}

		public AtlantisShieldOfTheWhaleBelly( Serial serial ) : base( serial )
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