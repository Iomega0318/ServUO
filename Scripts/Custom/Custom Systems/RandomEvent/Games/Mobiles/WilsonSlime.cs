using Server.Mobiles;

namespace Server.RandomEvent
{
    [CorpseName("a slimey wilson corpse")]
    public class WilsonSlime : BaseCreature, IGameMobile
    {
        public PlayerMobile PM { get; set; }

        [Constructable]
        public WilsonSlime() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "wilson the slime";
            Body = 51;
            BaseSoundID = 456;

            Hue = Utility.RandomBrightHue();

            SetStr(50, 80);
            SetDex(80, 100);
            SetInt(16, 25);

            SetHits(50, 150);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 50);
            SetResistance(ResistanceType.Poison, 90, 100);

            SetSkill(SkillName.Poisoning, 100.0, 120.0);
            SetSkill(SkillName.MagicResist, 60.0, 80.0);
            SetSkill(SkillName.Tactics, 50.0, 75.0);
            SetSkill(SkillName.Wrestling, 50.0, 75.0);

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 40;

            Tamable = false;
        }

        public WilsonSlime(Serial serial) : base(serial)
        {
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            if (defender is PlayerMobile)
                PM = defender as PlayerMobile;

            base.OnGaveMeleeAttack(defender);   
        }

        public override bool OnBeforeDeath()
        {
            if (PM != null)
            {
                if (PM.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer GP)
                {
                    GP.TotalPoints += HitsMax;
                    GP.GameMobsKilled++;

                    PM.SendMessage(PM.Name + ", you have been rewarded " + HitsMax.ToString() + " points for killing Wilson and 1 Game Token!");
                }
            }
            GameMain.GameMobiles.Remove(this);

            WilsonSlime wilson = new WilsonSlime();
            wilson.MoveToWorld(Location, GameMain.GameMap);
            GameMain.GameMobiles.Add(wilson);

            return base.OnBeforeDeath();
        }

        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Lesser;
            }
        }
        public override Poison HitPoison
        {
            get
            {
                return Poison.Lethal;
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat | FoodType.Fish | FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Eggs;
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Gems);
        }

        public override bool CheckMovement(Direction d, out int newZ)
        {
            if (!base.CheckMovement(d, out newZ))
                return false;

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0 && (AbilityProfile == null || AbilityProfile.MagicalAbility == MagicalAbility.None))
            {
                SetMagicalAbility(MagicalAbility.Poisoning);
            }
        }
    }
}
