
using System;
using Server;
using Server.Items;
using Server.Mobiles;



[CorpseName("an witch corpse")]
public class HalloweenWitch : BaseCreature
{
    [Constructable]
    public HalloweenWitch()
        : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
    {
        Name = "Halloween Witch";
        Title = "the wicked witch";
        Body = 401;
        Hue = 63;

        SetStr(110, 115);
        SetDex(115, 120);
        SetInt(115, 120);

        SetHits(2000, 2100);
        SetDamage(20, 30);

        SetDamageType(ResistanceType.Physical, 100);

        SetResistance(ResistanceType.Physical, 70, 80);
        SetResistance(ResistanceType.Fire, 65, 80);
        SetResistance(ResistanceType.Cold, 60, 80);
        SetResistance(ResistanceType.Poison, 70, 80);
        SetResistance(ResistanceType.Energy, 60, 80);

        SetSkill(SkillName.EvalInt, 105.0, 110.0);
        SetSkill(SkillName.EvalInt, 100.0, 110.0);
        SetSkill(SkillName.Magery, 110.0, 112.0);
        SetSkill(SkillName.Meditation, 110.0, 115.0);
        SetSkill(SkillName.MagicResist, 115.0, 120.0);
        SetSkill(SkillName.Tactics, 115.0, 120.0);
        SetSkill(SkillName.Macing, 100.0, 110.0);
        SetSkill(SkillName.Anatomy, 100.0);
        SetSkill(SkillName.Fencing, 110.0);

        Fame = 0;
        Karma = -24000;
        VirtualArmor = 90;

        Item hair = new Item(8252);
        hair.Layer = Layer.Hair;
        hair.Hue = 1109;
        hair.Movable = false;
        AddItem(hair);

        LeatherGloves gloves = new LeatherGloves();
        gloves.Hue = 1109;
        gloves.LootType = LootType.Blessed;
        AddItem(gloves);

        Skirt skirt = new Skirt();
        skirt.Hue = 1109;
        skirt.LootType = LootType.Blessed;
        AddItem(skirt);

        FancyShirt fancyshirt = new FancyShirt();
        fancyshirt.Hue = 1109;
        fancyshirt.LootType = LootType.Blessed;
        AddItem(fancyshirt);

        Cloak cloak = new Cloak();
        cloak.Hue = 1102;
        cloak.LootType = LootType.Blessed;
        AddItem(cloak);

        Shoes shoes = new Shoes();
        shoes.Hue = 1109;
        shoes.LootType = LootType.Blessed;
        AddItem(shoes);

        WizardsHat wizardshat = new WizardsHat();
        wizardshat.Hue = 1109;
        wizardshat.LootType = LootType.Blessed;
        AddItem(wizardshat);

        Item weapon = new WitchesBroom();
        weapon.Layer = Layer.OneHanded;
        AddItem(weapon);

        Container pack = new Backpack();
        PackItem(new Gold(100, 100));

        if (0.50 > Utility.RandomDouble()) // 0.50 = 55% = chance to drop 
            switch (Utility.Random(6)) //number of alternatives 
            {
                case 0: AddToBackpack(new WWRobe()); break;
                case 1: AddToBackpack(new HalloweenOuiJaBoard2010()); break;
                case 2: AddToBackpack(new Jack0Lantern2AddonDeed()); break;
                case 3: AddToBackpack(new CauldronSouthAddonDeed()); break;
                case 4: AddToBackpack(new SkeletonWithBootsEastAddonDeed()); break;
                case 5: AddToBackpack(new TortureBlockAddonDeed()); break;
            }
    }
    public override bool AlwaysMurderer { get { return true; } }

    public HalloweenWitch(Serial serial)
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
    }
}
