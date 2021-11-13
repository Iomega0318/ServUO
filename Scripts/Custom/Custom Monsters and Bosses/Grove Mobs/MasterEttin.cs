using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettins corpse" )]
	public class MasterEttin : BaseCreature
	{
		[Constructable]
		public MasterEttin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a master ettin";
			Body = 18;
			BaseSoundID = 367;
            Hue = 33;

			SetStr( 1036, 1365 );
			SetDex( 560, 750 );
			SetInt( 301, 505 );

			SetHits( 2820, 6990 );

			SetDamage( 13, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 70 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 70 );
			SetResistance( ResistanceType.Energy, 55, 65 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 60.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 38;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
            PackItem(new MasterCoin(5));
		}

		public override bool CanRummageCorpses{ get{ return false; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 4; } }
        public override bool AlwaysMurderer { get { return true; } }

		public MasterEttin( Serial serial ) : base( serial )
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