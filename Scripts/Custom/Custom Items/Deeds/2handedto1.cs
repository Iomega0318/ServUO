using System;
using Server.Network;
using Server.Prompts;
using Server.Targeting;
using Server.Items;



namespace Server.Items
{

	public class SingleHandDeed : Item
	{
		[Constructable]
		public SingleHandDeed() : base(0x14F0)
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
			Hue = 1161;
			Name = "One Handed Deed";
		}
		public SingleHandDeed(Serial serial) : base(serial)
		{ }
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001);
			}
			else
			{
				from.Target = new SingleHandDeedT(this);
			}
		}
	}

	public class SingleHandDeedT : Target
	{
		private SingleHandDeed m_GToO;

		public SingleHandDeedT(SingleHandDeed GToO) : base(1, false, TargetFlags.None)
		{
			m_GToO = GToO;
		}

		protected override void OnTarget(Mobile from, object target)
		{
			Item selx = from.Backpack.FindItemByType(typeof(SingleHandDeed));
			Item GNS = from.Backpack.FindItemByType(typeof(SingleHandDeed));
			if (target is BaseWeapon)
			{
				Item needNS = (Item)target;
				BaseWeapon weapon = target as BaseWeapon;
				if (needNS.RootParent == from)
				{
					weapon.Layer = Layer.OneHanded;
					selx.Delete();
					from.SendMessage(38, "The weapon is now one handed.");
				}
				else
					from.SendMessage(38, "This must be in your backpack to use.");
			}
			else
				from.SendMessage(38, "This can only be used on weapons.");
		}
	}

}

