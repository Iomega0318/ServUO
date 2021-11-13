
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class SerpentsSkinSandalsOfAtlantis : Sandals
	{


		public override int ArtifactRarity{ get{ return 80; } }

		[Constructable]
		public SerpentsSkinSandalsOfAtlantis()
		{
			Name = "Serpent's Skin Sandals Of Atlantis";
                        Hue = 2823;
                        ItemID = 5901;
                        Layer = Layer.Shoes;
                        
						Attributes.RegenHits = 12;
                        Attributes.LowerManaCost = 10;
                        Attributes.BonusDex = 10;
                        Attributes.Luck = 25;

              Attributes.WeaponDamage = 15;
			  Attributes.WeaponSpeed = 15;


		

			  StrRequirement = 30;
		}

		public SerpentsSkinSandalsOfAtlantis( Serial serial ) : base( serial )
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
