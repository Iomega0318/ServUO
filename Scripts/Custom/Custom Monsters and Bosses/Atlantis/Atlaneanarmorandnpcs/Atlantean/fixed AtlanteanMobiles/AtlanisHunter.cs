using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisHunter : BaseCreature
	{ 
		[Constructable] 
		public AtlantisHunter() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Atlantis Hunter";
		
			Hue = 1285;
			Body = 401;
                                                Female = true;

			SetStr( 290);
			SetDex( 220 );
			SetInt( 250 );

			SetHits( 1500 );
			
			SetDamage( 25, 35 );

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

			Fame = 5000;
			Karma = -500;

                        VirtualArmor = 65;
			CanSwim = true;
			CantWalk = false;

			Item Shirt = new Item( 5399 );
			Shirt.Hue = 87;
			Shirt.Layer = Layer.InnerTorso;
			Shirt.LootType = LootType.Blessed;
			AddItem( Shirt );
			
			Item ShortPants = new Item( 5422 );
			ShortPants.Hue = 87;
			ShortPants.Layer = Layer.Shirt;
			ShortPants.LootType = LootType.Blessed;
			AddItem( ShortPants );

			Item TwoPigTails = new Item( 8265 );
			TwoPigTails.Hue = 87;
			TwoPigTails.Layer = Layer.Hair;
			TwoPigTails.LootType = LootType.Blessed;
			AddItem( TwoPigTails );

                                                Item Sandals = new Item( 5901 );
			Sandals.Hue = 2223;
			Sandals.Layer = Layer.Shoes;
			Sandals.LootType = LootType.Blessed;
			AddItem( Sandals );

                                                AddItem( new AtlanteanFishingPole() );
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.98 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 4 )) //number of alternatives
			{
                        case 0: AddToBackpack( new SerpentsSkinChestOfAtlantis() ); break;
                        case 1: AddToBackpack( new Sextant() ); break;
                        case 2: AddToBackpack( new SpecialFishingNet() ); break;
                        case 3: AddToBackpack( new FishingBracelet() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisHunter( Serial serial ) : base( serial )
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
