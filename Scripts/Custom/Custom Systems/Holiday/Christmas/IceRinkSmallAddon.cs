
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
	public class IceRinkSmallAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {6093, 0, 2, 0}, {6093, 2, -1, 0}, {7979, -2, 2, 2}// 21	63	81	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new IceRinkSmallAddonDeed();
			}
		}

		[ Constructable ]
		public IceRinkSmallAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 7377, -2, 0, 0, 1153, -1, "Ice", 1);// 1
			AddComplexComponent( (BaseAddon) this, 7385, 0, 1, 0, 1153, -1, "Ice", 1);// 2
			AddComplexComponent( (BaseAddon) this, 7385, 0, 0, 0, 1153, -1, "Ice", 1);// 3
			AddComplexComponent( (BaseAddon) this, 6039, 2, 2, 0, 1153, -1, "Ice", 1);// 4
			AddComplexComponent( (BaseAddon) this, 7385, 1, 2, 0, 1153, -1, "Ice", 1);// 5
			AddComplexComponent( (BaseAddon) this, 6046, 3, 1, 0, 1153, -1, "Ice", 1);// 6
			AddComplexComponent( (BaseAddon) this, 6051, -2, -1, 0, 1153, -1, "Ice", 1);// 7
			AddComplexComponent( (BaseAddon) this, 7379, 0, 3, 0, 1153, -1, "Ice", 1);// 8
			AddComplexComponent( (BaseAddon) this, 6045, 3, 0, 0, 1153, -1, "Ice", 1);// 9
			AddComplexComponent( (BaseAddon) this, 6056, -2, 3, 0, 1153, -1, "Ice", 1);// 10
			AddComplexComponent( (BaseAddon) this, 6055, 3, 3, 0, 1153, -1, "Ice", 1);// 11
			AddComplexComponent( (BaseAddon) this, 7385, 1, -1, 0, 1153, -1, "Ice", 1);// 12
			AddComplexComponent( (BaseAddon) this, 7385, 2, 2, 0, 1153, -1, "Ice", 1);// 13
			AddComplexComponent( (BaseAddon) this, 6039, -1, 0, 0, 1153, -1, "Ice", 1);// 14
			AddComplexComponent( (BaseAddon) this, 6050, 0, 3, 0, 1153, -1, "Ice", 1);// 15
			AddComplexComponent( (BaseAddon) this, 6054, -2, -2, 0, 1153, -1, "Ice", 1);// 16
			AddComplexComponent( (BaseAddon) this, 6051, -2, 1, 0, 1153, -1, "Ice", 1);// 17
			AddComplexComponent( (BaseAddon) this, 7385, -1, 2, 0, 1153, -1, "Ice", 1);// 18
			AddComplexComponent( (BaseAddon) this, 6047, 2, -2, 0, 1153, -1, "Ice", 1);// 19
			AddComplexComponent( (BaseAddon) this, 6052, -2, 0, 0, 1153, -1, "Ice", 1);// 20
			AddComplexComponent( (BaseAddon) this, 7378, -2, 1, 0, 1153, -1, "Ice", 1);// 22
			AddComplexComponent( (BaseAddon) this, 6039, 1, -1, 0, 1153, -1, "Ice", 1);// 23
			AddComplexComponent( (BaseAddon) this, 7385, 1, 1, 0, 1153, -1, "Ice", 1);// 24
			AddComplexComponent( (BaseAddon) this, 6039, 1, 1, 0, 1153, -1, "Ice", 1);// 25
			AddComplexComponent( (BaseAddon) this, 6039, 2, 0, 0, 1153, -1, "Ice", 1);// 26
			AddComplexComponent( (BaseAddon) this, 6039, 2, 1, 0, 1153, -1, "Ice", 1);// 27
			AddComplexComponent( (BaseAddon) this, 7385, 2, -1, 0, 1153, -1, "Ice", 1);// 28
			AddComplexComponent( (BaseAddon) this, 7381, 2, -2, 0, 1153, -1, "Ice", 1);// 29
			AddComplexComponent( (BaseAddon) this, 6039, 0, -1, 0, 1153, -1, "Ice", 1);// 30
			AddComplexComponent( (BaseAddon) this, 6039, -1, 1, 0, 1153, -1, "Ice", 1);// 31
			AddComplexComponent( (BaseAddon) this, 6039, -1, -1, 0, 1153, -1, "Ice", 1);// 32
			AddComplexComponent( (BaseAddon) this, 7379, 2, 3, 0, 1153, -1, "Ice", 1);// 33
			AddComplexComponent( (BaseAddon) this, 5701, -1, -1, 0, 1153, -1, "Ice", 1);// 34
			AddComplexComponent( (BaseAddon) this, 6049, 1, 3, 0, 1153, -1, "Ice", 1);// 35
			AddComplexComponent( (BaseAddon) this, 6047, 0, -2, 0, 1153, -1, "Ice", 1);// 36
			AddComplexComponent( (BaseAddon) this, 6048, 1, -2, 0, 1153, -1, "Ice", 1);// 37
			AddComplexComponent( (BaseAddon) this, 6039, 1, 0, 0, 1153, -1, "Ice", 1);// 38
			AddComplexComponent( (BaseAddon) this, 7384, 3, -1, 0, 1153, -1, "Ice", 1);// 39
			AddComplexComponent( (BaseAddon) this, 7385, 2, 0, 0, 1153, -1, "Ice", 1);// 40
			AddComplexComponent( (BaseAddon) this, 10585, -2, -2, 0, 0, -1, "post", 1);// 41
			AddComplexComponent( (BaseAddon) this, 6050, 2, 3, 0, 1153, -1, "Ice", 1);// 42
			AddComplexComponent( (BaseAddon) this, 6039, 0, 2, 0, 1153, -1, "Ice", 1);// 43
			AddComplexComponent( (BaseAddon) this, 6048, -1, -2, 0, 1153, -1, "Ice", 1);// 44
			AddComplexComponent( (BaseAddon) this, 7385, -1, 1, 0, 1153, -1, "Ice", 1);// 45
			AddComplexComponent( (BaseAddon) this, 7385, -1, 0, 0, 1153, -1, "Ice", 1);// 46
			AddComplexComponent( (BaseAddon) this, 6039, 0, 0, 0, 1153, -1, "Ice", 1);// 47
			AddComplexComponent( (BaseAddon) this, 7376, 3, -2, 0, 1153, -1, "Ice", 1);// 48
			AddComplexComponent( (BaseAddon) this, 7385, 2, 1, 0, 1153, -1, "Ice", 1);// 49
			AddComplexComponent( (BaseAddon) this, 7385, 0, 2, 0, 1153, -1, "Ice", 1);// 50
			AddComplexComponent( (BaseAddon) this, 6052, -2, 2, 0, 1153, -1, "Ice", 1);// 51
			AddComplexComponent( (BaseAddon) this, 7373, -2, 3, 0, 1153, -1, "Ice", 1);// 52
			AddComplexComponent( (BaseAddon) this, 6049, -1, 3, 0, 1153, -1, "Ice", 1);// 53
			AddComplexComponent( (BaseAddon) this, 6045, 3, 2, 0, 1153, -1, "Ice", 1);// 54
			AddComplexComponent( (BaseAddon) this, 6039, 0, 1, 0, 1153, -1, "Ice", 1);// 55
			AddComplexComponent( (BaseAddon) this, 7385, 0, -1, 0, 1153, -1, "Ice", 1);// 56
			AddComplexComponent( (BaseAddon) this, 6053, 3, -2, 0, 1153, -1, "Ice", 1);// 57
			AddComplexComponent( (BaseAddon) this, 7378, -2, -1, 0, 1153, -1, "Ice", 1);// 58
			AddComplexComponent( (BaseAddon) this, 4764, -2, -2, 3, 1369, -1, "Ice Rink", 1);// 59
			AddComplexComponent( (BaseAddon) this, 6039, -1, 2, 0, 1153, -1, "Ice", 1);// 60
			AddComplexComponent( (BaseAddon) this, 6046, 3, -1, 0, 1153, -1, "Ice", 1);// 61
			AddComplexComponent( (BaseAddon) this, 3715, -2, 2, 0, 2101, -1, "Barrel", 1);// 62
			AddComplexComponent( (BaseAddon) this, 7374, 3, 3, 0, 1153, -1, "Ice", 1);// 64
			AddComplexComponent( (BaseAddon) this, 6039, 2, -1, 0, 1153, -1, "Ice", 1);// 65
			AddComplexComponent( (BaseAddon) this, 7385, 1, 0, 0, 1153, -1, "Ice", 1);// 66
			AddComplexComponent( (BaseAddon) this, 6039, 1, 2, 0, 1153, -1, "Ice", 1);// 67
			AddComplexComponent( (BaseAddon) this, 7385, -1, -1, 0, 1153, -1, "Ice", 1);// 68
			AddComplexComponent( (BaseAddon) this, 7377, -2, 2, 0, 1153, -1, "Ice", 1);// 69
			AddComplexComponent( (BaseAddon) this, 7382, 1, -2, 0, 1153, -1, "Ice", 1);// 70
			AddComplexComponent( (BaseAddon) this, 7381, 0, -2, 0, 1153, -1, "Ice", 1);// 71
			AddComplexComponent( (BaseAddon) this, 7383, 3, 2, 0, 1153, -1, "Ice", 1);// 72
			AddComplexComponent( (BaseAddon) this, 7382, -1, -2, 0, 1153, -1, "Ice", 1);// 73
			AddComplexComponent( (BaseAddon) this, 7380, -1, 3, 0, 1153, -1, "Ice", 1);// 74
			AddComplexComponent( (BaseAddon) this, 7384, 3, 1, 0, 1153, -1, "Ice", 1);// 75
			AddComplexComponent( (BaseAddon) this, 2860, -2, 0, 0, 38, -1, "", 1);// 76
			AddComplexComponent( (BaseAddon) this, 7383, 3, 0, 0, 1153, -1, "Ice", 1);// 77
			AddComplexComponent( (BaseAddon) this, 3555, -2, 2, 4, 0, 1, "", 1);// 78
			AddComplexComponent( (BaseAddon) this, 2860, -2, 1, 0, 38, -1, "", 1);// 79
			AddComplexComponent( (BaseAddon) this, 7375, -2, -2, 0, 1153, -1, "Ice", 1);// 80
			AddComplexComponent( (BaseAddon) this, 7380, 1, 3, 0, 1153, -1, "Ice", 1);// 82

		}

		public IceRinkSmallAddon( Serial serial ) : base( serial )
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

	public class IceRinkSmallAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new IceRinkSmallAddon();
			}
		}

		[Constructable]
		public IceRinkSmallAddonDeed()
		{
			Name = "IceRinkSmall";
		}

		public IceRinkSmallAddonDeed( Serial serial ) : base( serial )
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