//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 3/29/2015 11:03:31 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class ResurrectionSword : Katana
	{
		public override int ArtifactRarity{ get{ return 12; } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ResurrectionSword()
		{
			Name = "Sword of Resurrection";
			Hue = 1920;
			Attributes.AttackChance = 10;
			Attributes.DefendChance = 10;
			Attributes.Luck = 100;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 10;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			WeaponAttributes.HitLeechStam = 35;
			WeaponAttributes.HitLeechHits = 50;
			WeaponAttributes.HitLightning = 60;
			WeaponAttributes.HitFireball = 40;
			WeaponAttributes.HitLowerAttack = 30;
			WeaponAttributes.HitLowerDefend = 27;
			WeaponAttributes.UseBestSkill = 1;
		}

		public ResurrectionSword( Serial serial ) : base( serial )
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
