using System;
using Server.Mobiles;
using Server.Mobiles.Flying.Player;

namespace Server.Items
{
    public class MagicFlyingDeviceShadow : BaseShield
    {
        [Constructable]
        public MagicFlyingDeviceShadow(int hue, int landZ, int Spd) : base(0x1B7A)
        {
            this.Name = "Magic Flying Device";
            this.Weight = 5.0;
            this.Hue = hue;
            this.Z = landZ;

            int Rate = Spd;

            new InternalDeviceTimer(this, Rate).Start();
        }

        public MagicFlyingDeviceShadow(Serial serial) : base(serial)
        {
            new InternalDeviceTimer(this, 0).Start();
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }

        private class InternalDeviceTimer : Timer
        {
            private MagicFlyingDeviceShadow m_FlyingDevice;
            private readonly int Rate;

            public InternalDeviceTimer(MagicFlyingDeviceShadow flyingDevice, int rate) : base(TimeSpan.FromMilliseconds(rate))
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
