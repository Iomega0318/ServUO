using System; 
using Server;
using Server.Items; 
using Server.Mobiles; 


namespace Server.Mobiles 
{ 
	public class evilhalloweenbat : BaseCreature 
	{ 
		[Constructable] 
		public evilhalloweenbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Evil Halloween Bat";
			Hue = 1107; 
			Body = 754;
                         

			SetStr( 110 );
			SetDex( 115 );
			SetInt( 100 );

			SetHits( 1200 );
			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Fire, 80 );
			SetDamageType( ResistanceType.Energy, 70 );
			SetDamageType( ResistanceType.Poison, 90 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 90 );
			SetResistance( ResistanceType.Cold, 88 );
			SetResistance( ResistanceType.Poison, 90 );
			SetResistance( ResistanceType.Energy, 90 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 10.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 110.0 );


			Fame = 4000;
			Karma = 1000;

			VirtualArmor = 60;
                                                
            Container pack = new Backpack();
			PackItem( new Gold( 100, 110 ) );
			
			if ( 0.40 > Utility.RandomDouble() ) // 0.30 = 35% = chance to drop 
			switch ( Utility.Random( 5 ))//number of alternatives 
			 { 
			// Armors 
			
				case 0: PackItem( new CandyHalloweenCostumeMask() ); break;
                case 1: PackItem( new CandyHalloweenBoneHarvester() ); break;
                case 2: PackItem( new CandyHalloweenCostume() ); break;
                case 3: PackItem( new CandyHalloweenShoes() ); break;
                case 4: PackItem( new CandyHalloweenCloak() ); break;
				}
		}		
			
	    public override bool AlwaysMurderer{ get{ return true; } }

		public evilhalloweenbat( Serial serial ) : base( serial ) 
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