using System;

namespace Server.Items
{
    public class FlyingBlueRug : BaseAddon
    {
        [Constructable]
        public FlyingBlueRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xAD2, 1076589), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD3, 1076589), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD4, 1076589), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD5, 1076589), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD6, 1076589), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD7, 1076589), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD8, 1076589), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD9, 1076589), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD1, 1076589), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingBlueRug(Serial serial)
            : base(serial)
        {
            new InternalRugTimer(this, 0).Start();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }

        private class InternalRugTimer : Timer
        {
            private FlyingBlueRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingBlueRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
            {
                m_FlyingRug = flyingRug;
                Rate = rate;
            }

            protected override void OnTick()
            {
                m_FlyingRug.Delete();
            }
        }
    }
}
