using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircustreinTests
{
    [TestClass()]
    public class TrainTests
    {
        [TestMethod()]
        public void TrainTest()
        {
            Train train = new Train();
            Assert.IsNotNull(train.Wagons());
        }

        [TestMethod()]
        public void AddWagonTest()
        {
            Train train = new Train();

            train.AddWagon(new Wagon(new Herbivore(Size.Large)));

            var result = train.Wagons().ToList().Count;

            Assert.AreEqual(1, result);
        }
    }
}