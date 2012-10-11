namespace TennisScoring
{
    public class Player
    {
        public int Score { get; private set; }

        public void IncrementScore()
        {
            Score = GetNextScore();
        }

        private int GetNextScore()
        {
            switch (Score)
            {
                case 0:
                    return 15;
                case 15:
                    return 30;
                case 30:
                    return 40;
                default:
                    return 0;
            }
        }
    }
}