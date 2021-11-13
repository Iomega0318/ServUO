using System;

namespace Server.Items
{
    public class FlyingRedPlainRug : BaseAddon
    {
        [Constructable]
        public FlyingRedPlainRug(int hue, int landZ, int Spd)
            : base()
        {
            this.Name = "Magic Flying Rug";

            this.AddComponent(new LocalizedAddonComponent(0xAC9, 1076588), 1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACA, 1076588), -1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACB, 1076588), -1, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACC, 1076588), 1, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACD, 1076588), -1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACE, 1076588), 0, -1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xACF, 1076588), 1, 0, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAD0, 1076588), 0, 1, 0);
            this.AddComponent(new LocalizedAddonComponent(0xAC6, 1076588), 0, 0, 0);

            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalRugTimer(this, Rate).Start();
        }

        public FlyingRedPlainRug(Serial serial)
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
            private FlyingRedPlainRug m_FlyingRug;
            private readonly int Rate;

            public InternalRugTimer(FlyingRedPlainRug flyingRug, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
