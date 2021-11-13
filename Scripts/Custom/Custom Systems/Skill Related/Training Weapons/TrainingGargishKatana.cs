namespace Server.Items
{
    [Flipable(0x48BA, 0x48BB)]
    public class TrainingGargishKatana : BaseSword
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int DefHitSound { get { return 0x23B; } }
        public override int DefMissSound { get { return 0x23A; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingGargishKatana()
            : base(0x48BA)
        {
            Weight = 6.0;
            LootType = LootType.Blessed;
            Hue = 656;
            Name = "A Training Gargish Katana";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
        }

        public TrainingGargishKatana(Serial serial)
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
