
using BitBall.Scorers;
using System.Collections.Generic;
using System.Linq;

namespace BitBall.Infrastructure
{
    /// <summary>
    /// A BitBall Scorecard
    /// </summary>
    public class Scorecard
    {
        IScorer scorer;
        private List<Day> days = new List<Day>();

        /// <summary>
        /// Constructor, uses ClassicScorer
        /// </summary>
        public Scorecard()
        {
            scorer = new ClassicScorer();
        }

        /// <summary>
        /// Constructor, uses any IScorer implementation
        /// </summary>
        /// <param name="scorer"></param>
        public Scorecard(IScorer scorer)
        {
            this.scorer = scorer;
        }
        /// <summary>
        /// The current score of the game
        /// </summary>
        public int GameScore
        {
            get
            {
                int score = 0;

                foreach (Day day in Days)
                {
                    foreach (Round round in day.Rounds)
                    {
                        if (round != null && round.Accepted)
                        {
                            score += scorer.GetScore(round.ShotsMade);
                        }
                    }
                }

                return score;
            }
        }

        /// <summary>
        /// Get the day with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Day GetDay(int id)
        {
            return Days.Where(o => o.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// List of days on which a game of bitball is played, usually 4
        /// </summary>
        public List<Day> Days { get { return days; } }
    }
}
