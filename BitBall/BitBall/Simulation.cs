
using BitBall.Scorers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitBall
{
    class Simulation
    {
        static void Main(string[] args)
        {
            IScorer scorer = new CurrentScorer();
            Odds odds = new Odds(0.35);
            Random random = new Random();
            List<Player> players = new List<Player>();
            players.Add(new Player("Kevin  ", scorer, random, odds));
            players.Add(new Player("John   ", scorer, random, odds));
            players.Add(new Player("Glenn  ", scorer, random, odds));
            players.Add(new Player("Soren  ", scorer, random, odds));
            players.Add(new Player("Lindsey", scorer, random, odds));
            players.Add(new Player("Rommel ", scorer, random, odds));

            do
            {
                foreach (Player p in players)
                {
                    p.PlayWeek();
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("Winner: {0}", players.OrderByDescending(o => o.Scores.Sum()).Select(o => o.Name).FirstOrDefault());
                Console.WriteLine("Gap: {0} - {1}", players.Min(o => o.Scores.Sum()), players.Max(o => o.Scores.Sum()));
                Console.WriteLine(odds.PrintStats());
            } while (Console.ReadLine() != "q");
        }
    }

    class Odds
    {
        double chanceZero;
        double chanceOne;
        double chanceTwo;
        double chanceThree;

        int totalAttempts = 0;
        double totalZeros = 0;
        double totalOnes = 0;
        double totalTwos = 0;
        double totalThrees = 0;
        double totalFours = 0;

        public Odds(double chanceSuccess)
        {
            chanceZero = Math.Pow(1 - chanceSuccess, 4);
            chanceOne = chanceZero + 4 * Math.Pow(1 - chanceSuccess, 3) * chanceSuccess;
            chanceTwo = chanceOne + 6 * Math.Pow(1 - chanceSuccess, 2) * Math.Pow(chanceSuccess, 2);
            chanceThree = chanceTwo + 4 * (1 - chanceSuccess) * Math.Pow(chanceSuccess, 3);
        }

        public int GetBasketsMade(double random)
        {
            int basketsMade;
            totalAttempts++;
            if (random <= chanceZero)
            {
                totalZeros++;
                basketsMade = 0;
            }
            else if (random <= chanceOne)
            {
                totalOnes++;
                basketsMade = 1;
            }
            else if (random <= chanceTwo)
            {
                totalTwos++;
                basketsMade = 2;
            }
            else if (random <= chanceThree)
            {
                totalThrees++;
                basketsMade = 3;
            }
            else
            {
                totalFours++;
                basketsMade = 4;
            }
            return basketsMade;
        }

        public string PrintStats()
        {
            return String.Format("Total Shots: {0} | 0s: {1} | 1s: {2} | 2s: {3} | 3s: {4} | 4s: {5}",
                                 totalAttempts,
                                 ((double)(totalZeros / totalAttempts) * 100).ToString("00.00"),
                                 ((double)(totalOnes / totalAttempts) * 100).ToString("00.00"),
                                 ((double)(totalTwos / totalAttempts) * 100).ToString("00.00"),
                                 ((double)(totalThrees / totalAttempts) * 100).ToString("00.00"),
                                 ((double)(totalFours / totalAttempts) * 100).ToString("00.00"));
        }
    }

    class Player
    {
        public string Name { get; set; }
        public List<int> Baskets { get; set; }
        public List<int> Scores { get; set; }
        IScorer Scorer { get; set; }
        Random random;
        Odds odds;

        public Player(string Name, IScorer Scorer, Random random, Odds odds)
        {
            this.Name = Name;
            Baskets = new List<int>();
            Scores = new List<int>();
            this.Scorer = Scorer;
            this.random = random;
            this.odds = odds;
        }

        public void PlayWeek()
        {
            SetRandomBaskets();
            SetScoresBasedOnBaskets();
        }

        public override string ToString()
        {
            string info = String.Format("{0}: {1}", Name, Scores.Sum().ToString("00"));

            foreach (int basket in Baskets)
            {
                info = String.Format("{0} | {2} ({1})", info, basket, Scorer.GetScore(basket));
            }

            return info;
        }

        private void SetRandomBaskets()
        {
            Baskets.Clear();
            for (int i = 0; i < 4; i++)
            {
                Baskets.Add(odds.GetBasketsMade(random.NextDouble()));
            }
        }

        private void SetScoresBasedOnBaskets()
        {
            Scores.Clear();
            foreach (int shotsMade in Baskets)
            {
                Scores.Add(Scorer.GetScore(shotsMade));
            }
        }
    }
}
