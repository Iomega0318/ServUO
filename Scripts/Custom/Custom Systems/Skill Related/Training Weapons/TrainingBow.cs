using System;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class TrainingBow : BaseRanged
    {

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int DefMaxRange { get { return 10; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public TrainingBow()
            : base(0x13B2)
        {
            Weight = 10.0;
            Layer = Layer.TwoHanded;
            LootType = LootType.Blessed;
            Hue = 1161;
            Name = "A Training Bow";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
        }

        public TrainingBow(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
