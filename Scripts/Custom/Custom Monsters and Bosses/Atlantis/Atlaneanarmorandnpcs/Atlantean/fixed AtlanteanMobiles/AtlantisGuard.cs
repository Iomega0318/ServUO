using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisGuard : BaseCreature
	{ 
		[Constructable] 
		public AtlantisGuard() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
            Name = "Atlantis Guard";
			
			Hue = 1285;
			Body = 400;
                                                Female = false;

			SetStr( 380);
			SetDex( 320 );
			SetInt( 320 );

			SetHits( 1900 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 120 );
			SetDamageType( ResistanceType.Poison, 100 );

			SetResistance( ResistanceType.Physical, 125 );
			SetResistance( ResistanceType.Fire, 0, 0 );
			SetResistance( ResistanceType.Cold, 200 );
			SetResistance( ResistanceType.Poison, 60, 100 );
			SetResistance( ResistanceType.Energy, 180 );

			SetSkill( SkillName.Poisoning, 60.1, 120.0 );
			SetSkill( SkillName.MagicResist, 180.0 );
			SetSkill( SkillName.Tactics, 230.0 );
			SetSkill( SkillName.Wrestling, 240.0 );
			SetSkill( SkillName.Anatomy, 240.0 );
			SetSkill( SkillName.Swords, 240.0 );
			SetSkill( SkillName.Parry, 240.0  );;

			Fame = 1000;
			Karma = -800;

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
			switch ( Utility.Random( 4 )) //number of alternatives
			{
                        //case 0: AddToBackpack( new Triton() ); break;
                        case 0: AddToBackpack( new ScaledLegsOfAtlantis() ); break;
						case 1: AddToBackpack( new EnchantedBeads() ); break;
						case 2: AddToBackpack( new EnchantedSeaRoseStatuette() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisGuard( Serial serial ) : base( serial )
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
