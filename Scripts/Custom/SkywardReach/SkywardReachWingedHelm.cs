
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class SkywardReachWingedHelm : PlateHelm
        {
		
		public override int ArtifactRarity{ get{ return 81; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public SkywardReachWingedHelm()
		{
			ItemID = 21490;
                        Hue = 0;
              

			Name = "Skyward Reach Winged Helm";
                        
						
						ArmorAttributes.SelfRepair = 30;
                        Attributes.SpellDamage = 3;
                        Attributes.LowerRegCost = 25;
                        Attributes.CastSpeed = 3;
                        Attributes.CastRecovery = 3;
                        Attributes.AttackChance = 25;
                        
                        Attributes.BonusInt = 5;
			Attributes.BonusMana = 15;
			Attributes.RegenMana = 5;
			Attributes.LowerManaCost = 10;
			
			ColdBonus = 11;
						  
			Attributes.Luck = 25;
			  Attributes.DefendChance = 10;


			  StrRequirement = 45;
		}

		public SkywardReachWingedHelm( Serial serial ) : base( serial )
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
