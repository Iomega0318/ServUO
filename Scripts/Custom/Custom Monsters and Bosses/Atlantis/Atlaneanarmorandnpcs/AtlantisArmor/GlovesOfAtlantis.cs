
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class GlovesOfAtlantis : BoneGloves
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public GlovesOfAtlantis()
		{
			Name = "Gloves Of Atlantis";
                        Hue = 2823;
                        
						ArmorAttributes.SelfRepair = 30;
                        Attributes.CastRecovery = 1;
                        Attributes.CastSpeed = 1;
                        Attributes.AttackChance = 5;
                        Attributes.Luck = 20;
                        Attributes.SpellDamage = 5;
                        Attributes.RegenHits = 5;
                        Attributes.RegenStam = 5;
                        Attributes.LowerManaCost = 2;
                        Attributes.BonusDex = 5;
                        Attributes.Luck = 5;
			
						  Attributes.DefendChance = 5;
			  Attributes.LowerRegCost = 5;
			  Attributes.NightSight = 25;

		}

		public GlovesOfAtlantis( Serial serial ) : base( serial )
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
