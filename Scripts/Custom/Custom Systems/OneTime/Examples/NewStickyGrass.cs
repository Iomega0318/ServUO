using Server.Mobiles;

namespace Server
{
    class NewStickyGrass : Item
    {
        private int Time = Utility.Random(1, 3);

        private int Count { get; set; }
        private int OrgZ { get; set; }

        [Constructable]
        public NewStickyGrass() : base()
        {
            Count = 0;
            OrgZ = 999;

            Visible = false;

            switch (Utility.Random(2))
            {
                case 0: ItemID = 3378; break;
                case 1: ItemID = 3379; break;
            }
        }

        public NewStickyGrass(Serial serial) : base(serial)
        {
            Count = 0;

            Visible = false;
        }

        public void TimerTick()
        {
            if (OrgZ == 999)
            {
                OrgZ = Z;
            }

            RunCheck();
        }

        private void RunCheck()
        {
            if (Count >= Time)
            {
                if (IsPlayerClose())
                {
                    Visible = true;

                    if (ItemID == 3378)
                        ItemID = 3379;
                    else
                        ItemID = 3378;

                    if (Utility.Random(1, 5) == 1)
                    {
                        if (Z > OrgZ)
                        {
                            Z--;
                            Hue = 0;
                            Visible = false;
                        }
                        else
                        {
                            Z++;
                            Hue = 67;
                        }
                    }
                }
                else
                {
                    if (Z > OrgZ)
                    {
                        Z--;
                    }

                    Hue = 0;
                    Visible = false;
                }

                Count = 0;
            }

            Count++;
        }

        private bool IsPlayerClose()
        {
			foreach (Mobile mobile in GetMobilesInRange(2))
			{
				if (mobile is PlayerMobile)
				{
					return true;
				}
			}

			return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);

            writer.Write(Time);

            writer.Write(OrgZ);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			if (version > 0)
			{
				Time = reader.ReadInt();

				OrgZ = reader.ReadInt();
			}
        }
    }
}
