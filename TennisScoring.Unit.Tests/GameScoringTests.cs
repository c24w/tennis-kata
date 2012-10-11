using NUnit.Framework;

namespace TennisScoring.Unit.Tests
{
    [TestFixture]
    public class GameScoringTests
    {
        private GameScorer _gameScorer;
        private Player _player1;
        private Player _player2;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _gameScorer = new GameScorer(_player1, _player2);
        }

        [Test]
        public void Player_scores_start_at_love()
        {
            Assert.That(_gameScorer.Player1.Score, Is.EqualTo(0));
            Assert.That(_gameScorer.Player2.Score, Is.EqualTo(0));
        }

        [Test]
        [TestCase(1, 15)]
        [TestCase(2, 30)]
        [TestCase(3, 40)]
        public void Player_score_corresponds_to_number_of_points_won(int pointsWon, int expectedScore)
        {
            for (int i = 0; i < pointsWon; i++)
            {
                _gameScorer.ScorePlayer1();
                _gameScorer.ScorePlayer2();
            }

            Assert.That(_gameScorer.Player1.Score, Is.EqualTo(expectedScore));
            Assert.That(_gameScorer.Player2.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Player_has_advantage_when_winning_the_point_after_deuce()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameScorer.ScorePlayer1();
                _gameScorer.ScorePlayer2();
            }

            _gameScorer.ScorePlayer1();

            Assert.That(_gameScorer.Advantage, Is.EqualTo(_player1));
        }

        [Test]
        public void Score_is_deuce_and_advantage_is_removed_when_advantage_holder_loses_the_subsequent_point()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameScorer.ScorePlayer1();
                _gameScorer.ScorePlayer2();
            }

            _gameScorer.ScorePlayer1();
            _gameScorer.ScorePlayer2();

            Assert.That(_gameScorer.Player1.Score, Is.EqualTo(40));
            Assert.That(_gameScorer.Player2.Score, Is.EqualTo(40));

            Assert.That(_gameScorer.AdvantageSet(), Is.EqualTo(false));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Player_wins_the_game_by_winning_four_points_by_two_clear_points(int opponentPointsWon)
        {
            for (int i = 0; i < opponentPointsWon; i++)
                _gameScorer.ScorePlayer2();
            
            for (int i = 0; i < 4; i++)
                _gameScorer.ScorePlayer1();
            
            Assert.That(_gameScorer.GetWinner(), Is.EqualTo(_player1));
        }

        [Test]
        public void Player_wins_the_game_by_winning_a_point_while_having_the_advantage()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameScorer.ScorePlayer1();
                _gameScorer.ScorePlayer2();
            }

            _gameScorer.ScorePlayer1();
            _gameScorer.ScorePlayer1();

            Assert.That(_gameScorer.Advantage, Is.EqualTo(_player1));

            Assert.That(_gameScorer.GetWinner(), Is.EqualTo(_player1));
        }

        [Test]
        public void Scores_do_not_change_once_a_winner_has_been_set()
        {
            
        }
    }
}
