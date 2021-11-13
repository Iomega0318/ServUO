using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rotting corpse" )]
	public class MidZombie : BaseCreature
	{
		[Constructable]
		public MidZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Name = "-Energized Zombie-";
			Body = 0x305;
			BaseSoundID = 471;

			SetStr( 146, 270 );
			SetDex( 131, 150 );
			SetInt( 126, 140 );

			SetHits( 128, 542 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Poison, 5, 40 );

			SetSkill( SkillName.MagicResist, 15.1, 80.0 );
			SetSkill( SkillName.Tactics, 35.1, 90.0 );
			SetSkill( SkillName.Wrestling, 35.1, 90.0 );

			Fame = 600;
			Karma = -600;

			VirtualArmor = 18;
			
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new MasterCoin() ); break;
			}
		}

		public override void GenerateLoot()
		{
            //AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.FilthyRich, 1);
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public MidZombie( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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