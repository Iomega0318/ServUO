
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class SkywardReachEnergyHides : ChainChest
	{

		public override int ArtifactRarity{ get{ return 81; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public SkywardReachEnergyHides()
		{
			Name = "Skyward Reach Energy Hides";
                        Hue = 0;
						ItemID = 21492; 

						ArmorAttributes.SelfRepair = 25;
			
                          Attributes.WeaponDamage = 15;
                          Attributes.BonusStr = 5;
                          Attributes.LowerRegCost = 35;
			              Attributes.BonusMana = 10;
                          Attributes.RegenMana = 10;
			              Attributes.LowerManaCost = 20;
                          Attributes.CastRecovery = 7;

						  Attributes.CastSpeed = 7;
	 
	 	 	              
	 	 	               Attributes.AttackChance = 15;
	 	 	              Attributes.DefendChance = 25;
	 	 	              Attributes.WeaponDamage = 25;
	 	 	               Attributes.WeaponSpeed = 20;

			Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 8;

			EnergyBonus = 10;

			  StrRequirement = 50;
		}

		public SkywardReachEnergyHides( Serial serial ) : base( serial )
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
