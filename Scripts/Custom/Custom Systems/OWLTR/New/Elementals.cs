/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/
using Server.Items;
using daat99;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class Elementals : BaseCreature
	{
		private int i_Resource, i_Multiple;
		private bool b_Tinker = false;

		public Elementals(int Resource) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			i_Resource = Resource;
			
			if (i_Resource >= 301)
			{
				Name = "a wood elemental";
				Body = 301;
				i_Multiple = i_Resource - 300;
			}
			else if (i_Resource >= 101)
			{
				Name = "a leather elemental";
				Body = 101;
				i_Multiple = i_Resource - 99;
			}
			else 
				i_Multiple = i_Resource - 1;

			BaseSoundID = 268;
			 
			switch (i_Resource)
			{
				case 1: default: Name = "an ore elemental"; Body = 14; break;
				case 2: Name = "a dull copper ore elemental"; Hue = 0x973; Body = 110; break;
				case 3: Name = "a shadow iron ore elemental"; Hue = 0x966; Body = 111; break;
				case 4: Name = "a copper ore elemental"; Hue = 0x96D; Body = 109; break;
				case 5: Name = "a bronze ore elemental"; Hue = 0x972; Body = 108; break;
				case 6: Name = "a gold ore elemental"; Hue = 0x8A5; Body = 166; break;
				case 7: Name = "an agapite ore elemental"; Hue = 0x979; Body = 107; break;
				case 8: Name = "a verite ore elemental"; Hue = 0x89F; Body = 113; break;
				case 9: Name = "a valorite ore elemental"; Hue = 0x8AB; Body = 112; break;
				case 10: Name = "a blaze ore elemental"; Hue = 1161; Body = 113; break;
				case 11: Name = "an ice ore elemental"; Hue = 1152; Body = 161; break;
				case 12: Name = "a toxic ore elemental"; Hue = 1272; Body = 111; break;
				case 13: Name = "an electrum ore elemental"; Hue = 1278; Body = 112; break;
				case 14: Name = "a platinum ore elemental"; Hue = 1153; Body = 108; break;
				
				case 15: Name = "a stone colossus";  Body = 0x33D; break;
				case 16: Name = "a dull copper colossus"; Hue = 0x973; Body = 0x33D; break;
				case 17: Name = "a shadow iron colossus"; Hue = 0x966; Body = 0x33D; break;
				case 18: Name = "a copper colossus"; Hue = 0x96D; Body = 0x33D; break;
				case 19: Name = "a bronze colossus"; Hue = 0x972; Body = 0x33D; break;
				case 20: Name = "a gold colossus"; Hue = 0x8A5; Body = 0x33D; break;
				case 21: Name = "an agapite colossus"; Hue = 0x979; Body = 0x33D; break;
				case 22: Name = "a verite colossus"; Hue = 0x89F; Body = 0x33D; break;
				case 23: Name = "a valorite colossus"; Hue = 0x8AB; Body = 0x33D; break;
				case 24: Name = "a blaze colossus"; Hue = 1161; Body = 0x33D; break;
				case 25: Name = "an ice colossus"; Hue = 1152; Body = 0x33D; break;
				case 26: Name = "a toxic colossus"; Hue = 1272; Body = 0x33D; break;
				case 27: Name = "an electrum colossus"; Hue = 1278; Body = 0x33D; break;
				case 28: Name = "a platinum colossus"; Hue = 1153; Body = 0x33D; break;
				
				case 101: Name = "a leather elemental"; break;
				case 102: Name = "a spined leather elemental"; Hue = 0x8ac; break;
				case 103: Name = "a horned leather elemental"; Hue = 0x845; break;
				case 104: Name = "a barbed leather elemental"; Hue = 0x1C1; break;
				case 105: Name = "a polar leather elemental"; Hue = 1150; break;
				case 106: Name = "a synthetic leather elemental"; Hue = 1023; break;
				case 107: Name = "a blaze leather elemental"; Hue = 1260; break;
				case 108: Name = "a daemonic leather elemental"; Hue = 32; break;
				case 109: Name = "a shadow leather elemental"; Hue = 0x966; break;
				case 110: Name = "a frost leather elemental"; Hue = 93; break;
				case 111: Name = "an ethereal leather elemental"; Hue = 1159; break;
				
				case 301: Name = "a Wood elemental"; break;
                case 302: Name = "an Oak wood elemental"; Hue = 1281; break;
                case 303: Name = "an Ash wood elemental"; Hue = 488; break;
                case 304: Name = "a Yew wood elemental"; Hue = 2313; break;
				case 305: Name = "a Heartwood wood elemental"; Hue = 1262; break;
				case 306: Name = "a Bloodwood wood elemental"; Hue = 1194; break;
				case 307: Name = "a Frostwood wood elemental"; Hue = 1266; break;
				case 308: Name = "an ebony wood elemental"; Hue = 1457; break;
				case 309: Name = "a bamboo wood elemental"; Hue = 1719; break;
				case 310: Name = "a purple heart wood elemental"; Hue = 114; break;
				case 311: Name = "a redwood wood elemental"; Hue = 37; break;
				case 312: Name = "a petrified wood elemental"; Hue = 1153; break;
			}
			
			SetStr( 150 + (i_Multiple*10), 200 + (i_Multiple*10) );
			SetDex( 100 + (i_Multiple*10), 120 + (i_Multiple*10) );
			SetInt( 50 + (i_Multiple*10), 60 + (i_Multiple*10) );

			SetHits( 100 + (i_Multiple*10), 120 + (i_Multiple*10) );

			SetDamage( 5 + (i_Multiple*5), 10 + (i_Multiple*5) );

			SetDamageType( ResistanceType.Physical, 10 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Poison, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Fire, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Cold, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Energy, 5 + (i_Multiple*5) );

			SetResistance( ResistanceType.Physical, 10 + (i_Multiple*5), 20 + (i_Multiple*5) );
			SetResistance( ResistanceType.Fire, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Cold, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Poison, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Energy, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );

			SetSkill( SkillName.MagicResist, 10.0 + (i_Multiple*5) );
			SetSkill( SkillName.Tactics, 50.0 + (i_Multiple*5) );
			SetSkill( SkillName.Wrestling, 50.0 + (i_Multiple*5) );

			Fame = 500 + (i_Multiple*500);
			Karma = -500 - (i_Multiple*500);

			VirtualArmor = 5 + (i_Multiple*5);
			
			//PackMagicItems( 0 + (i_Multiple*1), 1 + (i_Multiple*5) );

			if ( OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT) )
					PackItem( new ResourceRecipe() );

			if ( i_Resource >= 1 && i_Resource < 101 )
			{
				if ( !Core.AOS && !OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.CRAFT_RUNIC_JEWELRY) && Utility.Random(10) == 1 )
					b_Tinker = true;
				else if (Utility.Random(4) == 1)
					b_Tinker = true;
			}

			switch (i_Resource)
			{
				case 1: { PackItem( new IronOre( 25 )); break; }
				case 2: { if (b_Tinker == true) PackItem( new DullCopperRunicTinkerTools( 5 ) ); else PackItem( new DullCopperRunicHammer( 5 )); PackItem( new DullCopperOre( 25 )); break; }
				case 3: { if (b_Tinker == true) PackItem( new ShadowIronRunicTinkerTools( 5 ) ); else PackItem( new ShadowIronRunicHammer( 5 )); PackItem( new ShadowIronOre( 25 )); break; }
				case 4: { if (b_Tinker == true) PackItem( new CopperRunicTinkerTools( 5 ) ); else PackItem( new CopperRunicHammer( 5 )); PackItem( new CopperOre( 25 )); break; }
				case 5: { if (b_Tinker == true) PackItem( new BronzeRunicTinkerTools( 5 ) ); else PackItem( new BronzeRunicHammer( 5 )); PackItem( new BronzeOre( 25 )); break; }
				case 6: { if (b_Tinker == true) PackItem( new GoldRunicTinkerTools( 5 ) ); else PackItem( new GoldRunicHammer( 5 )); PackItem( new GoldOre( 25 )); break; }
				case 7: { if (b_Tinker == true) PackItem( new AgapiteRunicTinkerTools( 5 ) ); else PackItem( new AgapiteRunicHammer( 5 )); PackItem( new AgapiteOre( 25 )); break; }
				case 8: { if (b_Tinker == true) PackItem( new VeriteRunicTinkerTools( 5 ) ); else PackItem( new VeriteRunicHammer( 5 )); PackItem( new VeriteOre( 25 )); break; }
				case 9: { if (b_Tinker == true) PackItem( new ValoriteRunicTinkerTools( 5 ) ); else PackItem( new ValoriteRunicHammer( 5 )); PackItem( new ValoriteOre( 25 )); break; }
				case 10: { if (b_Tinker == true) PackItem( new BlazeRunicTinkerTools( 5 ) ); else PackItem( new BlazeRunicHammer( 5 )); PackItem( new BlazeOre( 25 )); break; }
				case 11: { if (b_Tinker == true) PackItem( new IceRunicTinkerTools( 5 ) ); else PackItem( new IceRunicHammer( 5 )); PackItem( new IceOre( 25 )); break; }
				case 12: { if (b_Tinker == true) PackItem( new ToxicRunicTinkerTools( 5 ) ); else PackItem( new ToxicRunicHammer( 5 )); PackItem( new ToxicOre( 25 )); break; }
				case 13: { if (b_Tinker == true) PackItem( new ElectrumRunicTinkerTools( 5 ) ); else PackItem( new ElectrumRunicHammer( 5 )); PackItem( new ElectrumOre( 25 )); break; }
				case 14: { if (b_Tinker == true) PackItem( new PlatinumRunicTinkerTools( 5 ) ); else PackItem( new PlatinumRunicHammer( 5 )); PackItem( new PlatinumOre( 25 )); break; }
				
				case 15: { PackItem( new Granite( 25 )); break; }
				case 16: { if (b_Tinker == true) PackItem( new DullCopperRunicTinkerTools( 5 ) ); else PackItem( new DullCopperRunicHammer( 5 )); PackItem( new DullCopperGranite( 25 )); break; }
				case 17: { if (b_Tinker == true) PackItem( new ShadowIronRunicTinkerTools( 5 ) ); else PackItem( new ShadowIronRunicHammer( 5 )); PackItem( new ShadowIronGranite( 25 )); break; }
				case 18: { if (b_Tinker == true) PackItem( new CopperRunicTinkerTools( 5 ) ); else PackItem( new CopperRunicHammer( 5 )); PackItem( new CopperGranite( 25 )); break; }
				case 19: { if (b_Tinker == true) PackItem( new BronzeRunicTinkerTools( 5 ) ); else PackItem( new BronzeRunicHammer( 5 )); PackItem( new BronzeGranite( 25 )); break; }
				case 20: { if (b_Tinker == true) PackItem( new GoldRunicTinkerTools( 5 ) ); else PackItem( new GoldRunicHammer( 5 )); PackItem( new GoldGranite( 25 )); break; }
				case 21: { if (b_Tinker == true) PackItem( new AgapiteRunicTinkerTools( 5 ) ); else PackItem( new AgapiteRunicHammer( 5 )); PackItem( new AgapiteGranite( 25 )); break; }
				case 22: { if (b_Tinker == true) PackItem( new VeriteRunicTinkerTools( 5 ) ); else PackItem( new VeriteRunicHammer( 5 )); PackItem( new VeriteGranite( 25 )); break; }
				case 23: { if (b_Tinker == true) PackItem( new ValoriteRunicTinkerTools( 5 ) ); else PackItem( new ValoriteRunicHammer( 5 )); PackItem( new ValoriteGranite( 25 )); break; }
				case 24: { if (b_Tinker == true) PackItem( new BlazeRunicTinkerTools( 5 ) ); else PackItem( new BlazeRunicHammer( 5 )); PackItem( new BlazeGranite( 25 )); break; }
				case 25: { if (b_Tinker == true) PackItem( new IceRunicTinkerTools( 5 ) ); else PackItem( new IceRunicHammer( 5 )); PackItem( new IceGranite( 25 )); break; }
				case 26: { if (b_Tinker == true) PackItem( new ToxicRunicTinkerTools( 5 ) ); else PackItem( new ToxicRunicHammer( 5 )); PackItem( new ToxicGranite( 25 )); break; }
				case 27: { if (b_Tinker == true) PackItem( new ElectrumRunicTinkerTools( 5 ) ); else PackItem( new ElectrumRunicHammer( 5 )); PackItem( new ElectrumGranite( 25 )); break; }
				case 28: { if (b_Tinker == true) PackItem( new PlatinumRunicTinkerTools( 5 ) ); else PackItem( new PlatinumRunicHammer( 5 )); PackItem( new PlatinumGranite( 25 )); break; }
				
				case 102: { PackItem( new SpinedRunicSewingKit( 5 )); break; }
				case 103: { PackItem( new HornedRunicSewingKit( 5 )); break; }
				case 104: { PackItem( new BarbedRunicSewingKit( 5 )); break; }
				case 105: { PackItem( new PolarRunicSewingKit( 5 )); break; }
				case 106: { PackItem( new SyntheticRunicSewingKit( 5 )); break; }
				case 107: { PackItem( new BlazeRunicSewingKit( 5 )); break; }
				case 108: { PackItem( new DaemonicRunicSewingKit( 5 )); break; }
				case 109: { PackItem( new ShadowRunicSewingKit( 5 )); break; }
				case 110: { PackItem( new FrostRunicSewingKit( 5 )); break; }
				case 111: { PackItem( new EtherealRunicSewingKit( 5 )); break; }
				
				case 301: { PackItem( new Log( 50 )); break; }
                case 302: { PackItem( new OakRunicFletcherTools( 5));  PackItem(new OakLog(50)); break; }
                case 303: { PackItem( new AshRunicFletcherTools( 5));  PackItem(new AshLog(50)); break; }
                case 304: { PackItem( new YewRunicFletcherTools( 5));  PackItem(new YewLog(50)); break; }
				case 305: { PackItem( new HeartwoodRunicFletcherTools( 5 ));  PackItem( new HeartwoodLog( 50 )); break; }
				case 306: { PackItem( new BloodwoodRunicFletcherTools( 5 ));  PackItem( new BloodwoodLog( 50 )); break; }
				case 307: { PackItem( new FrostwoodRunicFletcherTools( 5 ));  PackItem( new FrostwoodLog( 50 )); break; }
				case 308: { PackItem( new EbonyRunicFletcherTools( 5 ));  PackItem( new EbonyLog( 50 )); break; }
				case 309: { PackItem( new BambooRunicFletcherTools( 5 ));  PackItem( new BambooLog( 50 )); break; }
				case 310: { PackItem( new PurpleHeartRunicFletcherTools( 5 ));  PackItem( new PurpleHeartLog( 50 )); break; }
				case 311: { PackItem( new RedwoodRunicFletcherTools( 5 ));  PackItem( new RedwoodLog( 50 )); break; }
				case 312: { PackItem( new PetrifiedRunicFletcherTools( 5 ));  PackItem( new PetrifiedLog( 50 )); break; }
			}
		}

		public override int Hides{ get{ if (i_Resource >= 101 && i_Resource < 201) return 50; else return 0; } }

		public override HideType HideType
		{ 
			get
			{ 
				switch (i_Resource)
				{
					case 102: { return HideType.Spined; }
					case 103: { return HideType.Horned; }
					case 104: { return HideType.Barbed; }
					case 105: { return HideType.Polar; }
					case 106: { return HideType.Synthetic; }
					case 107: { return HideType.BlazeL; }
					case 108: { return HideType.Daemonic; }
					case 109: { return HideType.Shadow; }
					case 110: { return HideType.Frost; }
					case 111: { return HideType.Ethereal; }
					default: { return HideType.Regular; }
				}
			} 
		}

		public override int Scales{ get{ if (i_Resource >= 101 && i_Resource < 201) return 50; else return 0; } }

		public override ScaleType ScaleType
		{ 
			get
			{ 
				switch (i_Resource)
				{
					case 103: case 104: { return ScaleType.Yellow; }
					case 105: { return ScaleType.Black; }
					case 106: { return ScaleType.Green; }
					case 107: { return ScaleType.White; }
					case 108: { return ScaleType.Blue; }
					case 109: { return ScaleType.Copper; }
					case 110: { return ScaleType.Silver; }
					case 111: { return ScaleType.Gold; }
					default: { return ScaleType.Red; }
				}
			} 
		}
		
		public override bool AutoDispel{ get{ return true; } }

		public Elementals( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}