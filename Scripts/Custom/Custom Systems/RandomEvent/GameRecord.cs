namespace Server.RandomEvent
{
    public class GameRecord
    {
        public int GameType { get; set; }

        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Points { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Gold { get; set; }

        public GameRecord(int game)
        {
            GameType = game;

            Wins = 0;
            Loses = 0;
            Points = 0;
            Kills = 0;
            Deaths = 0;
            Gold = 0;
        }
    }
}
