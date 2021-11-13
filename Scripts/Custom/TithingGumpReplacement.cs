using System;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Commands;

namespace Server.Gumps
{

	public class TithingGump2 : Gump
	{
        public Mobile m_From;
        int m_PlayerGold = 0;

		public TithingGump2(Mobile from) 
			: base(0, 0)
		{
            ComputeGold(from);

			Dragable = true;
			Closable = true;
			Resizable = false;
			Disposable = false;


            AddPage(0);
			AddImageTiled(200, 180, 262, 320, 3504); 
			AddImageTiled(460, 180, 5, 324, 2701); 
			AddImageTiled(200, 180, 5, 323, 2701); 
			AddImageTiled(200, 180, 261, 4, 2700); 
			AddImageTiled(200, 500, 261, 4, 2700); 
            AddImageTiled(257, 282, 150, 4, 2700); 
			AddImageTiled(257, 312, 150, 4, 2700); 
			AddImageTiled(257, 282, 5, 32, 2701); 
			AddImageTiled(402, 283, 5, 32, 2701); 
			AddItem(180, 178, 2); 
			AddItem(200, 178, 3); 
			AddItem(421, 179, 4); 
			AddItem(442, 179, 5); 
			AddItem(363, 286, 3823); 
			AddItem(220, 230, 2988); 
			AddItem(400, 230, 2987); 
			AddItem(310, 260, 5629);            
            AddHtml(260, 190, 145, 68, "<basefont size=5 color=#121314><center>How much gold" +
              "<basefont size=5 color=#121314><center>would you like"+
            "<basefont size=5 color=#121314><center>to Tithe?", false, false);
            AddLabel(274, 292, 0, String.Format("Gold : {0:0,0}", m_PlayerGold));

			AddButton(214, 323, 2118, 2117, 1, GumpButtonType.Reply, 0);
			AddHtml(230, 320, 100, 23, "<basefont size=5 color=#121314>10 Gold", false, false);
			AddButton(334, 323, 2118, 2117, 2, GumpButtonType.Reply, 0);
			AddHtml(350, 320, 100, 23, "<basefont size=5 color=#121314>25 Gold", false, false);
			AddButton(214, 353, 2118, 2117, 3, GumpButtonType.Reply, 0);
			AddHtml(230, 350, 100, 23, "<basefont size=5 color=#121314>50 Gold", false, false);
			AddButton(334, 353, 2118, 2117, 4, GumpButtonType.Reply, 0);
			AddHtml(350, 350, 100, 23, "<basefont size=5 color=#121314>100 Gold", false, false);
			AddButton(214, 383, 2118, 2117, 5, GumpButtonType.Reply, 0);
			AddHtml(230, 380, 100, 23, "<basefont size=5 color=#121314>250 Gold", false, false);
			AddButton(334, 383, 2118, 2117, 6, GumpButtonType.Reply, 0);
			AddHtml(350, 380, 100, 23, "<basefont size=5 color=#121314>500 Gold", false, false);
			AddButton(214, 413, 2118, 2117, 7, GumpButtonType.Reply, 0);
			AddHtml(230, 410, 100, 23, "<basefont size=5 color=#121314>1,000 Gold", false, false);
			AddButton(334, 413, 2118, 2117, 8, GumpButtonType.Reply, 0);
			AddHtml(350, 410, 100, 23, "<basefont size=5 color=#121314>2,500 Gold", false, false);
			AddButton(214, 443, 2118, 2117, 9, GumpButtonType.Reply, 0);
			AddHtml(230, 440, 100, 23, "<basefont size=5 color=#121314>5,000 Gold", false, false);
			AddButton(334, 443, 2118, 2117, 10, GumpButtonType.Reply, 0);
			AddHtml(350, 440, 100, 23, "<basefont size=5 color=#121314>10,000 Gold", false, false);
			AddButton(214, 473, 2118, 2117, 11, GumpButtonType.Reply, 0);
			AddHtml(230, 470, 100, 23, "<basefont size=5 color=#121314>25,000 Gold", false, false);
			AddButton(334, 473, 2118, 2117, 12, GumpButtonType.Reply, 0);
			AddHtml(350, 470, 100, 23, "<basefont size=5 color=#121314>50,000 Gold", false, false);
		}
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile; 

            switch ( info.ButtonID ) 
            { 
            case 0: //Close Gump 
                {
                from.SendMessage("You decided not to tithe anything");
                break; 
                }
            case 1: //Close Gump 
            { 
                if (from.Backpack.ConsumeTotal( typeof( Gold ), 10 ))
                {
                from.TithingPoints += 10;
                from.SendMessage("You tithed 10 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 10 ))
                {
                from.TithingPoints += 10;
                from.SendMessage("You tithed 10 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 2: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 25 ))
                {
                from.TithingPoints += 25;
                from.SendMessage("You tithed 25 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 25 ))
                {
                from.TithingPoints += 25;
                from.SendMessage("You tithed 25 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 3: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 50 ))
                {
                from.TithingPoints += 50;
                from.SendMessage("You tithed 50 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 50 ))
                {
                from.TithingPoints += 50;
                from.SendMessage("You tithed 50 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 4: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 100 ))
                {
                from.TithingPoints += 100;
                from.SendMessage("You tithed 100 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 100 ))
                {
                from.TithingPoints += 100;
                from.SendMessage("You tithed 100 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 5: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 250 ))
                {
                from.TithingPoints += 250;
                from.SendMessage("You tithed 250 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 250 ))
                {
                from.TithingPoints += 250;
                from.SendMessage("You tithed 250 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 6: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 500 ))
                {
                from.TithingPoints += 500;
                from.SendMessage("You tithed 500 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 500 ))
                {
                from.TithingPoints += 500;
                from.SendMessage("You tithed 500 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            }
            case 7: //Close Gump 
            { 
              if (from.Backpack.ConsumeTotal( typeof( Gold ), 1000 ))
                {
                from.TithingPoints += 1000;
                from.SendMessage("You tithed 1000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 1000 ))
                {
                from.TithingPoints += 1000;
                from.SendMessage("You tithed 1000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 8: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 2500 ))
                {
                from.TithingPoints += 2500;
                from.SendMessage("You tithed 2500 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 2500 ))
                {
                from.TithingPoints += 2500;
                from.SendMessage("You tithed 2500 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 9: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 5000 ))
                {
                from.TithingPoints += 5000;
                from.SendMessage("You tithed 5000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 5000 ))
                {
                from.TithingPoints += 5000;
                from.SendMessage("You tithed 5000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            }  
            case 10: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 10000 ))
                {
                from.TithingPoints += 10000;
                from.SendMessage("You tithed 10000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 10000 ))
                {
                from.TithingPoints += 10000;
                from.SendMessage("You tithed 10000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 11: //Close Gump 
            { 
               if (from.Backpack.ConsumeTotal( typeof( Gold ), 25000 ))
                {
                from.TithingPoints += 25000;
                from.SendMessage("You tithed 25000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 25000 ))
                {
                from.TithingPoints += 25000;
                from.SendMessage("You tithed 25000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            } 
            case 12: //Close Gump 
            { 
              if (from.Backpack.ConsumeTotal( typeof( Gold ), 50000 ))
                {
                from.TithingPoints += 50000;
                from.SendMessage("You tithed 50000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                }
                else if (from.BankBox.ConsumeTotal( typeof( Gold ), 50000 ))
                {
                from.TithingPoints += 50000;
                from.SendMessage("You tithed 50000 gold from your pack");
                from.PlaySound(0x243);
                from.PlaySound(0x2E6);
                } 
                else from.SendMessage("You decided not to tithe");
                break; 
            }
        }
    }
    public void ComputeGold(Mobile from)
        {
            int goldInPack = 0;
            int goldInBank = 0;
            foreach (Gold gold in from.Backpack.FindItemsByType<Gold>(true))
            {
                goldInPack += gold.Amount;
            }

            foreach (Gold gold in from.BankBox.FindItemsByType<Gold>(true))
            {
                goldInBank += gold.Amount;
            }

            m_PlayerGold = goldInPack + goldInBank;
        }
    }
}