using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{

	public class WarAxeOfATA : WarAxe
	{

		public override int ArtifactRarity{ get{ return 101; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }
				//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.DevastatingBlow; } }
        //public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ToxicStrike; } }
		//public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ZapStrStrike; } }

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

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		public override SkillName DefSkill{ get{ return SkillName.Macing; } }
		public override WeaponType DefType{ get{ return WeaponType.Bashing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

		public override HarvestSystem HarvestSystem{ get{ return null; } }

		[Constructable]
		public WarAxeOfATA() : base( 0x13B0 )
		{
			Weight = 8.0;

	 	 	Name = "War Axe Of ATA";
	 	 	
            Slayer = SlayerName.GargoylesFoe;

		

	 	 	Attributes.SpellChanneling = 4;
            Attributes.NightSight = 25;
;
	 	 	Attributes.BonusStr = 15;
	 	 	Attributes.BonusHits = 25;
	 	 	Attributes.RegenHits = 5;
            Attributes.ReflectPhysical = 10;
	 	 	
            WeaponAttributes.HitLeechHits = 20;
	 	 	WeaponAttributes.HitFireball = 20;

            WeaponAttributes.HitFireArea = 5;
            WeaponAttributes.HitPhysicalArea = 5;

            Attributes.AttackChance = 15;
            Attributes.DefendChance = 10;
	 	 	Attributes.WeaponDamage = 25;
	 	 	Attributes.WeaponSpeed = 15;
	 	 	Attributes.Luck = 75;

            WeaponAttributes.ResistFireBonus = 10;
	 	 	WeaponAttributes.ResistPhysicalBonus = 10;

            WeaponAttributes.SelfRepair = 50;
	 	 	
		}

		public WarAxeOfATA( Serial serial ) : base( serial )
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