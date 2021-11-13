using System;
using Server;

namespace Server.Items
{
	public class AtlantisBow : CompositeBow
	{
	 	public override int ArtifactRarity{ get{ return 80; } }
	 	public override int InitMinHits{ get{ return 5000; } }
	 	public override int InitMaxHits{ get{ return 5000; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ToxicStrike; } }



	 	[Constructable]
	 	public AtlantisBow()
	 	{
	 	 	Name = "Atlantis Bow";
			Hue = 1268;
	 	 	
			Attributes.SpellChanneling = 1;
	 	 
	 	 	Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 20;
	 	 	Attributes.Luck = 50;
	 	 	WeaponAttributes.SelfRepair = 30;
	 	 	WeaponAttributes.HitLowerDefend = 55;

			                        
						
                        WeaponAttributes.HitLeechHits = 5;
                        WeaponAttributes.HitLightning = 5;
                        WeaponAttributes.HitLeechMana = 5;
                        WeaponAttributes.UseBestSkill = 1;
                        Attributes.Luck = 10;
                        Attributes.BonusStr = 5;
                        Attributes.AttackChance = 5;
                        Attributes.WeaponSpeed = 10;
                        
	 	 	
	 	}

	 	public AtlantisBow(Serial serial) : base( serial )
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
