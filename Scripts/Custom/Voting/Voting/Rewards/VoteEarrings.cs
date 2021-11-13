using System; 
using Server; 

namespace Server.Items
{ 
	public class VoteEarrings : SilverEarrings
	{
		[Constructable]
		public VoteEarrings()
		{
			Name = "I Voted!";
			Hue = 0xB;

			Attributes.BonusDex = 10;
			Attributes.BonusStr = 10;
			Attributes.BonusInt = 10;

			Resistances.Physical = 20;
			Resistances.Fire = 20;
			Resistances.Cold = 20;
			Resistances.Poison = 20;
			Resistances.Energy = 20;

			Attributes.CastSpeed = 3;
			Attributes.CastRecovery = 4;
		}

		public VoteEarrings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
} 