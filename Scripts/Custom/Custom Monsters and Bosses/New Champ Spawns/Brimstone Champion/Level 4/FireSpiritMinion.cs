using System.Collections.Generic;
namespace Server.Mobiles
{
	[CorpseName( "a smoldering corpse" )]
	public class FireSpiritMinion : BaseCreature
	{        
		[Constructable]
		public FireSpiritMinion() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = " A FireSpirit Minion";
			Body = 128;
			BaseSoundID = 0x467;
		    Hue = 2519;

			SetStr( 1000, 2000 );
			SetDex( 500, 800 );
			SetInt( 350, 550 );

			SetHits( 2500, 3000 );

			SetDamage( 40, 65 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.Magery, 60.1, 70.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 80.1, 90.5 );

			Fame = 20000;

			VirtualArmor = 60;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override HideType HideType { get { return HideType.Regular; } }

		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public FireSpiritMinion( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}