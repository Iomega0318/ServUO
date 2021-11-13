namespace Server.Items
{
    [Flipable(0x48BC, 0x48BD)]
    public class TrainingGargishKryss : BaseSword
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.InfectiousStrike; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int DefHitSound { get { return 0x23C; } }
        public override int DefMissSound { get { return 0x238; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
        public override SkillName DefSkill { get { return SkillName.Fencing; } }
        public override WeaponType DefType { get { return WeaponType.Piercing; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public TrainingGargishKryss()
            : base(0x48BC)
        {
            Weight = 2.0;
            Hue = 656;
            Name = "A Training Gargish Kryss";
            WeaponAttributes.SelfRepair = 5;
            LootType = LootType.Blessed;
            Attributes.SpellChanneling = 1;

        }

        public TrainingGargishKryss(Serial serial)
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
