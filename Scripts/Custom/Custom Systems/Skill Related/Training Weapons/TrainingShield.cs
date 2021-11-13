using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishWoodenShield))]
    public class TrainingShield : BaseShield
    {

        public override int BasePhysicalResistance { get { return 25; } }
        public override int BaseFireResistance { get { return 25; } }
        public override int BaseColdResistance { get { return 25; } }
        public override int BasePoisonResistance { get { return 25; } }
        public override int BaseEnergyResistance { get { return 25; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
        public override int AosStrReq { get { return 10; } }

        [Constructable]
        public TrainingShield()
            : base(0x1B72)
        {
            Weight = 10.0;
            Name = "A Training shield";
            Hue = 1161;
            Attributes.SpellChanneling = 1;
            ArmorAttributes.LowerStatReq = 100;
            WeaponAttributes.SelfRepair = 10;
            LootType = LootType.Blessed;

        }

        public TrainingShield(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);//version
        }
    }
}