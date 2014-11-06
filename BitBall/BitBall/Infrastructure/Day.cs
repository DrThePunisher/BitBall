using System.Collections.Generic;
using System.Linq;

namespace BitBall.Infrastructure
{
    /// <summary>
    /// A day of up to 5 rounds
    /// </summary>
    public class Day
    {
        List<Round> rounds;

        /// <summary>
        /// Constructor
        /// </summary>
        public Day()
        {
            rounds = new List<Round>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A day is done if one of its rounds have been accepted
        /// </summary>
        public bool Done()
        {
            bool done = false;

            foreach (Round round in Rounds)
            {
                if (round.Accepted)
                {
                    done = true;
                }
            }

            return done;
        }

        /// <summary>
        /// Get the round with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Round GetRound(int id)
        {
            return Rounds.Where(o => o.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// The rounds of bitball played this day; one of these should be accepted
        /// </summary>
        public List<Round> Rounds { get { return rounds; } }
    }
}
