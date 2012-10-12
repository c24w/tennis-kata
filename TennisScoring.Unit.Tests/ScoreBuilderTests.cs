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
            _gameScorer = new GameScorer(new Player("Player 1"), new Player("Player 2"));
            _scoreBuilder = new ScoreBuilder(_gameScorer);
        }

        [Test]
        [TestCase(1, 2, "Fifteen - Thirty")]
        [TestCase(2, 3, "Thirty - Forty")]
        [TestCase(0, 3, "Love - Forty")]
        [TestCase(3, 1, "Forty - Fifteen")]
        [TestCase(0, 0, "Love-all")]
        [TestCase(1, 1, "Fifteen-all")]
        [TestCase(2, 2, "Thirty-all")]
        [TestCase(3, 3, "Deuce")]
        public void Points_won_returns_expected_score_string(int player1PointsWon, int player2PointsWon, string expected)
        {
            for (int i = 0; i < player1PointsWon; i++)
                _gameScorer.ScorePlayer1();

            for (int i = 0; i < player2PointsWon; i++)
                _gameScorer.ScorePlayer2();

            Assert.That(_scoreBuilder.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void When_a_player_has_advantage_the_expected_string_is_returned()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameScorer.ScorePlayer1();
                _gameScorer.ScorePlayer2();
            }

            _gameScorer.ScorePlayer1();

            Assert.That(_scoreBuilder.ToString(), Is.EqualTo("Advantage Player 1"));
        }

        [Test]
        [TestCase(4, 0, "Player 1 wins!")]
        [TestCase(4, 1, "Player 1 wins!")]
        [TestCase(2, 4, "Player 2 wins!")]
        [TestCase(3, 5, "Player 2 wins!")]
        [TestCase(10, 12, "Player 2 wins!")]
        public void When_a_player_wins_the_expected_string_is_returned(int player1PointsWon, int player2PointsWon, string expected)
        {
            for (int i = 0; i < player1PointsWon; i++)
                _gameScorer.ScorePlayer1();

            for (int i = 0; i < player2PointsWon; i++)
                _gameScorer.ScorePlayer2();

            Assert.That(_scoreBuilder.ToString(), Is.EqualTo(expected));
        }

    }
}