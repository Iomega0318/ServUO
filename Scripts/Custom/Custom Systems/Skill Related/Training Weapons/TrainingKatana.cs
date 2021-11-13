using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishKatana))]
    [FlipableAttribute(0x13FF, 0x13FE)]
    public class TrainingKatana : BaseSword
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override int OldStrengthReq { get { return 25; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int DefHitSound { get { return 0x23B; } }
        public override int DefMissSound { get { return 0x23A; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingKatana()
            : base(0x13FF)
        {
            Weight = 10.0;
            Hue = 1161;
            Name = "A Training Katana";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
        }

        public TrainingKatana(Serial serial)
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