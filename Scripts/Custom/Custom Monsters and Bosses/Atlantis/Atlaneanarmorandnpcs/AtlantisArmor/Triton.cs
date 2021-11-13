
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class Triton : WarFork
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

				public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }
				//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.FireStrike; } }
		

		[Constructable]
		public Triton()
		{
			Name = "Triton";
                        Hue = 2823;
                        WeaponAttributes.SelfRepair = 20;
                        
						Attributes.SpellChanneling = 1;
                        WeaponAttributes.HitLeechHits = 5;
                        WeaponAttributes.HitLightning = 5;
                        WeaponAttributes.HitLeechMana = 5;
                        WeaponAttributes.UseBestSkill = 1;
                        Attributes.Luck = 10;
                        Attributes.BonusStr = 5;
                        Attributes.AttackChance = 5;
                        Attributes.WeaponSpeed = 10;
                        
			

		}

		public Triton( Serial serial ) : base( serial )
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
