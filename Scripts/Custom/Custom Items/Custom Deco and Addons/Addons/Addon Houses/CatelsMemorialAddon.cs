
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
	public class CatelsMemorialAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {13423, -4, -6, 3}, {1301, -4, -1, 0}, {1301, -1, -4, 0}// 1	2	3	
			, {3215, 5, 6, 6}, {1301, -2, -3, 0}, {13451, -6, -6, 4}// 4	5	6	
			, {1301, 5, -1, 0}, {1301, -3, 1, 0}, {1301, -1, 6, 0}// 7	8	9	
			, {3215, -7, -6, 0}, {1276, -1, 7, 0}, {3215, 5, 6, 0}// 10	11	12	
			, {3215, 1, -7, 0}, {5951, -5, -6, 3}, {3211, -5, -2, 0}// 13	14	15	
			, {3215, -7, 6, 6}, {1301, -1, 5, 0}, {3215, 3, 6, 0}// 16	18	19	
			, {3215, -6, 6, 0}, {1301, -6, 0, 0}, {1301, 0, 6, 0}// 20	21	22	
			, {3255, -4, -5, 18}, {3215, -3, 6, 0}, {1301, -2, -4, 0}// 23	25	27	
			, {1301, -4, -2, 0}, {3215, 0, -7, 0}, {1301, -4, 1, 0}// 28	29	30	
			, {1301, -2, 3, 0}, {1301, 1, 2, 0}, {1301, 2, 2, 0}// 31	32	33	
			, {3215, -7, -1, 0}, {3215, 3, -7, 0}, {1301, 3, -2, 0}// 34	35	36	
			, {3307, -7, 7, 0}, {1301, 1, -4, 0}, {3212, -2, -5, 0}// 37	38	40	
			, {3215, -7, 2, 0}, {1301, -4, 0, 0}, {3307, 5, 7, 0}// 41	42	43	
			, {1301, 0, -4, 0}, {13423, -4, -4, 3}, {1978, -1, -1, 0}// 44	45	47	
			, {1301, 4, 0, 0}, {3215, 4, 6, 0}, {6011, -6, -3, 0}// 48	49	50	
			, {3215, -7, 3, 0}, {3211, -7, -7, 0}, {1301, 5, 0, 0}// 52	53	54	
			, {3215, -7, -2, 0}, {3215, -7, 0, 0}, {3214, 2, -5, 0}// 55	58	59	
			, {3215, 1, 6, 0}, {3215, -7, 5, 0}, {1301, 2, -2, 0}// 60	61	62	
			, {3214, 4, -3, 0}, {4963, -7, -6, 0}, {1301, -1, -6, 0}// 63	64	65	
			, {3307, -6, 7, 0}, {1301, -5, -1, 0}, {1301, 3, 0, 0}// 66	67	68	
			, {3215, 4, -7, 0}, {1301, -1, 4, 0}, {3215, 5, -7, 0}// 69	70	72	
			, {1301, -3, -3, 0}, {3215, 5, -7, 6}, {1301, -3, 2, 0}// 73	74	75	
			, {1301, 2, -3, 0}, {1301, 2, 1, 0}, {1301, 1, 3, 0}// 76	77	78	
			, {3215, -7, 5, 6}, {3215, -6, 6, 6}, {1301, -2, 2, 0}// 80	81	82	
			, {3215, -7, 1, 0}, {3215, -7, 6, 0}, {1301, -6, -1, 0}// 83	84	85	
			, {1301, 3, -1, 0}, {3215, -1, -7, 0}, {3215, -2, -7, 0}// 86	87	88	
			, {3215, -2, 6, 0}, {3215, -7, -6, 6}, {3215, -7, 4, 0}// 89	90	91	
			, {3215, -3, -7, 0}, {1301, 0, 4, 0}, {3215, -7, -5, 0}// 93	95	97	
			, {3215, -5, -7, 0}, {1301, 0, -6, 0}, {1301, -1, -5, 0}// 98	99	100	
			, {1301, 0, 3, 0}, {3215, -7, -4, 0}, {1301, -5, 0, 0}// 101	102	103	
			, {3215, -7, -3, 0}, {3215, -6, -7, 0}, {1301, -1, 3, 0}// 104	105	106	
			, {3215, -6, -7, 6}, {3215, -4, -7, 0}, {3215, -5, 6, 0}// 107	108	110	
			, {1301, 4, -1, 0}, {3215, 2, -7, 0}, {3215, -7, -7, 6}// 111	112	114	
			, {1301, 0, 5, 0}, {3214, 5, -5, 0}, {1301, 3, 1, 0}// 115	116	117	
			, {1301, 0, -5, 0}, {3215, 2, 6, 0}, {3215, -4, 6, 0}// 118	119	120	
			, {4963, -6, -7, 0}, {3215, -7, -7, 0}, {3214, -3, 4, 0}// 121	122	123	
			, {1301, 1, -3, 0}, {3214, -5, 2, 0}, {4967, -3, -4, 0}// 124	126	127	
			, {4963, -3, -6, 0}, {1276, 0, 7, 0}, {5952, -6, -6, 3}// 131	132	133	
			, {3795, 3, -5, 0}, {3809, 3, -6, 0}, {5949, -6, -5, 3}// 134	135	138	
			, {1313, 1, 7, 0}, {6212, -4, -4, 111}, {3256, -6, -5, 7}// 139	140	141	
			, {13423, -5, -4, 3}, {1313, -2, 7, 0}, {5950, -5, -5, 3}// 142	143	144	
			, {13423, -6, -4, 3}, {13423, -4, -5, 3}, {3208, -3, -3, 8}// 146	147	149	
			, {3707, -7, -7, 0}, {4964, -3, -5, 0}, {3339, -4, -4, 8}// 150	151	152	
			, {3268, -5, -3, 4}, {3223, -6, -3, 4}, {3338, -5, -4, 9}// 153	154	155	
			, {3268, -3, -5, 4}, {3224, -3, -3, 3}, {4967, -5, -7, 0}// 156	157	158	
			, {3203, -4, -6, 6}, {3223, -3, -6, 4}, {13452, -4, -4, 14}// 159	160	161	
			, {3214, 5, 3, 0}, {3214, 3, 5, 0}, {3203, -6, -4, 6}// 162	163	164	
			, {3215, 6, 3, 0}, {3215, 6, -1, 0}, {3215, 6, 4, 0}// 165	166	167	
			, {3215, 6, -7, 6}, {3307, 6, 7, 0}, {3311, 7, -7, 0}// 168	169	170	
			, {3311, 7, -6, 0}, {3311, 7, 5, 0}, {3215, 6, 1, 0}// 171	172	173	
			, {3215, 6, 5, 0}, {3215, 6, -7, 0}, {3215, 6, 6, 6}// 174	175	176	
			, {3215, 6, 5, 6}, {3215, 6, 2, 0}, {3215, 6, 6, 0}// 177	178	179	
			, {3215, 6, -3, 0}, {3215, 6, -2, 0}, {3215, 6, 0, 0}// 180	181	182	
			, {3215, 6, -6, 6}, {3215, 6, -6, 0}, {3215, 6, -4, 0}// 183	184	185	
			, {3215, 6, -5, 0}, {3311, 7, 6, 0}// 186	187	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CatelsMemorialAddonDeed();
			}
		}

		[ Constructable ]
		public CatelsMemorialAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 4011, -1, 0, 10, 2065, -1, "2065", 1);// 17
			AddComplexComponent( (BaseAddon) this, 1978, 0, 0, 0, 2065, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 4011, 0, -1, 10, 1910, -1, "1910", 1);// 26
			AddComplexComponent( (BaseAddon) this, 1978, 0, -1, 0, 2065, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 2861, -1, -3, 0, 2065, -1, "", 1);// 46
			AddComplexComponent( (BaseAddon) this, 14089, 1, 7, 0, 2064, 1, "", 1);// 51
			AddComplexComponent( (BaseAddon) this, 2860, -3, 0, 0, 2065, -1, "", 1);// 56
			AddComplexComponent( (BaseAddon) this, 6212, -4, -4, 12, 0, -1, "water", 1);// 57
			AddComplexComponent( (BaseAddon) this, 6362, 3, -6, 0, 0, -1, "Catel's Last flower", 1);// 71
			AddComplexComponent( (BaseAddon) this, 2861, -1, 2, 0, 1910, -1, "", 1);// 79
			AddComplexComponent( (BaseAddon) this, 2861, 0, 2, 0, 2065, -1, "", 1);// 92
			AddComplexComponent( (BaseAddon) this, 1978, -1, -1, 5, 2065, -1, "", 1);// 94
			AddComplexComponent( (BaseAddon) this, 3025, 0, 6, 13, 0, -1, "Catel's Memorial Park", 1);// 96
			AddComplexComponent( (BaseAddon) this, 1978, -1, 0, 0, 2065, -1, "", 1);// 109
			AddComplexComponent( (BaseAddon) this, 2861, 0, -3, 0, 1910, -1, "", 1);// 113
			AddComplexComponent( (BaseAddon) this, 3800, 3, -7, 0, 2067, -1, "Here Lays Catel one of the greatest Uo Players in history", 1);// 125
			AddComplexComponent( (BaseAddon) this, 2860, -3, -1, 0, 1910, -1, "", 1);// 128
			AddComplexComponent( (BaseAddon) this, 2860, 2, 0, 0, 1910, -1, "", 1);// 129
			AddComplexComponent( (BaseAddon) this, 2860, 2, -1, 0, 2065, -1, "", 1);// 130
			AddComplexComponent( (BaseAddon) this, 1978, -1, 0, 5, 1910, -1, "", 1);// 136
			AddComplexComponent( (BaseAddon) this, 1978, 0, -1, 5, 1910, -1, "", 1);// 137
			AddComplexComponent( (BaseAddon) this, 14089, -2, 7, 0, 1910, 1, "", 1);// 145
			AddComplexComponent( (BaseAddon) this, 6212, -6, -6, 2, 0, -1, "water", 1);// 148

		}

		public CatelsMemorialAddon( Serial serial ) : base( serial )
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

	public class CatelsMemorialAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CatelsMemorialAddon();
			}
		}

		[Constructable]
		public CatelsMemorialAddonDeed()
		{
			Name = "CatelsMemorial";
		}

		public CatelsMemorialAddonDeed( Serial serial ) : base( serial )
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