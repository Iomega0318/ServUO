
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class ScaledHelmetOfAtlantis : ChainHatsuburi
        {
		
		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public ScaledHelmetOfAtlantis()
		{
			ItemID = 10100;
                        Hue = 2823;
			Name = "Scaled Helmet Of Atlantis";
                        
						ArmorAttributes.SelfRepair = 30;
                        Attributes.SpellDamage = 2;
                        Attributes.LowerRegCost = 5;
                        Attributes.CastSpeed = 2;
                        Attributes.CastRecovery = 5;
                        Attributes.AttackChance = 10;
                        Attributes.BonusDex = 2;
                        Attributes.BonusInt = 5;
			Attributes.BonusMana = 2;
			Attributes.RegenMana = 5;
			Attributes.LowerManaCost = 2;
			EnergyBonus = 2;
		}

		public ScaledHelmetOfAtlantis( Serial serial ) : base( serial )
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
