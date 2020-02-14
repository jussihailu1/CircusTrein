using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Circustrein
{
    public class Train
    {
        private readonly List<Wagon> _wagons;
        public IEnumerable<Wagon> Wagons() => _wagons;
        public IEnumerable<Animal> AnimalsInTrain()
        {
            var animalsToReturn = new List<Animal>();

            foreach (var wagon in _wagons)
            {
                foreach (var wagonAnimal in wagon.Animals)
                {
                    animalsToReturn.Add(wagonAnimal);
                }
            }

            return animalsToReturn;
        }

        public Train()
        {
            _wagons = new List<Wagon>();
        }

        public void AddWagon(Wagon wagon)
        {
            _wagons.Add(wagon);
        }

    }
}
