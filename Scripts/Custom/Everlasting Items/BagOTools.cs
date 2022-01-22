using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class EverlastingBagOfTools : Bag
	{
		[Constructable]
		public EverlastingBagOfTools() : this(1)
		{
			Movable = true;
            LootType = LootType.Blessed;
            Name = "A bag of Everlasting Tools";
			Hue = 1153;
		}
		[Constructable]
		public EverlastingBagOfTools(int amount)
        {
            DropItem(new EverlastingFletcherTools());
            DropItem(new EverlastingGargoylesAxe());
            DropItem(new EverlastingGargoylesPickaxe());
            DropItem(new EverlastingGargoylesKnife());
            DropItem(new EverlastingMalletAndChisel());
            DropItem(new EverlastingMapmakersPen());
            DropItem(new EverlastingMortarPestle());
            DropItem(new EverlastingSaw());
            DropItem(new EverlastingScribesPen());
            DropItem(new EverlastingSewingKit());
            DropItem(new EverlastingShovel());
            DropItem(new EverlastingSkillet());
            DropItem(new EverlastingBlacksmithHammer());
            DropItem(new EverlastingTinkerTools());
        }

		public EverlastingBagOfTools(Serial serial) : base(serial)
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
