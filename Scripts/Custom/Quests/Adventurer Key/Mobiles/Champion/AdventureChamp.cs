using System;
using Server.Engines.CannedEvil;
using Server.Items;
using Server.Spells.Fifth;
using Server.Spells.Seventh;

namespace Server.Mobiles
{
    /*public class AdventureMobileDeleteTime : Timer
    {
        private Item mob;

        public AdventureMobileDeleteTime(Item m)
            : base(TimeSpan.FromSeconds(60))
        {
            mob = m;
            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            if (mob == null || mob.Deleted)
            {
                Stop();
                return;
            }

            mob.Delete();
        }
    }
    */
    public class AdventureChamp : BaseChampion
    {

        public override ChampionSkullType SkullType
        {
            get
            {
                return ChampionSkullType.None;
            }
        }
        public override Type[] UniqueList
        {
            get
            {
                return new Type[]
                {
                };
            }
        }
        public override Type[] SharedList
        {
            get
            {
                return new Type[]
                {
                };
            }
        }
        public override Type[] DecorativeList
        {
            get
            {
                return new Type[]
                {
                };
            }
        }
        public override MonsterStatuetteType[] StatueTypes
        {
            get
            {
                return new MonsterStatuetteType[] { };
            }
        }

        [Constructable]
        public AdventureChamp()
            : base(AIType.AI_Melee)
        {
            Name = "the orc chieftan";
            //Title = "";
            Body = 0x53;
            //Body = 0x190;
            //Hue = 0x83EC;

            SetStr(283, 425);
            SetDex(72, 150);
            SetInt(505, 750);

            SetHits(21000);
            SetStam(102, 300);
            SetMana(505, 750);

            SetDamage(129, 138);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 65, 75);
            SetResistance(ResistanceType.Fire, 70, 80);
            SetResistance(ResistanceType.Cold, 65, 80);
            SetResistance(ResistanceType.Poison, 70, 75);
            SetResistance(ResistanceType.Energy, 70, 80);

            SetSkill(SkillName.MagicResist, 100.0);
            SetSkill(SkillName.Tactics, 118.3, 120.2);
            SetSkill(SkillName.Wrestling, 118.4, 122.7);

            Fame = 22500;
            Karma = -22500;

            VirtualArmor = 70;
            
            /*AddItem(new FancyShirt(Utility.RandomGreenHue()));
            AddItem(new LongPants(Utility.RandomYellowHue()));
            AddItem(new JesterHat(Utility.RandomPinkHue()));
            AddItem(new Cloak(Utility.RandomPinkHue()));
            AddItem(new Sandals());

            HairItemID = 0x203B; // Short Hair
            HairHue = 0x94;*/

            m_SpecialSlayerMechanics = true;

            //AddItem(new AdventureSkull());
            //AddItem(new SOS(Map.Trammel, 3, true));
            //AddLoot(new SOS(Map.Trammel, 3, true));
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 100)
                c.DropItem(new AdventureKey());

        }

        /*public override bool OnBeforeDeath()
        {
            /*switch (Utility.Random(80))
            {
                case 0: PackItem(new GoreanBelt()); break;
                case 1: PackItem(new BraceletOfGor()); break;
                case 2: PackItem(new GoreanChest()); break;
                case 3: PackItem(new FreeWomanBustier()); break;
                case 4: PackItem(new GoreanEarrings()); break;
                case 5: PackItem(new GoreanGorget()); break;
                case 6: PackItem(new GoreanHelm()); break;
                case 7: PackItem(new GoreanLegs()); break;
                case 8: PackItem(new GoreanQuiver()); break;
                case 9: PackItem(new GoreanShield()); break;
                case 10: PackItem(new GoreanWarriorArms()); break;
                case 11: PackItem(new GoreanBoots()); break;
                case 12: PackItem(new GoreanWarriorCape()); break;
                case 13: PackItem(new GoreanRing()); break;
                case 14: PackItem(new GoreanWarriorRobe()); break;
                case 15: PackItem(new HandsOfGor()); break;
                case 16: PackItem(new KatanaOfGor()); break;
                case 17: PackItem(new FreeWomanSkirt()); break;
                case 18: PackItem(new SkirtOfTheFreeWoman()); break;
                case 19: PackItem(new ElfsDeath()); break;
            }
            // spawn the item
            Item item = (Item)Activator.CreateInstance(typeof(Moongate));
            Moongate moon = (Moongate)item;

            moon.TargetMap = Map.Trammel; //or map
            moon.Target = new Point3D(1422, 1697, 0); // Set map X,Y,Z location here

            // Map map = Map.Trammel; 

            Point3D pnt = GetSpawnLocation();

            moon.MoveToWorld(pnt, this.Map);

            Timer m_timer = new AdventureMobileDeleteTime(item);
            m_timer.Start();
            return base.OnBeforeDeath();
        }

        //from champspawn.cs
        public Point3D GetSpawnLocation()
        {
            int m_SpawnRange = 2;
            Map map = Map;

            if (map == null)
                return Location;

            // Try 20 times to find a spawnable location.
            for (int i = 0; i < 20; i++)
            {
                int x = Location.X + (Utility.Random((m_SpawnRange * 2) + 1) - m_SpawnRange);
                int y = Location.Y + (Utility.Random((m_SpawnRange * 2) + 1) - m_SpawnRange);
                int z = Map.GetAverageZ(x, y);

                if (Map.CanSpawnMobile(new Point2D(x, y), z))
                    return new Point3D(x, y, z);
            }

            return Location;
        }*/

        public AdventureChamp(Serial serial)
            : base(serial)
        {
        }

        public override bool AlwaysMurderer
        {
            get
            {
                return true;
            }
        }
        public override bool AutoDispel
        {
            get
            {
                return true;
            }
        }
        public override double AutoDispelChance
        {
            get
            {
                return 1.0;
            }
        }
        public override bool BardImmune
        {
            get
            {
                return !Core.SE;
            }
        }
		public override bool AllureImmune
		{
			get
			{
				return true;
			}
		}
        public override bool Unprovokable
        {
            get
            {
                return Core.SE;
            }
        }
        public override bool Uncalmable
        {
            get
            {
                return Core.SE;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Deadly;
            }
        }
        public override bool ShowFameTitle
        {
            get
            {
                return false;
            }
        }
        public override bool ClickTitle
        {
            get
            {
                return false;
            }
        }

        public override bool ForceStayHome { get { return true; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 3);
        }

        public void SpawnOrcs(Mobile target)
        {
            Map map = Map;

            if (map == null)
                return;

            int orcs = 0;

            IPooledEnumerable eable = GetMobilesInRange(10);

            foreach (Mobile m in eable)
            {
                if (m is AdventureOrc || m is AdventureOrcishArcher || m is AdventureOrcishMage)
                    ++orcs;
            }

            eable.Free();

            if (orcs < 16)
            {
                PlaySound(0x3D);

                int newOrcs = Utility.RandomMinMax(3, 6);

                for (int i = 0; i < newOrcs; ++i)
                {
                    BaseCreature orc;

                    switch ( Utility.Random(5) )
                    {
                        default:
                        case 0:
                        case 1:
                            orc = new AdventureOrc();
                            break;
                        case 2:
                        case 3:
                            orc = new AdventureOrcishArcher();
                            break;
                        case 4:
                            orc = new AdventureOrcishMage();
                            break;
                    }

                    orc.Team = Team;

                    bool validLocation = false;
                    Point3D loc = Location;

                    for (int j = 0; !validLocation && j < 10; ++j)
                    {
                        int x = X + Utility.Random(3) - 1;
                        int y = Y + Utility.Random(3) - 1;
                        int z = map.GetAverageZ(x, y);

                        if (validLocation = map.CanFit(x, y, Z, 16, false, false))
                            loc = new Point3D(x, y, Z);
                        else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                            loc = new Point3D(x, y, z);
                    }

                    orc.IsChampionSpawn = true;
                    orc.MoveToWorld(loc, map);
                    orc.Combatant = target;
                }
            }
        }

        public void DoSpecialAbility(Mobile target)
        {
            if (target == null || target.Deleted) //sanity
                return;

            if (0.1 >= Utility.RandomDouble()) // 10% chance to more orcs
                SpawnOrcs(target);
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            DoSpecialAbility(attacker);
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            DoSpecialAbility(defender);
        }

        public override void OnDamagedBySpell(Mobile from)
        {
            base.OnDamagedBySpell(from);

            DoSpecialAbility(from);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_SlayerVulnerabilities.Clear();
        }
    }
}
