using System;
using Server.Mobiles;

namespace Server.Items
{
    public class MasterScroll : SpecialScroll
    {
       
		
        public override int Message
        {
            get
            {
                return 1094933;
            }
        }
																
        public override string DefaultTitle
        {
            get
            {
                return String.Format("<basefont color=#FFFFFF>Master scroll of ({0} Skill):</basefont>", this.Value);
            }
        }

        public static MasterScroll CreateRandom(int min, int max)
        {
            SkillName skill = (SkillName)Utility.Random(SkillInfo.Table.Length);

            return new MasterScroll(skill, 120.0);
        }

        public MasterScroll()
            : this(SkillName.Alchemy, 0.0)
        {
        }
		
        [Constructable]
        public MasterScroll(SkillName skill, double value)
            : base(skill, value)
        {
			this.Name = "A Master scroll of Skill";
            this.ItemID = 0x14EF;
            this.Hue = 1154;
        }

        public MasterScroll(Serial serial)
            : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (this.Value == 1)
                list.Add(1076759, "{0}\t{1}.0 Skill Points", this.GetName(), this.Value);
            else
                list.Add(1076759, "{0}\t{1} Skill Points", this.GetName(), this.Value);
        }
		
        public override bool CanUse(Mobile from)
        {
            if (!base.CanUse(from))
                return false;
			
            PlayerMobile pm = from as PlayerMobile;
			
            if (pm == null)
                return false;
			
            #region Scroll of Alacrity
            if (pm.AcceleratedStart > DateTime.UtcNow)
            {
                from.SendLocalizedMessage(1077951); // You are already under the effect of an accelerated skillgain scroll.
                return false;
            }
            #endregion
			
            return true;
        }

        public override void Use(Mobile from)
        {
            if (!this.CanUse(from))
                return;
			
            double tskill = from.Skills[this.Skill].Base; // value of skill without item bonuses etc
            double tcap = from.Skills[this.Skill].Cap = this.Value; // maximum value permitted
            bool canGain = true;
			
            double newValue = this.Value;

            if ((tskill + newValue) > tcap)
                newValue = tcap - tskill;

            if (tskill < tcap && from.Skills[this.Skill].Lock == SkillLock.Up)
            {
                if ((from.SkillsTotal + newValue * 10) > from.SkillsCap)
                {
                    int ns = from.Skills.Length; // number of items in from.Skills[]

                    for (int i = 0; i < ns; i++)
                    {
                        // skill must point down and its value must be enough
                        if (from.Skills[i].Lock == SkillLock.Down && from.Skills[i].Base >= newValue)
                        {
                            from.Skills[i].Base -= newValue;
                            canGain = true;
                            break;
                        }
                    }
                }
                else
                    canGain = true;
            }
			
            if (!canGain)
            {
                from.SendLocalizedMessage(1094935);	/*You cannot increase this skill at this time. The skill may be locked or set to lower in your skill menu.
                *If you are at your total skill cap, you must use a Powerscroll to increase your current skill cap.*/
                return;
            }

            from.SendLocalizedMessage(1049513, this.GetNameLocalized()); // You feel a surge of magic as the scroll enhances your ~1_type~!
					
            from.Skills[this.Skill].Base += newValue;

            Effects.PlaySound(from.Location, from.Map, 0x1F7);
            Effects.SendTargetParticles(from, 0x373A, 35, 45, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);
            Effects.SendTargetParticles(from, 0x376A, 35, 45, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);

            this.Delete();
        }
		
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = (this.InheritsItem ? 0 : reader.ReadInt()); //Required for SpecialScroll insertion

            this.LootType = LootType.Cursed;
            this.Insured = false;

            if (this.Hue == 0x7E)
                this.Hue = 0x490;
        }
    }
}