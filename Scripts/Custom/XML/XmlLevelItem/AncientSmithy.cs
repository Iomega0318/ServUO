/*
 created by: dracana
 based on: Master of the Arts by Daat99 and Mephitis by RunUO team
*/
using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Services.Virtues;

namespace Server.Mobiles
{
    [CorpseName("corpse of a blacksmith")]
    public class AncientSmithy : BaseCreature
    {
        public override int GetAttackSound()
        {
            return 42; // play blacksmith sound
        }

        public override int GetAngerSound()
        {
            return 42; //play blacksmith sound
        }

        public override WeaponAbility GetWeaponAbility()
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.MortalStrike;
            else if (ability == 2)
                return WeaponAbility.BleedAttack;
            else
                return WeaponAbility.ArmorIgnore;
        }

        private int i_LUsCount;
        public int LUsCount { get { return i_LUsCount; } set { i_LUsCount = value; InvalidateProperties(); } }
        private bool i_ChampionSpawn;
        public bool ChampionSpawn { get { return i_ChampionSpawn; } set { i_ChampionSpawn = value; InvalidateProperties(); } }

        [Constructable]
        public AncientSmithy() : this(false)
        {
        }

        [Constructable]
        public AncientSmithy(bool i_ChampionSpawn) : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Ragnar";
            Title = "the Ancient Blacksmith";
            Body = 185;
            BaseSoundID = 42;

            ChampionSpawn = i_ChampionSpawn; //set if it spawn with champ spawn or normal spawn

            SetStr(405, 600);
            SetDex(82, 110);
            SetInt(202, 300);

            SetHits(1600, 2200);
            SetStam(105, 300);

            SetDamage(22, 35);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Poison, 50);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 100);
            SetResistance(ResistanceType.Energy, 60, 70);

            SetSkill(SkillName.Anatomy, 99.6, 120.0);
            SetSkill(SkillName.Tactics, 99.6, 120.0);
            SetSkill(SkillName.Macing, 99.6, 120.0);
            SetSkill(SkillName.MagicResist, 80.7, 110.0);

            Fame = 30000;
            Karma = -30000;

            VirtualArmor = 65;

            PlateGloves gloves = new PlateGloves();
            gloves.Hue = 0x28D;
            gloves.Movable = false;
            AddItem(gloves);

            ChainLegs legs = new ChainLegs();
            legs.Hue = 0x28D;
            legs.Movable = false;
            AddItem(legs);

            WarHammer weapon = new WarHammer();
            weapon.Movable = false;
            AddItem(weapon);

            Boots boots = new Boots();
            boots.Hue = 0x28D;
            boots.Movable = false;
            AddItem(boots);

            HairItemID = 0x2049;
            HairHue = 0x21A;
            FacialHairItemID = 0x203E;
            FacialHairHue = 0x21A;
        }

        private LevelUpScroll CreateRandomLevelUpScroll()
        {
            int level;
            double random = Utility.RandomDouble();

            if (0.1 >= random)
                level = 20;
            else if (0.4 >= random)
                level = 15;
            else if (0.7 >= random)
                level = 10;
            else
                level = 5;

            return new LevelUpScroll(level);
        }

        public void GiveLevelUpScrolls()
        {
            ArrayList toGive = new ArrayList();
            List<DamageStore> rights = GetLootingRights();

            for (int i = rights.Count - 1; i >= 0; --i)
            {
                DamageStore ds = rights[i];

                if (ds.m_HasRight)
                    toGive.Add(ds.m_Mobile);
            }

            if (toGive.Count == 0)
                return;

            for (int i = 0; i < toGive.Count; i++)
            {
                Mobile m = (Mobile)toGive[i];

                if (!(m is PlayerMobile))
                    continue;

                bool gainedPath = false;

                int pointsToGain = 800;

                if (VirtueHelper.Award(m, VirtueName.Valor, pointsToGain, ref gainedPath))
                {
                    if (gainedPath)
                        m.SendLocalizedMessage(1054032); // You have gained a path in Valor!
                    else
                        m.SendLocalizedMessage(1054030); // You have gained in Valor!
                }
            }

            // Randomize
            for (int i = 0; i < toGive.Count; ++i)
            {
                int rand = Utility.Random(toGive.Count);
                object hold = toGive[i];
                toGive[i] = toGive[rand];
                toGive[rand] = hold;
            }

            LUsCount = ChampionSpawn ? 6 : 2;
            for (int i = 0; i < LUsCount; ++i)
            {
                Mobile m = (Mobile)toGive[i % toGive.Count];

                LevelUpScroll lus = CreateRandomLevelUpScroll();

                m.SendMessage("You have received a scroll of level increase!");

                if (!Core.SE || m.Alive)
                    m.AddToBackpack(lus);
                else
                {
                    if (m.Corpse != null && !m.Corpse.Deleted)
                        ((Container)m.Corpse).DropItem(lus);
                    else
                        m.AddToBackpack(lus);
                }

                if (m is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m;

                    for (int j = 0; j < pm.JusticeProtectors.Count; ++j)
                    {
                        Mobile prot = (Mobile)pm.JusticeProtectors[j];

                        if (prot.Map != m.Map || prot.Kills >= 5 || prot.Criminal || !JusticeVirtue.CheckMapRegion(m, prot))
                            continue;

                        int chance = 0;

                        switch (VirtueHelper.GetLevel(prot, VirtueName.Justice))
                        {
                            case VirtueLevel.Seeker: chance = 60; break;
                            case VirtueLevel.Follower: chance = 80; break;
                            case VirtueLevel.Knight: chance = 100; break;
                        }

                        if (chance > Utility.Random(100))
                        {
                            lus = CreateRandomLevelUpScroll();

                            prot.SendLocalizedMessage(1049368); // You have been rewarded for your dedication to Justice!

                            if (!Core.SE || prot.Alive)
                                prot.AddToBackpack(lus);
                            else
                            {
                                if (prot.Corpse != null && !prot.Corpse.Deleted)
                                    ((Container)prot.Corpse).DropItem(lus);
                                else
                                    prot.AddToBackpack(lus);
                            }
                        }
                    }
                }
            }
        }

        public override bool OnBeforeDeath() //what happens before it dies
        {
            GiveLevelUpScrolls(); //give levelup scrolls

            if (ChampionSpawn == false) //if it wasn't spawned as part of champ spawn then don't add gold.
                return true;

            Map map = this.Map;
            if (map != null)
            {
                for (int x = -8; x <= 8; ++x)
                {
                    for (int y = -8; y <= 8; ++y)
                    {
                        double dist = Math.Sqrt(x * x + y * y);

                        if (dist <= 8)
                            new GoldTimer(map, X + x, Y + y).Start();
                    }
                }
            }
            return true;
        }

        public override bool BardImmune { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public override bool AlwaysMurderer { get { return true; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich);
        }

        public AncientSmithy(Serial serial) : base(serial)
        {
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
        }

        private class GoldTimer : Timer
        {
            private Map m_Map;
            private int m_X, m_Y;

            public GoldTimer(Map map, int x, int y) : base(TimeSpan.FromSeconds(Utility.RandomDouble() * 10.0))
            {
                m_Map = map;
                m_X = x;
                m_Y = y;
            }

            protected override void OnTick()
            {
                int z = m_Map.GetAverageZ(m_X, m_Y);
                bool canFit = m_Map.CanFit(m_X, m_Y, z, 6, false, false);

                for (int i = -3; !canFit && i <= 3; ++i)
                {
                    canFit = m_Map.CanFit(m_X, m_Y, z + i, 6, false, false);

                    if (canFit)
                        z += i;
                }

                if (!canFit)
                    return;

                Gold g = new Gold(500, 1000);

                g.MoveToWorld(new Point3D(m_X, m_Y, z), m_Map);

                if (0.5 >= Utility.RandomDouble())
                {
                    switch (Utility.Random(3))
                    {
                        case 0: // Fire column
                            {
                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x3709, 10, 30, 5052);
                                Effects.PlaySound(g, g.Map, 0x208);

                                break;
                            }
                        case 1: // Explosion
                            {
                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36BD, 20, 10, 5044);
                                Effects.PlaySound(g, g.Map, 0x307);

                                break;
                            }
                        case 2: // Ball of fire
                            {
                                Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36FE, 10, 10, 5052);

                                break;
                            }
                    }
                }
            }
        }
    }
}
