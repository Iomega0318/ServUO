
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class PrincessLunasNecklace : SilverNecklace
	{

		public override int ArtifactRarity{ get{ return 80; } }

		[Constructable]
		public PrincessLunasNecklace()
		{
			Name = "Princess Luna's Necklace";
                        Hue = 1289;
                        Attributes.CastRecovery = 1;
                        Attributes.CastSpeed = 1;
                        Attributes.DefendChance = 2;
                       
                        Attributes.SpellDamage = 5;
                        Attributes.RegenMana = 2;
                        Attributes.RegenStam = 2;
                        Attributes.LowerManaCost = 1;
                        Attributes.BonusStr = 2;
                        Attributes.Luck = 50;

		}

		public PrincessLunasNecklace( Serial serial ) : base( serial )
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
