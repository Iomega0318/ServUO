using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a  jellyfish corpse" )]
	public class jellyfish : BaseCreature
	{
		[Constructable]
		public jellyfish() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a jellyfish";
			Body = Utility.RandomList( 51, 51  );
			BaseSoundID = 456;
			Hue = 1153;

			SetStr( 100, 150 );
			SetDex( 80 );
			SetInt( 110 );

			SetHits( 400 );
			SetMana( 100 );

			

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 50 );

			SetResistance( ResistanceType.Physical, 10, 60 );

			SetSkill( SkillName.MagicResist, 120.5 );
			SetSkill( SkillName.Tactics, 120.5 );
			SetSkill( SkillName.Wrestling, 120.5 );

			Fame = 500;
			Karma = 0;

			VirtualArmor = 60;
            CanSwim = true;
			CantWalk = false;
			
			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 80.0;

			if ( Core.AOS && Utility.Random( 1000 ) == 0 ) // 0.1% chance to have mad cows
				FightMode = FightMode.Closest;
		}

		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

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

		public jellyfish(Serial serial) : base(serial)
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
