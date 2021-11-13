using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TrainingWeaponsHumans : Bag
	{
		[Constructable]
		public TrainingWeaponsHumans() : this(1)
		{
			Movable = true;
			Name = "Human Training Gear";
			Hue = 1161;
		}
		[Constructable]
		public TrainingWeaponsHumans(int amount)
		{
			DropItem(new TrainingKryss());
			DropItem(new TrainingKatana());
			DropItem(new TrainingMace());
			DropItem(new TrainingShield());
			DropItem(new TrainingQuiver());
			DropItem(new TrainingBow());
		}

		public TrainingWeaponsHumans(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
