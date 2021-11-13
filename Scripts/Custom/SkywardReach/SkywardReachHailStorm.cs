using System;
using Server;

namespace Server.Items
{
	public class SkywardReachHailStorm : CompositeBow
	{
	 	public override int ArtifactRarity{ get{ return 81; } }
	 	public override int InitMinHits{ get{ return 5000; } }
	 	public override int InitMaxHits{ get{ return 5000; } }
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MovingShot; } }
		//public override WeaponAbility ThirdAbility { get { return WeaponAbility.AchillesStrike; } }
		
	 	[Constructable]
	 	public SkywardReachHailStorm()
	 	{
	 	 	Name = "Skyward Reach Hail Storm";
			Hue = 0;
			ItemID = 21505;
	 	 	
			Attributes.SpellChanneling = 1;
	 	 
	 	 	Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 20;
	 	   
			Attributes.DefendChance = 10;
			Attributes.AttackChance = 10;
		    
            Attributes.BonusStr = 5;
          
		    WeaponAttributes.HitMagicArrow = 10;
	 	 	WeaponAttributes.HitLowerDefend = 25;
            WeaponAttributes.HitLeechHits = 10;
			WeaponAttributes.HitFireball = 25;
			WeaponAttributes.HitLeechHits = 5;
            WeaponAttributes.HitLightning = 5;
			WeaponAttributes.HitColdArea = 8;
            WeaponAttributes.HitLeechMana = 5;

			WeaponAttributes.ResistEnergyBonus = 15;
            
			WeaponAttributes.UseBestSkill = 1;

			WeaponAttributes.SelfRepair = 15;

			StrRequirement = 30;
                        

                        
 }

	 	public SkywardReachHailStorm(Serial serial) : base( serial )
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
