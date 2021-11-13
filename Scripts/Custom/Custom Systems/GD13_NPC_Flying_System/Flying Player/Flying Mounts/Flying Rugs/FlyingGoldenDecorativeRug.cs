using System;

namespace Server.Items
{
    public class FlyingGoldenDecorativeRug : BaseAddon
    {
        [Constructable]
        public FlyingGoldenDecorativeRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xADB, 1076586), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xADC, 1076586), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xADD, 1076586), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xADE, 1076586), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xADF, 1076586), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE0, 1076586), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE1, 1076586), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE2, 1076586), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xADA, 1076586), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingGoldenDecorativeRug(Serial serial)
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
            private FlyingGoldenDecorativeRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingGoldenDecorativeRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
