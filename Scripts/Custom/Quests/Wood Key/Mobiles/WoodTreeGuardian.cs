using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("a wood guardian treefellow corpse")]
    public class WoodTreeGuardian : BaseCreature
    {
        [Constructable]
        public WoodTreeGuardian() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Wood Guardian Treefellow";
            Body = 47;
            Hue = Utility.RandomList(1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165);

            SetStr(260);
            SetDex(160);
            SetInt(252);

            SetHits(1800);
            SetMana(240);
            SetStam(100);

            SetDamage(33);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50);
            SetDamageType(ResistanceType.Energy, 50);

            SetResistance(ResistanceType.Physical, 55);
            SetResistance(ResistanceType.Cold, 81);
            SetResistance(ResistanceType.Fire, 35);
            SetResistance(ResistanceType.Energy, 77);
            SetResistance(ResistanceType.Poison, 44);

            SetSkill(SkillName.Anatomy, 70);
            SetSkill(SkillName.Magery, 70);
            SetSkill(SkillName.Meditation, 90);
            SetSkill(SkillName.MagicResist, 85);
            SetSkill(SkillName.Wrestling, 95);
            SetSkill(SkillName.Tactics, 95);
            SetSkill(SkillName.Mysticism, 95);

            VirtualArmor = 30;
            {
            }

            Tamable = false;    // Not appropriate as a pet
        }

        public override void GenerateLoot()
        {
            PackGold(100);
            AddLoot(LootPack.Gems, Utility.Random(1, 5));
        }

        public WoodTreeGuardian(Serial serial) : base(serial)
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
        }
    }
}
