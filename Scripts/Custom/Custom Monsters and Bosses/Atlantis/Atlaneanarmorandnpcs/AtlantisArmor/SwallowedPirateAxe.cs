using System;
using Server;

namespace Server.Items
{
	public class SwallowedPirateAxe : WarAxe
	{
	 	public override int ArtifactRarity{ get{ return 30; } }
	 	public override int InitMinHits{ get{ return 2550; } }
	 	public override int InitMaxHits{ get{ return 2550; } }



		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }
        //public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MeleeProtection; } }





	 	[Constructable]
	 	public SwallowedPirateAxe()
	 	{
	 	 	Name = "Swallowed Pirate Axe";
	 	 	Hue = 2995;
	 	 	
			
	 	 	Attributes.BonusStr = 5;
	 	 	Attributes.BonusHits = 25;
	 	 	Attributes.RegenHits = 10;
	 	 	WeaponAttributes.HitLeechHits = 20;
	 	 	Attributes.AttackChance = 5;
	 	 	Attributes.WeaponDamage = 20;
	 	 	Attributes.WeaponSpeed = 20;
	 	 	Attributes.Luck = 25;
	 	 	WeaponAttributes.SelfRepair = 25;
	 	 	
	 	 	
	 	}

	 	public SwallowedPirateAxe(Serial serial) : base( serial )
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
