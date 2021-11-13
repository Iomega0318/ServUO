using System;
using Server;

namespace Server.Items
{
	public class AxeOfATA : WarAxe
	{
	 	public override int ArtifactRarity{ get{ return 100; } }
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		//public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }
	    //public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.EarthStrike; } }
		//public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MeleeProtection2; } }
		

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 33; } }
		public override float MlSpeed{ get{ return 3.25f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 27; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		public override SkillName DefSkill{ get{ return SkillName.Macing; } }
		public override WeaponType DefType{ get{ return WeaponType.Bashing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

		
	 	
		[Constructable]
	 	public AxeOfATA()
	   {
	 	 	Name = "Axe Of ATA";
	 	 	Hue = 1154;
			Slayer = SlayerName.BalronDamnation;
			ItemID = 5040;

		 

	 	 	Attributes.SpellChanneling = 4;
	 	 	Attributes.BonusStr = 15;
	 	 	Attributes.BonusHits = 25;
	 	 	Attributes.RegenHits = 15;
	 	 	WeaponAttributes.HitLeechHits = 25;
	 	 	Attributes.AttackChance = 25;
	 	 	Attributes.WeaponDamage = 20;
	 	 	Attributes.WeaponSpeed = 20;
	 	 	Attributes.Luck = 100;
	 	 	WeaponAttributes.SelfRepair = 50;
						Attributes.LowerRegCost = 20;
	 	 	
	 	 	
	 	}

	 	public AxeOfATA(Serial serial) : base( serial )
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
