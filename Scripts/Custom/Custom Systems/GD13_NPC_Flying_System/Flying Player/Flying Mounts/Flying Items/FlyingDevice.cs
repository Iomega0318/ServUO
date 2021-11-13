using Server.Mobiles;
using Server.Mobiles.Flying.Player;

namespace Server.Items
{
    public class MagicFlyingDevice : BaseShield
    {
        [Constructable]
        public MagicFlyingDevice() : base(0x1B7A)
        {
            this.Name = "Magic Flying Device";
            this.Weight = 5.0;
            this.Hue = 1281;
        }

        public MagicFlyingDevice(Serial serial) : base(serial)
        {
        }

        private void EffectsFlying(PlayerMobile pm)
        {
            pm.Animate(AnimationType.Spell, 0);
            pm.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Head);
            pm.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            Item ff = pm.Backpack.FindItemByType(typeof(FlightTotem));

            if (ff == null)
                pm.AddToBackpack(new FlightTotem());

            if (!pm.Flying && this.IsChildOf(pm.Backpack))
            {
                if (pm.CantWalk == false)
                {
                    pm.CantWalk = true;

                    EffectsFlying(pm);

                    FlyingTimer f_timer = new FlyingTimer(pm);

                    f_timer.Start();

                    this.Visible = false;
                    this.Name = "Magic Flying Device-Active";
                }
            }
            else
            {
                pm.Flying = false;
                pm.CantWalk = false;
            }
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
    }
}
