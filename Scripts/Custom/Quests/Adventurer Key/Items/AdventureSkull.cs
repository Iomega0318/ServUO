//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/10/2021 2:42:03 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class AdventureSkull : PeerlessKey
	{

		public override int Lifespan{ get{ return 600; } }

		[Constructable]
		public AdventureSkull() : base(0x1AE1)
		{
			Name ="Skull of the Orc Chieftan";
			Weight = 1.00;
			//Hue = 1;
		}

		public AdventureSkull( Serial serial ) : base( serial )
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
