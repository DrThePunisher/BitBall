using System;
using System.Collections.Generic;
using System.Linq;

namespace BitBall.Helpers
{
    /// <summary>
    /// Extension class for adding functionality to IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Shuffle the collection randomly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
        {
            // Further reading: http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
            int randomIndex = 0;
            List<T> list = null;
            T currentObject = default(T);

            if (source != null && random != null)
            {
                // Convert to list so we can play with indexes
                list = source.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    // Get random index - apparently if this starts at 0 it could cause bias...
                    randomIndex = random.Next(i, list.Count);

                    // Swap object at current index with object at random index
                    currentObject = list[i];
                    list[i] = list[randomIndex];
                    list[randomIndex] = currentObject;
                }
            }

            return source;
        }
    }
}
