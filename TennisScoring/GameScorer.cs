namespace TennisScoring
{
    public class GameScorer
    {
        public readonly Player Player1;
        public readonly Player Player2;
        public Player Advantage { get; private set; }
        public Player Winner { get; private set; }

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

        public bool AnyPlayerHasAdvantage()
        {
            return Advantage != null;
        }

        public bool HasWinner()
        {
            return Winner != null;
        }

        void ScorePlayers(Player pointWinner, Player pointLoser)
        {
            if (HasWinner())
                return;

            if (Advantage == pointWinner)
            {
                Winner = pointWinner;
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

                Winner = pointWinner;
                return;
            }
            
            pointWinner.IncrementScore();
        }
    }
}