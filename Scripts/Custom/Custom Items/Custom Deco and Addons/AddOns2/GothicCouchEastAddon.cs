
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
	public class GothicCouchEastAddon : BaseAddon
	{
         
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new GothicCouchEastAddonDeed();
			}
		}

		[ Constructable ]
		public GothicCouchEastAddon()
		{



			AddComplexComponent( (BaseAddon) this, 2767, 2, -2, 0, 1261, -1, "gothic couch", 1);// 1
			AddComplexComponent( (BaseAddon) this, 3530, -1, -2, 5, 1107, -1, "gothic couch", 1);// 2
			AddComplexComponent( (BaseAddon) this, 12566, -2, -2, 1, 0, -1, "gothic couch", 1);// 3
			AddComplexComponent( (BaseAddon) this, 2760, 1, -2, 0, 1261, -1, "gothic couch", 1);// 4
			AddComplexComponent( (BaseAddon) this, 13042, 0, -2, 0, 1106, -1, "gothic couch", 1);// 5
			AddComplexComponent( (BaseAddon) this, 13833, -1, -2, 0, 1105, -1, "gothic couch", 1);// 6
			AddComplexComponent( (BaseAddon) this, 2914, 0, 1, 0, 1108, -1, "gothic couch", 1);// 7
			AddComplexComponent( (BaseAddon) this, 3799, -2, -1, 4, 1103, -1, "gothic couch", 1);// 8
			AddComplexComponent( (BaseAddon) this, 5028, -1, 1, 5, 1261, -1, "gothic couch", 1);// 9
			AddComplexComponent( (BaseAddon) this, 2767, 2, -1, 0, 1261, -1, "gothic couch", 1);// 10
			AddComplexComponent( (BaseAddon) this, 2760, 1, -1, 0, 1261, -1, "gothic couch", 1);// 11
			AddComplexComponent( (BaseAddon) this, 2760, 1, 0, 0, 1261, -1, "gothic couch", 1);// 12
			AddComplexComponent( (BaseAddon) this, 3799, -2, 0, 4, 1103, -1, "gothic couch", 1);// 13
			AddComplexComponent( (BaseAddon) this, 13042, 0, 2, 0, 1106, -1, "gothic couch", 1);// 14
			AddComplexComponent( (BaseAddon) this, 12566, -2, 2, 0, 0, -1, "gothic couch", 1);// 15
			AddComplexComponent( (BaseAddon) this, 3530, -1, 2, 5, 1107, -1, "gothic couch", 1);// 16
			AddComplexComponent( (BaseAddon) this, 2760, 0, -1, 0, 1261, -1, "gothic couch", 1);// 17
			AddComplexComponent( (BaseAddon) this, 2767, 2, 1, 0, 1261, -1, "gothic couch", 1);// 18
			AddComplexComponent( (BaseAddon) this, 5028, -1, -1, 5, 1261, -1, "gothic couch", 1);// 19
			AddComplexComponent( (BaseAddon) this, 3530, -1, 1, 5, 1107, -1, "gothic couch", 1);// 20
			AddComplexComponent( (BaseAddon) this, 2760, 1, 1, 0, 1261, -1, "gothic couch", 1);// 21
			AddComplexComponent( (BaseAddon) this, 13833, -1, 2, 0, 1105, -1, "gothic couch", 1);// 22
			AddComplexComponent( (BaseAddon) this, 3530, -1, -1, 5, 1107, -1, "gothic couch", 1);// 23
			AddComplexComponent( (BaseAddon) this, 2915, 0, -1, 0, 1108, -1, "gothic couch", 1);// 24
			AddComplexComponent( (BaseAddon) this, 2916, 0, 0, 0, 1108, -1, "gothic couch", 1);// 25
			AddComplexComponent( (BaseAddon) this, 2760, 0, 0, 0, 1261, -1, "gothic couch", 1);// 26
			AddComplexComponent( (BaseAddon) this, 6228, 1, -1, 17, 0, 1, "skull with candle", 1);// 27
			AddComplexComponent( (BaseAddon) this, 3530, -1, 0, 5, 1107, -1, "gothic couch", 1);// 28
			AddComplexComponent( (BaseAddon) this, 13833, -1, 0, 0, 1105, -1, "gothic couch", 1);// 29
			AddComplexComponent( (BaseAddon) this, 2760, 0, 1, 0, 1261, -1, "gothic couch", 1);// 30
			AddComplexComponent( (BaseAddon) this, 3799, -2, 1, 5, 1103, -1, "gothic couch", 1);// 31
			AddComplexComponent( (BaseAddon) this, 2767, 2, 0, 0, 1261, -1, "gothic couch", 1);// 32
			AddComplexComponent( (BaseAddon) this, 2767, 2, 2, 0, 1261, -1, "gothic couch", 1);// 33
			AddComplexComponent( (BaseAddon) this, 2760, 1, 2, 0, 1261, -1, "gothic couch", 1);// 34
			AddComplexComponent( (BaseAddon) this, 13833, -1, 1, 0, 1105, -1, "gothic couch", 1);// 35
			AddComplexComponent( (BaseAddon) this, 13833, -1, -1, 0, 1105, -1, "gothic couch", 1);// 36
			AddComplexComponent( (BaseAddon) this, 5028, -1, 0, 5, 1261, -1, "gothic couch", 1);// 37

		}

		public GothicCouchEastAddon( Serial serial ) : base( serial )
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

	public class GothicCouchEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new GothicCouchEastAddon();
			}
		}

		[Constructable]
		public GothicCouchEastAddonDeed()
		{
			Name = "GothicCouchEast";
		}

		public GothicCouchEastAddonDeed( Serial serial ) : base( serial )
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