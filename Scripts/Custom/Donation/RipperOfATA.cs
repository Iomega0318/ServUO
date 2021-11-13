using System;
using Server;

namespace Server.Items
{
	public class RipperOfATA : Katana
	{
	 	public override int ArtifactRarity{ get{ return 100; } }
                public override int InitMinHits{ get{ return 2550; } }
	 	public override int InitMaxHits{ get{ return 2550; } }
        public override int AosMinDamage { get { return 20; } }
        public override int AosMaxDamage { get { return 35; } }
        
		public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ArmorIgnore; } }
		//public override WeaponAbility ThirdAbility { get { return WeaponAbility.ZapStamStrike; } }
        //public override WeaponAbility FourthAbility { get { return WeaponAbility.StunningStrike; } }	 	
		
		
		
		
		[Constructable]
	 	public RipperOfATA()
	 	{
	 	 	Name = "Ripper Of ATA";
	 	 	Hue = 1154;
			Slayer = SlayerName.DaemonDismissal;

				

	 	 	Attributes.SpellChanneling = 2;
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
	 	 	
	 	 	
	 	 	WeaponAttributes.SelfRepair = 50;
	 	 	
	 	}

	 	public RipperOfATA(Serial serial) : base( serial )
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
