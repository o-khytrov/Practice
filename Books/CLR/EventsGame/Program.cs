using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventsGame
{
    public class GameEventArgs : EventArgs
    {
        public bool Win { get; set; }
    }


    public class Roulette
    {
        public Random rand;

        public event EventHandler<GameEventArgs> GamePlayed;

        public int Money { get; set; }

        public int Bid { get; set; }

        public int Odd { get; set; }

        public Roulette()
        {
            rand = new Random();
        }

        public void Play()
        {

            if (Money >= Bid)
            {
                bool win = false;
                var number = rand.Next(1, 10);
                if (Odd == number)
                {
                    win = true;
                    Money += Bid;
                }
                else
                {
                    Money -= Bid;
                }
                Bid = 0;
                if (GamePlayed != null)
                {
                    GamePlayed(this, new GameEventArgs { Win = win });
                }

            }


        }
    }

    internal class Program
    {
        static int Money;
        private static void DisplayResultsOfGame(object sender, GameEventArgs args)
        {
            Money = ((Roulette)sender).Money;
            if (args.Win)
            {
                Console.WriteLine($"Congrats. You won! {((Roulette)sender).Odd} $$$");
            }
            else
            {
                Console.WriteLine($"Soryy. You lost(( {((Roulette)sender).Odd} $$$");
            }

            Console.WriteLine($"Your score {Money}");

        }
        private static void Main(string[] args)
        {
            Task.Run(() =>
            {
                Money = 100;
                var bid = 3;

                var r = new Roulette();
                r.Money = Money;
                r.Bid = bid;
                r.GamePlayed += DisplayResultsOfGame;
                while (Money > bid)
                {
                    r.Odd = r.rand.Next(1, 10);
                    r.Bid = bid;

                    r.Play();
                }
            });

            Task.Run(() =>
            {
                Money = 100;
                var bid = 3;

                var r = new Roulette();
                r.Money = Money;
                r.Bid = bid;
                r.GamePlayed += DisplayResultsOfGame;
                while (Money > bid)
                {
                    r.Odd = r.rand.Next(1, 10);
                    r.Bid = bid;

                    r.Play();
                }
            });

            Console.ReadKey();

        }
    }
}