namespace Server.Items
{
    [Flipable(0x48C2, 0x48C3)]
    public class TrainingGargishMaul : BaseBashing
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 3; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingGargishMaul()
            : base(0x48C2)
        {
            Hue = 656;
            Name = "A Training Gargish Maul";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
            Weight = 5.0;
        }

        public TrainingGargishMaul(Serial serial)
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
