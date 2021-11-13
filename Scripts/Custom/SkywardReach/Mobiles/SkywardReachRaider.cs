using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class SkywardReachRaider : BaseCreature
	{ 
		[Constructable] 
		public SkywardReachRaider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Skyward Reach Raider";
		
			Hue = 566;
			Body = 401;
                                                Female = true;

			SetStr( 290);
			SetDex( 200 );
			SetInt( 200 );

			SetHits( 1200 );
			
			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 110 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 115 );
			
			SetResistance( ResistanceType.Cold, 220 );
			SetResistance( ResistanceType.Poison, 0, 60 );
			SetResistance( ResistanceType.Energy, 320 );

			
			SetSkill( SkillName.MagicResist, 130 );
			SetSkill( SkillName.Tactics, 115, 130 );
			SetSkill( SkillName.Wrestling, 240 );
			SetSkill( SkillName.Anatomy, 250 );
			SetSkill( SkillName.Swords, 250 );
			SetSkill( SkillName.Parry, 200  );;

			Fame = 2000;
			Karma = -1000;

                        VirtualArmor = 65;
			
			CanSwim = false;
			CantWalk = false;

			Item Shirt = new Item( 5399 );
			Shirt.Hue = 1369;
			Shirt.Layer = Layer.InnerTorso;
			Shirt.LootType = LootType.Blessed;
			AddItem( Shirt );
			
			Item ShortPants = new Item( 5422 );
			ShortPants.Hue = 1108;
			ShortPants.Layer = Layer.Shirt;
			ShortPants.LootType = LootType.Blessed;
			AddItem( ShortPants );

			Item TwoPigTails = new Item( 8265 );
			TwoPigTails.Hue = 87;
			TwoPigTails.Layer = Layer.Hair;
			TwoPigTails.LootType = LootType.Blessed;
			AddItem( TwoPigTails );

                                                Item Shoes = new Item( 5903 );
			Shoes.Hue = 1369;
			Shoes.Layer = Layer.Shoes;
			Shoes.LootType = LootType.Blessed;
			AddItem( Shoes );

			SkywardReachProtectionShield shield = new SkywardReachProtectionShield();
			shield.Movable = false;
            AddItem( shield );

			SkywardReachSlasher weapon = new SkywardReachSlasher();
			weapon.Movable = false;
            AddItem( weapon );

			SkywardReachWingedHelm helmet = new SkywardReachWingedHelm();
			helmet.Movable = false;
            AddItem( helmet );

			SkywardReachFeatheredCloak cloak = new SkywardReachFeatheredCloak();
			cloak.Movable = false;
            AddItem( cloak );

                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.45 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 10 )) //number of alternatives
			{
                        case 0: AddToBackpack( new SkywardReachBabyDragonFlower() ); break;
                        case 1: AddToBackpack( new SkywardReachPoisonHides() ); break;
                        case 2: AddToBackpack( new SkywardReachEnergyHides() ); break;
						case 3: AddToBackpack( new SkywardReachProtectionShield() ); break;
						case 4: AddToBackpack( new SkywardReachWingedHelm() ); break;
						case 5: AddToBackpack( new NightSkyBedAddonDeed() ); break;
						case 6: AddToBackpack( new SkywardReachSlasher() ); break;
				        case 7: AddToBackpack( new SkywardReachFeatheredCloak() ); break;
						case 8:	AddToBackpack( new SkywardReachDreamCapture2() ); break;
						
                        
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public SkywardReachRaider( Serial serial ) : base( serial )
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
