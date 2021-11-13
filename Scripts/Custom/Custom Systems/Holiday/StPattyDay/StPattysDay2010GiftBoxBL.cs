using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[Flipable( 0x232A, 0x232B )]
	public class StPatricksDay2010BL : GiftBox
	{
		[Constructable]
		public StPatricksDay2010BL()
		{
		
		Name = "St. Patricks's Day GiftSet 2010";
		        Hue = 1370;
		        
			DropItem( new LeprechaunCloakBL() );
			DropItem( new LeprechaunPantsBL() );
			DropItem( new LeprechaunBootsBL() );
			DropItem( new LeprechaunShirtBL() );
			DropItem( new LeprechaunHat1BL() );
			DropItem( new LeprechaunHat2BL() );
			DropItem( new LeprechaunPotOfGoldBLAddonDeed() );
		        DropItem( new ShillelaghBL() );
			DropItem( new LeprechaunsMug2010() );
			DropItem( new SaintPatricksHoodedShroud() );
			//DropItem( new GreenAle07() );
			//DropItem( new GreenAle07() );
 
		}

		public StPatricksDay2010BL( Serial serial ) : base( serial )
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