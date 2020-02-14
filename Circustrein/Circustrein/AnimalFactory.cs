using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Circustrein
{
    public class AnimalFactory
    {
        private readonly IEnumerable<Animal> _animals;

        private readonly IEnumerable<AnimalTemplate> _animalTemplates;

        public IEnumerable<Animal> GetCreatedAnimals() => _animals;

        public AnimalFactory(int smallCarnivoors, int mediumCarnivoors, int largeCarnivoors, int smallHerbivoors, int mediumHerbivoors, int largeHerbivoors)
        {
            _animalTemplates = new List<AnimalTemplate>(){
                new AnimalTemplate(smallCarnivoors, Size.Small, typeof(Carnivore)),
                new AnimalTemplate(mediumCarnivoors, Size.Medium, typeof(Carnivore)),
                new AnimalTemplate(largeCarnivoors, Size.Large, typeof(Carnivore)),
                new AnimalTemplate(largeHerbivoors, Size.Large, typeof(Herbivore)),
                new AnimalTemplate(mediumHerbivoors, Size.Medium, typeof(Herbivore)),
                new AnimalTemplate(smallHerbivoors, Size.Small, typeof(Herbivore))
            };

            _animals = CreateAnimals();
        }

        private IEnumerable<Animal> CreateAnimals()
        {
            var animalsToReturn = new List<Animal>();
            foreach (AnimalTemplate animalTemplate in _animalTemplates)
            {
                for (int i = 0; i < animalTemplate.Quantity; i++)
                {
                    if (animalTemplate.Animal == typeof(Carnivore))
                    {
                        animalsToReturn.Add(new Carnivore(animalTemplate.Size));
                    }
                    else if (animalTemplate.Animal == typeof(Herbivore))
                    {
                        animalsToReturn.Add(new Herbivore(animalTemplate.Size));
                    }
                }
            }

            return animalsToReturn;
        }

        private class AnimalTemplate
        {
            public int Quantity { get; }
            public Size Size { get; }
            public Type Animal { get; }

            public AnimalTemplate(int quantity, Size size, Type animal)
            {
                Quantity = quantity;
                Size = size;
                Animal = animal;
            }
        }
    }
}
