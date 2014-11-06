
namespace BitBall.Infrastructure
{
    /// <summary>
    /// A round of 4 shots
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Round()
        {
            Accepted = false;
            Attempt = 0;
            Number = 0;
            ShotsAttempted = 0;
            ShotsMade = 0;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// If this series of shots has been accepted for the current round
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Current shot attempt
        /// </summary>
        public int Attempt { get; set; }

        /// <summary>
        /// The number of this round ie Round 1, Round 2, etc
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Total shots attempted so far
        /// </summary>
        public int ShotsAttempted { get; set; }

        /// <summary>
        /// Total shots made so far
        /// </summary>
        public int ShotsMade { get; set; }
    }
}
