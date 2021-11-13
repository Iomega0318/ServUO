using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisSeaHunter : BaseCreature
	{ 
		[Constructable] 
		public AtlantisSeaHunter() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Kai,";
			Title = "The Atlantis Sea Hunter";
			Hue = 1285;
			Body = 400;
                                                Female = false;

			SetStr( 280);
			SetDex( 250 );
			SetInt( 280 );

			SetHits( 1300 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 90 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 160 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 125 );

			SetSkill( SkillName.Anatomy, 230.0 );
			SetSkill( SkillName.Fencing, 180.0 );
			SetSkill( SkillName.Parry, 180.0 );
			SetSkill( SkillName.MagicResist, 140.0 );
			SetSkill( SkillName.Tactics, 240.0 );

			Fame = 5000;
			Karma = -1000;

			VirtualArmor = 75;
			CanSwim = true;
			CantWalk = false;
                                                 new AtlanteanSeaHorseEthereal().Rider = this;

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

			Item PonyTail = new Item( 8253 );
			PonyTail.Hue = 87;
			PonyTail.Layer = Layer.Hair;
			PonyTail.LootType = LootType.Blessed;
			AddItem( PonyTail );

                        Item ThighBoots = new Item( 5905 );
			ThighBoots.Hue = 2223;
			ThighBoots.Layer = Layer.Shoes;
			ThighBoots.LootType = LootType.Blessed;
			AddItem( ThighBoots );

                                                AddItem( new Pike() );
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.98 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 4 )) //number of alternatives
			{
                        case 0: AddToBackpack( new AtlanteanFishingPole() ); break;
                        case 1: AddToBackpack( new MermaidsTail() ); break;
                        case 2: AddToBackpack( new SpecialFishingNet() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisSeaHunter( Serial serial ) : base( serial )
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
