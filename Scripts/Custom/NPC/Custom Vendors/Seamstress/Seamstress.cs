// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{ 
	public class Seamstress : BaseVendor
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Seamstress() : base( "The Seamstress" )
		{
			SetSkill( SkillName.Tailoring, 64.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSeamstress() );
		}

		public override VendorShoeType ShoeType{ get{ return VendorShoeType.Sandals; } }

		public Seamstress( Serial serial ) : base( serial )
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