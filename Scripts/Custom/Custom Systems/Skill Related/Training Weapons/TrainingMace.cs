using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DiscMace))]
    [FlipableAttribute(0xF5C, 0xF5D)]
    public class TrainingMace : BaseBashing
    {

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Disarm; } }
        public override int OldStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 1; } }
        public override int AosMaxDamage { get { return 1; } }
        public override int AosSpeed { get { return 2; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public TrainingMace()
            : base(0xF5C)
        {
            Weight = 14.0;
            Hue = 1161;
            Name = "A Training Mace";
            LootType = LootType.Blessed;
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
        }

        public TrainingMace(Serial serial)
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