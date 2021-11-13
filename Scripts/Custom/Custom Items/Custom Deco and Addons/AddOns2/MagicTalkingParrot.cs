using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a corpse of a parrot" )]
	public class MagicTalkingParrot : BaseCreature
	{
		private Mobile m_ListeningTo;
		private string m_LastSaid;
		private string m_LastHeard;
		[Constructable]
		public MagicTalkingParrot() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.1, 0.2 )
		{
			SpeechHue = Utility.RandomDyedHue();
			

			Body = 282;

			Name = NameList.RandomName( "male" );
			Title = "the Magical Parrot";
			m_ListeningTo = null;
			m_LastSaid = null;
			m_LastHeard = null;

			SetStr( 30 );
			SetDex( 50 );
			SetInt( 110 );
			SetHits( 100 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.Anatomy, 30.0 );
			SetSkill( SkillName.MagicResist, 60.0 );
			SetSkill( SkillName.Tactics, 60.0 );
			SetSkill( SkillName.Wrestling, 60.0 );
			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 60.0 );

			Fame = 15000;
			Karma = -15000;

			PackGem();
			PackItem( new Gold( Utility.Random( 500, 2000 )));
			Tamable = true;
			MinTameSkill = 80.0;
			ControlSlots = 1;
		}

		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; }}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			damage = damage / 10;
		}

		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			damage = damage / 10;
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled )
			{
				Mobile from = e.Mobile;
				if ( this.ControlMaster == from )
				{
					String command = e.Speech;
					if ( command == "What did you just say?" && m_LastSaid != null )
						this.Say( m_LastSaid );
					else if ( command == "Repeat what you just heard." && m_LastHeard != null )
					if ( command == "Who are you listening to?" && this.m_ListeningTo != null )
						this.Say( "{0}", this.m_ListeningTo.Name );
				}
				if ( from is PlayerMobile )
				{
					String text = e.Speech;
					if ( this.m_ListeningTo == null )
					{
						this.m_ListeningTo = from;
						this.BeginLineRecognition( text, from );
					}
					else if ( this.m_ListeningTo == from )
						this.BeginLineRecognition( text, from );
				}
			}
		}

		public override void OnThink()
		{
			if ( this.m_ListeningTo != null && !this.m_ListeningTo.InRange( this.Location, 6 ))
				this.m_ListeningTo = null;
		}

		public void BeginLineRecognition( String text, Mobile from )
		{
			string response = this.GetResponseFor( text, from );
			this.m_LastSaid = response;
			this.m_LastHeard = text;
			this.Say( response );
		}

		public string GetResponseFor( String text, Mobile from )
		{
			if ( text == "Hello" || text == "Hello." || text == "Hello!" || text == "Hail" || text == "Hail." || text == "Hail!" || text == "Hi" || text == "Hi." || text == "Hi!" )
				return "Hello!";
			else if ( text == "How are you" || text == "How are you?" || text == "How's in going" || text == "How's it going?" || text == "Hows it going" || text == "Hows it going?" || text == "How's life" || text == "How's life?" || text == "Hows life" || text == "Hows life?" )
				return "Not too bad.";
			else if ( text == "What's up" || text == "What's up?" || text == "Whats up" || text == "Whats up?" || text == "What's Happenin'" || text == "What's Happenin'?" || text == "What's Happenin" || text == "What's Happenin?" || text == "What's Happening" || text == "What's Happening?" || text == "What it do" || text == "What it do?" || text == "Wut it do" || text == "Wut it do?" )
				return "Nothin' much, man.";
			else if ( text == "Whazap" || text == "Whazzap" || text == "Whazaap" || text == "Whazzaap" || text == "Whazap?" || text == "Whazzap?" || text == "Whazaap?" || text == "Whazzaap?" || text == "Whazap!" || text == "Whazzap!" || text == "Whazaap!" || text == "Whazzaap!" )
				return "Whazzaap!";
			else if ( text == "Fuck you" || text == "Fuck you parrot." || text == "Fuck you, parrot." || text == "Fuck you!" || text == "Fuck you parrot!" || text == "Fuck you, parrot!" )
				return "Fuck you too, bitch!";
			else if ( text == "You wanna go?" || text == "You wanna go" || text == "You want to go?" || text == "You want to go" || text == "You wanna fight?" || text == "You wanna fight" || text == "You want to fight?" || text == "You want to fight" || text == "Wanna start somethin'?" || text == "Wanna start somethin'" || text == "Wanna start somethin?" || text == "Wanna start somethin" || text == "Want to start somethin'?" || text == "Want to start somethin?" || text == "Want to start somethin'" || text == "Want to start somethin" || text == "You wanna start somethin'?" || text == "You wanna start somethin?" || text == "You wanna start somethin" || text == "You wanna start somethin'" || text == "You want to start somethin'?" || text == "You want to start somethin'" || text == "You want to start somethin?" || text == "You want to start somethin" || text == "throw down?" || text == "we fight!" )
			{
				return "You aksed for it, biatch!";
				this.Combatant = from;
				from.Combatant = this;
			}
			else
				return text;
		}

		public MagicTalkingParrot( Serial serial ) : base( serial )
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
