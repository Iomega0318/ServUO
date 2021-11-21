using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Burning Ember spider corpse" )]
	public class BurningEmberSpider : BaseCreature
	{

		[Constructable]
		public BurningEmberSpider () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.15, 0.2 )
		{           
            Body = 173;
			BaseSoundID = 362;
            Hue = 1922;
            Name = " Burning Ember Spider";

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType(ResistanceType.Energy, 50);

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 25, 45 );
			SetResistance( ResistanceType.Poison, 40, 50 );
            SetResistance(ResistanceType.Energy, 80, 90);

			SetSkill( SkillName.EvalInt, 89.1, 97.0 );
			SetSkill( SkillName.Magery, 89.1, 98.0 );
			SetSkill( SkillName.MagicResist, 84.1, 94.0 );
			SetSkill( SkillName.Tactics, 87.6, 92.0 );
			SetSkill( SkillName.Wrestling, 83.1, 90.1);



			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 65;

			Tamable = false;
			
			AddLoot( LootPack.FilthyRich, 2 );
            PackItem(new Gold(250, 400));
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 19; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		
		public BurningEmberSpider( Serial serial ) : base( serial )
		{
		}
        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble())
            {
                SendExplosion(attacker);
            }
        }

        public void SendExplosion(Mobile to)
        {
            
            this.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
            to.PlaySound(0x307);
            this.DoHarmful(to);
            AOS.Damage(to, this, 50, 0, 0, 0, 0, 100);
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