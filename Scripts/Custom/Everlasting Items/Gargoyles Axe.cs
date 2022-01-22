using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0xf45, 0xf46 )]
	public class EverlastingGargoylesAxe : BaseAxe
	{
		public override HarvestSystem HarvestSystem{ get{ return Lumberjacking.System; } }

		[Constructable]
		public EverlastingGargoylesAxe()
            : base( 0xf45 )
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Gargoyles Axe";
            Hue = 1153;
		}

		public EverlastingGargoylesAxe( Serial serial )
            : base( serial )
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
