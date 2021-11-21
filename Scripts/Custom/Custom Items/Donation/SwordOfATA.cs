using System;
using Server;

namespace Server.Items
{
	public class SwordOfATA : VikingSword
	{
	 	public override int ArtifactRarity{ get{ return 100; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MeleeProtection; } }
		//public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FireStrike; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 28; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.75f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
	 	
		
		[Constructable]
	 	public SwordOfATA()
	 	{
	 	 	Name = "Sword Of ATA";
	 	 	Hue = 1154;
			Slayer = SlayerName.DragonSlaying;

			Attributes.BonusMana = 10;

	 	 	Attributes.SpellChanneling = 5;
			Attributes.WeaponSpeed = 15;
			Attributes.WeaponDamage = 20;
			Attributes.ReflectPhysical = 25;
	 	 	Attributes.BonusStr = 15;
	 	 	Attributes.RegenStam = 15;
	 	 	Attributes.AttackChance = 35;
	 	 	WeaponAttributes.SelfRepair = 50;
	 	 	WeaponAttributes.HitLowerAttack = 35;
			Attributes.LowerRegCost = 20;
	 	}

	 	public SwordOfATA(Serial serial) : base( serial )
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
