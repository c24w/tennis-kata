using System.Collections.Generic;
using NUnit.Framework;

namespace TennisScoring.Unit.Tests
{
    [TestFixture]
    public class ScoreBuilderTests
    {
        private GameScorer _gameScorer;
        private ScoreBuilder _scoreBuilder;

        [SetUp]
        public void SetUp()
        {
            _gameScorer = new GameScorer(new Player(), new Player());
            _scoreBuilder = new ScoreBuilder(_gameScorer);
        }

        [Test]
        [TestCase(0, 0, "Love all")]
        [TestCase(1, 2, "Fifteen - Thirty")]
        [TestCase(2, 3, "Thirty - Forty")]
        [TestCase(0, 3, "Love - Forty")]
        [TestCase(3, 1, "Forty - Fifteen")]
        [TestCase(1, 1, "Fifteen all")]
        [TestCase(2, 2, "Thirty all")]
        [TestCase(3, 3, "Deuce")]
        [TestCase(4, 3, "Deuce")]
        public void Points_won_returns_expected_score_string(int player1PointsWon, int player2PointsWon, string expected)
        {
            for (int i = 0; i < player1PointsWon; i++)
                _gameScorer.Player1WinsPoint();

            for (int i = 0; i < player2PointsWon; i++)
                _gameScorer.Player2WinsPoint();

            Assert.That(_scoreBuilder.ToString(), Is.EqualTo(expected));
        }
    }

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
            int score1 = _gameScorer.Player1.Score;
            int score2 = _gameScorer.Player2.Score;

            if (score1 == 40 && score2 == 40)
                return "Deuce";

            if (score1 == score2)
                return string.Format("{0} all", _scoreWord[score1]);

            return string.Format(
                "{0} - {1}",
                _scoreWord[score1],
                _scoreWord[score2]
            );
        }
    }
}