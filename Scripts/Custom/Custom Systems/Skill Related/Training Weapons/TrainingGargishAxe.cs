namespace Server.Items
{
    [Flipable(0x48B2, 0x48B3)]
    public class TrainingGargishAxe : BaseAxe
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 3; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingGargishAxe()
            : base(0x48B2)
        {
            Weight = 4.0;
            Hue = 656;
            LootType = LootType.Blessed;
            Name = "A Training Gargish Axe";
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;

        }

        public TrainingGargishAxe(Serial serial)
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
