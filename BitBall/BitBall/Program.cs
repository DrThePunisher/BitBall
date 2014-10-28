using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBall
{
    class Program
    {
        static void Main(string[] args)
        {
            //Scorer scorer = new ClassicBitBallScorer();
            Scorer scorer = new NewScorer();
            Random random = new Random();
            List<Player> players = new List<Player>();
            players.Add(new Player("Kevin  ", scorer, random));
            players.Add(new Player("John   ", scorer, random));
            players.Add(new Player("Glenn  ", scorer, random));
            players.Add(new Player("Soren  ", scorer, random));
            players.Add(new Player("Lindsey", scorer, random));
            players.Add(new Player("Rommel ", scorer, random));

            do
            {
                foreach (Player p in players)
                {
                    p.PlayWeek();
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("Winner: {0}", players.OrderByDescending(o => o.Scores.Sum()).Select(o => o.Name).FirstOrDefault());
                Console.WriteLine("Gap: {0} - {1}", players.Min(o => o.Scores.Sum()), players.Max(o => o.Scores.Sum()));
            } while (Console.ReadLine() != "q");
        }

    }

    class Player
    {
        public string Name { get; set; }
        public List<int> Baskets { get; set; }
        public List<int> Scores { get; set; }
        Scorer Scorer { get; set; }
        Random random;



        public Player(string Name, Scorer Scorer, Random random)
        {
            this.Name = Name;
            Baskets = new List<int>();
            Scores = new List<int>();
            this.Scorer = Scorer;
            this.random = random;
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
                Baskets.Add(GetRandomBasketsMade());
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

        private int GetRandomBasketsMade()
        {
            int basketsMade;

            var weight = random.NextDouble();

            if (weight >= 0.0 && weight < 0.2)
            {
                basketsMade = 0;
            }
            else if (weight >= 0.2 && weight < 0.5)
            {
                basketsMade = 1;
            }
            else if (weight >= 0.5 && weight < 0.8)
            {
                basketsMade = 2;
            }
            else if (weight >= 0.8 && weight < 0.95)
            {
                basketsMade = 3;
            }
            else
            {
                basketsMade = 4;
            }

            return basketsMade;
        }
    }

    interface Scorer
    {
        int GetScore(int basketsMade);
    }

    class ClassicBitBallScorer : Scorer
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

    class NewScorer : Scorer
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
