using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Atlantis Whale Serpent corpse" )]
	public class AtlantisWhaleSerpent : BaseCreature
	{
		[Constructable]
		public AtlantisWhaleSerpent() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Atlantis Whale Serpent";
			Body = 150;
			BaseSoundID = 447;
                                                Hue = 2990;

			SetStr( 260 );
			SetDex( 250 );
			SetInt( 280 );

			SetHits( 1500 );
			SetMana( 190 );

			SetDamage( 20, 35 );


			SetDamageType( ResistanceType.Physical, 180 );

			SetResistance( ResistanceType.Physical, 240 );

			SetSkill( SkillName.MagicResist, 220.20 );
			SetSkill( SkillName.Tactics, 190.50 );
			SetSkill( SkillName.Wrestling, 190.50 );

			Fame = 2000;
			Karma = 0;

			VirtualArmor = 75;

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
						case 4: AddToBackpack( new AtlantisShieldOfTheWhaleBelly() ); break;
                        case 5: AddToBackpack( new SwallowedPirateCutlass() ); break;
                        case 6: AddToBackpack( new SwallowedPirateMaul() ); break;
						case 7: AddToBackpack( new SwallowedPirateAxe() ); break;
						case 8: AddToBackpack( new SerpentsMedallion() ); break;
			
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

		public AtlantisWhaleSerpent(Serial serial) : base(serial)
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