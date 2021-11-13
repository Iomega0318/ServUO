using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisNoble : BaseCreature
	{ 
		[Constructable] 
		public AtlantisNoble() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Sir Kerris,";
			Title = "An Atlantis Noble";
			Hue = 1285;
			Body = 400;
                                                Female = false;

			SetStr( 210);
			SetDex( 280 );
			SetInt( 210 );

			SetHits( 1200 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 190 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 190 );

			SetSkill( SkillName.Anatomy, 250.0 );
			SetSkill( SkillName.Archery, 200.0 );
			SetSkill( SkillName.Fencing, 120.0 );
			SetSkill( SkillName.MagicResist, 130.0 );
			SetSkill( SkillName.Tactics, 220.0 );

			Fame = 1000;
			Karma = -1000;

                        VirtualArmor = 75;
			CanSwim = true;
			CantWalk = false;
                                                 new AtlanteanSeaHorseEthereal().Rider = this;

			Item LeatherChest = new Item( 5068 );
			LeatherChest.Hue = 87;
			LeatherChest.Layer = Layer.InnerTorso;
			LeatherChest.LootType = LootType.Blessed;
			AddItem( LeatherChest );

			Item ShortHair = new Item( 8251 );
			ShortHair.Hue = 87;
			ShortHair.Layer = Layer.Hair;
			ShortHair.LootType = LootType.Blessed;
			AddItem( ShortHair );

                        Item Vandyke = new Item( 8269 );
			Vandyke.Hue = 87;
			Vandyke.Layer = Layer.FacialHair;
			Vandyke.LootType = LootType.Blessed;
			AddItem( Vandyke );

                                                Item Sandals = new Item( 5901 );
			Sandals.Hue = 2223;
			Sandals.Layer = Layer.Shoes;
			Sandals.LootType = LootType.Blessed;
			AddItem( Sandals );

			Item PlateLegs = new Item( 5054 );
			PlateLegs.Hue = 87;
			PlateLegs.Layer = Layer.Pants;
			PlateLegs.LootType = LootType.Blessed;
			AddItem( PlateLegs );

			Item Cloak = new Item( 5397 );
			Cloak.Hue = 92;
			Cloak.Layer = Layer.Cloak;
			Cloak.LootType = LootType.Blessed;
			AddItem( Cloak );

                                                AddItem( new Lance() );
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.98 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 3 )) //number of alternatives
			{
                        case 0: AddToBackpack( new ScaledChestOfAtlantis() ); break;
                        case 1: AddToBackpack( new CrownOfAtlantis() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisNoble( Serial serial ) : base( serial )
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
