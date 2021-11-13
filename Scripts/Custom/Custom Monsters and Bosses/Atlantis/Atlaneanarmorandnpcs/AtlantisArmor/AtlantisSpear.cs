using System;
using Server;

namespace Server.Items
{
	public class AtlantisSpear : ShortSpear
	{
	 	public override int ArtifactRarity{ get{ return 80; } }
	 	public override int InitMinHits{ get{ return 2550; } }
	 	public override int InitMaxHits{ get{ return 2550; } }

				public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ShadowInfectiousStrike; } }
	 	
        [Constructable]
	 	public AtlantisSpear()
	 	{
	 	 	Name = "Atlantis Spear";
	 	 	Hue = 1173;
	 	 	
			Attributes.SpellChanneling = 3;
	 	 	Attributes.BonusInt = 5;
	 	 	Attributes.RegenMana = 9;
	 	 	WeaponAttributes.HitLeechMana = 25;
	 	 	Attributes.AttackChance = 5;
	 	 	Attributes.WeaponDamage = 5;
	 	 	Attributes.WeaponSpeed = 25;
	 	 	Attributes.EnhancePotions = 35;
	 	 	Attributes.SpellDamage = 35;
	 	 	WeaponAttributes.ResistEnergyBonus = 20;
	 	 	WeaponAttributes.SelfRepair = 30;
	 	 	Attributes.CastSpeed = 5;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.LowerManaCost = 50;
	 	}

	 	public AtlantisSpear(Serial serial) : base( serial )
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
