using System.Collections;

namespace BowlingKata
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];

        private int _currentRollIndex;
        private int _totalScore;

        public void Roll(int pinsKnocked)
        {
            _rolls[_currentRollIndex++] += pinsKnocked;
        }
        
        public int GetScore()
        {
            _currentRollIndex = 0;
            
            for (int i = 0; i < 10; i++)
            {
                if (IsStrike())
                {
                    AddStrikeBonus();
                }
                else if (IsSpare())
                {
                    AddSpareBonus();
                }
                else
                {
                    AddRegularScore();
                }
            }

            return _totalScore;
        }

        private void AddStrikeBonus()
        {
            int nextFrameScoreTotal = _rolls[_currentRollIndex + 1] + _rolls[_currentRollIndex + 2];
            
            _totalScore += 10 + nextFrameScoreTotal;
            _currentRollIndex += 1;
        }

        private void AddRegularScore()
        {
            _totalScore += _rolls[_currentRollIndex] + _rolls[_currentRollIndex + 1];
            _currentRollIndex += 2;
        }

        private bool IsStrike()
        {
            return _rolls[_currentRollIndex] == 10;
        }

        private bool IsSpare()
        {
            return _rolls[_currentRollIndex] + _rolls[_currentRollIndex + 1] == 10;
        }

        private void AddSpareBonus()
        {
            _totalScore += 10 + _rolls[_currentRollIndex + 2];
            _currentRollIndex += 2;
        }
    }
}