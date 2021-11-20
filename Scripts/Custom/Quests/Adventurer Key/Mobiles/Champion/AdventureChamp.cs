using System;
using Server.Engines.CannedEvil;
using Server.Items;
using Server.Spells.Fifth;
using Server.Spells.Seventh;

namespace Server.Mobiles
{
    public class AdventureChamp : BaseChampion
    {

        public override ChampionSkullType SkullType
        {
            get
            {
                return ChampionSkullType.Enlightenment;
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
            Body = 0x190;
            Hue = 0x83EC;

            SetStr(283, 425);
            SetDex(72, 150);
            SetInt(505, 750);

            SetHits(12000);
            SetStam(102, 300);
            SetMana(505, 750);

            SetDamage(29, 38);

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

            AddItem(new FancyShirt(Utility.RandomGreenHue()));
            AddItem(new LongPants(Utility.RandomYellowHue()));
            AddItem(new JesterHat(Utility.RandomPinkHue()));
            AddItem(new Cloak(Utility.RandomPinkHue()));
            AddItem(new Sandals());

            HairItemID = 0x203B; // Short Hair
            HairHue = 0x94;

            m_SpecialSlayerMechanics = true;

            AddItem(new SOS(Map.Trammel, 3, true));
            //AddLoot(new SOS(Map.Trammel, 3, true));
        }

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
                if (m is Orc || m is OrcishArcher || m is OrcishMage)
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
                            orc = new Orc();
                            break;
                        case 2:
                        case 3:
                            orc = new OrcishArcher();
                            break;
                        case 4:
                            orc = new OrcishMage();
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
