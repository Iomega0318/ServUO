
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class SerpentsSkinChestOfAtlantis : FemalePlateChest
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public SerpentsSkinChestOfAtlantis()
		{
			Name = "Serpent's Skin Chest Of Atlantis";
                        Hue = 2823;
						
						ArmorAttributes.SelfRepair = 30;
						
						Attributes.BonusStr = 5;
                        Attributes.LowerManaCost = 10;
                        ArmorAttributes.MageArmor = 2;
                        Attributes.BonusHits = 5;
			Attributes.ReflectPhysical = 15;
			PhysicalBonus = 15;
		}

		public SerpentsSkinChestOfAtlantis( Serial serial ) : base( serial )
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
