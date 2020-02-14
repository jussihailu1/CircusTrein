using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Large Carnivores?");
            //int.TryParse(Console.ReadLine(), out var lc);

            //Console.WriteLine("Medium Carnivores?");
            //int.TryParse(Console.ReadLine(), out var mc);

            //Console.WriteLine("Small Carnivores?");
            //int.TryParse(Console.ReadLine(), out var sc);

            //Console.WriteLine("Large Herbivores?");
            //int.TryParse(Console.ReadLine(), out var lh);

            //Console.WriteLine("Medium Herbivores?");
            //int.TryParse(Console.ReadLine(), out var mh);

            //Console.WriteLine("Small Herbivores?");
            //int.TryParse(Console.ReadLine(), out var sh);

           int lc = 2;
           int mc = 3;
           int sc = 1;
           int lh = 3;
           int mh = 0;
           int sh = 0;

            Distributor distributor = new Distributor(sc, mc, lc, sh, mh, lh);

            distributor.DistributeAnimals();

            Display(distributor.Train);

            Console.Read();
        }

        public static void Display(Train train)
        {
            Console.WriteLine(" ");
            foreach (var wagon in train.Wagons())
            {
                //Console.WriteLine($"Wagon {train.GetWagons().FindIndex(w => w.Equals(wagon)) + 1}:  Wagon points = {wagon.Points}");
                Console.WriteLine($"Wagon {train.Wagons().ToList().IndexOf(wagon) + 1}:  Wagon points = {wagon.Points}");
                //foreach (var animal in wagon.Animals())
                foreach (var animal in wagon.Animals)
                {
                    Console.WriteLine(animal.Size + " " + animal.GetType().ToString().Substring(12));
                }
                Console.WriteLine(" ");
            }
        }

        public static void DisplayForTestData(Train train)
        {
            Console.WriteLine(" ");
            string wagonsString = "";
            foreach (Wagon wagon in train.Wagons())
            {
                //foreach (Animal animal in wagon.Animals())
                foreach (Animal animal in wagon.Animals)
                {
                    wagonsString += animal.GetType().ToString().Substring(12, 1) + animal.Size.ToString();
                }

                wagonsString += ',';
            }

            Console.WriteLine(wagonsString + train.Wagons().ToList().Count);
        }
    }
}
