using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("wood guardian corpse")]
    public class WoodGuardian : BaseCreature
    {
        [Constructable]
        public WoodGuardian()
            : base(AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Wood Guardian";
            Body = 301;

            SetStr(296, 320);
            SetDex(131, 155);
            SetInt(166, 190);

            SetHits(11118, 11132);

            SetDamage(12, 16);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 25);
            SetResistance(ResistanceType.Cold, 50, 60);
            SetResistance(ResistanceType.Poison, 30, 35);
            SetResistance(ResistanceType.Energy, 20, 30);

            SetSkill(SkillName.MagicResist, 40.1, 55.0);
            SetSkill(SkillName.Tactics, 65.1, 90.0);
            SetSkill(SkillName.Wrestling, 65.1, 85.0);

            Fame = 500;
            Karma = 1500;

            VirtualArmor = 24;
            PackItem(new Log(Utility.RandomMinMax(23, 34)));
            PackItem(new RavenwoodAxe());

            SetWeaponAbility(WeaponAbility.Dismount);
        }

        public WoodGuardian(Serial serial)
            : base(serial)
        {
        }

        public override TribeType Tribe { get { return TribeType.Fey; } }

        public override OppositionGroup OppositionGroup
        {
            get
            {
                return OppositionGroup.FeyAndUndead;
            }
        }
        public override bool BleedImmune
        {
            get
            {
                return true;
            }
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

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
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
