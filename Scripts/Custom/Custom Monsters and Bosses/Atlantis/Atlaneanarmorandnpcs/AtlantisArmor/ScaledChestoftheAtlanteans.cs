
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class ScaledChestOfAtlantis : ChainChest
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public ScaledChestOfAtlantis()
		{
			Name = "Scaled Chest Of Atlantis";
                        Hue = 2823;

						ArmorAttributes.SelfRepair = 30;
			
                          Attributes.WeaponDamage = 15;
                          Attributes.BonusStr = 5;
                          Attributes.LowerRegCost = 35;
			              Attributes.BonusMana = 10;
                          Attributes.RegenMana = 10;
			              Attributes.LowerManaCost = 15;
                          Attributes.CastRecovery = 7;

						  Attributes.CastSpeed = 7;
	 
	 	 	              
	 	 	              Attributes.SpellDamage = 8;

						  Attributes.AttackChance = 15;
	 	 	              Attributes.DefendChance = 25;
	 	 	              Attributes.WeaponDamage = 25;
	 	 	               Attributes.WeaponSpeed = 10;

			  StrRequirement = 30;
		}

		public ScaledChestOfAtlantis( Serial serial ) : base( serial )
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
