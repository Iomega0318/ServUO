using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0x13F6, 0x13F7 )]
	public class EverlastingGargoylesKnife : BaseKnife
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 5; } }
		public override int AosMinDamage{ get{ return 9; } }
		public override int AosMaxDamage{ get{ return 11; } }
		public override int AosSpeed{ get{ return 49; } }

		public override int OldStrengthReq{ get{ return 5; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 14; } }
		public override int OldSpeed{ get{ return 40; } }
		public override float MlSpeed { get { return 2.25f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

		[Constructable]
		public EverlastingGargoylesKnife() : base( 0x13F6 )
		{
			//Hue = 0x973; //removed in RunUO
			Name = "Gargoyles Knife";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Target = new EverlastingGargoylesKnifeTarget( this );
			from.SendMessage( "Which corpse you want to carve?" ); 					
		}
		
		private class EverlastingGargoylesKnifeTarget : Target 
		{ 
			private EverlastingGargoylesKnife m_Knife;

			public EverlastingGargoylesKnifeTarget(EverlastingGargoylesKnife knife ) : base( 15, false, TargetFlags.None )
			{
				m_Knife = knife;
			}
			
			protected override void OnTarget( Mobile from, object target ) 
			{ 
				if ( target is Corpse ) 
				{	
					Corpse c = (Corpse)target; 
					if (c.Owner is BaseCreature)
					{
						if (c.Carved == false && ((BaseCreature)c.Owner).Hides != 0)
						{
							Map map = from.Map;
							if ( map == null )
								return;
							BaseCreature spawned = null;
							if (((BaseCreature)c.Owner).HideType == HideType.Regular)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(4))
									{
										case 0: spawned = new Elementals(102); break;
										case 1: spawned = new Elementals(103); break;
										case 2: spawned = new Elementals(104); break;
										case 3: spawned = new Elementals(105); break;
									}
								}
								switch(Utility.Random(4))
								{
									case 0: c.AddItem( new SpinedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new HornedHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Spined)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(5))
									{
										case 0: spawned = new Elementals(103); break;
										case 1: spawned = new Elementals(104); break;
										case 2: spawned = new Elementals(105); break;
										case 3: spawned = new Elementals(106); break;
										case 4: spawned = new Elementals(107); break;
									}
								}
								switch(Utility.Random(5))
								{
									case 0: c.AddItem( new HornedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Horned)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(6))
									{
										case 0: spawned = new Elementals(104); break;
										case 1: spawned = new Elementals(105); break;
										case 2: spawned = new Elementals(106); break;
										case 3: spawned = new Elementals(107); break;
										case 4: spawned = new Elementals(108); break;
										case 5: spawned = new Elementals(109); break;
									}
								}
								switch(Utility.Random(6))
								{
									case 0: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Barbed)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(7))
									{
										case 0: spawned = new Elementals(105); break;
										case 1: spawned = new Elementals(106); break;
										case 2: spawned = new Elementals(107); break;
										case 3: spawned = new Elementals(108); break;
										case 4: spawned = new Elementals(109); break;
										case 5: spawned = new Elementals(110); break;
										case 6: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(7))
								{
									case 0: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 6: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Polar)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(6))
									{
										case 0: spawned = new Elementals(106); break;
										case 1: spawned = new Elementals(107); break;
										case 2: spawned = new Elementals(108); break;
										case 3: spawned = new Elementals(109); break;
										case 4: spawned = new Elementals(110); break;
										case 5: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(6))
								{
									case 0: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Synthetic)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(5))
									{
										case 0: spawned = new Elementals(107); break;
										case 1: spawned = new Elementals(108); break;
										case 2: spawned = new Elementals(109); break;
										case 3: spawned = new Elementals(110); break;
										case 4: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(5))
								{
									case 0: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.BlazeL)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(4))
									{
										case 0: spawned = new Elementals(108); break;
										case 1: spawned = new Elementals(109); break;
										case 2: spawned = new Elementals(110); break;
										case 3: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(4))
								{
									case 0: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Daemonic)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(3))
									{
										case 0: spawned = new Elementals(109); break;
										case 1: spawned = new Elementals(110); break;
										case 2: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(3))
								{
									case 0: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Shadow)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(2))
									{
										case 0: spawned = new Elementals(110); break;
										case 1: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(2))
								{
									case 0: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType >= HideType.Frost)
							{
								if (0.1 > Utility.RandomDouble())
									spawned = new Elementals(111);
								c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides));
							}
							else
							{
								from.SendMessage("You can't use gargoyles knife on that.");
								from.PlaySound(1066); //play giggle sound
								return;
							}
							c.Carved = true;
							if (m_Knife != null)
							{
								if (m_Knife.UsesRemaining > 1)
									m_Knife.UsesRemaining--; 
								else
								{
									m_Knife.Delete();
									from.SendMessage("You used up your gargoyles knife");
								}
							}
							if ( spawned != null )
							{
								from.SendMessage("When you used your gargoyles knife on the corpse a leather elemental came to defend it.");
								from.PlaySound(1098); //play m_yell

								int offset = Utility.Random( 8 ) * 2;
								for ( int i = 0; i < m_Offsets.Length; i += 2 )
								{
									int x = from.X + m_Offsets[(offset + i) % m_Offsets.Length];
									int y = from.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];
									if ( map.CanSpawnMobile( x, y, from.Z ) )
									{
										spawned.MoveToWorld( new Point3D( x, y, from.Z ), map );
										spawned.Combatant = from;
										return;
									}
									else
									{
										int z = map.GetAverageZ( x, y );

										if ( map.CanSpawnMobile( x, y, z ) )
										{
											spawned.MoveToWorld( new Point3D( x, y, z ), map );
											spawned.Combatant = from;
											return;
										}
									}
								}
								try 
								{
									spawned.MoveToWorld( from.Location, from.Map );
									spawned.Combatant = from;
								}
								catch
								{
								}
							}
							else
							{
								from.SendMessage("Nothing happened when you used your gargoyles knife on the corpse.");
								if (from.BodyValue == 401)
									from.PlaySound(787); // play f_cry
								else if (from.BodyValue == 400)
									from.PlaySound(1058); //play m_cry
							}
						}
						else
							from.SendMessage("You see nothing useful to carve from the corpse.");
					}
				}
			}
		}
		public EverlastingGargoylesKnife( Serial serial ) : base( serial )
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
