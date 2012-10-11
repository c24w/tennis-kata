namespace TennisScoring
{
    public class GameScorer
    {
        public readonly Player Player1;
        public readonly Player Player2;
        private Player _winner;
        private Player _advantage;

        public GameScorer(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void Player1WinsPoint()
        {
            ScorePlayers(Player1, Player2);
        }

        public void Player2WinsPoint()
        {
            ScorePlayers(Player2, Player1);
        }

        public bool Player1HasAdvantage()
        {
            return _advantage == Player1;
        }

        public bool Player2HasAdvantage()
        {
            return _advantage == Player2;
        }

        void ScorePlayers(Player pointWinner, Player pointLoser)
        {
            if (_advantage == pointWinner)
            {
                _winner = pointWinner;
                return;
            }

            if (_advantage == pointLoser)
            {
                _advantage = null;
                return;
            }
            
            if (pointWinner.Score == 40)
            {
                if (pointLoser.Score == 40)
                {
                    _advantage = pointWinner;
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