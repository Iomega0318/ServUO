using System;
using Server;
using Server.Network;

namespace Server.Items
{
    public class LargeCrystalBall : Item
    {
        [Constructable]
        public LargeCrystalBall() : base(0x468B)
        {
            this.Name = "a large crystal ball";
            this.Weight = 10;
            this.Stackable = false;
            this.LootType = LootType.Blessed;
            this.Light = LightType.Circle150;
        }

        public LargeCrystalBall(Serial serial) : base(serial)
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
