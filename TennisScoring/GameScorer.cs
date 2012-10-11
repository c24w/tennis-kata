namespace TennisScoring
{
    public class GameScorer
    {
        public readonly Player Player1;
        public readonly Player Player2;
        private Player _winner;
        public Player Advantage { get; private set; }

        public GameScorer(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void ScorePlayer1()
        {
            ScorePlayers(Player1, Player2);
        }

        public void ScorePlayer2()
        {
            ScorePlayers(Player2, Player1);
        }

        public bool AdvantageSet()
        {
            return Advantage != null;
        }

        void ScorePlayers(Player pointWinner, Player pointLoser)
        {
            if (Advantage == pointWinner)
            {
                _winner = pointWinner;
                return;
            }

            if (Advantage == pointLoser)
            {
                Advantage = null;
                return;
            }
            
            if (pointWinner.Score == 40)
            {
                if (pointLoser.Score == 40)
                {
                    Advantage = pointWinner;
                    return;
                }

                _winner = pointWinner;
                return;
            }
            
            pointWinner.IncrementScore();
        }

        public bool HasWinner()
        {
            return _winner != null;
        }

        public Player GetWinner()
        {
            return _winner;
        }
    }
}