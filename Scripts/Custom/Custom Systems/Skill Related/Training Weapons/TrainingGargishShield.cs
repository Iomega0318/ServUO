namespace Server.Items
{
    [Flipable(0x422A, 0x422C)]
    public class TrainingGargishShield : BaseShield
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
        public TrainingGargishShield()
            : base(0x422A)
        {
            Name = "A Training Gargish Shield";
            Hue = 656;
            Weight = 2.0;
            WeaponAttributes.SelfRepair = 5;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
        }

        public TrainingGargishShield(Serial serial)
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
            writer.Write(0); //version
        }
    }
}
