using System;

namespace Server.Items
{
    public class FlyingLantern : BaseEquipableLight
    {
        [Constructable]
        public FlyingLantern(int hue, int landZ, int Spd) : base(0xA22)
        {
            this.Burning = true;
            this.Weight = 2.0;
            this.Hue = hue;

            this.Z = landZ;

            if (this.Z >= 70)
            {
                this.Light = LightType.Circle150;
            }
            else if (this.Z > 35)
            {
                this.Light = LightType.Circle225;
            }
            else
            {
                this.Light = LightType.Circle300;
            }

            int Rate = Spd;

            new InternalLightTimer(this, Rate).Start();
        }

        public FlyingLantern(Serial serial) : base(serial)
        {
            new InternalLightTimer(this, 0).Start();
        }

        public override int LitItemID
        {
            get
            {
                if (this.ItemID == 0xA15 || this.ItemID == 0xA17)
                    return this.ItemID;

                return 0xA22;
            }
        }
        public override int UnlitItemID
        {
            get
            {
                if (this.ItemID == 0xA18)
                    return this.ItemID;

                return 0xA25;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        private class InternalLightTimer : Timer
        {
            private FlyingLantern m_FlyingDevice;
            private readonly int Rate;

            public InternalLightTimer(FlyingLantern flyingDevice, int rate) : base(TimeSpan.FromMilliseconds(rate))
            {
                m_FlyingDevice = flyingDevice;
                Rate = rate;
            }

            protected override void OnTick()
            {
                m_FlyingDevice.Delete();
            }
        }
    }
}
