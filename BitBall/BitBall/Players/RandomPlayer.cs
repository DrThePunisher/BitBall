
using BitBall.Helpers;
using System;

namespace BitBall.Players
{
    /// <summary>
    /// A random BitBall player
    /// </summary>
    public class RandomPlayer : BasePlayer
    {
        public RandomPlayer()
        {
            Name = "Randy";
        }

        /// <summary>
        /// Player shoots
        /// </summary>
        /// <returns></returns>
        public override bool Shoot()
        {
            // Shoot might be a bad candidate for being handled by the player object...
            Random random = ThreadSafeRandom.ThisThreadsRandom;
            int randy = random.Next(0, 2);
            return (randy == 0);
        }

        /// <summary>
        /// Randy always wants to shoot...
        /// </summary>
        /// <returns></returns>
        public override bool WantsToShoot()
        {
            return true;
        }
    }
}
