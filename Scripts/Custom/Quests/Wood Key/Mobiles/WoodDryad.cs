using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Haven
{
    public class WoodDryad : BaseQuester
    {
        [Constructable]
        public WoodDryad()
            : base("the Dryad")
        {
            this.SetSkill(SkillName.Peacemaking, 80.0, 100.0);
            this.SetSkill(SkillName.Cooking, 80.0, 100.0);
            this.SetSkill(SkillName.Provocation, 80.0, 100.0);
            this.SetSkill(SkillName.Musicianship, 80.0, 100.0);
            this.SetSkill(SkillName.Poisoning, 80.0, 100.0);
            this.SetSkill(SkillName.Archery, 80.0, 100.0);
            this.SetSkill(SkillName.Tailoring, 80.0, 100.0);
        }

        public WoodDryad(Serial serial)
            : base(serial)
        {
        }

        public override bool IsActiveVendor
        {
            get
            {
                return true;
            }
        }
        public override bool DisallowAllMoves
        {
            get
            {
                return false;
            }
        }
        public override bool ClickTitle
        {
            get
            {
                return true;
            }
        }
        public override bool CanTeach
        {
            get
            {
                return true;
            }
        }
        public override void InitBody()
        {
            this.InitStats(100, 100, 25);

            this.Hue = 0x85A7;

            this.Female = true;
            this.Body = 0x191;
            this.Name = "Anwin Brenna";
        }

        public override void InitOutfit()
        {
            this.AddItem(new Kilt(0x301));
            this.AddItem(new FancyShirt(0x300));

            this.HairItemID = 0x203D; // Pony Tail
            this.HairHue = 0x22;

            Bow bow = new Bow();
            bow.Movable = false;
            this.AddItem(bow);
        }

        public override void InitSBInfo()
        {
            this.m_SBInfos.Add(new SBDryad());
        }

        public override int GetAutoTalkRange(PlayerMobile pm)
        {
            return 4;
        }

        public override bool CanTalkTo(PlayerMobile to)
        {
            UzeraanTurmoilQuest qs = to.Quest as UzeraanTurmoilQuest;

            return (qs != null && qs.FindObjective(typeof(FindDryadObjective)) != null);
        }

        public override void OnTalk(PlayerMobile player, bool contextMenu)
        {
            QuestSystem qs = player.Quest;

            if (qs is UzeraanTurmoilQuest)
            {
                if (UzeraanTurmoilQuest.HasLostFertileDirt(player))
                {
                    this.FocusTo(player);
                    qs.AddConversation(new LostFertileDirtConversation(false));
                }
                else
                {
                    QuestObjective obj = qs.FindObjective(typeof(FindDryadObjective));

                    if (obj != null && !obj.Completed)
                    {
                        this.FocusTo(player);

                        Item fertileDirt = new QuestFertileDirt();

                        if (!player.PlaceInBackpack(fertileDirt))
                        {
                            fertileDirt.Delete();
                            player.SendLocalizedMessage(1046260); // You need to clear some space in your inventory to continue with the quest.  Come back here when you have more space in your inventory.
                        }
                        else
                        {
                            obj.Complete();
                        }
                    }
                    else if (contextMenu)
                    {
                        this.FocusTo(player);
                        this.SayTo(player, 1049357); // I have nothing more for you at this time.
                    }
                }
            }
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            PlayerMobile player = from as PlayerMobile;

            if (player != null)
            {
                UzeraanTurmoilQuest qs = player.Quest as UzeraanTurmoilQuest;

                if (qs != null && dropped is Apple && UzeraanTurmoilQuest.HasLostFertileDirt(from))
                {
                    this.FocusTo(from);

                    Item fertileDirt = new QuestFertileDirt();

                    if (!player.PlaceInBackpack(fertileDirt))
                    {
                        fertileDirt.Delete();
                        player.SendLocalizedMessage(1046260); // You need to clear some space in your inventory to continue with the quest.  Come back here when you have more space in your inventory.
                        return false;
                    }
                    else
                    {
                        dropped.Consume();
                        qs.AddConversation(new DryadAppleConversation());
                        return dropped.Deleted;
                    }
                }
            }

            return base.OnDragDrop(from, dropped);
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
