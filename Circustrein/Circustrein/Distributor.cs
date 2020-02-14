using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Circustrein
{
    public class Distributor
    {
        private readonly IEnumerable<Animal> _animals;
        public IEnumerable<Animal> AnimalsToDistribute { get; }
        public Train Train { get; }

        public Distributor(int smallCarnivoors, int mediumCarnivoors, int largeCarnivoors, int smallHerbivoors, int mediumHerbivoors, int largeHerbivoors)
        {
            Train = new Train();
            var animalFactory = new AnimalFactory(smallCarnivoors, mediumCarnivoors, largeCarnivoors, smallHerbivoors, mediumHerbivoors, largeHerbivoors);
            _animals = animalFactory.GetCreatedAnimals();
            _animals = OrderAnimals();
            AnimalsToDistribute = _animals;
        }

        private List<Animal> OrderAnimals()
        {
            var animalsToReturn = new List<Animal>();

            var carns = _animals.Where(animal => animal is Carnivore).OrderBy(animal => animal.Size);
            animalsToReturn.AddRange(carns);

            var herbs = _animals.Where(animal => animal is Herbivore).OrderByDescending(animal => animal.Size);
            animalsToReturn.AddRange(herbs);

            return animalsToReturn;
        }

        public void DistributeAnimals()
        {
            DistributeCarnivores();
            DistributeHerbivores();
        }

        private void DistributeCarnivores()
        {
            foreach (var animal in _animals.Where(animal => animal.GetType() == typeof(Carnivore)))
            {
                Train.AddWagon(new Wagon(animal));
            }
        }

        private void DistributeHerbivores()
        {
            foreach (var animal in _animals.Where(a => a.GetType() == typeof(Herbivore)))
            {
                bool animalIsAdded = false;
                foreach (var wagon in Train.Wagons())
                {
                    if (!wagon.AddAnimal(animal)) continue;
                    animalIsAdded = true;
                    break;
                }

                if (animalIsAdded == false)
                {
                    Train.AddWagon(new Wagon(animal));
                }
            }
        }
    }
}
