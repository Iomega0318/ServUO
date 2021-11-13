using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TrainingWeaponsGargoyles : Bag
	{
		[Constructable]
		public TrainingWeaponsGargoyles() : this(1)
		{
			Movable = true;
			Name = "Gargoyle Training Weapons";
			Hue = 1161;
		}
		[Constructable]
		public TrainingWeaponsGargoyles(int amount)
		{
			DropItem(new TrainingGargishKryss());
			DropItem(new TrainingGargishKatana());
			DropItem(new TrainingGargishMaul());
			DropItem(new TrainingGargishShield());
			DropItem(new TrainingGargishBoomerang());
			DropItem(new TrainingGargishAxe());
		}

		public TrainingWeaponsGargoyles(Serial serial) : base(serial)
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
