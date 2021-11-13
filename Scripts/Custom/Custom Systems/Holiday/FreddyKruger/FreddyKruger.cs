using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( " a corpse" )] 
	public class FreddyKruger : BaseCreature 
	{ 
		[Constructable] 
		public FreddyKruger() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Freddy Kruger";
			Body = 400;
            Hue = 0;

                     

			SetStr( 481, 705 );
			SetDex( 291, 315 );
			SetInt( 226, 350 );

			SetHits( 2000, 2500 );

			SetDamage(45, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70, 75 );
			SetResistance( ResistanceType.Fire, 80, 85 );
			SetResistance( ResistanceType.Cold, 60, 65 );
			SetResistance( ResistanceType.Poison, 90, 95 );
			SetResistance( ResistanceType.Energy, 80, 85 );

			SetSkill( SkillName.EvalInt, 90.2, 100.0 );
			SetSkill( SkillName.Magery, 120.1, 120.2 );
			SetSkill( SkillName.Meditation, 100.5, 110.0 );
			SetSkill( SkillName.MagicResist, 80.5, 100.0 );
			SetSkill( SkillName.Tactics, 95.0, 100.5 );
			SetSkill( SkillName.Wrestling, 100.3, 110.0 );

			Fame = 0;
			Karma = -10500;

			VirtualArmor = 90;

                        


			LeatherMempo leathermempo = new LeatherMempo();
			leathermempo.Hue = 2117;
            leathermempo.Movable = false;
            AddItem(leathermempo);

			LongPants legs = new LongPants();
			legs.Hue = 1175;
            legs.Movable = false;
			AddItem( legs );

			FingersOfFreddy weapon = new FingersOfFreddy();
			weapon.Movable = false;
            AddItem( weapon );

			Shoes shoes = new Shoes();
			shoes.Hue = 1175;
            shoes.Movable = false;
            AddItem(shoes);

            FeatheredHat featheredhat = new FeatheredHat();
            featheredhat.Hue = 1750;
            featheredhat.Movable = false;
            AddItem(featheredhat);

            FancyShirt fancyshirt = new FancyShirt();
            fancyshirt.Hue = 2263;
            fancyshirt.Movable = false;
            AddItem(fancyshirt);

			

		}

		public override bool CanRummageCorpses{ get{ return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Average );
                      { 
                       if ( 0.50 > Utility.RandomDouble() ) // 0.50 = 55% = chance to drop 
			switch ( Utility.Random( 6 )) //number of alternatives 
			{ 
			// Armors 
			
			
			 
			case 0: AddToBackpack( new FingersOfFreddy() ); break;
            case 1: AddToBackpack(new CoffinClosedEastAddonDeed()); break;
            case 2: AddToBackpack(new CoffinOpenTopAddonDeed()); break;
            case 3: AddToBackpack(new CoffinClosedSouthAddonDeed()); break;
            case 4: AddToBackpack(new CoffinOpenWithSkeletonSouthAddonDeed()); break;
			
			
		}
 }              }

		public FreddyKruger( Serial serial ) : base( serial ) 
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
