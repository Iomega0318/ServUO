//Created By Neshoba
using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class MobileDeleteTime : Timer
    {
        private Item mob;

        public MobileDeleteTime(Item m)
            : base(TimeSpan.FromSeconds(15))
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
    [CorpseName("PriestKing Serus corpse")]
    public class PriestKingSerus : BaseCreature
    {
        [Constructable]
        public PriestKingSerus()
            : base(AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Serus The Priest King";
            Body = 313;
            Hue = 1719;

            SetStr(800, 1000);
            SetDex(300, 420);
            SetInt(200, 310);

            SetHits(25000, 55000);

            SetDamage(180, 205);

            SetDamageType(ResistanceType.Physical, 50);

            SetResistance(ResistanceType.Physical, 100, 110);
            SetResistance(ResistanceType.Cold, 100, 110);
            SetResistance(ResistanceType.Poison, 100, 110);
            SetResistance(ResistanceType.Energy, 100, 110);
            SetResistance(ResistanceType.Fire, 100, 110);

            SetSkill(SkillName.MagicResist, 100.0, 110.0);
            SetSkill(SkillName.Tactics, 110.0, 120.0);
            SetSkill(SkillName.Wrestling, 130.0, 160.0);

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 70;
        }
        public override bool OnBeforeDeath()
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
            }*/
            // spawn the item
            Item item = (Item)Activator.CreateInstance(typeof(Moongate));
            Moongate moon = (Moongate)item;

            moon.TargetMap = Map.Trammel; //or map
            moon.Target = new Point3D(1422, 1697, 0); // Set map X,Y,Z location here

            // Map map = Map.Trammel; 

            Point3D pnt = GetSpawnLocation();

            moon.MoveToWorld(pnt, this.Map);

            Timer m_timer = new MobileDeleteTime(item);
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
        }
        public override bool IsScaryToPets { get { return true; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average, 2);
        }

        public override int GetIdleSound()
        {
            return 443;
        }

        public override int GetDeathSound()
        {
            return 31;
        }

        public override int GetAttackSound()
        {
            return 672;
        }

        public PriestKingSerus(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (BaseSoundID == 471)
                BaseSoundID = 0xE0;
        }
    }
}
