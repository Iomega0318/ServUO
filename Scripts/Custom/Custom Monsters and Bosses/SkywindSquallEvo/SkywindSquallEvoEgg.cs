using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class SkywindSquallEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new SkywindSquall( "a skywind squall hatchling" );
		}

		[Constructable]
		public SkywindSquallEgg() : base()
		{
			Name = "a skywind squall egg";
			HatchDuration = 0.01;		// 15 minutes
                                                Hue = 1372;
		}

		public SkywindSquallEgg( Serial serial ) : base ( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}