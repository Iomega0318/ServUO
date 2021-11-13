//////////////////////////////////
//// scripted by Doaker /////
//////// 10/10/08 ////////
////////////////////////////////
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Pirates Wind On Land corpse" )]
	[TypeAlias( "Server.Mobiles.BrownHorse" )]
	public class PiratesWindOnLand : BaseMount
	{
		private static int[] m_IDs = new int[]
			{
				0xCC, 0x3EA2
			};

		[Constructable]
		public PiratesWindOnLand() : this( "Pirates Wind On Land" )
		{
		}

		[Constructable]
		public PiratesWindOnLand( string name ) : base( name, 0xCC, 0x3EA2, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.9 )
		{
			BaseSoundID = 0xA8;
			Hue = 2534;

            SetStr( 200, 575 );
			SetDex( 80, 140 );
			SetInt( 100, 125 );

			SetHits( 300, 415 );

			SetDamage( 15, 26 );

			SetDamageType( ResistanceType.Fire, 35 );

			SetResistance( ResistanceType.Physical, 55, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 50, 110 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 55, 110 );

			SetSkill( SkillName.EvalInt, 39.1, 49.0 );
			SetSkill( SkillName.Magery, 40.1, 50.0 );
			SetSkill( SkillName.MagicResist, 79.1, 100.0 );
			SetSkill( SkillName.Tactics, 79.6, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 92.5 );
			
			SetSpecialAbility(SpecialAbility.DragonBreath);

			Fame = 7000;
			Karma = -7000;

			VirtualArmor = 75;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 109;

		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		//public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }
		public PiratesWindOnLand( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}