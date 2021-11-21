using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Mushroom_Lamp_Blue_v2Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new Mushroom_Lamp_Blue_v2AddonDeed();
			}
		}

		[ Constructable ]
		public Mushroom_Lamp_Blue_v2Addon()
		{
			AddComplexComponent( (BaseAddon) this, 3865, 1, 0, 1, 0, -1, "Pull chain", 1);// 1
			AddComplexComponent( (BaseAddon) this, 3865, 1, 0, 2, 0, -1, "Pull chain", 1);// 2
			AddComplexComponent( (BaseAddon) this, 3865, 1, 0, 0, 0, -1, "Pull chain", 1);// 3
			AddComplexComponent( (BaseAddon) this, 16639, 0, 0, 0, 0, 2, "Light", 1);// 4
			AddComplexComponent( (BaseAddon) this, 8752, 0, 0, 1, 1152, -1, "Blue Mushroom Lamp", 1);// 5
		}

		public Mushroom_Lamp_Blue_v2Addon( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Blue_v2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new Mushroom_Lamp_Blue_v2Addon();
			}
		}

		[Constructable]
		public Mushroom_Lamp_Blue_v2AddonDeed()
		{
			Name = "Blue Mushroom Lamp";
		}

		public Mushroom_Lamp_Blue_v2AddonDeed( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Red_v2Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new Mushroom_Lamp_Red_v2AddonDeed();
			}
		}

		[ Constructable ]
		public Mushroom_Lamp_Red_v2Addon()
		{
			AddComplexComponent( (BaseAddon) this, 3859, 0, 0, 2, 0, -1, "Pull chain", 1);// 1
			AddComplexComponent( (BaseAddon) this, 3859, 0, 0, 1, 0, -1, "Pull chain", 1);// 2
			AddComplexComponent( (BaseAddon) this, 3859, 0, 0, 0, 0, -1, "Pull chain", 1);// 3
			AddComplexComponent( (BaseAddon) this, 8750, 0, 0, 3, 2118, -1, "Red Mushroom Lamp", 1);// 4
			AddComplexComponent( (BaseAddon) this, 16638, 0, 0, 2, 0, 2, "Light", 1);// 5
		}

		public Mushroom_Lamp_Red_v2Addon( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Red_v2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new Mushroom_Lamp_Red_v2Addon();
			}
		}

		[Constructable]
		public Mushroom_Lamp_Red_v2AddonDeed()
		{
			Name = "Red Mushroom Lamp";
		}

		public Mushroom_Lamp_Red_v2AddonDeed( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Green_v2Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new Mushroom_Lamp_Green_v2AddonDeed();
			}
		}

		[ Constructable ]
		public Mushroom_Lamp_Green_v2Addon()
		{
			AddComplexComponent( (BaseAddon) this, 16640, 0, 0, 0, 0, 2, "Light", 1);// 1
			AddComplexComponent( (BaseAddon) this, 3856, 0, 0, 0, 0, -1, "Pull chain", 1);// 2
			AddComplexComponent( (BaseAddon) this, 8753, 0, 0, 1, 1400, -1, "Green Mushroom Lamp", 1);// 3
			AddComplexComponent( (BaseAddon) this, 3856, 0, 0, 1, 0, -1, "Pull chain", 1);// 4
			AddComplexComponent( (BaseAddon) this, 3856, 0, 0, 2, 0, -1, "Pull chain", 1);// 5
			AddComplexComponent( (BaseAddon) this, 3856, 0, 0, 3, 0, -1, "Pull chain", 1);// 6
		}

		public Mushroom_Lamp_Green_v2Addon( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Green_v2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new Mushroom_Lamp_Green_v2Addon();
			}
		}

		[Constructable]
		public Mushroom_Lamp_Green_v2AddonDeed()
		{
			Name = "Green Mushroom Lamp";
		}

		public Mushroom_Lamp_Green_v2AddonDeed( Serial serial ) : base( serial )
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

public class Mushroom_Lamp_Purple_v2Addon : BaseAddon
	{  
		public override BaseAddonDeed Deed
		{
			get
			{
				return new Mushroom_Lamp_Purple_v2AddonDeed();
			}
		}

		[ Constructable ]
		public Mushroom_Lamp_Purple_v2Addon()
		{
			AddComplexComponent( (BaseAddon) this, 16641, 0, 0, 0, 0, 2, "Light", 1);// 1
			AddComplexComponent( (BaseAddon) this, 8752, 0, 0, 1, 1460, -1, "Purple Mushroom Lamp", 1);// 2
			AddComplexComponent( (BaseAddon) this, 3862, 0, 1, 2, 0, -1, "Pull chain", 1);// 3
			AddComplexComponent( (BaseAddon) this, 3862, 0, 1, 3, 0, -1, "Pull chain", 1);// 4
			AddComplexComponent( (BaseAddon) this, 3862, 0, 1, 4, 0, -1, "Pull chain", 1);// 5
			AddComplexComponent( (BaseAddon) this, 3862, 0, 1, 5, 0, -1, "Pull chain", 1);// 6
			AddComplexComponent( (BaseAddon) this, 3862, 0, 1, 6, 0, -1, "Pull chain", 1);// 7
		}

		public Mushroom_Lamp_Purple_v2Addon( Serial serial ) : base( serial )
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

	public class Mushroom_Lamp_Purple_v2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new Mushroom_Lamp_Purple_v2Addon();
			}
		}

		[Constructable]
		public Mushroom_Lamp_Purple_v2AddonDeed()
		{
			Name = "Purple Mushroom Lamp";
		}

		public Mushroom_Lamp_Purple_v2AddonDeed( Serial serial ) : base( serial )
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