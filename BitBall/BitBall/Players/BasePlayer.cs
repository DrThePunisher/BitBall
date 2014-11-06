
using BitBall.Infrastructure;
using BitBall.Scorers;
using System.Collections.Generic;

namespace BitBall.Players
{
    /// <summary>
    /// Functionality probably common to all players
    /// </summary>
    public abstract class BasePlayer : IPlayer
    {
        /// <summary>
        /// The player's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The player's scorecard, containing all their stats
        /// </summary>
        public Scorecard Scorecard { get; set; }

        /// <summary>
        /// Any modifier to a player's odds for making a shot
        /// </summary>
        public virtual double OddsModifier { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info = string.Empty;

            if (Scorecard != null)
            {
                info = string.Format("{0}: {1}", Name, Scorecard.GameScore.ToString("00"));

                //foreach (int basket in Baskets)
                //{
                //    info = String.Format("{0} | {2} ({1})", info, basket, Scorer.GetScore(basket));
                //}
            }

            return info;
        }

        /// <summary>
        /// The player's shoot action - inheriting classes must implement
        /// </summary>
        /// <returns></returns>
        public abstract bool Shoot();

        /// <summary>
        /// The player's decision if they should shoot or not - inheriting classes must implement
        /// </summary>
        /// <returns></returns>
        public abstract bool WantsToShoot();
    }
}
