using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.RandomEvent
{
    class GameStoreGump : Gump
    {
        PlayerMobile PM { get; set; }
        bool IsStoreOpen { get; set; }

        bool HasRecord { get; set; }
        GameHistory Record { get; set; }

        public GameStoreGump(PlayerMobile pm, bool OpenStore) : base(100, 100)
        {
            PM = pm;
            IsStoreOpen = OpenStore;
            HasRecord = false;

            if (EventBook.BaseGameHistory != null)
            {
                foreach (GameHistory history in EventBook.BaseGameHistory)
                {
                    if (history.Player == pm as PlayerMobile)
                    {
                        Record = history;
                        HasRecord = true;
                    }
                }
            }

            Closable = false;
            Dragable = true;

            if (OpenStore)
            {
                AddImage(0, 0, 40012);
                AddButton(20, 20, 5572, 5571, 1, GumpButtonType.Reply, 0); //Close Store

                if (Record != null)
                    AddLabel(110, 40, 53, "- Event Token Store - You have " + Record.GameTokens.ToString() + " Game Tokens");
                else
                    AddLabel(110, 40, 53, "- Event Token Store - You have no Game Tokens");

                if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
                {
                    AddItem(90, 80, 3530, 1177);
                    AddLabel(150, 90, 1152, "<- Flag Catcher - Cost 50 Game Tokens ->");
                    AddButton(450, 93, 11400, 11402, 2, GumpButtonType.Reply, 0); //Buy Flag Catcher
                }
                else
                {
                    AddItem(90, 80, 3530, 1177);
                    AddLabel(150, 90, 1152, "<- Player Catcher - Cost 50 Game Tokens ->");
                    AddButton(450, 93, 11400, 11402, 2, GumpButtonType.Reply, 0); //Buy Player Catcher
                }

                AddItem(90, 133, 571, 1177);
                AddLabel(150, 130, 1152, "<- Player Bouncer - Cost 75 Game Tokens ->");
                AddButton(450, 133, 11400, 11402, 3, GumpButtonType.Reply, 0); //Buy Player Catcher
            }
            else
            {
                AddButton(20, 20, 5571, 5572, 1, GumpButtonType.Reply, 0); //Open Store
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (IsStoreOpen)
            {
                switch (info.ButtonID)
                {
                    case 1: PM.SendGump(new GameStoreGump(PM, false)); break;

                    case 2:
                        if (HasRecord && Record.GameTokens >= 50)
                        {
                            PM.AddToBackpack(new Catcher(PM));
                            Record.GameTokens -= 50;
                        }
                        else
                        {
                            if (Record != null)
                                PM.SendMessage(PM.Name + ", you can not afford that item, you only have " + Record.GameTokens.ToString() + " Game Tokens");
                            else
                                PM.SendMessage(PM.Name + ", you can not afford that item, you have no Game Tokens");

                        }
                        PM.SendGump(new GameStoreGump(PM, true)); break;

                    case 3:
                        if (HasRecord && Record.GameTokens >= 75)
                        {
                            PM.AddToBackpack(new Bouncer(PM));
                            Record.GameTokens -= 75;
                        }
                        else
                        {
                            if (Record != null)
                                PM.SendMessage(PM.Name + ", you can not afford that item, you only have " + Record.GameTokens.ToString() + " Game Tokens");
                            else
                                PM.SendMessage(PM.Name + ", you can not afford that item, you have no Game Tokens");

                        }
                        PM.SendGump(new GameStoreGump(PM, true)); break;

                    default:
                        break;
                }
            }
            else
            {
                switch (info.ButtonID)
                {
                    case 1: PM.SendGump(new GameStoreGump(PM, true)); break;
                    default:
                        break;
                }
            }
        }
    }
}
