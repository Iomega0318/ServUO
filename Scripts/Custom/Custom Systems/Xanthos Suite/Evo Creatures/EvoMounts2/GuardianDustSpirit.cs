
using System; 
using Server;
using Server.Items;
using Server.Mobiles; 

namespace Xanthos.Evo
{ 
	[CorpseName( "an guardian dust spirit corpse" )] 
	public class GuardianDustSpirit : BaseCreature 
	{ 
		[Constructable] 
		public GuardianDustSpirit() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 

			
			Name = "Guardian Dust Spirit";
			//Title = "the Keeper of Evo Dust";
			Body = 970;  
			 
			BaseSoundID = 383;
			Hue = 1150; 

			SetStr( 110, 112 );
			SetDex( 100, 110 );
			SetInt( 100, 120 );

			SetHits( 500, 800 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 60, 80 );
			SetResistance( ResistanceType.Energy, 60, 80 );

			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Magery, 110.0, 112.0 );
			SetSkill( SkillName.Meditation, 110.0, 115.0 );
			SetSkill( SkillName.MagicResist, 115.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.Macing, 120.0, 120.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 75;

			Container pack = new Backpack();
			PackItem( new Gold( 100, 100 ) );
                                                
			if ( 0.50 > Utility.RandomDouble() ) // 0.45 = 55% = chance to drop 
			switch ( Utility.Random( 21 )) //number of alternatives 
			{ 
			// Armors 
			
			
			 
			case 0: AddToBackpack( new NightmareEvoDust() ); break; 
			case 1: AddToBackpack( new HellsteedEvoDust() ); break;
            case 2: AddToBackpack( new RidableLlamaEvoDust()); break;
            case 3: AddToBackpack( new UnicornEvoDust() ); break;
            case 4: AddToBackpack( new KirinEvoDust() ); break;
            case 5: AddToBackpack( new FrenziedOstardEvoDust() ); break;
           // case 6: AddToBackpack( new HiryuEvoDust() ); break;
			case 6: AddToBackpack( new HiryuEvoDust() ); break;
            case 7: AddToBackpack( new RaelisDragonDust()); break;
            case 8: AddToBackpack( new RidablePolarBearEvoDust()); break;
            //case 9: AddToBackpack( new SkywindSquallDust()); break; 
            case 9: AddToBackpack( new CuSidheEvoDust()); break; 
			//case 10: AddToBackpack( new DragonDust(25)); break; 
			//case 11: AddToBackpack( new EvilMageDust(25)); break;
			case 10: AddToBackpack( new SwampDragonEvoDust()); break;
			//case 13: AddToBackpack( new HorseDust(25)); break;
			case 11: AddToBackpack( new AngelDust()); break;
			case 12: AddToBackpack( new DaemonDust()); break;
			case 13: AddToBackpack( new TreeDust()); break;
			case 14: AddToBackpack( new FireDragonDust()); break;
			case 15: AddToBackpack( new IceDragonDust()); break;
			case 16: AddToBackpack( new PoisonDragonDust()); break;
			case 17: AddToBackpack( new ThunderDragonDust()); break;
			case 18: AddToBackpack( new InsectDust()); break;
			case 19: AddToBackpack( new TigerEvoDust()); break;
			case 20: AddToBackpack( new RidableHellHoundEvoDust()); break;
			
			
			
			
			
                      

                	}
		}

		public override bool AlwaysMurderer{ get{ return true; } }

        public GuardianDustSpirit(Serial serial)
            : base(serial) 
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