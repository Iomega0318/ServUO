//Edited by Darck...
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a MC grizzly corpse" )]
	public class MCGrizzlyBear : BaseMount
	{
		[Constructable]
		public MCGrizzlyBear() : this( "a mc grizzly bear" )
		{
		}

		[Constructable]
		public MCGrizzlyBear( string name ) : base( name, 0xD5, 0x3EC5, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Hue = 2075;
			BaseSoundID = 0xA3;

            SetStr(1251, 1550);
            SetDex(801, 1050);
            SetInt(151, 400);

            SetHits(751, 1930);
            SetMana(0);

            SetDamage(11, 23);

            SetDamageType(ResistanceType.Physical, 40);

            SetResistance(ResistanceType.Physical, 30, 70);
            SetResistance(ResistanceType.Cold, 30, 50);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.Wrestling, 73.4, 88.1);
            SetSkill(SkillName.Tactics, 73.6, 110.5);
            SetSkill(SkillName.MagicResist, 32.8, 54.6);
            SetSkill(SkillName.Anatomy, 0, 0);

			Fame = 20000;
			Karma = -20000;

            VirtualArmor = 24;

			Tamable = false;
			ControlSlots = 3;
			MinTameSkill = 106.0;
		}

		public override void GenerateLoot()
		{
			PackItem( new Ruby( Utility.RandomMinMax( 16, 30 ) ) );
            PackItem( new MasterCoin( 3 ) );
		}

        public override int Meat { get { return 4; } }
        public override int Hides { get { return 32; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Daemon | PackInstinct.Bear; } }
        public override bool AlwaysMurderer { get { return true; } }

		public MCGrizzlyBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( BaseSoundID <= 0 )
				BaseSoundID = 0xA3;

			if( version < 1 )
			{
				for ( int i = 0; i < Skills.Length; ++i )
				{
					Skills[i].Cap = Math.Max( 100.0, Skills[i].Cap * 0.9 );

					if ( Skills[i].Base > Skills[i].Cap )
					{
						Skills[i].Base = Skills[i].Cap;
					}
				}
			}
		}
	}
}