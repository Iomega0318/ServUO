using System;
using Server;

namespace Server.Items
{
	public class PirateBlade : Longsword
	{
		public override int ArtifactRarity{ get{ return 30; } } 


		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ConsecratedStrike; } }
		

		[Constructable]
		public PirateBlade()
		{
			Weight = 3.0;
            		Name = "Sword of the Pirate";
            		Hue = 2995;

			
			WeaponAttributes.HitLeechHits = 15;
			WeaponAttributes.HitLeechMana = 15;
			WeaponAttributes.HitLeechStam = 15;                                   
			
			WeaponAttributes.SelfRepair = 25;
			WeaponAttributes.UseBestSkill = 1;

			Attributes.AttackChance = 20;

			Attributes.BonusStr = 5;
			Attributes.Luck = 5;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 25;
			Attributes.WeaponSpeed = 20;

			
			StrRequirement = 20;

			
		}

		public PirateBlade( Serial serial ) : base( serial )
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