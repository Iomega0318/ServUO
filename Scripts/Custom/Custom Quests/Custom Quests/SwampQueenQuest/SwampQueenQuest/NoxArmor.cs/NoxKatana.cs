

using System;
using Server;

namespace Server.Items
{ 
	public class NoxKatana: Katana
	{
		public override int ArtifactRarity{ get{ return 10; } }

        public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 600; } }
                
		public override int AosStrengthReq{ get{ return 100; } }
		public override int AosMinDamage{ get{ return 19; } }
		public override int AosMaxDamage{ get{ return 31; } }
		public override int AosSpeed{ get{ return 48; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 19; } }
		public override int OldMaxDamage{ get{ return 37; } }
		public override int OldSpeed{ get{ return 48; } }

        public override int DefMaxRange{ get{ return 1; } }
		public override int DefHitSound{ get{ return 1140; } }
		public override int DefMissSound{ get{ return 517; } }
	
	

		[Constructable]
		public NoxKatana()
		{
            Name = " Katana of the Swamp Queen";
			Hue = 2210;

            Attributes.Luck = 150;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
			Attributes.SpellChanneling = 1;
            Attributes.AttackChance = 25;
            WeaponAttributes.SelfRepair = 5;
            WeaponAttributes.HitPoisonArea = 0;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitLeechMana = 35;
            WeaponAttributes.UseBestSkill = 0;
            WeaponAttributes.ResistPoisonBonus = 0;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = nrgy = chaos = direct = 0;
			pois = 100;
		}

		public NoxKatana( Serial serial ) : base( serial )
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