using System;
using Server;

namespace Server.Items
{
	public class SwallowedPirateMaul : Maul
	{
	 	public override int ArtifactRarity{ get{ return 30; } }
	 	public override int InitMinHits{ get{ return 2550; } }
	 	public override int InitMaxHits{ get{ return 2550; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
        //public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.FistsOfFury; } }




	 	[Constructable]
	 	public SwallowedPirateMaul()
	 	{
	 	 	Name = "Swallowed Pirate Maul";
	 	 	Hue = 2995;
	 	 	
			Attributes.SpellChanneling = 3;
	 	 	Attributes.BonusStr = 15;
	 	 	Attributes.BonusHits = 20;
	 	 	Attributes.RegenHits = 15;
	 	 	Attributes.WeaponDamage = 25;
	 	 	Attributes.WeaponSpeed = 35;
	 	 	WeaponAttributes.SelfRepair = 25;
	 	 	WeaponAttributes.HitHarm = 35;
			Attributes.NightSight = 25;
	 	}

	 	public SwallowedPirateMaul(Serial serial) : base( serial )
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
