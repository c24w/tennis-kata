using System.Collections.Generic;

namespace TennisScoring
{
    public class ScoreBuilder
    {
        private readonly GameScorer _gameScorer;

        private readonly Dictionary<int, string> _scoreWord = new Dictionary<int, string>
            {
                {0, "Love"},
                {15, "Fifteen"},
                {30, "Thirty"},
                {40, "Forty"},
            };

        public ScoreBuilder(GameScorer gameScorer)
        {
            _gameScorer = gameScorer;
        }

        public override string ToString()
        {
            if (_gameScorer.AdvantageSet())
                return string.Format("Advantage {0}", _gameScorer.Advantage.Name);

            int score1 = _gameScorer.Player1.Score;
            int score2 = _gameScorer.Player2.Score;

            if (score1 == 40 && score2 == 40)
                return "Deuce";

            if (score1 == score2)
                return string.Format("{0}-all", _scoreWord[score1]);

            return string.Format(
                "{0} - {1}",
                _scoreWord[score1],
                _scoreWord[score2]
                );
        }
    }
}