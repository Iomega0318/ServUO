using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	
	public class TessenOfATA : Tessen
	{

		public override int ArtifactRarity{ get{ return 101; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Feint; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Block; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.LightningFury; } }
        //public override WeaponAbility FourthAbility{ get{ return WeaponAbility.StunningStrike; } }
		//public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 12; } }
		public override int AosSpeed{ get{ return 50; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.00f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 12; } }
		public override int OldSpeed{ get{ return 50; } }

		public override int DefHitSound{ get{ return 0x232; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 55; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }

		[Constructable]
		public TessenOfATA() : base( 0x27A3 )
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
            Name = "Tessen Of ATA";
            ItemID = 10147;


            Slayer = SlayerName.SummerWind;
            Attributes.LowerRegCost = 15;

            Attributes.WeaponDamage = 25;
            Attributes.WeaponSpeed = 15;

            Attributes.BonusStr = 7;
            Attributes.BonusInt = 7;
            Attributes.BonusDex = 7;
            Attributes.BonusHits = 10;
            Attributes.BonusStam = 7;
            Attributes.BonusMana = 10;
            Attributes.RegenHits = 10;
            Attributes.RegenStam = 10;

            Attributes.AttackChance = 25;
            Attributes.DefendChance = 15;

            Attributes.ReflectPhysical = 10;
            WeaponAttributes.ResistPhysicalBonus = 10;

            WeaponAttributes.HitPoisonArea = 10;
            WeaponAttributes.ResistPhysicalBonus = 10;
            WeaponAttributes.ResistPoisonBonus = 10;



            WeaponAttributes.HitLowerAttack = 15;
            Attributes.Luck = 75;
            WeaponAttributes.SelfRepair = 50;
		}

		public TessenOfATA( Serial serial ) : base( serial )
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