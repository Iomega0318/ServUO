using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class SkywardSunBlaze : BaseCreature
	{ 
		[Constructable] 
		public SkywardSunBlaze() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
            Name = "SkyBender";
			Title = "Skyward Sun Blaze";
			Hue = 72;
			Body = 400;
              
			Female = false;

			SetStr( 240);
			SetDex( 200 );
			SetInt( 220 );

			SetHits( 1000 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 90 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 200 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 200 );

			SetSkill( SkillName.Anatomy, 180.0 );
			SetSkill( SkillName.Archery, 280.0 );
			SetSkill( SkillName.Parry, 150.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 110.0 );

			Fame = 5000;
			Karma = -100;

			VirtualArmor = 65;
			CanSwim = false;
			CantWalk = false;
			Hue = 289;
            new  Reptalon().Rider = this;



			Item ShortHair = new Item( 8251 );
			ShortHair.Hue = 1266;
			ShortHair.Layer = Layer.Hair;
			ShortHair.LootType = LootType.Blessed;
			AddItem( ShortHair );

            Item Vandyke = new Item( 8269 );
			Vandyke.Hue = 87;
			Vandyke.Layer = Layer.FacialHair;
			Vandyke.LootType = LootType.Blessed;
			AddItem( Vandyke );
            


			Item LongPants = new Item( 5433 );
			LongPants.Hue = 177;
			LongPants.Layer = Layer.Pants;
			LongPants.LootType = LootType.Blessed;
			AddItem( LongPants );

			Item Cloak = new Item( 1030 );
			Cloak.Hue = 0;
			Cloak.Layer = Layer.Cloak;
			Cloak.LootType = LootType.Blessed;
			AddItem( Cloak );

			SkywardReachFlight cloak = new SkywardReachFlight();
			cloak.Movable = false;
            AddItem( cloak );

			SkywardReachWingedHelm helmet = new SkywardReachWingedHelm();
			helmet.Movable = false;
            AddItem( helmet );

			SkywardReachHailStorm weapon = new SkywardReachHailStorm();
			weapon.Movable = false;
            AddItem( weapon );



			Arrow arrows = new Arrow( 250 );

			arrows.LootType = LootType.Newbied;
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.45 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 8 )) //number of alternatives
			{
                        case 0: AddToBackpack( new SkywardReachHailStorm() ); break;
                        case 1: AddToBackpack( new SkywardReachFireHides() ); break;
						case 2: AddToBackpack( new SkywardReachFlight() ); break;
						case 3: AddToBackpack( new SkywardReachDragonFlower() ); break;
						case 4: AddToBackpack( new SkywardReachWingedHelm() ); break;
                        case 5: AddToBackpack( new SkywardReachBabySongBirdInCage() ); break;
						case 6:	AddToBackpack( new SkywardReachDreamCapture1() ); break;
						
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public SkywardSunBlaze( Serial serial ) : base( serial )
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
