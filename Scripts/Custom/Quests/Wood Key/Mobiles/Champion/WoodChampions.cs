using System;
using System.Collections.Generic;
using Server.Engines.CannedEvil;
using Server.Items;

namespace Server.Mobiles
{
    public class WoodChamp : BaseChampion
    {
        private Mobile m_Guardian;
        private bool m_SpawnedGuardian;
        [Constructable]
        public WoodChamp()
            : base(AIType.AI_Paladin, FightMode.Evil)
        {
            Body = 47;
            Name = "Guardian of the Forest";

            SetStr(403, 850);
            SetDex(101, 150);
            SetInt(503, 800);

            SetHits(21000);
            SetStam(202, 400);

            SetDamage(121, 133);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Fire, 25);

            SetResistance(ResistanceType.Physical, 85, 90);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 80, 90);
            SetResistance(ResistanceType.Energy, 80, 90);

            SetSkill(SkillName.Anatomy, 75.1, 100.0);
            SetSkill(SkillName.EvalInt, 120.1, 130.0);
            SetSkill(SkillName.Magery, 120.0);
            SetSkill(SkillName.Meditation, 120.1, 130.0);
            SetSkill(SkillName.MagicResist, 100.5, 150.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Wrestling, 100.0);
            SetSkill(SkillName.Chivalry, 100.0);

            Fame = 22500;
            Karma = 22500;

            VirtualArmor = 100;
        }

        public WoodChamp(Serial serial)
            : base(serial)
        {
        }

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
                return new Type[] { typeof(OrcChieftainHelm) };
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
        public override bool AutoDispel
        {
            get
            {
                return true;
            }
        }
        public override bool CanFly
        {
            get
            {
                return true;
            }
        }
        public override bool BardImmune
        {
            get
            {
                return !Core.SE;
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

        public override TribeType Tribe { get { return TribeType.Fey; } }

        public override OppositionGroup OppositionGroup
        {
            get
            {
                return OppositionGroup.FeyAndUndead;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Deadly;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 5);
        }

        public override bool OnBeforeDeath()
        {
            SpawnRavenwoodTree();

            return base.OnBeforeDeath();
        }

        public override void OnDeath(Container c)
        {
                //TODO: Confirm SE change or AoS one too?
                List<DamageStore> rights = GetLootingRights();
                List<Mobile> toGive = new List<Mobile>();

                for (int i = rights.Count - 1; i >= 0; --i)
                {
                    DamageStore ds = rights[i];

                    if (ds.m_HasRight)
                        toGive.Add(ds.m_Mobile);
                }
                    if (toGive.Count > 0)
                        toGive[Utility.Random(toGive.Count)].AddToBackpack(new RavenwoodAxe());
                    else
                        c.DropItem(new RavenwoodAxe());

                if (Core.SA)
                    RefinementComponent.Roll(c, 3, 0.10);

            base.OnDeath(c);
        }

        public void SpawnPixies(Mobile target)
        {
            Map map = Map;

            if (map == null)
                return;

            Say(1042154); // You shall never defeat me as long as I have my queen!

            int newPixies = Utility.RandomMinMax(3, 6);

            for (int i = 0; i < newPixies; ++i)
            {
                WoodPixie pixie = new WoodPixie();

                pixie.Team = Team;
                pixie.FightMode = FightMode.Closest;

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

                pixie.MoveToWorld(loc, map);
                pixie.Combatant = target;
            }
        }

        public void SpawnRavenwoodTree()
        {
            Map map = Map;

            if (map == null)
                return;

            int newRavenwoodTree = Utility.RandomMinMax(20, 40);

            for (int i = 0; i < newRavenwoodTree; ++i)
            {
                RavenwoodTree ravenwoodtree = new RavenwoodTree();

                bool validLocation = false;
                Point3D loc = Location;

                for (int j = 0; !validLocation && j < 10; ++j)
                {
                    int x = X + Utility.Random(75) - 1;
                    int y = Y + Utility.Random(75) - 1;
                    int z = map.GetAverageZ(x, y);

                    if (validLocation = map.CanFit(x, y, Z, 16, false, false))
                        loc = new Point3D(x, y, Z);
                    else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                        loc = new Point3D(x, y, z);
                }

                ravenwoodtree.MoveToWorld(loc, map);
            }
        }

        public override int GetAngerSound()
        {
            return 0x2F8;
        }

        public override int GetIdleSound()
        {
            return 0x2F8;
        }

        public override int GetAttackSound()
        {
            return Utility.Random(0x2F5, 2);
        }

        public override int GetHurtSound()
        {
            return 0x2F9;
        }

        public override int GetDeathSound()
        {
            return 0x2F7;
        }

        public void CheckGuardian()
        {
            if (Map == null)
                return;

            if (!m_SpawnedGuardian)
            {
                Say(1042153); // Come forth my queen!

                m_Guardian = new WoodGuardian();

                ((BaseCreature)m_Guardian).Team = Team;

                m_Guardian.MoveToWorld(Location, Map);

                m_SpawnedGuardian = true;
            }
            else if (m_Guardian != null && m_Guardian.Deleted)
            {
                m_Guardian = null;
            }
        }

        public override void AlterDamageScalarFrom(Mobile caster, ref double scalar)
        {
            CheckGuardian();

            if (m_Guardian != null)
            {
                scalar *= 0.1;

                if (0.1 >= Utility.RandomDouble())
                    SpawnPixies(caster);
            }
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.25 > Utility.RandomDouble())
            {
                int toSap = Utility.RandomMinMax(20, 30);

                switch (Utility.Random(3))
                {
                    case 0:
                        defender.Damage(toSap, this);
                        Hits += toSap;
                        break;
                    case 1:
                        defender.Stam -= toSap;
                        Stam += toSap;
                        break;
                    case 2:
                        defender.Mana -= toSap;
                        Mana += toSap;
                        break;
                }
            }

            /*defender.Damage(Utility.Random(20, 10), this);
            defender.Stam -= Utility.Random(20, 10);
            defender.Mana -= Utility.Random(20, 10);*/
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            CheckGuardian();

            if (m_Guardian != null && 0.1 >= Utility.RandomDouble())
                SpawnPixies(attacker);

            /*attacker.Damage(Utility.Random(20, 10), this);
            attacker.Stam -= Utility.Random(20, 10);
            attacker.Mana -= Utility.Random(20, 10);*/
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Guardian);
            writer.Write(m_SpawnedGuardian);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                    {
                        m_Guardian = reader.ReadMobile();
                        m_SpawnedGuardian = reader.ReadBool();

                        break;
                    }
            }
        }
    }
}
