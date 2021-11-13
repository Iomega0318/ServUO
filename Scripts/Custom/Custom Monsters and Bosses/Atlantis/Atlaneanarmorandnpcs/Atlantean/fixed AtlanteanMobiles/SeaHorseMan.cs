using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "SeaHorse Man corpse" )]
	public class SeaHorseMan : BaseCreature
	{
		[Constructable]
		public SeaHorseMan() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "SeaHorse Man";
			Body = 101;
			BaseSoundID = 377;
                                                Hue = 2995;

			SetStr( 200 );
			SetDex( 125 );
			SetInt( 220 );

			SetHits( 1500 );
			SetMana( 200 );

			SetDamage( 25, 40 );

			

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 95, 105 );

			SetSkill( SkillName.MagicResist, 130.20 );
			SetSkill( SkillName.Tactics, 220.50 );
			SetSkill( SkillName.Wrestling, 220.50 );

			Fame = 1000;
			Karma = -500;

			VirtualArmor = 65;

			Tamable = false;
                      Container pack = new Backpack();
                        PackItem( new Gold( 1000, 2500 ) );                              
                     
        		if ( 0.50 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop 
			switch ( Utility.Random( 9 )) //number of alternatives 
			{ 
			// Armors 
                        case 0: AddToBackpack( new AtlantisShell() ); break;
                        case 1: AddToBackpack( new AtlantisSandDollar() ); break;
                        case 2: AddToBackpack( new AtlantisCoral() ); break;
						case 3: AddToBackpack( new AtlantisSeaLoft() ); break;
						case 4: AddToBackpack( new AtlantisBraceletOfProtection() ); break;
                        case 5: AddToBackpack( new EdibleSeaWeed() ); break;
                        case 6: AddToBackpack( new AtlantisBrazier() ); break;
						case 7: AddToBackpack( new AtlantisSeaTree() ); break;
						case 8: AddToBackpack( new EdibleJellyfish() ); break;;
			
		}

		}

		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 12; } }
		

		public override void OnDoubleClick( Mobile from )
		{
			base.OnDoubleClick( from );

			int random = Utility.Random( 100 );

			if ( random < 5 )
				Tip();
			else if ( random < 20 )
				PlaySound( 120 );
			else if ( random < 40 )
				PlaySound( 121 );
		}

		public void Tip()
		{
			PlaySound( 121 );
			Animate( 8, 0, 3, true, false, 0 );
		}

		public SeaHorseMan(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}