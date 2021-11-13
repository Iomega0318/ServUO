using Server.Gumps;
using Server.Mobiles;

namespace Server.RandomEvent
{
    public class GameClockGump : Gump
    {
        public GameClockGump(PlayerMobile pm, string time) : base (550, 50)
        {
            if (pm != null && pm.HasGump(typeof(GameClockGump)))
                pm.CloseGump(typeof(GameClockGump));

            Closable = false;
            Dragable = true;

            AddImage(0, 0, 1764);
            AddLabel(20, 14, 1153, $"Game Time : {time}");
        }
    }
}
