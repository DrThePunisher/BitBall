
namespace BitBall.Scorers
{
    public class CurrentScorer : IScorer
    {
        public int GetScore(int basketsMade)
        {
            int score = 0;
            
            switch (basketsMade)
            {
                case 0:
                    score = 0;
                    break;
                case 1:
                    score = 2;
                    break;
                case 2:
                    score = 4;
                    break;
                case 3:
                    score = 5;
                    break;
                case 4:
                    score = 6;
                    break;
            }

            return score;
        }
    }
}
