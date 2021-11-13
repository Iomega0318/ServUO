using System;

namespace Server.Items
{

public class AtlantisGoggles : BaseHat
	{
	public override int ArtifactRarity{ get{ return 80; } }

		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 5; } }


		[Constructable]
		public AtlantisGoggles() : base( 0x2FB8 )
		{
			Name = "Atlantis Goggles";
                        Hue = 1289;
                        Attributes.CastRecovery = 1;
                        Attributes.CastSpeed = 1;
                        Attributes.DefendChance = 2;
                       
                        Attributes.SpellDamage = 5;
                        Attributes.RegenMana = 2;
                        Attributes.RegenStam = 2;
                        Attributes.LowerManaCost = 1;
                        Attributes.BonusStr = 1;
                        Attributes.Luck = 25;

			Weight = 1.0;
		}

		public AtlantisGoggles( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

