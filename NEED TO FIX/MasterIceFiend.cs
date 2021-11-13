using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an master ice fiend corpse" )]
	public class MasterIceFiend : AuraCreature
	{
		[Constructable]
		public MasterIceFiend () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			AuraMessage = "The intense cold is damaging you!"; // TODO Cliloc support: 1008111
			AuraType = ResistanceType.Cold;
			MinAuraDelay = 5;
			MaxAuraDelay = 15;
			MinAuraDamage = 15;
			MaxAuraDamage = 25;
			AuraRange = 2;

			Name = "an master ice fiend";
			Body = 43;
			BaseSoundID = 357;
            Hue = 1151;

			SetStr( 1176, 1405 );
			SetDex( 376, 995 );
			SetInt( 301, 925 );

			SetHits( 2426, 7543 );

			SetDamage( 11, 29 );

			SetSkill( SkillName.EvalInt, 80.1, 120.0 );
			SetSkill( SkillName.Magery, 80.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 110.0 );
			SetSkill( SkillName.Wrestling, 80.1, 120.0 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 10, 40 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls, 2 );
            PackItem(new MasterCoin(5));
		}

        public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public MasterIceFiend( Serial serial ) : base( serial )
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