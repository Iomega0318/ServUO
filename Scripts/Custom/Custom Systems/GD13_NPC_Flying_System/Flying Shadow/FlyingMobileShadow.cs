using System;

namespace Server.Mobiles
{
    [CorpseName("")]
    public class FlyingMobileShadow : BaseCreature
    {
        [Constructable]
        public FlyingMobileShadow(int body, Direction direction, int landZ, int Spd) : base(AIType.AI_Animal, FightMode.None, 0, 0, 0.2, 0.2)
        {
            this.Name = "";
            this.Body = body;
            this.Hue = 0x4001; // 1;  change to 1 if you want pure black shadows
            this.Flying = true;
            this.CanMove = false;
            this.CantWalk = true;
            this.Direction = direction;
            this.Z = (landZ);

            int Rate = Spd;

            new InternalMobileTimer(this, Rate).Start();
        }

        public FlyingMobileShadow(Serial serial) : base(serial)
        {
            new InternalMobileTimer(this, 0).Start();
        }

        public override void OnThink()
        {
        }

        public override void OnSingleClick(Mobile from)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
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

        private class InternalMobileTimer : Timer
        {
            private BaseCreature m_FlyingCreature;
            private readonly int Rate;

            public InternalMobileTimer(BaseCreature FlyingCreature, int rate) : base(TimeSpan.FromMilliseconds(rate))
            {
                m_FlyingCreature = FlyingCreature;
                Rate = rate;
            }

            protected override void OnTick()
            {
                m_FlyingCreature.Delete();
            }
        }
    }
}
