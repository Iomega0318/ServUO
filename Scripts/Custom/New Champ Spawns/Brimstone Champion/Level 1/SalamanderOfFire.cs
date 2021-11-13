using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a salamander corpse" )]
	public class SalamanderOfFire : BaseCreature
	{
		[Constructable]
		public SalamanderOfFire() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Salamander Of Fire";
			Body = 0xCE;
			Hue = 1922;

			SetStr( 150 );
			SetDex( 2000 );
			SetInt( 1000 );

			SetHits( 200, 250 );
			SetStam( 500 );
			SetMana( 0 );

			SetDamage( 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 5.0 );
			SetSkill( SkillName.Wrestling, 5.0 );

			Fame = 1000;
			Karma = 0;

			VirtualArmor = 4;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich, 2 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );	
			
			c.DropItem( new Gold(150) );
		}
		
		public override int Meat{ get{ return 11; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }

		public SalamanderOfFire( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound()
		{
			return 0xC9;
		}

		public override int GetHurtSound()
		{
			return 0xCA;
		}

		public override int GetDeathSound()
		{
			return 0xCB;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}