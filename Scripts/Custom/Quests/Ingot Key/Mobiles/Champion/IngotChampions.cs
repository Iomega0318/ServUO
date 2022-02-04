using System;
using System.Collections.Generic;
using Server.Engines.CannedEvil;
using Server.Items;

namespace Server.Mobiles
{
    public class IngotChamp : BaseChampion
    {
        [Constructable]
        public IngotChamp()
            : base(AIType.AI_Melee, FightMode.Closest)
        {
            // TODO: Gas attack
            Name = "Hoarder of Ingots";
            Body = 112;
            Hue = 268;
            BaseSoundID = 268;

            SetStr(1260, 1550);
            SetDex(150, 185);
            SetInt(1200, 1392);

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

        public IngotChamp(Serial serial)
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
                return new Type[] {};
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
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Deadly;
            }
        }
        public override void CheckReflect(Mobile caster, ref bool reflect)
        {
            reflect = true; // Every spell is reflected back to the caster
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 5);
        }

        public override bool OnBeforeDeath()
        {
            SpawnUraniumVein();

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
                        toGive[Utility.Random(toGive.Count)].AddToBackpack(new UraniumPickaxe());
                    else
                        c.DropItem(new UraniumPickaxe());

                if (Core.SA)
                    RefinementComponent.Roll(c, 3, 0.10);

            base.OnDeath(c);
        }

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            if (from is BaseCreature)
            {
                BaseCreature bc = (BaseCreature)from;

                if (bc.Controlled || bc.BardTarget == this)
                    damage = 0; // Immune to pets and provoked creatures
            }
            else
            {
                AOS.Damage(from, this, damage / 2, 0, 0, 0, 0, 0, 0, 100);
            }

            base.AlterMeleeDamageFrom(from, ref damage);
        }

        public void SpawnUraniumVein()
        {
            Map map = Map;

            if (map == null)
                return;

            int newUraniumVein = Utility.RandomMinMax(20, 40);

            for (int i = 0; i < newUraniumVein; ++i)
            {
                UraniumVein uraniumvein = new UraniumVein();

                bool validLocation = false;
                Point3D loc = Location;

                for (int j = 0; !validLocation && j < 10; ++j)
                {
                    int x = X + Utility.Random(30) - 1;
                    int y = Y + Utility.Random(30) - 1;
                    int z = map.GetAverageZ(x, y);

                    if (validLocation = map.CanFit(x, y, Z, 16, false, false))
                        loc = new Point3D(x, y, Z);
                    else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                        loc = new Point3D(x, y, z);
                }

                uraniumvein.MoveToWorld(loc, map);
            }
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
    }
}
