using System;
using Server;

namespace Server.Items
{
	public class SwallowedPirateCutlass : Cutlass
	{
	 	public override int ArtifactRarity{ get{ return 30; } }
                public override int InitMinHits{ get{ return 2550; } }
	 	public override int InitMaxHits{ get{ return 2550; } }

				public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
				//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ZapStamStrike; } }
		
	 	[Constructable]
	 	public SwallowedPirateCutlass()
	 	{
	 	 	Name = "Swallowed Pirate Cutlass";
	 	 	Hue = 2995;
	 	 	
	 	 	Attributes.BonusStr = 5;
	 	 	Attributes.BonusHits = 15;
	 	 	Attributes.BonusDex = 15;
	 	 	Attributes.RegenHits = 8;
	 	 	Attributes.RegenStam = 8;
	 	 	WeaponAttributes.HitLeechMana = 35;
	 	 	Attributes.AttackChance = 5;
	 	 	Attributes.DefendChance = 15;
	 	 	Attributes.WeaponDamage = 15;
	 	 	Attributes.WeaponSpeed = 20;
			Attributes.NightSight = 25;
	 	 	
	 	 	
	 	 	WeaponAttributes.SelfRepair = 25;
	 	 	
	 	}

	 	public SwallowedPirateCutlass(Serial serial) : base( serial )
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
