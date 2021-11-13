using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Network;
using System.Collections;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using Server.Engines.CannedEvil;

namespace Server.Mobiles 
{ 
	public class AtlantisMermaid : BaseCreature 
	{ 
		[Constructable] 
		public AtlantisMermaid() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Atlantis Mermaid";
			Hue = 2474; 
			Body = 401;
                        Female = true;
			

			SetStr( 250 );
			SetDex( 220 );
			SetInt( 250 );

			SetHits( 2500 );
			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 200 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 200 );

			SetSkill( SkillName.Anatomy, 160.0 );
			SetSkill( SkillName.Archery, 210.0 );
			SetSkill( SkillName.Wrestling, 250.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 160.0 );

			Fame = 7000;
			Karma = -500;

			VirtualArmor = 75;

			Item hair = new Item( 8252 ); 
			hair.Hue = 2474; 
			hair.Layer = Layer.Hair; 
			hair.Movable = false; 
			AddItem( hair ); 

			                                                    
            Item FlowerGarland = new Item( 8966 ); 
			FlowerGarland.Hue = 2896; 
			FlowerGarland.Layer = Layer.Helm;
			FlowerGarland.LootType = LootType.Blessed;
			AddItem( FlowerGarland );

			Item FemaleKimono = new Item( 10115 ); 
			FemaleKimono.Hue = 2435; 
			FemaleKimono.Layer = Layer.OuterTorso;
			FemaleKimono.LootType = LootType.Blessed;
			AddItem( FemaleKimono );             
                                                
                                               
                        Container pack = new Backpack();
			PackGold( 4900, 6500  );
                      //PackItem( new Tokens( 1100, 1200 ) );

			if ( 0.07 > Utility.RandomDouble() ) // 0.20 = 20% = chance to drop 
			switch ( Utility.Random( 8 )) //number of alternatives 
			{ 
			// Armors 
			case 0: AddToBackpack( new AtlantisTreasure() ); break; 
			case 1: AddToBackpack( new MermaidsTail() ); break; 
			case 2: AddToBackpack( new AtlantisSpear() ); break; 
			case 3: AddToBackpack( new PearlRingOfAtlantis() ); break; 
			case 4: AddToBackpack( new EnchantedSeaRoseStatuette() ); break; 
			case 5: AddToBackpack( new FishingBracelet() ); break; 
			case 6: AddToBackpack( new SerpentsSkinSandalsOfAtlantis() ); break; 
			case 7: AddToBackpack( new MermaidsBelly() ); break; 
			}





		} 

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool IsScaryToPets{ get{ return true; } }


                                public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				

				m.BodyMod = 77;
				m.HueMod = 2635;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 1.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}
		public void DoSpecialAbility( Mobile target )
		{
			if ( 0.6 >= Utility.RandomDouble() ) // 60% chance to polymorph attacker into a ratman
				Polymorph( target );


			if ( Hits < 500 && !IsBodyMod ) // Baracoon is low on life, polymorph into a ratman
				Polymorph( this );
		}
		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}

		public AtlantisMermaid( Serial serial ) : base( serial ) 
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