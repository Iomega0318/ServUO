
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class CrownOfAtlantis : PlateHelm
        {
		
		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public CrownOfAtlantis()
		{
			ItemID = 11120;
                        Hue = 2221;
			Name = "Crown Of Atlantis";
                        ArmorAttributes.SelfRepair = 30;
                        Attributes.SpellDamage = 3;
                        Attributes.LowerRegCost = 25;
                        Attributes.CastSpeed = 2;
                        Attributes.CastRecovery = 2;
                        Attributes.AttackChance = 25;
                        
                        Attributes.BonusInt = 5;
			Attributes.BonusMana = 10;
			Attributes.RegenMana = 2;
			Attributes.LowerManaCost = 8;
			EnergyBonus = 15;
						  
						  Attributes.Luck = 25;
			  Attributes.DefendChance = 5;


			  StrRequirement = 10;
		}

		public CrownOfAtlantis( Serial serial ) : base( serial )
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
