
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
	public class VikingBoatAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {7722, -2, 0, 1}, {15976, 5, 1, 1}, {7722, 2, 0, 4}// 7	10	16	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new VikingBoatAddonDeed();
			}
		}

		[ Constructable ]
		public VikingBoatAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 16020, -3, 0, 1, 0, -1, "Viking Boat", 1);// 1
			AddComplexComponent( (BaseAddon) this, 16018, -3, 1, 1, 0, -1, "Viking Boat", 1);// 2
			AddComplexComponent( (BaseAddon) this, 16017, -3, 2, 1, 0, -1, "Viking Boat", 1);// 3
			AddComplexComponent( (BaseAddon) this, 15971, -4, 1, 1, 0, -1, "Viking Boat", 1);// 4
			AddComplexComponent( (BaseAddon) this, 1981, 0, -1, 0, 0, -1, "Viking Boat", 1);// 5
			AddComplexComponent( (BaseAddon) this, 15994, 4, 1, 1, 0, -1, "Viking Boat", 1);// 6
			AddComplexComponent( (BaseAddon) this, 15993, 4, 2, 1, 0, -1, "Viking Boat", 1);// 8
			AddComplexComponent( (BaseAddon) this, 2860, 3, 1, 4, 0, -1, "Viking Boat", 1);// 9
			AddComplexComponent( (BaseAddon) this, 15999, 2, 0, 1, 0, -1, "Viking Boat", 1);// 11
			AddComplexComponent( (BaseAddon) this, 16011, -1, 1, 1, 0, -1, "Viking Boat", 1);// 12
			AddComplexComponent( (BaseAddon) this, 15995, 4, 0, 1, 0, -1, "Viking Boat", 1);// 13
			AddComplexComponent( (BaseAddon) this, 15996, 3, 2, 1, 0, -1, "Viking Boat", 1);// 14
			AddComplexComponent( (BaseAddon) this, 16011, 3, 1, 1, 0, -1, "Viking Boat", 1);// 15
			AddComplexComponent( (BaseAddon) this, 15997, 3, 0, 1, 0, -1, "Viking Boat", 1);// 17
			AddComplexComponent( (BaseAddon) this, 16015, -2, 1, 1, 0, -1, "Viking Boat", 1);// 18
			AddComplexComponent( (BaseAddon) this, 15977, 5, 1, 1, 0, -1, "Viking Boat", 1);// 19
			AddComplexComponent( (BaseAddon) this, 16014, -2, 2, 1, 0, -1, "Viking Boat", 1);// 20
			AddComplexComponent( (BaseAddon) this, 16011, 2, 1, 1, 0, -1, "Viking Boat", 1);// 21
			AddComplexComponent( (BaseAddon) this, 16011, 1, 1, 1, 0, -1, "Viking Boat", 1);// 22
			AddComplexComponent( (BaseAddon) this, 16013, -1, 0, 1, 0, -1, "Viking Boat", 1);// 23
			AddComplexComponent( (BaseAddon) this, 16011, 0, 2, 1, 0, -1, "Viking Boat", 1);// 24
			AddComplexComponent( (BaseAddon) this, 16016, -2, 0, 1, 0, -1, "Viking Boat", 1);// 25
			AddComplexComponent( (BaseAddon) this, 16008, 0, 0, 1, 0, -1, "Viking Boat", 1);// 26
			AddComplexComponent( (BaseAddon) this, 2860, -1, 1, 4, 0, -1, "Viking Boat", 1);// 27
			AddComplexComponent( (BaseAddon) this, 15998, 2, 2, 1, 0, -1, "Viking Boat", 1);// 28
			AddComplexComponent( (BaseAddon) this, 16001, 1, 0, 1, 0, -1, "Viking Boat", 1);// 29
			AddComplexComponent( (BaseAddon) this, 16000, 1, 2, 1, 0, -1, "Viking Boat", 1);// 30
			AddComplexComponent( (BaseAddon) this, 16012, -1, 2, 1, 0, -1, "Viking Boat", 1);// 31
			AddComplexComponent( (BaseAddon) this, 16011, 0, 1, 1, 0, -1, "Viking Boat", 1);// 32

		}

		public VikingBoatAddon( Serial serial ) : base( serial )
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

	public class VikingBoatAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new VikingBoatAddon();
			}
		}

		[Constructable]
		public VikingBoatAddonDeed()
		{
			Name = "VikingBoat";
		}

		public VikingBoatAddonDeed( Serial serial ) : base( serial )
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