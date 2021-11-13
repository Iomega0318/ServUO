using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class AtlantisPrincess : BaseCreature
	{ 
		[Constructable] 
		public AtlantisPrincess() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
			Name = "Elite Luna,";
			Title = "The Atlantis Princess";
			Hue = 196;
			Body = 401;
                                                Female = true;

			SetStr( 310 );
			SetDex( 230 );
			SetInt( 280 );

			SetHits( 3000 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 75 );

			SetResistance( ResistanceType.Physical, 80 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 220 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 220 );

			SetSkill( SkillName.Anatomy, 160.0 );
			SetSkill( SkillName.Fencing, 120.0 );
			SetSkill( SkillName.Parry, 180.0 );
			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 150.0 );

			Fame = 8000;
			Karma = -3000;

			VirtualArmor = 75;
			CanSwim = true;
			CantWalk = false;

			Item Kamishimo = new Item( 7172 );
			Kamishimo.Hue = 87;
			Kamishimo.Layer = Layer.OuterTorso;
			Kamishimo.LootType = LootType.Blessed;
			AddItem( Kamishimo );
			
			Item LongHair = new Item( 8252 );
			LongHair.Hue = 2474;
			LongHair.Layer = Layer.Hair;
			LongHair.LootType = LootType.Blessed;
			AddItem( LongHair );

			Item TribalMask = new Item( 5440 );
			TribalMask.Hue = 2524;
			TribalMask.Name = "AtlantisCrown";
			TribalMask.Layer = Layer.Helm;
			TribalMask.LootType = LootType.Regular;
			AddItem( TribalMask );


			Item SilverNecklace = new Item( 7944 );
			SilverNecklace.Hue = 2524;
			SilverNecklace.Layer = Layer.Neck;
			SilverNecklace.LootType = LootType.Blessed;
			AddItem( SilverNecklace );

			
                                                AddItem( new WarFork() );
                                                
                                                Container pack = new Backpack();

                        PackItem( new Gold( 1000, 2000 ) );
                                                if ( 0.98 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 7 )) //number of alternatives
			{
                        case 0: AddToBackpack( new PrincessLunasNecklace() ); break;
                        case 1: AddToBackpack( new SerpentsSkinSandalsOfAtlantis() ); break;
                        case 2: AddToBackpack( new PearlRingOfAtlantis() ); break;
						case 3: AddToBackpack( new AtlantisTreasure() ); break;
						case 4: AddToBackpack( new AtlantisCloak() ); break;
						case 5: AddToBackpack( new AtlantisStatue() ); break;
						case 6: AddToBackpack( new AtlantisBanner() ); break;
			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                                public override bool IsScaryToPets{ get{ return false; } }

		public AtlantisPrincess( Serial serial ) : base( serial )
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
