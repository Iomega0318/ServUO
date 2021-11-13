
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
	public class PantryAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {5633, -1, 0, 16}, {2519, 0, 0, 1}, {2519, 0, 0, 0}// 4	5	6	
			, {6277, 0, 0, 0}, {2416, 1, 0, 18}, {5636, 1, 0, 12}// 7	8	10	
			, {5634, -2, 0, 13}, {1825, -2, 0, 0}, {2541, -1, 0, 0}// 14	15	16	
			, {11599, 1, 0, 6}, {4163, 0, 0, 6}, {2431, 0, 0, 0}// 17	18	20	
			, {2516, 0, 0, 0}, {5638, 0, 0, 12}, {5625, -1, 0, 12}// 29	30	31	
			, {5928, -1, 0, 6}, {2519, 0, 0, 2}, {4329, 1, 0, 0}// 32	33	34	
			, {5637, 1, 0, 0}, {2212, 2, 1, 0}, {5931, 1, 1, 13}// 35	36	37	
			, {2512, 0, 1, 14}, {5926, 0, 1, 12}, {5921, -1, 1, 12}// 38	39	40	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new PantryAddonDeed();
			}
		}

		[ Constructable ]
		public PantryAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 1824, 2, 0, 10, 0, -1, "pantry", 1);// 1
			AddComplexComponent( (BaseAddon) this, 1993, -1, 0, 0, 0, -1, "pantry", 1);// 2
			AddComplexComponent( (BaseAddon) this, 1993, 0, 0, 0, 0, -1, "pantry", 1);// 3
			AddComplexComponent( (BaseAddon) this, 1824, -2, 0, 5, 0, -1, "pantry", 1);// 9
			AddComplexComponent( (BaseAddon) this, 1824, -2, 0, 14, 0, -1, "pantry", 1);// 11
			AddComplexComponent( (BaseAddon) this, 1824, 2, 0, 14, 0, -1, "pantry", 1);// 12
			AddComplexComponent( (BaseAddon) this, 1993, 0, 0, 12, 0, -1, "pantry", 1);// 13
			AddComplexComponent( (BaseAddon) this, 1824, -2, 0, 10, 0, -1, "pantry", 1);// 19
			AddComplexComponent( (BaseAddon) this, 1993, -1, 0, 12, 0, -1, "pantry", 1);// 21
			AddComplexComponent( (BaseAddon) this, 1993, 1, 0, 6, 0, -1, "pantry", 1);// 22
			AddComplexComponent( (BaseAddon) this, 1993, 0, 0, 6, 0, -1, "pantry", 1);// 23
			AddComplexComponent( (BaseAddon) this, 1993, -1, 0, 6, 0, -1, "pantry", 1);// 24
			AddComplexComponent( (BaseAddon) this, 1993, 1, 0, 12, 0, -1, "pantry", 1);// 25
			AddComplexComponent( (BaseAddon) this, 1824, 2, 0, 0, 0, -1, "pantry", 1);// 26
			AddComplexComponent( (BaseAddon) this, 1993, 1, 0, 0, 0, -1, "pantry", 1);// 27
			AddComplexComponent( (BaseAddon) this, 1824, 2, 0, 5, 0, -1, "pantry", 1);// 28

		}

		public PantryAddon( Serial serial ) : base( serial )
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

	public class PantryAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new PantryAddon();
			}
		}

		[Constructable]
		public PantryAddonDeed()
		{
			Name = "Pantry";
		}

		public PantryAddonDeed( Serial serial ) : base( serial )
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