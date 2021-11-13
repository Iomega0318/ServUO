using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisArcher : BaseCreature
	{ 
		[Constructable] 
		public AtlantisArcher() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Giasa,";
			Title = "Atlantis Archer";
			Hue = 1285;
			Body = 400;
                                                Female = false;

			SetStr( 340);
			SetDex( 250 );
			SetInt( 350 );

			SetHits( 1200 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 90 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 200 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 200 );

			SetSkill( SkillName.Anatomy, 210.0 );
			SetSkill( SkillName.Archery, 320.0 );
			SetSkill( SkillName.Parry, 150.0 );
			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 110.0 );

			Fame = 5000;
			Karma = -100;

			VirtualArmor = 75;
			CanSwim = true;
			CantWalk = false;
            new AtlanteanSeaHorseEthereal().Rider = this;



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
            


			Item Hakama = new Item( 10138 );
			Hakama.Hue = 87;
			Hakama.Layer = Layer.Pants;
			Hakama.LootType = LootType.Blessed;
			AddItem( Hakama );



                                                AddItem( new Yumi() );
			Arrow arrows = new Arrow( 250 );

			arrows.LootType = LootType.Newbied;
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.95 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 3 )) //number of alternatives
			{
                        case 0: AddToBackpack( new ArmsOfAtlantis() ); break;
                        case 1: AddToBackpack( new GlovesOfAtlantis() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisArcher( Serial serial ) : base( serial )
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
