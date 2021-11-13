using System;
using Server.Items;
using System.Collections;
using Server.Targeting;
using Server.Network;


namespace Server.Mobiles
{
    [CorpseName("a cow corpse")]
    public class TamingCow : BaseCreature
    {
        private DateTime m_MilkedOn;
        private int m_Milk;
        //private BaseTamer m_Item;
        private static Hashtable m_BeingTamed = new Hashtable();
		private bool m_SetSkillTime = true;
		
        [Constructable]
        public TamingCow()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "a cow";
            Body = Utility.RandomList(0xD8, 0xE7);
            BaseSoundID = 0x78;

            SetStr(30);
            SetDex(15);
            SetInt(5);
			CantWalk = true;

            SetHits(18);
            SetMana(0);

            SetDamage(1, 4);

            SetDamage(1, 4);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 15);

            SetSkill(SkillName.MagicResist, 5.5);
            SetSkill(SkillName.Tactics, 5.5);
            SetSkill(SkillName.Wrestling, 5.5);

            Fame = 300;
            Karma = 0;

            VirtualArmor = 10;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 11.1;

            if (Core.AOS && Utility.Random(1000) == 0) // 0.1% chance to have mad cows
                FightMode = FightMode.Closest;
        }

        public TamingCow(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime MilkedOn
        {
            get
            {
                return m_MilkedOn;
            }
            set
            {
                m_MilkedOn = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Milk
        {
            get
            {
                return m_Milk;
            }
            set
            {
                m_Milk = value;
            }
        }
        public override int Meat
        {
            get
            {
                return 8;
            }
        }
        public override int Hides
        {
            get
            {
                return 12;
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
            }
        }
       

        public void Tip()
        {
            PlaySound(121);
            Animate(8, 0, 3, true, false, 0);
        }

        public bool TryMilk(Mobile from)
        {
            if (!from.InLOS(this) || !from.InRange(Location, 2))
                from.SendLocalizedMessage(1080400); // You can not milk the cow from this location.
            if (Controlled && ControlMaster != from)
                from.SendLocalizedMessage(1071182); // The cow nimbly escapes your attempts to milk it.
            if (m_Milk == 0 && m_MilkedOn + TimeSpan.FromDays(1) > DateTime.UtcNow)
                from.SendLocalizedMessage(1080198); // This cow can not be milked now. Please wait for some time.
            else
            {
                if (m_Milk == 0)
                    m_Milk = 4;

                m_MilkedOn = DateTime.UtcNow;
                m_Milk--;

                return true;
            }

            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1);

            writer.Write((DateTime)m_MilkedOn);
            writer.Write((int)m_Milk);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version > 0)
            {
                m_MilkedOn = reader.ReadDateTime();
                m_Milk = reader.ReadInt();
            }
        }
		 public override void OnDoubleClick(Mobile from)
         {
			object target = this;
            if( target == from )
                      from.SendLocalizedMessage( 1005576 );

            if ( target is Mobile )
            {
               if ( target is BaseCreature )
               {
                  BaseCreature creature = (BaseCreature)target;

				  
                  if ( !creature.Tamable )
                  {
                     from.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                     //m_Item.Movable = true;
                  }
				  
                  else if ( creature.Controlled )
                  {
                     //from.SendLocalizedMessage( 502467 ); // That animal looks tame already.
                    // m_Item.Movable = true;
					creature.Controlled = false;
                  }
				  
                  else if ( from.Female ? !creature.AllowFemaleTamer : !creature.AllowMaleTamer )
                  {
                     from.SendLocalizedMessage( 502801 ); // You can't tame that!
                    // m_Item.Movable = true;
                  }
				 
                  else if ( from.Followers + creature.ControlSlots > from.FollowersMax )
                  {
                     from.SendLocalizedMessage( 1049611 ); // You have too many followers to tame that creature.
                   //  m_Item.Movable = true;
                  }
				  
                  else if ( from.Skills[SkillName.AnimalTaming].Value >= 110.0 )
				  {
					  
                     if ( m_BeingTamed.Contains( target ) )
                     {
                        from.SendLocalizedMessage( 502802 ); // Someone else is already taming this.
                     //   m_Item.Movable = true;
                     }
					
                     else
                     {
						
                        m_BeingTamed[target] = target;

						
                        // Face the creature
                        from.Direction = from.GetDirectionTo( creature );

                        //from.NextSkillTime = DateTime.MaxValue;
                        from.NextSkillTime = Core.TickCount + 6000;

                        from.LocalOverheadMessage( MessageType.Emote, 0x59, 1010597 ); // You start to tame the creature.
                        from.NonlocalOverheadMessage( MessageType.Emote, 0x59, 1010598 ); // *begins taming a creature.*

						
                        new InternalTimer(from, creature, Utility.Random( 3, 2 ) ).Start();

                        m_SetSkillTime = false;
                        //m_Item.Movable = false;
						
                     }
					 

                  }
				  
                  else
                  {
                     from.SendLocalizedMessage( 502806 ); // You have no chance of taming this creature.
                     //m_Item.Movable = true;
                  }
               }
               else
               {
                  from.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                  //m_Item.Movable = true;
               }
            }
            else
            {
               from.SendLocalizedMessage( 502801 ); // You can't tame that!
               //m_Item.Movable = true;
            }

         }
		 private class InternalTimer : Timer
         {
            //private BaseTamer m_Item;
            private Mobile m_Tamer;
            private BaseCreature m_Creature;
            private int m_MaxCount;
            private int m_Count;



            //public InternalTimer( BaseTamer item, Mobile tamer, BaseCreature creature, int count ) : base( TimeSpan.FromSeconds( 3.0 ), TimeSpan.FromSeconds( 3.0 ), count )
			public InternalTimer( Mobile tamer, BaseCreature creature, int count ) : base( TimeSpan.FromSeconds( 3.0 ), TimeSpan.FromSeconds( 3.0 ), count )
            {

               m_Tamer = tamer;
               m_Creature = creature;
               m_MaxCount = count;
               //m_Item = item;
			   m_Creature.Controlled = false;
				
				
            }

            protected override void OnTick()
            {
               m_Count++;

               if ( !m_Tamer.InRange( m_Creature, 6 ) )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502795 ); // You are too far away to continue taming.
                  //m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Tamer.CheckAlive() )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502796 ); // You are dead, and cannot continue taming.
                  //m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Tamer.CanSee( m_Creature ) )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502800 ); // You can't see that.
                  //m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Creature.Tamable )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                  //m_Item.Movable = true;
               Stop();
               }
               else if ( m_Creature.Controlled )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502804 ); // That animal looks tame already.
                  //m_Item.Movable = true;
                  Stop();
               }
               else if ( m_Count < m_MaxCount )
               {
                  m_Tamer.RevealingAction();
                  m_Tamer.PublicOverheadMessage( MessageType.Regular, 0x3B2, Utility.Random( 502790, 4 ) );
                  m_Tamer.Direction = m_Tamer.GetDirectionTo( m_Creature );

               }
			   
			   
               else
               {
                  m_Tamer.RevealingAction();
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_BeingTamed.Remove( m_Creature );
                  //m_Item.DoTamerTarget( m_Tamer, m_Creature );
                  //m_Item.Movable = true;

                  if ( m_Tamer.Skills[SkillName.AnimalTaming].Value >= 110.0 )
                  {
                     if ( m_Tamer.Skills[SkillName.AnimalTaming].Value >= 110.0 )
                        m_Tamer.SendLocalizedMessage( 502797 ); // That wasn't even challenging.
                     else
                        m_Creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 502799, m_Tamer.NetState ); // It seems to accept you as master.

                     m_Creature.SetControlMaster( m_Tamer );

                  }

                  else
                  {
                     m_Tamer.SendLocalizedMessage( 502798 ); // You fail to tame the creature.
                  }
               }
            }
         }
    }
}