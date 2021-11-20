
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
	public class ChuckleAtronGoldAddon : BaseAddon
	{
         
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new ChuckleAtronGoldAddonDeed();
			}
		}

		[ Constructable ]
		public ChuckleAtronGoldAddon()
		{



			AddComplexComponent( (BaseAddon) this, 7960, 0, 0, 9, 1290, -1, "ChuckleAtron Trophy - GOLD", 1);// 1
			AddComplexComponent( (BaseAddon) this, 4643, 0, 0, 0, 1290, -1, "ChuckleAtron Trophy - GOLD", 1);// 2
			AddComplexComponent( (BaseAddon) this, 8454, 0, 0, 17, 1290, -1, "ChuckleAtron Trophy - GOLD", 1);// 3

		}

		public ChuckleAtronGoldAddon( Serial serial ) : base( serial )
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

	public class ChuckleAtronGoldAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new ChuckleAtronGoldAddon();
			}
		}

		[Constructable]
		public ChuckleAtronGoldAddonDeed()
		{
			Name = "ChuckleAtronGold";
		}

		public ChuckleAtronGoldAddonDeed( Serial serial ) : base( serial )
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