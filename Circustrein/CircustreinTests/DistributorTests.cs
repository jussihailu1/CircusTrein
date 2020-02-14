using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircustreinTests
{
    [TestClass()]
    public class DistributorTests
    {
        [TestMethod()]
        public void DistributorTest()
        {
            var distributor = new Distributor(1, 1, 1, 1, 1, 1);
            Assert.IsNotNull(distributor.Train);
        }

        [TestMethod()]
        public void DistributeAnimalsTest()
        {
            var distributor = new Distributor(1, 1, 1, 1, 1, 1);
            distributor.DistributeAnimals();
            var result = distributor.Train.Wagons().ToList().Count;

            Assert.AreEqual(4, result);
        }

        #region Efficiency

        [TestMethod]
        public void DistributorEfficiencyTest1()
        {
            var C1 = 0;
            var C3 = 0;
            var C5 = 0;
            var H1 = 5;
            var H3 = 3;
            var H5 = 1;

            var distributor = new Distributor(C1, C3, C5, H1, H3, H5);
            distributor.DistributeAnimals();
            var totalWagonsSpace = distributor.Train.Wagons().Count() * Wagon.MaxPoints;
            var totalWagonsSpaceUsed = distributor.Train.Wagons().Sum(wagon => wagon.Points);
            var expectedSpaceLeft = 1;
            var actualSpaceLeft = totalWagonsSpace - totalWagonsSpaceUsed;

            Assert.AreEqual(expectedSpaceLeft, actualSpaceLeft);
        }

        [TestMethod]
        public void DistributorEfficiencyTest2()
        {
            var C1 = 1;
            var C3 = 3;
            var C5 = 2;
            var H1 = 0;
            var H3 = 0;
            var H5 = 3;

            var distributor = new Distributor(C1, C3, C5, H1, H3, H5);
            distributor.DistributeAnimals();
            var totalWagonsSpace = distributor.Train.Wagons().Count() * Wagon.MaxPoints;
            var totalWagonsSpaceUsed = distributor.Train.Wagons().Sum(wagon => wagon.Points);
            var expectedSpaceLeft = 25;
            var actualSpaceLeft = totalWagonsSpace - totalWagonsSpaceUsed;

            Assert.AreEqual(expectedSpaceLeft, actualSpaceLeft);
        }

        [TestMethod]
        public void DistributorEfficiencyTest3()
        {
            var C1 = 2;
            var C3 = 2;
            var C5 = 2;
            var H1 = 5;
            var H3 = 5;
            var H5 = 5;

            var distributor = new Distributor(C1, C3, C5, H1, H3, H5);
            distributor.DistributeAnimals();
            var totalWagonsSpace = distributor.Train.Wagons().Count() * Wagon.MaxPoints;
            var totalWagonsSpaceUsed = distributor.Train.Wagons().Sum(wagon => wagon.Points);
            var expectedSpaceLeft = 17;
            var actualSpaceLeft = totalWagonsSpace - totalWagonsSpaceUsed;

            Assert.AreEqual(expectedSpaceLeft, actualSpaceLeft);
        }

        [TestMethod]
        public void DistributorEfficiencyTest4()
        {
            var C1 = 0;
            var C3 = 0;
            var C5 = 0;
            var H1 = 1;
            var H3 = 3;
            var H5 = 2;

            var distributor = new Distributor(C1, C3, C5, H1, H3, H5);
            distributor.DistributeAnimals();
            var totalWagonsSpace = distributor.Train.Wagons().Count() * Wagon.MaxPoints;
            var totalWagonsSpaceUsed = distributor.Train.Wagons().Sum(wagon => wagon.Points);
            var expectedSpaceLeft = 0;
            var actualSpaceLeft = totalWagonsSpace - totalWagonsSpaceUsed;

            Assert.AreEqual(expectedSpaceLeft, actualSpaceLeft);
        }

        #endregion

        [TestMethod]
        public void Are_all_animals_distributed_Test()
        {
            var smallCarns = 1;
            var mediumCarns = 1;
            var largeCarns = 1;
            var smallHerbs = 1;
            var mediumHerbs = 1;
            var largeHerbs = 1;

            var distributor = new Distributor(smallCarns, mediumCarns, largeCarns, smallHerbs, mediumHerbs, largeHerbs);
            distributor.DistributeAnimals();

            var animalsToDistribute = new List<Animal>();
            var animalsInTrain = new List<Animal>();

            foreach (var animalToDistribute in distributor.AnimalsToDistribute)
            {
                animalsToDistribute.Add(animalToDistribute);
            }

            foreach (var animalInTrain in distributor.Train.AnimalsInTrain())
            {
                animalsInTrain.Add(animalInTrain);
            }

            animalsToDistribute = OrderAnimals(animalsToDistribute);
            animalsInTrain = OrderAnimals(animalsInTrain);

            CollectionAssert.AreEqual(animalsToDistribute, animalsInTrain);
        }

        private List<Animal> OrderAnimals(List<Animal> animalsToReturn)
        {
            IEnumerable test = new List<Animal>();

            var carns = animalsToReturn.Where(animal => animal is Carnivore).OrderBy(animal => animal.Size);
            var herbs = animalsToReturn.Where(animal => animal is Herbivore).OrderByDescending(animal => animal.Size);

            animalsToReturn.Clear();
            animalsToReturn.AddRange(carns);
            animalsToReturn.AddRange(herbs);

            return animalsToReturn;
        }

        [TestMethod]
        public void Are_all_animals_effciently_distributed()
        {
            //Are all animals distributed---------------------------------------------------------------------------------------

            var smallCarns = 2;
            var mediumCarns = 2;
            var largeCarns = 2;
            var smallHerbs = 5;
            var mediumHerbs = 5;
            var largeHerbs = 5;

            var distributor = new Distributor(smallCarns, mediumCarns, largeCarns, smallHerbs, mediumHerbs, largeHerbs);
            distributor.DistributeAnimals();

            var animalsToDistribute = new List<Animal>();
            var animalsInTrain = new List<Animal>();

            foreach (var animalToDistribute in distributor.AnimalsToDistribute)
            {
                animalsToDistribute.Add(animalToDistribute);
            }

            foreach (var animalInTrain in distributor.Train.AnimalsInTrain())
            {
                animalsInTrain.Add(animalInTrain);
            }

            animalsToDistribute = OrderAnimals(animalsToDistribute);
            animalsInTrain = OrderAnimals(animalsInTrain);

            CollectionAssert.AreEqual(animalsToDistribute, animalsInTrain);

            //------------------------------------------------------------------------------------------------------------------

            //Efficiency--------------------------------------------------------------------------------------------------------

            var totalWagonsSpace = distributor.Train.Wagons().Count() * Wagon.MaxPoints;
            var totalWagonsSpaceUsed = distributor.Train.Wagons().Sum(wagon => wagon.Points);
            var expectedSpaceLeft = 17;
            var actualSpaceLeft = totalWagonsSpace - totalWagonsSpaceUsed;

            Assert.AreEqual(expectedSpaceLeft, actualSpaceLeft);

            //------------------------------------------------------------------------------------------------------------------
        }
    }
}