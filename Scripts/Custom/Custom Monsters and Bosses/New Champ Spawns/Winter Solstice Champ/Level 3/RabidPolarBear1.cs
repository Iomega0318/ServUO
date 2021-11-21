using System;
using Server.Mobiles;
using Server.Items;
namespace Server.Mobiles
{
	[CorpseName( "a polar bear corpse" )]
	[TypeAlias( "Server.Mobiles.Polarbear" )]
	public class RabidPolarBear1 : BaseCreature
	{
		[Constructable]
		public RabidPolarBear1() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a rabid polar bear";
			Body = 213;
            Hue = 2429;
			BaseSoundID = 0xA3;

			SetStr( 216, 240 );
			SetDex( 181, 205 );
			SetInt( 126, 150 );

			SetHits( 250, 450 );
			SetMana( 80 );

			SetDamage( 21, 33 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Cold, 95, 96 );
			SetResistance( ResistanceType.Poison, 95, 96 );
			SetResistance( ResistanceType.Energy, 20, 45 );

			SetSkill( SkillName.MagicResist, 145.1, 160.0 );
			SetSkill( SkillName.Tactics, 160.1, 190.0 );
			SetSkill( SkillName.Wrestling, 145.1, 170.0 );

			Fame = -8500;
			Karma = -8500;

			VirtualArmor = 80;

			//if( Utility.RandomDouble() <= 0.10 ) PackItem( new PileOfGlacialSnow() );
            PackItem ( new Gold (500, 800)); 

			Tamable = false;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		//public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		//public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public RabidPolarBear1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}