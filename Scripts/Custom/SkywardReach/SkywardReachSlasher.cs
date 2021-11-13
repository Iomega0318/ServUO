using System;
using Server;

namespace Server.Items
{
	public class SkywardReachSlasher : VikingSword
	{
	 	public override int ArtifactRarity{ get{ return 81; } }
	 	public override int InitMinHits{ get{ return 5000; } }
	 	public override int InitMaxHits{ get{ return 5000; } }

				public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.DevastatingBlow; } }


	 	[Constructable]
	 	public SkywardReachSlasher()
	 	{
	 	 	Name = "Skyward Reach Slasher";
	 	 	Hue = 0;
			ItemID = 21543;
	 	 	
			Attributes.SpellChanneling = -1;
            WeaponAttributes.UseBestSkill = 1;

	 	 	Attributes.BonusStr = 10;
	 	 	Attributes.BonusHits = 10;
	 	 	
			Attributes.RegenHits = 4;
			Attributes.RegenStam = 4;
	 	 	
	 	 	Attributes.DefendChance = 10;
			Attributes.AttackChance = 10;
	 	 	
			Attributes.WeaponDamage = 15;
	 	 	Attributes.WeaponSpeed = 8;

            WeaponAttributes.HitLightning = 7;
			WeaponAttributes.HitEnergyArea = 7;
			WeaponAttributes.HitFireball = 7;

			WeaponAttributes.HitLowerAttack = 5;
			WeaponAttributes.HitDispel = 8;
			WeaponAttributes.HitHarm = 8;
	 	 	WeaponAttributes.ResistEnergyBonus = 15;

			WeaponAttributes.SelfRepair = 15;
			
			StrRequirement = 50;
	 	}

	 	public SkywardReachSlasher(Serial serial) : base( serial )
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
