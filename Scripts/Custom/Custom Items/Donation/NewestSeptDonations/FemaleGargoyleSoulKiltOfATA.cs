using Server;
using Server.Items;

namespace Server.Items
{	
	public class FemaleGargoyleSoulKiltOfATA : BaseArmor
	{
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }


        public override int ArmorBase { get { return 13; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

		public override Race RequiredRace { get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }


		[Constructable]
        public FemaleGargoyleSoulKiltOfATA()
            : base(0x0408)
		{
            Name = "Female Gargoyle Soul Kilt Of ATA";
            Hue = 1154;
			Weight = 2.0;
            ItemID = 784;

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

                        Attributes.BonusDex = 10;
                        Attributes.Luck = 25;

			Attributes.BonusMana = 2;
			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 2;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 5;
			Attributes.SpellDamage = 2;
		    Attributes.RegenMana = 5;
			ArmorAttributes.SelfRepair = 50;

		AbsorptionAttributes.SoulChargeFire = 5;
		AbsorptionAttributes.SoulChargeCold	= 5;	
		AbsorptionAttributes.SoulChargePoison = 5;	
		AbsorptionAttributes.SoulChargeEnergy = 5;	
		AbsorptionAttributes.SoulChargeKinetic = 5;
		AbsorptionAttributes.CastingFocus = 2;

		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				if ( ((Mobile)parent).Female )
					ItemID = 0x0407;
				else
					ItemID = 0x0408;
			}
		}

        public FemaleGargoyleSoulKiltOfATA(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}

