
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CrystalCouchNorthAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {5535, 2, 2, 2}, {5535, -2, 2, 2}, {13792, -1, 1, 3}// 19	20	41	
			, {13792, 0, 1, 4}, {13792, 1, 1, 3}// 42	43	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CrystalCouchNorthAddonDeed();
			}
		}

		[ Constructable ]
		public CrystalCouchNorthAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 13949, -2, 1, 0, 0, -1, "crystal couch", 1);// 1
			AddComplexComponent( (BaseAddon) this, 13949, 2, 1, 0, 0, -1, "crystal couch", 1);// 2
			AddComplexComponent( (BaseAddon) this, 13778, -2, 1, 0, 0, -1, "crystal couch", 1);// 3
			AddComplexComponent( (BaseAddon) this, 13778, -1, 1, 0, 0, -1, "crystal couch", 1);// 4
			AddComplexComponent( (BaseAddon) this, 13778, 0, 1, 0, 0, -1, "crystal couch", 1);// 5
			AddComplexComponent( (BaseAddon) this, 13778, 1, 1, 0, 0, -1, "crystal couch", 1);// 6
			AddComplexComponent( (BaseAddon) this, 13778, 2, 1, 0, 0, -1, "crystal couch", 1);// 7
			AddComplexComponent( (BaseAddon) this, 13778, 2, 0, 0, 0, -1, "crystal couch", 1);// 8
			AddComplexComponent( (BaseAddon) this, 13778, -2, 0, 0, 0, -1, "crystal couch", 1);// 9
			AddComplexComponent( (BaseAddon) this, 2921, -1, 0, 0, 191, -1, "", 1);// 10
			AddComplexComponent( (BaseAddon) this, 2920, 1, 0, 0, 191, -1, "", 1);// 11
			AddComplexComponent( (BaseAddon) this, 2922, 0, 0, 0, 191, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 13786, 2, 0, 9, 1153, -1, "crystal lamp", 1);// 13
			AddComplexComponent( (BaseAddon) this, 13786, -2, 0, 9, 1153, -1, "crystal lamp", 1);// 14
			AddComplexComponent( (BaseAddon) this, 2330, 2, 0, 10, 91, -1, "crystal lamp", 1);// 15
			AddComplexComponent( (BaseAddon) this, 2330, -2, 0, 10, 91, -1, "crystal lamp", 1);// 16
			AddComplexComponent( (BaseAddon) this, 3538, 2, 0, 7, 1266, -1, "crystal couch", 1);// 17
			AddComplexComponent( (BaseAddon) this, 3538, -2, 0, 7, 1266, -1, "crystal couch", 1);// 18
			AddComplexComponent( (BaseAddon) this, 2760, -2, -1, 0, 1266, -1, "", 1);// 21
			AddComplexComponent( (BaseAddon) this, 2760, -2, 0, 0, 1266, -1, "", 1);// 22
			AddComplexComponent( (BaseAddon) this, 2760, -2, 1, 0, 1266, -1, "", 1);// 23
			AddComplexComponent( (BaseAddon) this, 2760, -1, -1, 0, 1266, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 2760, -1, 0, 0, 1266, -1, "", 1);// 25
			AddComplexComponent( (BaseAddon) this, 2760, -1, 1, 0, 1266, -1, "", 1);// 26
			AddComplexComponent( (BaseAddon) this, 2760, 0, -1, 0, 1266, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 2760, 0, 0, 0, 1266, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 2760, 0, 1, 0, 1266, -1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 2760, 1, -1, 0, 1266, -1, "", 1);// 30
			AddComplexComponent( (BaseAddon) this, 2760, 1, 0, 0, 1266, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 2760, 1, 1, 0, 1266, -1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 2760, 2, -1, 0, 1266, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 2760, 2, 0, 0, 1266, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 2760, 2, 1, 0, 1266, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 2766, -2, -2, 0, 1266, -1, "", 1);// 36
			AddComplexComponent( (BaseAddon) this, 2766, -1, -2, 0, 1266, -1, "", 1);// 37
			AddComplexComponent( (BaseAddon) this, 2766, 0, -2, 0, 1266, -1, "", 1);// 38
			AddComplexComponent( (BaseAddon) this, 2766, 1, -2, 0, 1266, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 2766, 2, -2, 0, 1266, -1, "", 1);// 40

		}

		public CrystalCouchNorthAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class CrystalCouchNorthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CrystalCouchNorthAddon();
			}
		}

		[Constructable]
		public CrystalCouchNorthAddonDeed()
		{
			Name = "CrystalCouchNorth";
		}

		public CrystalCouchNorthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}