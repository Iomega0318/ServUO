using System;
using Server;

namespace Server.Items
{
	public class PureWhiteFeatherBow : Bow 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public PureWhiteFeatherBow()
		{
			Weight = 5.0;
            		Name = "Pure White Feather Bow";
            		Hue = 1153;

			//WeaponAttributes.DurabilityBonus = 10; 
			//WeaponAttributes.HitEnergyArea = 05;
			WeaponAttributes.HitLeechHits = 55;
			//WeaponAttributes.HitPoisonArea = 01;   
			//WeaponAttributes.ResistEnergyBonus = 10;
			WeaponAttributes.ResistPoisonBonus = 30;
			WeaponAttributes.UseBestSkill = 1;

			Attributes.BonusDex = 10;
			Attributes.BonusStr = 10;
			//Attributes.Luck = 300;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 45;
			Attributes.WeaponDamage = 65;

			StrRequirement = 01;

			LootType = LootType.Blessed;
		}
        public override bool CanEquip(Mobile from)
        {
            if (from.Skills[SkillName.Archery].Base <= 100.0)
            {
                from.SendMessage("You are not skilled enough to equip that.");
                return false;
            }
            else
            {
                return base.CanEquip(from);
            }
        }		
		public PureWhiteFeatherBow( Serial serial ) : base( serial )
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
