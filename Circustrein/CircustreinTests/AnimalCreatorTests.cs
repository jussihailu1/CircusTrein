using System.Linq;
using Circustrein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircustreinTests
{
    [TestClass()]
    public class AnimalCreatorTests
    {
        [TestMethod()]
        public void CreateAnimalsTest()
        {
            AnimalFactory animalFactory = new AnimalFactory(1, 1, 1, 1, 1, 1);

            var result = animalFactory.GetCreatedAnimals().ToList().Count;

            Assert.AreEqual(6, result);
        }


        // For 100% coverage
        [TestMethod()]
        public void GetCreatedAnimalsTest()
        {
            AnimalFactory animalFactory = new AnimalFactory(1, 1, 1, 1, 1, 1);

            var result = animalFactory.GetCreatedAnimals().ToList().Count;

            Assert.AreEqual(6, result);
        }
    }
}