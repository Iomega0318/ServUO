using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisSorceress: BaseCreature
	{ 
		[Constructable] 
		public AtlantisSorceress() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
                        Name = "Trini,";
			Title = "The Atlantis Sorceress";
			Hue = 1285;
			Body = 401;
                                                Female = true;

			SetStr( 150);
			SetDex( 280 );
			SetInt( 280 );

			SetHits( 1200 );

			SetDamage( 30, 38 );

			SetMana( 350 );

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
			Karma = -200;

			VirtualArmor = 75;
			CanSwim = true;
			CantWalk = false;

			Item PlainDress = new Item( 7937 );
			PlainDress.Hue = 87;
			PlainDress.Layer = Layer.OuterTorso;
			PlainDress.LootType = LootType.Blessed;
			AddItem( PlainDress );

			Item LongHair = new Item( 8252 );
			LongHair.Hue = 87;
			LongHair.Layer = Layer.Hair;
			LongHair.LootType = LootType.Blessed;
			AddItem( LongHair );

                                                Item Sandals = new Item( 5901 );
			Sandals.Hue = 2223;
			Sandals.Layer = Layer.Shoes;
			Sandals.LootType = LootType.Blessed;
			AddItem( Sandals );

                                                AddItem( new BlackStaff() );
                                                
                                               Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.98 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 4 )) //number of alternatives
			{
                        case 0: AddToBackpack( new EnchantedSeaRoseStatuette() ); break;
                        case 1: AddToBackpack( new SerpentsMedallion() ); break;
                        case 2: AddToBackpack( new EnchantedBeads() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return true; } }

		public AtlantisSorceress( Serial serial ) : base( serial )
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
