using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{

	public class BowOfATA : BaseRanged
	{

		public override int ArtifactRarity{ get{ return 101; } }

		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }
			    //public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.FreezeStrike; } }
		//public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MagicProtection; } } 

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 25; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 4.00f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 15; } }
		public override int OldMaxDamage{ get{ return 17; } }
		public override int OldSpeed{ get{ return 25; } }
	 	 	
	 	 	

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public BowOfATA() : base( 0x26C2 )
		{
			Weight = 5.0;
            
            Name = "Bow Of ATA";
            Slayer = SlayerName.EarthShatter;
            ItemID = 9922;



	 	 	Attributes.SpellChanneling = 4;
	 	 	Attributes.BonusDex = 15;
            Attributes.BonusStr = 5;
            Attributes.BonusInt = 5;

            Attributes.RegenHits = 5;
            Attributes.RegenStam = 5;
	 	 	
            
	 	 	Attributes.AttackChance = 30;
            Attributes.DefendChance = 15;
	 	 	Attributes.WeaponSpeed = 25;
            Attributes.WeaponDamage = 15;

	 	 	Attributes.ReflectPhysical = 20;

            WeaponAttributes.HitLeechHits = 30;
            WeaponAttributes.HitHarm = 15;
            
	 	 	WeaponAttributes.ResistColdBonus = 45;
            WeaponAttributes.ResistEnergyBonus = 25;

						Attributes.LowerRegCost = 20;

	 	 	Attributes.Luck = 75;

	 	 	WeaponAttributes.SelfRepair = 50;
		}

		public BowOfATA( Serial serial ) : base( serial )
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