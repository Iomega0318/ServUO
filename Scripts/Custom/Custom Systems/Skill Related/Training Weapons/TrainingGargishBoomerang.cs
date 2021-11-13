namespace Server.Items
{
    public class TrainingGargishBoomerang : BaseThrown
    {

        public override int MinThrowRange { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.MysticArc; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingGargishBoomerang()
            : base(0x8FF)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Hue = 656;
            LootType = LootType.Blessed;
            Name = "A Training Boomerang";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
        }

        public TrainingGargishBoomerang(Serial serial)
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
