using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.RandomEvent
{
    public class GameGump : Gump
    {
        private int Stage { get; set; }

        public GameGump(int stage, int team1 = 0, int team2 = 0) : base(50, 50)
        {
            Stage = stage;

            Closable = false;
            Dragable = true;

            AddImage(0, 0, 1764);

            if (Stage == 99)
            {
                AddLabel(20, 14, 1153, "Play Solo Quest?");

                AddButton(160, 17, 11400, 11402, 11, GumpButtonType.Reply, 0); //Accept

                AddButton(180, 17, 11410, 11412, 12, GumpButtonType.Reply, 0); //Cancel
            }
            else
            {
                if (Stage == 1)
                {
                    AddLabel(20, 14, 1153, "Join Next Event?");

                    AddButton(160, 17, 11400, 11402, 1, GumpButtonType.Reply, 0); //Accept

                    AddButton(180, 17, 11410, 11412, 2, GumpButtonType.Reply, 0); //Cancel
                }
                else if (stage == 2)
                {
                    if (GameMain.GameSetUpDelay - GameMain.GameCounter > 1)
                        AddLabel(13, 14, 53, "Waiting to join players");
                    else
                        AddLabel(13, 14, 37, "Waiting to join players");

                    AddButton(180, 17, 11410, 11412, 2, GumpButtonType.Reply, 0); //Cancel

                }
                else if (stage == 3)
                {
                    if (GameMain.GameCounter > GameMain.GameLength - 2)
                        AddLabel(13, 14, 37, "Ending: " + GameMain.GameType.ToString().Replace('_', ' '));
                    else
                        AddLabel(13, 14, 53, "Active: " + GameMain.GameType.ToString().Replace('_', ' '));

                    AddButton(180, 17, 11410, 11412, 2, GumpButtonType.Reply, 0); //Cancel
                }
                else if (stage == 4)
                {
                    if (team1 > team2)
                        AddLabel(13, 14, 62, "Your score was " + team1 + " vs " + team2);
                    else if (team1 < team2)
                        AddLabel(13, 14, 37, "Your score was " + team1 + " vs " + team2);
                    else if (team1 == team2)
                        AddLabel(13, 14, 53, "Your score was " + team1 + " vs " + team2);
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile pm = sender.Mobile as PlayerMobile;

            if (pm.HasGump(typeof(GameStoreGump)))
                pm.CloseGump(typeof(GameStoreGump));

            switch (info.ButtonID)
            {
                case 0:
                    break;
                case 1:
                    {
                        GameMain.GameCounter = 0;

                        if (GameMain.TeamOne.Count > GameMain.TeamTwo.Count)
                            GameMain.TeamTwo.Add(pm);
                        else
                            GameMain.TeamOne.Add(pm);

                        GameMain.SendMessageToBoth(62, pm.Name + ", has joined " + GameMain.GameType.ToString().Replace('_', ' '), 2);

                        pm.SendGump(new GameStoreGump(pm, false));

                        sender.Mobile.PlaySound(0x66C);
                    }
                    break;
                case 2:
                    {
                        if (Stage == 1)
                        {
                            GameMain.OptOut.Add(pm);

                            pm.SendGump(new GameGump(99));
                        }
                        else if (Stage == 2)
                        {
                            if (GameMain.TeamOne.Contains(pm))
                                GameMain.TeamOne.Remove(pm);

                            if (GameMain.TeamTwo.Contains(pm))
                                GameMain.TeamTwo.Remove(pm);

                            GameMain.SendMessageToBoth(62, pm.Name + ", has left " + GameMain.GameType.ToString().Replace('_', ' '), 2);

                            GameMain.OptOut.Add(pm);
                        }
                        else
                        {
                            bool HasFlag = false;

                            if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
                            {
                                if (pm.Backpack.FindItemByType(typeof(CTFFlag)) is CTFFlag flag)
                                {
                                    HasFlag = true;
                                    pm.SendMessage(pm.Name + ", you have the flag, you can not leave the game with it!");
                                }
                            }

                            if (!HasFlag)
                            {
                                GameMain.ReturnPlayer(pm);
                            }
                        }

                        if (pm.HasGump(typeof(GameClockGump)))
                            pm.CloseGump(typeof(GameClockGump));
                    }
                    break;
                case 11:
                    pm.SendMessage(62, pm.Name + ", you have started a solo quest, good luck!");
                    pm.AddToBackpack(new QuestPlayer(pm, Utility.RandomMinMax(10, 45)));
                    pm.PlaySound(0x5B4);
                    break;
                case 12:
                    if (pm.HasGump(typeof(GameClockGump)))
                        pm.CloseGump(typeof(GameClockGump));
                    break;
                default:
                    break;
            }
        }
    }
}
