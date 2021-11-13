using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Gumps
{
    public class ExpBar : Gump
    {
        public static void Initialize()
        {
			CommandSystem.Register("ExpBar", AccessLevel.Player, new CommandEventHandler(ExpBar_OnCommand));
        }

        private static void ExpBar_OnCommand(CommandEventArgs e)
        {
			XMLPlayerLevelAtt xmlplayer = (XMLPlayerLevelAtt)XmlAttach.FindAttachment(e.Mobile, typeof(XMLPlayerLevelAtt));
			if (xmlplayer == null)
			{
				e.Mobile.SendMessage("You may not use this!");
				return;
			}
			else
			{
				e.Mobile.CloseGump(typeof(ExpBar));
				e.Mobile.SendGump(new ExpBar(e.Mobile));
			}
        }

        public ExpBar(Mobile m)
            : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);

            PlayerMobile pm = m as PlayerMobile;
			XMLPlayerLevelAtt xmlplayer = (XMLPlayerLevelAtt)XmlAttach.FindAttachment(m, typeof(XMLPlayerLevelAtt));
            AddBackground(10, 10, 295, 90, 9270);
            AddLabel(25, 25, 1161, "EXP:");
            AddLabel(55, 25, 1152, "" + xmlplayer.Expp.ToString("#,0"));
			AddLabel(130, 25, 1161, "Level");
			AddLabel(160, 25, 1153, "" + xmlplayer.Levell.ToString("#,0"));
			AddLabel(190, 25, 1161, "Max Level:");
			AddLabel(255, 25, 1152, "" + xmlplayer.MaxLevel.ToString("#,0"));
            AddLabel(25, 45, 1161, "Level At:");
            AddLabel(82, 45, 1152, "" + xmlplayer.ToLevell.ToString("#,0"));
            AddLabel(187, 45, 1152, "" + GetPercentage((int)xmlplayer.Expp, xmlplayer.ToLevell, 2) + "%");
            AddLabel(180, 45, 1161, "(" + AddSpaces(GetPercentage((int)xmlplayer.Expp, xmlplayer.ToLevell, 2) + "%") + "  Reached)");
            AddLabel(31, 55, 1153, "____________________________");
            
            double ShowBarAt = xmlplayer.ToLevell / 100;
            double NextExtendAt = 0;
            int LengthOfBar = 0;

            if (NextExtendAt == 0)
                NextExtendAt = ShowBarAt;

            for (int i = 0; xmlplayer.Expp >= NextExtendAt; i++)
            {
                NextExtendAt += ShowBarAt;
                LengthOfBar = (int)(2.24 * i);
            }

            AddImageTiled(30, 70, LengthOfBar, 15, 58);//x, y, Width, Heigth, ID
            AddLabel(26, 68, 1153, "(____________________________)");
        }

        public static string AddSpaces(string SpaceNeeded)
        {
            int Number = 0;
            string Spaces = "";

            for (int i = 0; i < SpaceNeeded.Length; i++)
            {
                if (i == 0)
                    Number = 1;
                else
                    Number = i;
            }

            while (Spaces.Length < Number)
            { Spaces += " "; }

            return Spaces;
        }

        public static string GetPercentage(int value, int total, int places)
        {
            Decimal percent = 0;
            string retval = string.Empty;
            String strplaces = new String('0', places);
            
            if (value == 0 || total == 0)
            { percent = 0; }
            else
            {
                percent = Decimal.Divide(value, total) * 100;

                if (places > 0)
                { strplaces = "." + strplaces; }
            }

            retval = percent.ToString("#" + strplaces);
            return retval;
        }
    }
}