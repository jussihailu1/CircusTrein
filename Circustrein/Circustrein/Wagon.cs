using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circustrein
{
    public class Wagon
    {
        public int Points { get; private set; }
        public static readonly int MaxPoints = 10;

        private readonly List<Animal> _animals;
        public IEnumerable<Animal> Animals => _animals;

        public Wagon(Animal animal)
        {
            Points = 0;
            _animals = new List<Animal>();
            AddAnimal(animal);
        }

        public bool SpaceAvailable(Animal animal)
        {
            return Points + (int)animal.Size <= MaxPoints;
        }

        public bool AddAnimal(Animal animal)
        {
            if (SpaceAvailable(animal) && animal.IsFriendsWith(_animals))
            {
                _animals.Add(animal);
                Points += (int)animal.Size;
                return true;
            }

            return false;
        }

    }
}
