using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a enchanted dragon corpse" )]
	public class EnchantedDragon : BaseCreature
	{
		[Constructable]
		public EnchantedDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Enchanted Dragon ";
			Body = 0xC5;
			BaseSoundID = 362;
            Hue = 0;

            SetStr( 900, 975 );
			SetDex( 120, 150 );
			SetInt( 565, 625 );

			SetHits( 775, 955 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 25, 55 );
			SetResistance( ResistanceType.Energy, 35, 55 );

			SetSkill( SkillName.EvalInt, 39.1, 49.0 );
			SetSkill( SkillName.Magery, 40.1, 50.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );
			
			SetSpecialAbility(SpecialAbility.DragonBreath);

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 75;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 115;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, 12 );
            
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		//public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
        public override HideType HideType { get { return HideType.BlazeL; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Gold : ScaleType.Gold ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public EnchantedDragon( Serial serial ) : base( serial )
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