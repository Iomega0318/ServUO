using System;
using Server;

namespace Server.Items
{
	public class ATAStaffOfTheMagi : BlackStaff
	{
		public override int LabelNumber{ get{ return 1061600; } } // Staff of the Magi
		public override int ArtifactRarity{ get{ return 101; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MagicProtection; } }
        //public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MagicProtection2; } }
		//public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ElementalStrike; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 48; } }
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int OldSpeed{ get{ return 48; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ATAStaffOfTheMagi()
		{
			
            Name = "ATA Staff Of The Magi";
            

			

            Slayer = SlayerName.Fey;

            WeaponAttributes.MageWeapon = 30;

            WeaponAttributes.UseBestSkill = 1;
			
			Attributes.WeaponDamage = 25;

            Attributes.SpellChanneling = 1;
           
            Attributes.BonusStr = 5;
            Attributes.BonusInt = 5;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 5;
            Attributes.BonusStam = 5;
            Attributes.BonusMana = 10;
            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;
            
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 10;
            Attributes.WeaponSpeed = 10;
            Attributes.WeaponDamage = 25;

            Attributes.ReflectPhysical = 10;
            Attributes.EnhancePotions = 10;
            Attributes.SpellDamage = 5;
           
            WeaponAttributes.HitColdArea = 10;
            
            WeaponAttributes.HitEnergyArea = 10;
            
            
            WeaponAttributes.ResistColdBonus = 10;
            
            WeaponAttributes.ResistEnergyBonus = 10;
            
            WeaponAttributes.HitLeechMana = 10;
            
            Attributes.CastSpeed = 3;
            Attributes.CastRecovery = 4;
            Attributes.LowerManaCost = 10;
            Attributes.LowerRegCost = 25;

         
            WeaponAttributes.HitLightning = 5;
            WeaponAttributes.HitDispel = 5;

            WeaponAttributes.SelfRepair = 50;
        }

		#region Mondain's Legacy
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}
		#endregion

		public ATAStaffOfTheMagi( Serial serial ) : base( serial )
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

			if ( WeaponAttributes.MageWeapon == 0 )
				WeaponAttributes.MageWeapon = 30;

			if ( ItemID == 0xDF1 )
				ItemID = 0xDF0;
		}
	}
}