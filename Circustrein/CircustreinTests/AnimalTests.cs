using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CircustreinTests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestMethod()]
        public void IsFriendsWithTest()
        {
            Animal animal = new Herbivore(Size.Medium);
            var animals = new List<Animal>() { new Carnivore(Size.Large) };

            var result = animal.IsFriendsWith(animals);

            Assert.IsFalse(result);
        }

        #region MatrixTests

        private List<Animal> OrderAnimals(List<Animal> animals)
        {
            var carns = animals.Where(animal => animal is Carnivore).OrderBy(animal => animal.Size).ToList();
            var herbs = animals.Where(animal => animal is Herbivore).OrderByDescending(animal => animal.Size).ToList();
            var orderedList = new List<Animal>();
            orderedList.AddRange(carns);
            orderedList.AddRange(herbs);

            return orderedList;
        }
                
        #region Singles

        [TestMethod]
        public void C1_IsFriendsWith_C1()
        {
            var animals = new AnimalFactory(2, 0, 0, 0, 0, 0).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(0, 2, 0, 0, 0, 0).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C5_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(0, 0, 2, 0, 0, 0).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(0, 0, 0, 2, 0, 0).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(0, 0, 0, 0, 2, 0).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(0, 0, 0, 0, 0, 2).GetCreatedAnimals().ToList();
            var animals1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var animals2 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = animals1[0].IsFriendsWith(animals2);

            Assert.IsTrue(result);
        }

        #endregion 

        #region Doubles

        [TestMethod]
        public void C1_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(1, 1, 0, 0, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C1[0].IsFriendsWith(C3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_C1()
        {
            var animals = new AnimalFactory(1, 1, 0, 0, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C3[0].IsFriendsWith(C1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C1_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(1, 0, 1, 0, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C1[0].IsFriendsWith(C5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(0, 1, 1, 0, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C3[0].IsFriendsWith(C5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C5_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(0, 1, 1, 0, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C5[0].IsFriendsWith(C3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C1_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(1, 0, 0, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C1[0].IsFriendsWith(H1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_C1()
        {
            var animals = new AnimalFactory(1, 0, 0, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H1[0].IsFriendsWith(C1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(0, 1, 0, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H1[0].IsFriendsWith(C3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(0, 1, 0, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C3[0].IsFriendsWith(H1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(0, 0, 1, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H1[0].IsFriendsWith(C5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C5_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(0, 1, 0, 1, 0, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C5[0].IsFriendsWith(H1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C1_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(1, 0, 0, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C1[0].IsFriendsWith(H3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_C1()
        {
            var animals = new AnimalFactory(1, 0, 0, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H3[0].IsFriendsWith(C1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(0, 1, 0, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H3[0].IsFriendsWith(C3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(0, 1, 0, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C3[0].IsFriendsWith(H3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C5_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(0, 0, 1, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C5[0].IsFriendsWith(H3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(0, 0, 1, 0, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H3[0].IsFriendsWith(C5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(0, 0, 0, 1, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H3[0].IsFriendsWith(H1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(0, 0, 0, 1, 1, 0).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H1[0].IsFriendsWith(H3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_C1()
        {
            var animals = new AnimalFactory(1, 0, 0, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H5[0].IsFriendsWith(C1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C1_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(1, 0, 0, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C1 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C1[0].IsFriendsWith(H5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_C3()
        {
            var animals = new AnimalFactory(0, 1, 0, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H5[0].IsFriendsWith(C3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C3_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(0, 1, 0, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C3 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C3[0].IsFriendsWith(H5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_C5()
        {
            var animals = new AnimalFactory(0, 0, 1, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H5[0].IsFriendsWith(C5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void C5_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(0, 0, 1, 0, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var C5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = C5[0].IsFriendsWith(H5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_H1()
        {
            var animals = new AnimalFactory(0, 0, 0, 1, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H5[0].IsFriendsWith(H1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H1_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(0, 0, 0, 1, 0, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H1 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H1[0].IsFriendsWith(H5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H5_IsFriendsWith_H3()
        {
            var animals = new AnimalFactory(0, 0, 0, 0, 1, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H5[0].IsFriendsWith(H3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void H3_IsFriendsWith_H5()
        {
            var animals = new AnimalFactory(0, 0, 0, 0, 1, 1).GetCreatedAnimals().ToList();
            animals = OrderAnimals(animals);
            var H5 = animals.Where(animal => animals.IndexOf(animal) != 1).ToList();
            var H3 = animals.Where(animal => animals.IndexOf(animal) != 0).ToList();

            var result = H3[0].IsFriendsWith(H5);

            Assert.IsTrue(result);
        }

        #endregion

        #endregion
    }
}