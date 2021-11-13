using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class SkywardElementWizard: BaseCreature
	{ 
		[Constructable] 
		public SkywardElementWizard() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "SkyStorm";
			Title = "Earth, Wind, Fire, Sky, Water";
			Hue = 196;
			Body = 401;
                                                Female = true;

			SetStr( 250);
			SetDex( 180 );
			SetInt( 220 );

			SetHits( 1200 );

			SetDamage( 22, 30 );

			SetMana( 370 );

            SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 120 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 5, 15 );
			SetResistance( ResistanceType.Cold, 200, 300 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 200, 300 );

			SetSkill( SkillName.EvalInt, 120.1, 150.0 );
			SetSkill( SkillName.Magery, 200.0 );
			SetSkill( SkillName.MagicResist, 260.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 200.1 );
			SetSkill( SkillName.Macing, 110.0, 150.0 );

			Fame = 2000;
			Karma = -2000;

			VirtualArmor = 65;
			CanSwim = false;
			CantWalk = false;

			Item PlainDress = new Item( 7937 );
			PlainDress.Hue = 1282;
			PlainDress.Layer = Layer.OuterTorso;
			PlainDress.LootType = LootType.Blessed;
			AddItem( PlainDress );

			Item LongHair = new Item( 8252 );
			LongHair.Hue = 672;
			LongHair.Layer = Layer.Hair;
			LongHair.LootType = LootType.Blessed;
			AddItem( LongHair );

            Item Sandals = new Item( 5901 );
			Sandals.Hue = 1282;
			Sandals.Layer = Layer.Shoes;
			Sandals.LootType = LootType.Blessed;
			AddItem( Sandals );


			SkywardReachSquallPendant necklace = new SkywardReachSquallPendant();
			necklace.Movable = false;
            AddItem( necklace );

			SkywardReachFlight cloak = new SkywardReachFlight();
			cloak.Movable = false;
            AddItem( cloak );

			StaffOfPower weapon = new StaffOfPower();
			weapon.Movable = false;
            AddItem( weapon );


                                                
                                               Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.45 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 7 )) //number of alternatives
			{
                        case 0: AddToBackpack( new  SkywardReachFlight() ); break;
                        case 1: AddToBackpack( new StaffOfPower() ); break;
                        case 2: AddToBackpack( new SkywardReachWovenClawGown() ); break;
	                    case 3: AddToBackpack( new SkywardReachSquallPendant() ); break;
                        case 4: AddToBackpack( new StaffOfPower() ); break;
						case 5:	AddToBackpack( new SkywardReachDreamCapture3() ); break;


			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return true; } }

		public SkywardElementWizard( Serial serial ) : base( serial )
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
