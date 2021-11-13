using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1451, 0x1456 )]
	public class ImpalerHelm : BaseArmor
	{
        public override bool CanFortify { get { return false; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int ArmorBase{ get{ return 30; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public ImpalerHelm() : base( 0x1451 )
		{
            Name = "Helm of the Impaler";
            Hue = 688;
			Weight = 3.0;

            //LootType = LootType.Newbied;
            Attributes.BonusStr = 1;
            Attributes.DefendChance = 5;
            Attributes.ReflectPhysical = 3;
		}

        public ImpalerHelm(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			if ( Weight == 1.0 )
				Weight = 3.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

    [FlipableAttribute(0x144f, 0x1454)]
    public class ImpalerChest : BaseArmor
    {
        public override bool CanFortify { get { return false; } }

        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 10; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }

        public override int AosStrReq { get { return 60; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -6; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 11; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ImpalerChest()
            : base(0x144F)
        {
            Name = "Impaler's BreastPlate";
            Hue = 688;
            Weight = 6.0;

            //LootType = LootType.Newbied;
            Attributes.BonusStr = 1;
            Attributes.DefendChance = 5;
            Attributes.ReflectPhysical = 3;
        }

        public ImpalerChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 6.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [FlipableAttribute(0x144e, 0x1453)]
    public class ImpalerArms : BaseArmor
    {
        public override bool CanFortify { get { return false; } }

        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 10; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ImpalerArms()
            : base(0x144E)
        {
            Name = "Bracers of the Impaler";
            Hue = 688;
            Weight = 2.0;

            //LootType = LootType.Newbied;
            Attributes.BonusStr = 1;
            Attributes.DefendChance = 5;
            Attributes.ReflectPhysical = 3;
        }

        public ImpalerArms(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 2.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [FlipableAttribute(0x1450, 0x1455)]
    public class ImpalerGloves : BaseArmor
    {
        public override bool CanFortify { get { return false; } }

        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 10; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -1; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 2; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ImpalerGloves()
            : base(0x1450)
        {
            Name = "Impaler's Guantlets";
            Hue = 688;
            Weight = 2.0;

            //LootType = LootType.Newbied;
            Attributes.BonusStr = 1;
            Attributes.DefendChance = 5;
            Attributes.ReflectPhysical = 3;
        }

        public ImpalerGloves(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 2.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }


    [FlipableAttribute(0x1452, 0x1457)]
    public class ImpalerLegs : BaseArmor
    {
        public override bool CanFortify { get { return false; } }

        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 10; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -4; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 7; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public ImpalerLegs()
            : base(0x1452)
        {
            Name = "Impaler's Leggings";
            Hue = 688;
            Weight = 3.0;

            //LootType = LootType.Newbied;
            Attributes.BonusStr = 1;
            Attributes.DefendChance = 5;
            Attributes.ReflectPhysical = 3;
        }

        public ImpalerLegs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
