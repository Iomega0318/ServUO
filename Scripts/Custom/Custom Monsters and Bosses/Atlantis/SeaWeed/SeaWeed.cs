using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "seaweed" )]
	public class SeaWeed : BaseCreature
	{
		[Constructable]
		public SeaWeed() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Sea Weed";
			Body = 8;
			Hue = 2635;
			BaseSoundID = 352;

			SetStr( 50, 100 );
			SetDex( 56, 60 );
			SetInt( 16, 20 );

			SetMana( 100 );

			SetDamage( 7, 15 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 45, 65 );
			SetResistance( ResistanceType.Fire, 0, 0 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 75, 95 );
			SetResistance( ResistanceType.Energy, 0, 0 );

			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 1000;
			Karma = -1000;

			VirtualArmor = 45;

			//PackReg( 3 );
			PackItem( new FertileDirt( Utility.RandomMinMax( 5, 25 ) ) );

			//if ( 0.2 >= Utility.RandomDouble() )
				//PackItem( new ExecutionersCap() );

			//PackItem( new Vines() );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public SeaWeed( Serial serial ) : base( serial )
		{
		}


                public override void OnDeath( Container c )
		{
			base.OnDeath( c );	
			
			
			switch ( Utility.Random( 4 ) )
			{
				case 0: c.DropItem( new AtlantisFloweringVine1() ); break;
				case 1: c.DropItem( new AtlantisFloweringVine2() ); break;
				case 2: c.DropItem( new AtlantisFloweringVine3() ); break;
                                case 3: c.DropItem( new AtlantisFloweringVine4() ); break;
			}
			
			//if ( Utility.RandomDouble() < 0.5 )				
				//c.DropItem( new GardenFlower() );
			
			//if ( Utility.RandomDouble() < 0.1 )
				//c.DropItem( new Seed() );
				
			//if ( Utility.RandomDouble() < 0.05 )
				//c.DropItem( new ArchersSinch() );
				
			//if ( Utility.RandomDouble() < 0.05 )
				//c.DropItem( new SinchoftheMagi() );
				
			
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