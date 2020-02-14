using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircustreinTests
{
    [TestClass()]
    public class WagonTests
    {
        [TestMethod()]
        public void WagonTest()
        {
            Animal animal = new Carnivore(Size.Small);

            Wagon wagon = new Wagon(animal);

            //var result = wagon.Animals().ToList();
            var result = wagon.Animals.ToList();

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod()]
        public void SpaceAvailableTest()
        {
            Wagon wagon = new Wagon(new Carnivore(Size.Medium));

            wagon.AddAnimal(new Herbivore(Size.Large));

            Animal animal = new Herbivore(Size.Large);

            var result = wagon.SpaceAvailable(animal);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AddAnimalTest()
        {
            Wagon wagon = new Wagon(new Carnivore(Size.Medium));

            Animal animal = new Herbivore(Size.Small);

            var result = wagon.AddAnimal(animal);

            Assert.IsFalse(result);
        }

        //Only ffor the 100% coverage
        [TestMethod()]
        public void GetAnimalsTest()
        {
            Wagon wagon = new Wagon(new Carnivore(Size.Medium));

            //Assert.AreEqual(1, wagon.Animals().ToList().Count);
            Assert.AreEqual(1, wagon.Animals.ToList().Count);
        }
    }
}