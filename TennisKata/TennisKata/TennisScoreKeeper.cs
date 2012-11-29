using System;

namespace TennisKata
{
    public class TennisScoreKeeper
    {
        private int _player1Score;
        private int _player2Score;
        private bool _gameOver;

        public string CurrentScore
        {
            get
            {
                if (ScoreIsDeuce())
                    return "Deuce";

                if (ScoreDoesNotExceedFortyForEitherPlayer())
                    return string.Format("{0}-{1}", ToWord(_player1Score), ToWord(_player2Score));

                if (EitherPlayerIsAheadByTwoOrMorePoints())
                    return string.Format("Player {0} wins!", WinningPlayer());

                return string.Format("Advantage Player {0}", WinningPlayer());
            }
        }

        private bool ScoreIsDeuce()
        {
            return _player1Score == _player2Score && _player1Score >= Forty;
        }

        private bool ScoreDoesNotExceedFortyForEitherPlayer()
        {
            return !ScoreExceedsFortyForEitherPlayer();
        }

        private bool ScoreExceedsFortyForEitherPlayer()
        {
            return (_player1Score > Forty || _player2Score > Forty);
        }

        private bool EitherPlayerIsAheadByTwoOrMorePoints()
        {
            return Math.Abs(_player1Score - _player2Score) >= 2;
        }

        private Player WinningPlayer()
        {
            return _player1Score > _player2Score ? Player.One : Player.Two;
        }

        public void PointForPlayerOne()
        {
            PointFor(Player.One);
        }

        public void PointForPlayerTwo()
        {
            PointFor(Player.Two);
        }

        private void PointFor(Player player)
        {
            if (_gameOver)
                throw new InvalidOperationException("Game over! No more points allowed!");

            if (player == Player.One)
                _player1Score++;
            else
                _player2Score++;

            _gameOver = ScoreExceedsFortyForEitherPlayer() && EitherPlayerIsAheadByTwoOrMorePoints();
        }

        private static string ToWord(int score)
        {
            return ((Score)(score)).ToString();
        }

        private int Forty { get { return (int)Score.Forty; } }

        private enum Player
        {
            One,
            Two
        }

        private enum Score
        {
            Luv = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }
    }
}