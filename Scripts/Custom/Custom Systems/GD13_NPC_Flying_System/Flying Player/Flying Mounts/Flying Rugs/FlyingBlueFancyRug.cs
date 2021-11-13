using System;

namespace Server.Items
{
    public class FlyingBlueFancyRug : BaseAddon
    {
        [Constructable]
        public FlyingBlueFancyRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xAC2, 1076273), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAC3, 1076273), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAC4, 1076273), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAC5, 1076273), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF6, 1076273), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF7, 1076273), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF8, 1076273), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAF9, 1076273), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAFA, 1076273), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingBlueFancyRug(Serial serial)
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
            private FlyingBlueFancyRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingBlueFancyRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
