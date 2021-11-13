//Written by Quikspot

namespace Server.Items
{
    public class TrainingQuiver : BaseQuiver
    {
        public override bool IsArtifact => true;

        [Constructable]

        public TrainingQuiver()
                : base(0x2B02)
        {

            Weight = 5.0;
            Name = "Training Quiver";
            Hue = 1161;
            LowerAmmoCost = 100;
            LootType = LootType.Blessed;
        }

        public TrainingQuiver(Serial serial)
            : base(serial)
        {
        }

        public override bool CanAlter => false;

        public override int LabelNumber => 1075201;// Infinite Ammo Quiver
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(2); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            if (version < 1 && DamageIncrease == 0)
                DamageIncrease = 0;

            if (version < 2 && Attributes.WeaponDamage == 10)
                Attributes.WeaponDamage = 0;
        }
    }
}