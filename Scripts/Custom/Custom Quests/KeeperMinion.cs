using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a keeper's minion corpse")]
    public class KeeperMinion : BaseCreature
    {
        [Constructable]
        public KeeperMinion()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "The Keeper's Minion";
            this.Hue = 1910;
            this.Body = 776;
            this.BaseSoundID = 357;

            this.SetStr(23, 60);
            this.SetDex(31, 60);
            this.SetInt(11, 25);

            this.SetHits(10, 24);

            this.SetDamage(15, 30);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 30, 50);
            this.SetResistance(ResistanceType.Fire, 15, 30);
            this.SetResistance(ResistanceType.Energy, 15, 30);

            this.SetSkill(SkillName.MagicResist, 75.0);
            this.SetSkill(SkillName.Tactics, 50.0);
            this.SetSkill(SkillName.Wrestling, 75.0);

            this.Fame = 500;
            this.Karma = -500;

            this.VirtualArmor = 18;

            this.AddItem(new LightSource());

            this.PackItem(new Bone(3));
            // TODO: Body parts
        }

        public KeeperMinion(Serial serial)
            : base(serial)
        {
        }

        public override int GetIdleSound()
        {
            return 338;
        }

        public override int GetAngerSound()
        {
            return 338;
        }

        public override int GetDeathSound()
        {
            return 338;
        }

        public override int GetAttackSound()
        {
            return 406;
        }

        public override int GetHurtSound()
        {
            return 194;
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