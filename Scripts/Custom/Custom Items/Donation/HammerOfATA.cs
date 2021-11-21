using System;
using Server;

namespace Server.Items
{
	public class HammerOfATA : HammerPick
	{
	 	public override int ArtifactRarity{ get{ return 100; } }
	 	public override int InitMinHits{ get{ return 5000; } }
	 	public override int InitMaxHits{ get{ return 5000; } }
        public override int AosMinDamage { get { return 20; } }
        public override int AosMaxDamage { get { return 35; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }
		        //public override WeaponAbility ThirdAbility { get { return WeaponAbility.ZapManaStrike; } }
        //public override WeaponAbility FourthAbility { get { return WeaponAbility.ShadowInfectiousStrike; } }
		

	 	[Constructable]
	 	public HammerOfATA()
	 	{
	 	 	Name = "Hammer Of ATA";
	 	 	Hue = 1154;
			Slayer = SlayerName.BloodDrinking;

			

            Attributes.SpellChanneling = 4;
            Attributes.BonusStr = 20;
            Attributes.BonusHits = 25;
            Attributes.BonusDex = 20;
            Attributes.RegenHits = 15;
            Attributes.RegenStam = 15;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitLeechMana = 35;
            Attributes.AttackChance = 20;
            Attributes.DefendChance = 25;
            Attributes.WeaponDamage = 10;
            Attributes.WeaponSpeed = 30;

						Attributes.LowerRegCost = 20;


            WeaponAttributes.SelfRepair = 50;
	 	}

	 	public HammerOfATA(Serial serial) : base( serial )
	 	{
	 	}

	 	public override void Serialize( GenericWriter writer )
	 	{
	 	 	base.Serialize( writer );

	 	 	writer.Write( (int) 0 );
	 	}
	 	public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader );

	 	 	int version = reader.ReadInt();
	 	}
	}
}
