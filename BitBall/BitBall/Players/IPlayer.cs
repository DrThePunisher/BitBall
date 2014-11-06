
using BitBall.Infrastructure;

namespace BitBall.Players
{
    /// <summary>
    /// An interface for BitBall players
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The player's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Any modifier to a player's odds for making a shot
        /// </summary>
        double OddsModifier { get; set; }

        /// <summary>
        /// The player's scorecard, containing all their stats
        /// </summary>
        Scorecard Scorecard { get; set; }

        /// <summary>
        /// Player shoots
        /// </summary>
        /// <returns></returns>
        bool Shoot();

        /// <summary>
        /// Player will decide whether or not to shoot
        /// </summary>
        /// <returns></returns>
        bool WantsToShoot();

        /// <summary>
        /// Display player as a string
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
