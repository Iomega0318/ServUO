
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
	public class GothicWaterfountainSouthAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {3216, -2, -1, 7}, {3216, 2, -1, 7}, {3255, 1, 1, 15}// 1	9	11	
			, {3332, 0, 1, 18}, {5953, 0, 0, 17}, {12569, 3, 2, 0}// 19	21	22	
			, {3216, 1, -1, 7}, {12561, 0, -1, 8}, {12560, 1, -1, 8}// 23	24	25	
			, {12560, -1, -1, 8}, {13422, 1, 0, 14}, {13422, -1, 1, 14}// 26	29	30	
			, {13422, 0, 0, 14}, {13422, -1, 0, 14}, {3521, 1, 1, 20}// 31	32	33	
			, {3338, 1, 1, 20}, {3332, 1, 0, 16}, {13422, 0, 1, 14}// 34	35	36	
			, {13422, 1, 1, 14}// 38	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new GothicWaterfountainSouthAddonDeed();
			}
		}

		[ Constructable ]
		public GothicWaterfountainSouthAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 13878, -2, 1, 9, 1102, -1, "", 1);// 2
			AddComplexComponent( (BaseAddon) this, 2328, -2, 1, 7, 1102, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 2328, -2, 2, 7, 1102, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 2328, -2, -1, 7, 1102, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 13878, -2, 0, 9, 1102, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 2328, -2, 0, 7, 1102, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 13879, 0, 1, 9, 1102, -1, "", 1);// 8
			AddComplexComponent( (BaseAddon) this, 2328, -1, 2, 7, 1102, -1, "", 1);// 10
			AddComplexComponent( (BaseAddon) this, 2328, 0, 2, 7, 1102, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 13878, 1, 0, 9, 1102, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 2328, 1, 2, 7, 1102, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 2328, 2, 2, 7, 1102, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 2328, 2, 1, 7, 1102, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 2328, 2, -1, 7, 1102, -1, "", 1);// 17
			AddComplexComponent( (BaseAddon) this, 2328, 1, -1, 7, 1102, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 6211, 0, 0, 13, 0, -1, "water", 1);// 20
			AddComplexComponent( (BaseAddon) this, 13879, -1, 1, 9, 1102, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 2328, 2, 0, 7, 1102, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 13844, 1, 1, 9, 1102, -1, "", 1);// 37

		}

		public GothicWaterfountainSouthAddon( Serial serial ) : base( serial )
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

	public class GothicWaterfountainSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new GothicWaterfountainSouthAddon();
			}
		}

		[Constructable]
		public GothicWaterfountainSouthAddonDeed()
		{
			Name = "GothicWaterfountainSouth";
		}

		public GothicWaterfountainSouthAddonDeed( Serial serial ) : base( serial )
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