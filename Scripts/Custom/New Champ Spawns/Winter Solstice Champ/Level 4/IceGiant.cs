using System;

namespace Server.Mobiles
{
    [CorpseName("an Ice Giant corpse")]
    public class IceGiant : BaseCreature
    {
        [Constructable]
        public IceGiant()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "an Ice Giant";
            this.Body = 76;
            this.BaseSoundID = 609;
			this.Hue = 1152;

            this.SetStr(250, 485);
            this.SetDex(126, 145);
            this.SetInt(281, 305);

            this.SetHits(950, 1175);

            this.SetDamage(13, 16);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 35, 45);
            this.SetResistance(ResistanceType.Fire, 30, 40);
            this.SetResistance(ResistanceType.Cold, 25, 35);
            this.SetResistance(ResistanceType.Poison, 30, 40);
            this.SetResistance(ResistanceType.Energy, 30, 40);

            this.SetSkill(SkillName.EvalInt, 85.1, 100.0);
            this.SetSkill(SkillName.Magery, 85.1, 100.0);
            this.SetSkill(SkillName.MagicResist, 80.2, 110.0);
            this.SetSkill(SkillName.Tactics, 60.1, 80.0);
            this.SetSkill(SkillName.Wrestling, 40.1, 50.0);

            this.Fame = 5000;
            this.Karma = -2500;

            this.VirtualArmor = 40;

            if (Core.ML && Utility.RandomDouble() < .33)
                this.PackItem(Engines.Plants.Seed.RandomPeculiarSeed(1));
        }

        public IceGiant(Serial serial)
            : base(serial)
        {
        }

        public override int Meat
        {
            get
            {
                return 4;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Regular;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 3;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.Average);
            this.AddLoot(LootPack.MedScrolls);
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