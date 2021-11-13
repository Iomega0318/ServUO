
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class MermaidsTail : WoodenKiteShield
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public MermaidsTail()
		{
			Name = "Mermaid's Tail";
                        Hue = 1285;
                        ArmorAttributes.SelfRepair = 15;
                        Attributes.SpellChanneling = 2;
                        Attributes.AttackChance = 5;
                        Attributes.CastSpeed = 1;
                        Attributes.DefendChance = 15;
                        Attributes.Luck = 5;
                        Attributes.SpellDamage = 5;
                        Attributes.RegenStam = 5;
                        Attributes.BonusDex = 5;
                       
			PhysicalBonus = 15;

						   ColdBonus = 10;
			   EnergyBonus = 10;
			   FireBonus = 10;
			   PhysicalBonus = 10;
			   PoisonBonus = 10;

		}

		public MermaidsTail( Serial serial ) : base( serial )
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
