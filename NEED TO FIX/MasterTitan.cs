using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an Master titan corpse" )]
	public class MasterTitan : BaseCreature
	{
		public override bool StatLossAfterTame { get { return false; } }

		[Constructable]
		public MasterTitan () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Hue = 0x5555;
			Name = "The Master Titan";
			Body = 0x4C;
			BaseSoundID = 0x261;

			SetStr( 1025, 1425 );
			SetDex( 81, 148 );
			SetInt( 475, 675 );

			SetHits( 3500, 4000 );
			SetStam( 120, 135 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 60, 85 );
			SetResistance( ResistanceType.Fire, 65, 90 );
			SetResistance( ResistanceType.Cold, 50, 55 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 50, 75 );

			SetSkill( SkillName.Meditation, 0 );
			SetSkill( SkillName.EvalInt, 110.0, 140.0 );
			SetSkill( SkillName.Magery, 110.0, 140.0 );
			SetSkill( SkillName.Poisoning, 110.0, 140.0 );
			SetSkill( SkillName.Anatomy, 110.0, 140.0 );
			SetSkill( SkillName.MagicResist, 110.0, 140.0 );
			SetSkill( SkillName.Tactics, 110.0, 140.0 );
			SetSkill( SkillName.Wrestling, 115.0, 145.0 );
			
			SetSpecialAbility(SpecialAbility.DragonBreath);

			Fame = 22000;
			Karma = -15000;

			VirtualArmor = 75;
			
		

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 20 );
			PackItem( new MasterCoin( 5 ) );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		//public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 6; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 30; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Yellow : ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public MasterTitan( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			SetDamage( 5, 35 );

			if( version == 0 )
			{
				Server.SkillHandlers.AnimalTaming.ScaleStats( this, 0.50 );
				Server.SkillHandlers.AnimalTaming.ScaleSkills( this, 0.80, 0.90 ); // 90% * 80% = 72% of original skills trainable to 90%
				Skills[SkillName.Magery].Base = Skills[SkillName.Magery].Cap; // Greater dragons have a 90% cap reduction and 90% skill reduction on magery
			}
		}
	}
}
