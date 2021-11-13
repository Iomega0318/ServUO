using System;

namespace Server.Items
{
    public class FlyingCinnamonFancyRug : BaseAddon
    {
        [Constructable]
        public FlyingCinnamonFancyRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xAE3, 1076587), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE4, 1076587), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE5, 1076587), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE6, 1076587), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE7, 1076587), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE8, 1076587), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAE9, 1076587), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAEA, 1076587), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAEB, 1076587), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingCinnamonFancyRug(Serial serial)
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
            private FlyingCinnamonFancyRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingCinnamonFancyRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
