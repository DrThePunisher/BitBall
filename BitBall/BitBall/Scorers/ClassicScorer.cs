
namespace BitBall.Scorers
{
    class ClassicScorer : IScorer
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
                    score = 1;
                    break;
                case 2:
                    score = 2;
                    break;
                case 3:
                    score = 4;
                    break;
                case 4:
                    score = 8;
                    break;
            }

            return score;
        }
    }
}
