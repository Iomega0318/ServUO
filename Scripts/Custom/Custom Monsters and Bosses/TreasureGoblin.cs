using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
	public class TreasureGoblin : BaseChampion
	{
		public override ChampionSkullType SkullType{ get{ return ChampionSkullType.Power; } }

		public override Type[] UniqueList{ get{ return new Type[] { typeof( FangOfRactus ) }; } }
		public override Type[] SharedList{ get{ return new Type[] { 	typeof( EmbroideredOakLeafCloak ),
										typeof( DjinnisRing ),
										typeof( DetectiveBoots )/*,
										typeof( GuantletsOfAnger )*/ }; } }
		public override Type[] DecorativeList{ get{ return new Type[] { typeof( SwampTile ), typeof( MonsterStatuette ) }; } }

		public override MonsterStatuetteType[] StatueTypes{ get{ return new MonsterStatuetteType[] { MonsterStatuetteType.Slime }; } }

		[Constructable]
		public TreasureGoblin() : base( AIType.AI_Melee )
		{
			Name = "Treasure Goblin";
			Body = 17;
			BaseSoundID = 0x45A;
			Hue = 2734;
			

			SetStr( 50, 55 );
			SetDex( 52, 58 );
			SetInt( 50, 55 );

			SetHits( 20000 );
			SetStam( 5102, 5300 );

			SetDamage( 2, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 99, 100.0 );
			SetSkill( SkillName.Wrestling, 99, 100.0 );
                        SetSkill( SkillName.Swords, 99, 100 );
                        SetSkill( SkillName.Parry, 99, 100 );
			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 70;

			PackItem( new MandrakeRoot ( 1000 ) );
			PackItem( new BlackPearl ( 1000 ) );
			PackItem( new SpidersSilk ( 1000 ) );
			PackItem( new Garlic ( 1000 ) );
			PackItem( new Ginseng ( 1000 ) );
			PackItem( new SulfurousAsh ( 1000 ) );
            PackItem( new Nightshade ( 1000 ) );
			PackItem( new Bloodmoss ( 1000 ) );
	    }	

			
            
        
		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 5 );
			AddLoot( LootPack.UltraRich, 5 );
			AddLoot( LootPack.UltraRich, 5 );
			AddLoot( LootPack.Gems, 200 );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.Potions );
			
		}

		
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override double AutoDispelChance{ get{ return 1.0; } }
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool Uncalmable{ get{ return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

		public override bool ShowFameTitle{ get{ return false; } }
		public override bool ClickTitle{ get{ return false; } }

		
		
			


		public TreasureGoblin( Serial serial ) : base( serial )
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