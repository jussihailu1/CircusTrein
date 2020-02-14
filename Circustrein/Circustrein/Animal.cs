using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circustrein
{
    public abstract class Animal
    {
        public Size Size { get; }

        protected Animal(Size size)
        {
            Size = size;
        }

        public bool IsFriendsWith(IEnumerable<Animal> animals)
        {
            return !animals.ToList().Exists(animal => animal.GetType() == typeof(Carnivore) && (int)animal.Size >= (int)Size);
        }
    }

    public enum Size
    {
        Small = 1,
        Medium = 3,
        Large = 5
    }
}
