using System;

namespace Server.Items
{
    public class FlyingPinkFancyRug : BaseAddon
    {
        [Constructable]
        public FlyingPinkFancyRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xAEE, 1076590), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAEF, 1076590), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF0, 1076590), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF1, 1076590), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF2, 1076590), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF3, 1076590), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF4, 1076590), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF5, 1076590), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAEC, 1076590), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingPinkFancyRug(Serial serial)
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
            private FlyingPinkFancyRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingPinkFancyRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
