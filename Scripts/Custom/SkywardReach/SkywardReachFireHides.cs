
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class SkywardReachFireHides : PlateLegs
	{

		public override int ArtifactRarity{ get{ return 81; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public SkywardReachFireHides()
		{
			Name = "Skyward Reach Fire Hides";
                        Hue = 0;
						ItemID = 21493;
                        
						ArmorAttributes.SelfRepair = 30;
                        Attributes.RegenHits = 12;
                        Attributes.RegenMana = 12;
                        Attributes.LowerManaCost = 15;
                        Attributes.BonusInt = 10;
                        Attributes.Luck = 20;

			 FireBonus = 10;

			Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 8;

			StrRequirement = 50;
		}

		public SkywardReachFireHides( Serial serial ) : base( serial )
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
